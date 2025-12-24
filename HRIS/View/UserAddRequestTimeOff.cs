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
using HRIS.Model;
using HRIS.View.User;

namespace HRIS.View
{
    public partial class UserAddRequestTimeOff : Form
    {
        EmployeeController ctrl = new EmployeeController();

        public UserAddRequestTimeOff()
        {
            InitializeComponent();
        }

        private void UserAddRequestTimeOff_Load(object sender, EventArgs e)
        {
            FontManager.LoadFonts();
            SetFonts();

            cmbLeaveType.Items.AddRange(new string[]
            {
            "Absent",
            "Sick",
            "Excused",
            "BusinessTrip"
            });

            cmbLeaveType.DropDownStyle = ComboBoxStyle.DropDownList;

            // ===== DATE RULE =====
            dtFrom.MinDate = DateTime.Today;
            dtTo.MinDate = DateTime.Today;

            txtTotalDay.ReadOnly = true;

            dtFrom.ValueChanged += DateChanged;
            dtTo.ValueChanged += DateChanged;

        }


        // ================= AUTO CALCULATE DAYS =================
        private void DateChanged(object sender, EventArgs e)
        {
            if (dtTo.Value.Date <= dtFrom.Value.Date)
            {
                txtTotalDay.Text = "0";
                return;
            }

            int days = (dtTo.Value.Date - dtFrom.Value.Date).Days;
            txtTotalDay.Text = days.ToString();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbLeaveType.SelectedIndex == -1 ||
        string.IsNullOrWhiteSpace(txtDesc.Text))
            {
                MessageBox.Show(
                    "All fields must be filled",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtTotalDay.Text, out int totalDays))
                totalDays = 0;

            string error;
            bool success = ctrl.Insert(
                Session.CurrentUser.EmployeeId,
                cmbLeaveType.Text,
                dtFrom.Value.Date,
                dtTo.Value.Date,
                totalDays,
                txtDesc.Text,
                out error
            );

            if (!success)
            {
                MessageBox.Show(
                    error,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(
                "Request saved successfully",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            Close();
            UserTimeOff timeOff = new UserTimeOff();
            timeOff.StartPosition = FormStartPosition.Manual;
            timeOff.Location = this.Location;
            timeOff.Show();

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

        private void ClearForm()
        {
            cmbLeaveType.SelectedIndex = -1;
            dtFrom.Value = DateTime.Today;
            dtTo.Value = DateTime.Today;
            txtTotalDay.Text = "0";
            txtDesc.Clear();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UserTimeOff timeOff = new UserTimeOff();
            timeOff.StartPosition = FormStartPosition.Manual;
            timeOff.Location = this.Location;
            timeOff.Show();
            this.Hide();
        }
    }
}
