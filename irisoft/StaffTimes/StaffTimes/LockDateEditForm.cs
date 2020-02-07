using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;

namespace StaffTimes
{
    public partial class LockDateEditForm : Form
    {
        StaffTimeDbContainer _db = new StaffTimeDbContainer();
        private Property _property;
        private const string PropertyKey = "DateOfLock";

        public LockDateEditForm()
        {
            InitializeComponent();
            _property = _db.PropertySet.FirstOrDefault(p => p.Key == PropertyKey);
            if (_property != null)
            {
                _dtpLock.Value = Convert.ToDateTime(_property.Value);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }

        private void _bSave_Click(object sender, EventArgs e)
        {
            if (_dtpLock.Value != null)
            {
                if (_property == null)
                {
                    _property = _db.PropertySet.Create();
                    _property.Key = PropertyKey;
                    _db.PropertySet.Add(_property);
                }
                _property.Value = _dtpLock.Value.ToShortDateString();
                _db.SaveChanges();

                
            }
            DialogResult = DialogResult.OK;
        }
    }
}
