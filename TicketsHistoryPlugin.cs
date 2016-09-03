using ResourceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GitUIPluginInterfaces;

namespace TicketsHistoryPlugin
{
    public class TicketsHistoryPlugin : GitPluginBase
    {
        public TicketsHistoryPlugin()
        {
            SetNameAndDescription("Tickets History");
            Translate();
        }

        public override bool Execute(GitUIBaseEventArgs gitUiCommands)
        {
            using (var mainPluginForm = new MainForm(gitUiCommands.GitUICommands))
            {
                mainPluginForm.ShowDialog(gitUiCommands.OwnerForm);
            }
            
            return true;
        }
    }

}
