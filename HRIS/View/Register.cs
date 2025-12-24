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
    public partial class Register : Form
    {
       EmployeeController ctrl = new EmployeeController();
        public Register()
        {
            InitializeComponent();

        }

        private void btnDaftar_Click(object sender, EventArgs e)
        {
            string nik = txtNik.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            // 🔴 EMPTY FIELD VALIDATION (VIEW LEVEL)
            if (nik == "" || email == "" || password == "")
            {
                MessageBox.Show(
                    "All fields are required.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 🔎 NIK VALIDATION
            if (!ctrl.IsNikTerdaftar(nik, out long employeeId, out string fullName))
            {
                MessageBox.Show(
                    "NIK is not registered or the employee is inactive.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // 🔁 CHECK EXISTING ACCOUNT
            if (ctrl.IsEmployeeSudahPunyaAkun(employeeId))
            {
                MessageBox.Show(
                    "This employee already has an account.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // 📧 EMAIL FORMAT VALIDATION
            if (!ctrl.IsEmailFormatValid(email))
            {
                MessageBox.Show(
                    "Invalid email format.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // 📧 EMAIL ALREADY USED
            if (ctrl.IsEmailSudahDipakai(email))
            {
                MessageBox.Show(
                    "This email address is already in use.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // 🔐 PASSWORD VALIDATION
            if (!ctrl.IsPasswordValid(password))
            {
                MessageBox.Show(
                    "Password must be at least 8 characters long.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // ✅ SAVE USER (ALL LOGIC HANDLED IN CONTROLLER)
            try
            {
                ctrl.Register(nik, email, password);

                MessageBox.Show(
                    "Registration successful!\nYour username will be sent to your email.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Login login = new Login();
                login.StartPosition = FormStartPosition.Manual;
                login.Location = this.Location;
                login.Show();
                this.Hide();
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

        private void btnBatal_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.StartPosition = FormStartPosition.Manual;
            login.Location = this.Location;
            login.Show();
            this.Hide();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            SetFonts();
        }

        private void SetFonts()
        {

            label2.Font = FontManager.Bold(8);
            label3.Font = FontManager.Bold(8);
            btnBatal.Font = FontManager.Bold(8);
            btnDaftar.Font = FontManager.Bold(8);
            txtEmail.Font = FontManager.Regular(8);
            txtNik.Font = FontManager.Regular(8);
            txtPassword.Font = FontManager.Regular(8);
            label1.Font = FontManager.Bold(8);
        }



    }
}
