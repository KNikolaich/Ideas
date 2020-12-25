using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Configuration.Helpers;

namespace Configuration.Controls
{
    public partial class GeniralEditCfgControl : UserControl
    {
        public GeniralEditCfgControl()
        {
            InitializeComponent();
        }

        public void SetAssistant(Assistant assistant)
        {
            if (!string.IsNullOrEmpty(assistant.SourceFileName))
            {
                assistant.BeforeHasDifferents = null;
                foreach (Control control in Controls)
                {
                    control.Dispose();
                }
                Controls.Clear();
                SuspendLayout();
                var elemControl = assistant.LoadControls(assistant.SourceFileName);
                elemControl.Dock = DockStyle.Fill;
                Controls.Add(elemControl);
                ResumeLayout(false);
                PerformLayout();
            }
        }
    }
}