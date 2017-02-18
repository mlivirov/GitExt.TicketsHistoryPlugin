using GitUI;
using GitUIPluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketsHistoryPlugin
{
    public partial class MainForm : Form
    {
        private readonly IGitUICommands _gitUiCommands;

        private readonly TicketsHistoryAnalyzer _analyzier;

        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        public MainForm(IGitUICommands gitUiCommands)
        {
            InitializeComponent();

            _gitUiCommands = gitUiCommands;
            
            _analyzier = new TicketsHistoryAnalyzer(_gitUiCommands.GitModule);
            _analyzier.ScanFinished += OnAnalyzerScanFinished;
            _analyzier.ProgressChanged += OnAnalyzerProgressChanged;
            _analyzier.ErrorOccured += OnErrorOccured;
            
            _searchPattern.Text = Properties.Settings.Default.SearchPattern;
            _outputFormat.Text = Properties.Settings.Default.OutputFormat;

            var uiCommandsSource = new UICommandsSource
            {
                UICommands = (GitUICommands)_gitUiCommands
            };

            _lastCommitPicker.UICommandsSource = uiCommandsSource;
            _firstCommitPicker.UICommandsSource = uiCommandsSource;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            if (disposing && (_cancellationTokenSource != null))
            {
                _cancellationTokenSource.Dispose();
            }

            base.Dispose(disposing);
        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            _cancellationTokenSource.Cancel();
            base.OnClosing(e);
        }

        private void OnAnalyzeButtonClicked(object sender, EventArgs e)
        {
            var revsList = _analyzier.GetRevisionsList(_firstCommitPicker.SelectedCommitHash, _lastCommitPicker.SelectedCommitHash);
            if (!revsList.Any())
            {
                MessageBox.Show(
                    this, 
                    string.Format("No revisions found between {0} and {1} commit.", _firstCommitPicker.SelectedCommitHash, _lastCommitPicker.SelectedCommitHash),
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            _progressBar.Show();
            _analyzeButton.Enabled = false;
            _analyzier.ScanForTicketNumbersAsync(revsList, _searchPattern.Text, _outputFormat.Text, _cancellationTokenSource.Token);
        }

        private void OnSearchPatternChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SearchPattern = _searchPattern.Text;
            Properties.Settings.Default.Save();
        }

        private void OnOutputFormatChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.OutputFormat = _outputFormat.Text;
            Properties.Settings.Default.Save();
        }

        private void OnAnalyzerScanFinished(IEnumerable<string> ticketNumbers)
        {
            this.InvokeIfRequired(() =>
            {
                _analyzeButton.Enabled = true;
                _progressBar.Hide();

                if (!ticketNumbers.Any())
                {
                    MessageBox.Show(
                        this,
                        string.Format("No related tickets found. Make shure that search pattern is correct.", _firstCommitPicker.SelectedCommitHash, _lastCommitPicker.SelectedCommitHash),
                        Text,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);

                    return;
                }

                var resultsForm = new ResultsForm(ticketNumbers);
                resultsForm.ShowDialog(this);
            });
        }

        private void OnAnalyzerProgressChanged(int total, int current)
        {
            _progressBar.InvokeIfRequired(() =>
            {
                _progressBar.Value = (int)(((double)current / total) * 100);
            });
        }

        private void OnErrorOccured(Exception exception)
        {
            var text = "An error occured!";

            if (exception != null)
            {
                text += "\n" + exception.Message;
            }

            MessageBox.Show(this, text, @"Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
