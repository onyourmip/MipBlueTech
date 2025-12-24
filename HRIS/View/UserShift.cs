using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRIS.Controller;
using HRIS.Helper;
using HRIS.View.User;

namespace HRIS.View
{
    public partial class UserShift : Form
    {
        private readonly EmployeeController ctrl = new EmployeeController();
        private readonly long employeeId;
        public UserShift(long employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
        }

        private void UserShift_Load(object sender, EventArgs e)
        {
            LoadMyShift();
            SetFonts();
        }

        private void SetFonts()
        {
            btnLogout.Font = FontManager.Bold(8);
            btnCheckIn.Font = FontManager.Bold(8);
            btnHome.Font = FontManager.Bold(8);
            btnSet.Font = FontManager.Bold(8);
            btnShift.Font = FontManager.Bold(8);
            btnTimeOff.Font = FontManager.Bold(8);

            dgvMyShift.Font = FontManager.Bold(8);
        }

        private void LoadMyShift()
        {
            dgvMyShift.AutoGenerateColumns = true;
            dgvMyShift.DataSource = ctrl.GetMyWorkSchedule(employeeId);

            dgvMyShift.ReadOnly = true;
            dgvMyShift.AllowUserToAddRows = false;
            dgvMyShift.AllowUserToDeleteRows = false;
            dgvMyShift.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMyShift.MultiSelect = false;


            dgvMyShift.ColumnHeadersVisible = true;
            dgvMyShift.EnableHeadersVisualStyles = false;

            dgvMyShift.RowHeadersVisible = false;
            dgvMyShift.AllowUserToResizeColumns = false;
            dgvMyShift.AllowUserToResizeRows = false;

            dgvMyShift.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMyShift.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            UserHome hm = new UserHome();
            hm.StartPosition = FormStartPosition.Manual;
            hm.Location = this.Location;
            hm.Show();
            this.Hide();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            UserCheckIn form = new UserCheckIn();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.Show();
            this.Hide();
        }

        private void btnTimeOff_Click(object sender, EventArgs e)
        {
            UserTimeOff timeOff = new UserTimeOff();
            timeOff.StartPosition = FormStartPosition.Manual;
            timeOff.Location = this.Location;
            timeOff.Show();
            this.Hide();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            UserProfile profile = new UserProfile(Session.CurrentUser.EmployeeId);
            profile.StartPosition = FormStartPosition.Manual;
            profile.Location = this.Location;
            profile.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Are you sure you want to log out?",
               "Confirm Logout",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                login.StartPosition = FormStartPosition.Manual;
                login.Location = this.Location;
                login.Show();
                this.Hide();
            }
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            UserShift shift = new UserShift(Session.CurrentUser.EmployeeId);
            shift.StartPosition = FormStartPosition.Manual;
            shift.Location = this.Location;
            shift.Show();
            this.Hide();
        }
    }
}
