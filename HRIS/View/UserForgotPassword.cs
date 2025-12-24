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
    public partial class UserForgotPassword : Form
    {
        EmployeeController ctrl = new EmployeeController();
        public UserForgotPassword()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ctrl.RequestPasswordReset(txtEmail.Text.Trim());

                MessageBox.Show("Please check your email. A token has been sent.");

               UserVerifikasiResetPassword otp = new UserVerifikasiResetPassword();
                otp.StartPosition = FormStartPosition.Manual;
                otp.Location = this.Location;
                otp.Show();
                this.Close();


                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UserForgotPassword_Load(object sender, EventArgs e)
        {
            SetFonts();
        }

        private void SetFonts()
        {
            btnReset.Font = FontManager.Bold(8);
            label1.Font = FontManager.Regular(8);
            txtEmail.Font = FontManager.Bold(8);
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
