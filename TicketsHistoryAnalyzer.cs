using GitUIPluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace TicketsHistoryPlugin
{
    internal class TicketsHistoryAnalyzer
    {
        private readonly IGitModule _gitModule;

        public delegate void ProgressChangedEventHandler(int total, int current);

        public event ProgressChangedEventHandler ProgressChanged;

        public event Action ScanStarted;

        public event Action<Exception> ErrorOccured;

        public event Action<IEnumerable<string>> ScanFinished;

        public bool IsActive { get; private set; }

        public TicketsHistoryAnalyzer(IGitModule gitModule)
        {
            _gitModule = gitModule;
        }

        public List<string> GetRevisionsList(string firstCommitHash, string lastCommitHash)
        {
            var revListCommand = string.Format(
                "rev-list {0}..{1}",
                firstCommitHash,
                lastCommitHash);

            var revListCommandResult = _gitModule.RunGitCmd(revListCommand);
            return revListCommandResult.SplitLinesThenTrim().ToList();
        }

        public void ScanForTicketNumbersAsync(
            List<string> revisionsList,
            string searchPattern,
            string outputFormat,
            CancellationToken cancellationToken)
        {
            OnScanStarted();

            Task.Factory.StartNew(() =>
            {
                var ticketNumbers = ScanForTicketNumbers(revisionsList, searchPattern, outputFormat, OnProgressChanged, cancellationToken);
                OnScanFinished(ticketNumbers);
            },
            cancellationToken).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    OnErrorOccured(task.Exception);
                }
            }, cancellationToken);
        }

        private List<string> ScanForTicketNumbers(
            List<string> revisionsList,
            string searchPattern,
            string outputFormat,
            ProgressChangedEventHandler progressChangedCallback,
            CancellationToken cancellationToken)
        {
            var resultTicketNumbers = new List<string>();
            for (int i = 0, size = revisionsList.Count(); i < size && !cancellationToken.IsCancellationRequested; progressChangedCallback(size, ++i))
            {
                var showCommand = string.Format("show --no-patch {0}", revisionsList[i]);
                var showCommandResult = _gitModule.RunGitCmd(showCommand).ToLower();

                if (string.IsNullOrEmpty(showCommandResult))
                {
                    throw new Exception("Unexpected show command result.");
                }

                var matchesFoundInCommit = Regex.Matches(showCommandResult, searchPattern).Cast<Match>().Select(match => match.Value);
                foreach (var matchFoundInCommit in matchesFoundInCommit)
                {
                    var ticketNumber = string.Format(outputFormat, Regex.Match(matchFoundInCommit, @"\d+").Value);
                    if (!resultTicketNumbers.Contains(ticketNumber))
                    {
                        resultTicketNumbers.Add(ticketNumber);
                    }
                }
            }

            return resultTicketNumbers;
        }

        protected void OnProgressChanged(int total, int current)
        {
            var progressChangedEvent = ProgressChanged;
            if(progressChangedEvent == null)
            {
                return;
            }

            progressChangedEvent(total, current);
        }

        protected void OnScanStarted()
        {
            var scanStarted = ScanStarted;
            if(scanStarted == null)
            {
                return;
            }

            IsActive = true;
            scanStarted();
        }

        protected void OnScanFinished(IEnumerable<string> result)
        {
            var scanFinished = ScanFinished;
            if (scanFinished == null)
            {
                return;
            }

            scanFinished(result);
            IsActive = false;
        }

        protected void OnErrorOccured(Exception exception)
        {
            var errorOccured = ErrorOccured;
            if (errorOccured == null)
            {
                return;
            }

            errorOccured(exception);
        }
    }
}
