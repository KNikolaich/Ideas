using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.Model;
using DevExpress.XtraEditors.Controls;

namespace StaffTimes.SubControls
{
    public partial class TestForm : Form
    {
        private ContextAdapter _repository;

        public TestForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            _repository = new ContextAdapter();
            gridControl1.DataSource = _repository.GetDataTableTasks(2, DateTime.Today.AddYears(-1), DateTime.Today.AddDays(7));
            _repositoryItemMRUEdit1.Items.AddRange(new object[] {
                "www.devexpress.com",
                "www.devexpress.com/ClientCenter/Downloads/#Trials",
                "www.devexpress.com/ClientCenter/Purchase/"});
            _repositoryItemMRUEdit1.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;


            base.OnLoad(e);
        }
    }
}
