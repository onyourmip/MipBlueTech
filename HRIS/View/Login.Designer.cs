namespace HRIS
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.linkLblDaftar = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLblLupaPw = new System.Windows.Forms.LinkLabel();
            this.txtPwLogin = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUsnLogin = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(174)))), ((int)(((byte)(224)))));
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(610, 444);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(439, 45);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Sign In";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // linkLblDaftar
            // 
            this.linkLblDaftar.AutoSize = true;
            this.linkLblDaftar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.linkLblDaftar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.linkLblDaftar.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(38)))), ((int)(((byte)(89)))));
            this.linkLblDaftar.Location = new System.Drawing.Point(908, 557);
            this.linkLblDaftar.Name = "linkLblDaftar";
            this.linkLblDaftar.Size = new System.Drawing.Size(78, 25);
            this.linkLblDaftar.TabIndex = 6;
            this.linkLblDaftar.TabStop = true;
            this.linkLblDaftar.Text = "Sign Up";
            this.linkLblDaftar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblDaftar_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(653, 557);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Don’t have an MNC ID yet?";
            // 
            // linkLblLupaPw
            // 
            this.linkLblLupaPw.AutoSize = true;
            this.linkLblLupaPw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.linkLblLupaPw.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(38)))), ((int)(((byte)(89)))));
            this.linkLblLupaPw.Location = new System.Drawing.Point(901, 391);
            this.linkLblLupaPw.Name = "linkLblLupaPw";
            this.linkLblLupaPw.Size = new System.Drawing.Size(127, 20);
            this.linkLblLupaPw.TabIndex = 4;
            this.linkLblLupaPw.TabStop = true;
            this.linkLblLupaPw.Text = "Lupa Password?";
            this.linkLblLupaPw.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblLupaPw_LinkClicked);
            // 
            // txtPwLogin
            // 
            this.txtPwLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPwLogin.DefaultText = "";
            this.txtPwLogin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPwLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPwLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPwLogin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPwLogin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPwLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPwLogin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPwLogin.IconLeft = global::HRIS.Properties.Resources.icons8_password_30;
            this.txtPwLogin.Location = new System.Drawing.Point(610, 326);
            this.txtPwLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPwLogin.Name = "txtPwLogin";
            this.txtPwLogin.PlaceholderForeColor = System.Drawing.Color.Black;
            this.txtPwLogin.PlaceholderText = "Password";
            this.txtPwLogin.SelectedText = "";
            this.txtPwLogin.Size = new System.Drawing.Size(439, 49);
            this.txtPwLogin.TabIndex = 1;
            // 
            // txtUsnLogin
            // 
            this.txtUsnLogin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsnLogin.DefaultText = "";
            this.txtUsnLogin.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsnLogin.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsnLogin.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsnLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsnLogin.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsnLogin.IconLeft = global::HRIS.Properties.Resources.icons8_user_24__1_;
            this.txtUsnLogin.Location = new System.Drawing.Point(610, 254);
            this.txtUsnLogin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsnLogin.Name = "txtUsnLogin";
            this.txtUsnLogin.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.txtUsnLogin.PlaceholderText = "Username";
            this.txtUsnLogin.SelectedText = "";
            this.txtUsnLogin.Size = new System.Drawing.Size(439, 49);
            this.txtUsnLogin.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.Brown;
            this.btnClose.Location = new System.Drawing.Point(610, 495);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedColor = System.Drawing.Color.Maroon;
            this.btnClose.Size = new System.Drawing.Size(439, 42);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::HRIS.Properties.Resources.bg_frLogin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1187, 692);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.linkLblDaftar);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUsnLogin);
            this.Controls.Add(this.linkLblLupaPw);
            this.Controls.Add(this.txtPwLogin);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtUsnLogin;
        private System.Windows.Forms.LinkLabel linkLblDaftar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLblLupaPw;
        private Guna.UI2.WinForms.Guna2TextBox txtPwLogin;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}

