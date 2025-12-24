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

namespace HRIS.View
{
    public partial class UserResetPassword : Form
    {
        EmployeeController ctrl = new EmployeeController();
        public UserResetPassword()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length < 8)
            {
                MessageBox.Show(
                    "Password must be at least 8 characters long.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show(
                    "Passwords do not match.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            try
            {
                ctrl.ResetPassword(
                    UserVerifikasiResetPassword.ResetUserId,
                    txtPassword.Text
                );

                MessageBox.Show(
                    "Password has been reset successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }

        private void UserResetPassword_Load(object sender, EventArgs e)
        {
            SetFonts();
        }

        private void SetFonts()
        {
            txtConfirmPassword.Font = FontManager.Bold(8);
            txtPassword.Font = FontManager.Bold(8);

            btnCancel.Font = FontManager.Bold(8);
            btnReset.Font = FontManager.Bold(8);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.StartPosition = FormStartPosition.Manual;
            login.Location = this.Location;
            login.Show();
            this.Hide();
        }
    }
}
