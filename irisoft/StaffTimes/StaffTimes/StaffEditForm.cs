using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Core.Model;

namespace StaffTimes
{
    public partial class StaffEditForm : Form
    {
        private User _theUser;

        public StaffEditForm(User user)
        {
            InitializeComponent();
            Staff = user;
        }

        public User Staff
        {
            get => _theUser;
            private set
            {
                if (value == null)
                {
                    value = new User();
                }
                _theUser = value;
            }
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            _theUser.UserName = _textBoxName.Text;
            _theUser.Login = _textBoxLogin.Text;
            _theUser.Password = _textBoxLogin.Text.GetHashCode().ToString();

            if(Enum.TryParse(_textBoxRole.Text, out RoleEnum roleSh))
            {
                _theUser.Role = (short) roleSh;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
