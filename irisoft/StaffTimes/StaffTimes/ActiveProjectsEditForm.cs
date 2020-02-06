using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using Core;

namespace StaffTimes
{
    public partial class ActiveProjectsEditForm : Form
    {
        StaffTimeDbContainer _db = new StaffTimeDbContainer();

        public ActiveProjectsEditForm(User user)
        {
            InitializeComponent();
            Staff = user;
            DrawListprojects();
            checkBoxForAll.CheckedChanged += checkBoxForAll_CheckedChanged;

        }

        private void DrawListprojects()
        {
            var activeProjects = _db.ActiveProjectOnStaffSet.Where(a => a.UserId == Staff.Id).Select(aps => aps.ProjectId).ToList();
            var allProjects = _db.Project.Where(p=> !p.IsArchive.HasValue || !p.IsArchive.Value).ToList();
            foreach (Project project in allProjects.OrderBy(p=>p.ProjectName))
            {
                var checkd = activeProjects.Contains(project.Id);
                _checkedListBoxControl.Items.Add(project, checkd);
            }
            _checkedListBoxControl.ItemCheck -= _checkedListBoxControl_ItemCheck;
            
            if(activeProjects.Count == allProjects.Count)
                checkBoxForAll.CheckState = CheckState.Checked;
            else if(activeProjects.Count == 0)
                checkBoxForAll.CheckState = CheckState.Unchecked;

            _checkedListBoxControl.ItemCheck += _checkedListBoxControl_ItemCheck;
        }

        public User Staff { get; }

        private void checkBoxForAll_CheckedChanged(object sender, System.EventArgs e)
        {
            

            switch (checkBoxForAll.CheckState)
            {
                case CheckState.Checked:
                    _checkedListBoxControl.CheckAll();
                    break;
                case CheckState.Unchecked:
                    _checkedListBoxControl.UnCheckAll();
                    break;
            }
            
        }

        private void _checkedListBoxControl_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            Project project = (Project)((DevExpress.XtraEditors.Controls.ListBoxItem)_checkedListBoxControl.GetItem(e.Index)).Value;
            switch (e.State)
            {
                case CheckState.Checked:
                    var newProjectOnStaff = _db.ActiveProjectOnStaffSet.Create();
                    newProjectOnStaff.UserId = Staff.Id;
                    newProjectOnStaff.ProjectId = project.Id;
                    _db.ActiveProjectOnStaffSet.Add(newProjectOnStaff);
                    _db.SaveChanges();
                    break;
                case CheckState.Unchecked:
                    var delProjectOnStaffs = _db.ActiveProjectOnStaffSet.Where(aps =>aps.ProjectId == project.Id && aps.UserId == Staff.Id).ToList();
                    foreach (var activeProjectOnStaff in delProjectOnStaffs)
                    {
                        _db.Entry(activeProjectOnStaff).State = EntityState.Deleted;
                    }
                    _db.SaveChanges();

                    break;
            }
            checkBoxForAll.CheckState = CheckState.Indeterminate;
        }

    }
}
