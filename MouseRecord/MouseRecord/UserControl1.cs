using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;

namespace MouseRecord
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        #region Overrides of UserControl

        protected override void OnLoad(EventArgs e)
        {
            treeList1.AppendNode(new object[] { Properties.Resources.blankcircle, 1}, null);
            base.OnLoad(e);
        }

        #endregion

        private void repositoryItemPictureEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Ура");
        }
    }

    
}
