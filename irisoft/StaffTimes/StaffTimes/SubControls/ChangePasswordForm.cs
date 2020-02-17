using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;
using Core.Model;

namespace StaffTimes.SubControls
{
    public partial class ChangePasswordForm : Form
    {
        ContextAdapter _context = new ContextAdapter();
        private int _userId;

        public ChangePasswordForm(int currentUserId)
        {
            InitializeComponent();
            _userId = currentUserId;
        }

        private void _sbOk_Click(object sender, EventArgs e)
        {
            var user = _context.Users.Where(u => u.Id == _userId).First();
            var oldPasswd = _teOldPassword.Text;
            string errorMsg = null;
            if (oldPasswd != user.Password)
            {
                errorMsg = "Старый пароль не принят.";
            }
            else
            {
                if (_teNewPasswrd.Text != _teNewParrdw2.Text)
                {
                    errorMsg = "Новый пароль не продублирован.";
                }
                else if (_teNewParrdw2.Text.Trim() == "")
                {
                    errorMsg = "Пароль не может быть пустым.";
                }
            }

            if (!string.IsNullOrEmpty(errorMsg))
            {
                MessageBox.Show(errorMsg, "Ошибка смены пароля.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None;

            }
            else
            {
                user.Password = _teNewParrdw2.Text;
                _context.Update();
            }
        }
    }
}
