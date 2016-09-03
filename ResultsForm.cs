using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TicketsHistoryPlugin
{
    public partial class ResultsForm : Form
    {
        public ResultsForm(IEnumerable<string> result)
        {
            InitializeComponent();
            _richTextBox.Text = string.Join("\n\n", result) + string.Format("\n\n__________________\nTotal: {0}", result.Count());
        }

        private void OnRichTextBoxLinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}
