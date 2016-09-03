using GitUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsHistoryPlugin
{
    internal class UICommandsSource : IGitUICommandsSource
    {
        public GitUICommands UICommands { get; set; }

        public event EventHandler<GitUICommandsChangedEventArgs> GitUICommandsChanged;
    }
}
