using System;
using System.Windows.Forms;
using Core.Model;

namespace StaffTimes
{
    public partial class LoginForm : Form
    {
        User _user;

        public LoginForm()
        {
            InitializeComponent();
        }

        public User GetUser()
        {
            return _user;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var tuple = Core.Conf.ReadLoginPassword();
            if (!string.IsNullOrEmpty(tuple.Item1))
            {
                tbLogin.Text = tuple.Item1;
            }
            if (!string.IsNullOrEmpty(tuple.Item2))
            {
                _tbPasswd.Text = tuple.Item2;
            }
        }

        private void _bOk_Click(object sender, EventArgs e)
        {
            EnterKey();
        }

        private void EnterKey()
        {
            DialogResult = DialogResult.Abort;

            using (StaffTimeModelContainer container = new StaffTimeModelContainer())
            {
                if ((_user = container.GetUser(tbLogin.Text, _tbPasswd.Text)) != null)
                {
                    Core.Conf.Write(tbLogin.Text, _tbPasswd.Text);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else if (MessageBox.Show("Ошибка", "Не верно введены дынные! Повторить?", MessageBoxButtons.YesNo,
                             MessageBoxIcon.Error) != DialogResult.Yes)
                {
                    Close();
                }
                else
                {
                    DialogResult = DialogResult.None;
                }
            }
        }
        
        private void tbLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                EnterKey();
            }
        }

        private void _tbPasswd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                EnterKey();
            }
        }
    }
}
