using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using HRIS.Controller;
using HRIS.Helper;

namespace HRIS.View.User
{
    public partial class UserTimeOff : Form
    {
        EmployeeController ctrl = new EmployeeController();


        public UserTimeOff()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            DataTable table =
                ctrl.GetByEmployee(Session.CurrentUser.EmployeeId);

            dgvTimeOff.DataSource = table;

            if (table != null && table.Columns.Count > 0)
                SetupGridHeader();

            dgvTimeOff.ClearSelection();
        }


        // =========================
        // HEADER TABEL
        // =========================
        private void SetupGridHeader()
        {
            dgvTimeOff.ReadOnly = true;
            dgvTimeOff.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTimeOff.MultiSelect = false;
            dgvTimeOff.AllowUserToAddRows = false;
            dgvTimeOff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvTimeOff.Columns.Contains("leave_id"))
            {
                dgvTimeOff.Columns["leave_id"].HeaderText = "ID Request";
                dgvTimeOff.Columns["leave_id"].Visible = false;
            }

            if (dgvTimeOff.Columns.Contains("leave_type"))
                dgvTimeOff.Columns["leave_type"].HeaderText = "Leave Type";

            if (dgvTimeOff.Columns.Contains("start_date"))
                dgvTimeOff.Columns["start_date"].HeaderText = "From";

            if (dgvTimeOff.Columns.Contains("end_date"))
                dgvTimeOff.Columns["end_date"].HeaderText = "To";

            if (dgvTimeOff.Columns.Contains("total_days"))
                dgvTimeOff.Columns["total_days"].HeaderText = "Total Days";

            if (dgvTimeOff.Columns.Contains("leave_category"))
                dgvTimeOff.Columns["leave_category"].HeaderText = "Category";

            if (dgvTimeOff.Columns.Contains("remarks"))
                dgvTimeOff.Columns["remarks"].HeaderText = "Description";

            if (dgvTimeOff.Columns.Contains("status"))
                dgvTimeOff.Columns["status"].HeaderText = "Status";
        }


        // =========================
        // SELECTION CHANGED
        // =========================
        private void dgvTimeOff_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTimeOff.CurrentRow == null)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                return;
            }

            object statusObj =
                dgvTimeOff.CurrentRow.Cells["status"].Value;

            if (statusObj == null)
            {
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                return;
            }

            string status = statusObj.ToString();
            bool canEdit = status == "Pending";

            btnEdit.Enabled = canEdit;
            btnDelete.Enabled = canEdit;
        }


        private void SetFonts()
        {
            btnLogout.Font = FontManager.Bold(8);
            btnCheckIn.Font = FontManager.Bold(8);
            btnHome.Font = FontManager.Bold(8);
            btnSet.Font = FontManager.Bold(8);
            btnShift.Font = FontManager.Bold(8);
            btnTimeOff.Font = FontManager.Bold(8);


            label1.Font = FontManager.Bold(8);

            dgvTimeOff.Font = FontManager.Bold(8);
            btnAddRequest.Font = FontManager.Bold(8);
            btnDelete.Font = FontManager.Bold(8);
            btnEdit.Font = FontManager.Bold(8);

        }

        private void UserTimeOff_Load(object sender, EventArgs e)
        {
            if (Session.CurrentUser == null)
            {
                MessageBox.Show("Session expired. Please login again.");
                Close();
                return;
            }

            dgvTimeOff.ColumnHeadersVisible = true;
            dgvTimeOff.EnableHeadersVisualStyles = false;

            dgvTimeOff.RowHeadersVisible = false;
            dgvTimeOff.AllowUserToResizeColumns = false;
            dgvTimeOff.AllowUserToResizeRows = false;

            dgvTimeOff.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvTimeOff.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;



            SetFonts();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvTimeOff.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request first.");
                return;
            }

            DataGridViewRow row = dgvTimeOff.SelectedRows[0];
            string status = row.Cells["status"].Value?.ToString();

            if (status != "Pending")
            {
                MessageBox.Show(
                    "Only pending requests can be edited.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int leaveId = Convert.ToInt32(row.Cells["leave_id"].Value);

            UserEditTimeOff form = new UserEditTimeOff(leaveId);
            form.ShowDialog();

            LoadData();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvTimeOff.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a request first.");
                return;
            }

            DataGridViewRow row = dgvTimeOff.SelectedRows[0];
            string status = row.Cells["status"].Value?.ToString();

            if (status != "Pending")
            {
                MessageBox.Show(
                    "Only pending requests can be deleted.",
                    "Access Denied",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int leaveId = Convert.ToInt32(row.Cells["leave_id"].Value);

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this request?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            bool success = ctrl.Delete(leaveId);

            if (!success)
            {
                MessageBox.Show("Failed to delete request.");
                return;
            }

            MessageBox.Show("Request deleted successfully.");
            LoadData();
        }

        private void btnAddRequest_Click(object sender, EventArgs e)
        {
            if (ctrl.HasPendingLeave(Session.CurrentUser.EmployeeId))
            {
                MessageBox.Show(
                    "You still have a leave request with Pending status.\n" +
                    "Please wait until it has been processed.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            UserAddRequestTimeOff addForm = new UserAddRequestTimeOff();
            addForm.StartPosition = FormStartPosition.Manual;
            addForm.Location = this.Location;
            addForm.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            UserHome hm = new UserHome();
            hm.StartPosition = FormStartPosition.Manual;
            hm.Location = this.Location;
            hm.Show();
            this.Hide();
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            UserShift shift = new UserShift(Session.CurrentUser.EmployeeId);
            shift.StartPosition = FormStartPosition.Manual;
            shift.Location = this.Location;
            shift.Show();
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
    }
}
