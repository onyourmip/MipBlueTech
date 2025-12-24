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
using HRIS.View;

namespace HRIS
{
    public partial class Login : Form
    {
        EmployeeController ctrl = new EmployeeController();
        public Login()
        {
            InitializeComponent();
            txtPwLogin.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserSession user = ctrl.Login(
                txtUsnLogin.Text.Trim(),
                txtPwLogin.Text
            );

            if (user == null)
            {
                MessageBox.Show(
                    "Username is not registered or password is incorrect",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            Session.CurrentUser = user;

            MessageBox.Show(
                "Login Successful",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            UserHome home = new UserHome();
            home.StartPosition = FormStartPosition.Manual;
            home.Location = this.Location;
            home.Show();
            this.Hide();

        }

        private void linkLblDaftar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register reg = new Register();
            reg.StartPosition= FormStartPosition.Manual;
            reg.Location = this.Location;
            reg.Show();
            this.Hide();
        }

        private void SetFonts()
        {
            
            btnLogin.Font = FontManager.Bold(9);
            label3.Font = FontManager.Bold(9);
            linkLblDaftar.Font = FontManager.Bold(9);
            linkLblLupaPw.Font = FontManager.Bold(9);
            txtUsnLogin.Font = FontManager.Regular(8);
            btnClose.Font = FontManager.Regular(8);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            SetFonts();
        }

        private void linkLblLupaPw_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserForgotPassword forgotpw = new UserForgotPassword();
            forgotpw.StartPosition = FormStartPosition.Manual;
            forgotpw.Location = this.Location;
            forgotpw.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
