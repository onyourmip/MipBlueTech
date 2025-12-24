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
    public partial class UserEditTimeOff : Form
    {
        EmployeeController ctrl = new EmployeeController();


        private readonly int leaveId;

        public UserEditTimeOff(int leaveId)
        {
            InitializeComponent();
            this.leaveId = leaveId;
        }

        private void UserEditTimeOff_Load(object sender, EventArgs e)
        {
            LoadLeaveType();
            cmbLeaveType.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadData();
            CalculateDays();

            dtFrom.ValueChanged += DateChanged;
            dtTo.ValueChanged += DateChanged;

            SetFonts();

        }

        private void SetFonts()
        {

            // ===== LABEL =====
            lblLeaveType.Font = FontManager.Regular(9);
            lblFrom.Font = FontManager.Regular(9);
            lblTo.Font = FontManager.Regular(9);
            lblTotalDay.Font = FontManager.Regular(9);
            lblDescription.Font = FontManager.Regular(9);

            // ===== INPUT =====
            cmbLeaveType.Font = FontManager.Regular(9);
            dtFrom.Font = FontManager.Regular(9);
            dtTo.Font = FontManager.Regular(9);
            txtTotalDay.Font = FontManager.Bold(9);
            txtDesc.Font = FontManager.Regular(9);

            // ===== BUTTON =====
            btnAdd.Font = FontManager.Bold(9);
            btnClear.Font = FontManager.Bold(9);
        }

        private void LoadLeaveType()
        {
            cmbLeaveType.Items.AddRange(new string[]
            {
                "Absent",
                "Sick",
                "Excused",
                "BusinessTrip"
            });
        }

        private void LoadData()
        {
            DataRow row = ctrl.GetById(leaveId);

            if (row == null)
            {
                MessageBox.Show("Data not found");
                Close();
                return;
            }

            cmbLeaveType.Text = row["leave_type"].ToString();
            dtFrom.Value = Convert.ToDateTime(row["start_date"]);
            dtTo.Value = Convert.ToDateTime(row["end_date"]);
            txtTotalDay.Text = row["total_days"].ToString();
            txtDesc.Text = row["remarks"].ToString();

            txtTotalDay.ReadOnly = true;
        }

        private void DateChanged(object sender, EventArgs e)
        {
            CalculateDays();
        }

        private void CalculateDays()
        {
            if (dtTo.Value.Date < dtFrom.Value.Date)
            {
                txtTotalDay.Text = "0";
                return;
            }

            int days =
                (dtTo.Value.Date - dtFrom.Value.Date).Days + 1;

            txtTotalDay.Text = days.ToString();
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtTotalDay.Text, out int totalDays) || totalDays <= 0)
            {
                MessageBox.Show("Invalid total days");
                return;
            }

            bool success = ctrl.Update(
                leaveId,
                cmbLeaveType.Text,
                dtFrom.Value.Date,
                dtTo.Value.Date,
                totalDays,
                txtDesc.Text
            );

            if (!success)
            {
                MessageBox.Show("The request has already been processed or is not in Pending status");
                return;
            }

            MessageBox.Show("The request has been successfully updated");
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbLeaveType.SelectedIndex = -1;
            dtFrom.Value = DateTime.Today;
            dtTo.Value = DateTime.Today;
            txtTotalDay.Text = "0";
            txtDesc.Clear();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UserTimeOff timeOff = new UserTimeOff();
            timeOff.StartPosition = FormStartPosition.Manual;
            timeOff.Location = this.Location;
            timeOff.Show();
            this.Hide();
        }
    }
}
