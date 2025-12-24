using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using HRIS.Controller;
using HRIS.Helper;

namespace HRIS.View
{
    public partial class UserVerifikasiResetPassword : Form
    {
        EmployeeController ctrl = new EmployeeController();
        public static int ResetUserId;

        public UserVerifikasiResetPassword()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                ResetUserId = ctrl.VerifyResetToken(txtToken.Text.Trim());

                new UserResetPassword().Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UserVerifikasiResetPassword_Load(object sender, EventArgs e)
        {
            SetFonts();
        }

        private void SetFonts()
        {
            btnConfirm.Font = FontManager.Bold(8);
            txtToken.Font = FontManager.Bold(8);
            linkLabel1.Font = FontManager.Bold(8);
            linkLabel1.Font = FontManager.Bold(8);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserForgotPassword change = new UserForgotPassword();
            change.StartPosition = FormStartPosition.Manual;
            change.Location = this.Location;
            change.Show();
            this.Hide();
        }
    }
}
