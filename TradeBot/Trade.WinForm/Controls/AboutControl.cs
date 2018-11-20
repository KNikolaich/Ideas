using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsFormApp.Controls
{
    public partial class AboutControl : DevExpress.XtraEditors.XtraUserControl
    {
        public AboutControl()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var assembly = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            labelProductName.Text += " " + assembly.FileDescription;
            labelVersion.Text += " " + assembly.ProductVersion;
            labelCopyright.Text += " " + assembly.LegalCopyright;
            label1.Text += " " + assembly.CompanyName;

#if DEBUG
            lDebug.Text = "Debug";
#else
            lDebug.Text = "Release";
#endif
            textBoxDescription.Text += " " + assembly.Comments;
        }
    }
}
