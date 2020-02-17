using System;
using System.Linq;
using System.Windows.Forms;
using Core;
using Core.Exceptions;

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
            MessageNotify.AddNotify += (sender, a) =>
            {
                MessageBox.Show(a.Message, a.Title, MessageBoxButtons.OK, a.Notify == NotifyEnum.Info? MessageBoxIcon.Information:MessageBoxIcon.Warning);
            };
            var tuple = Conf.ReadLoginPassword();
            if (!string.IsNullOrEmpty(tuple.Item1))
            {
                tbLogin.Text = tuple.Item1;
            }
            if (!string.IsNullOrEmpty(tuple.Item2))
            {
                _tbPasswd.Text = tuple.Item2;
                _cbSavePass.Checked = true;
            }
            else
            {
                _cbSavePass.Checked = false;
            }
        }

        private void _bOk_Click(object sender, EventArgs e)
        {
            EnterKey();
        }

        private void EnterKey()
        {
            DialogResult = DialogResult.Abort;

            using (var container = new StaffTimeDbContainer())
            {
                Cursor oldCursor = Cursor.Current;
                Cursor = Cursors.WaitCursor;
                if ((_user = container.GetUser(tbLogin.Text, _tbPasswd.Text)) != null)
                {
                    Conf.Write(tbLogin.Text, _tbPasswd.Text, _cbSavePass.Checked);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else if (MessageBox.Show(
                             $"Неверно введены данные авторизации! {Environment.NewLine}Повторить попытку?", "Ошибка",
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Error) != DialogResult.Yes)
                {
                    Close();
                }
                else
                {
                    DialogResult = DialogResult.None;
                }
                Cursor = oldCursor;
            }
        }

        private void tbLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                EnterKey();
            }
        }

        private void _tbPasswd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                EnterKey();
            }
        }
    }
}