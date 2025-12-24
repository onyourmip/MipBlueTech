namespace HRIS.View
{
    partial class UserShift
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMbt = new System.Windows.Forms.Label();
            this.dgvMyShift = new System.Windows.Forms.DataGridView();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
            this.btnCheckIn = new Guna.UI2.WinForms.Guna2Button();
            this.btnSet = new Guna.UI2.WinForms.Guna2Button();
            this.btnShift = new Guna.UI2.WinForms.Guna2Button();
            this.btnTimeOff = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyShift)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(222)))), ((int)(((byte)(239)))));
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.btnLogout);
            this.guna2Panel1.Controls.Add(this.btnHome);
            this.guna2Panel1.Controls.Add(this.btnCheckIn);
            this.guna2Panel1.Controls.Add(this.btnSet);
            this.guna2Panel1.Controls.Add(this.btnShift);
            this.guna2Panel1.Controls.Add(this.btnTimeOff);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 34);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(262, 658);
            this.guna2Panel1.TabIndex = 76;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Location = new System.Drawing.Point(258, 0);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1013, 655);
            this.guna2Panel2.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "My Shift";
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.AutoScroll = true;
            this.guna2Panel3.BackColor = System.Drawing.Color.Khaki;
            this.guna2Panel3.Controls.Add(this.dgvMyShift);
            this.guna2Panel3.Controls.Add(this.label1);
            this.guna2Panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(253)))), ((int)(((byte)(245)))));
            this.guna2Panel3.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.guna2Panel3.Location = new System.Drawing.Point(261, 34);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(926, 658);
            this.guna2Panel3.TabIndex = 77;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(134)))));
            this.flowLayoutPanel1.Controls.Add(this.lblMbt);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1187, 34);
            this.flowLayoutPanel1.TabIndex = 75;
            // 
            // lblMbt
            // 
            this.lblMbt.AutoSize = true;
            this.lblMbt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(134)))));
            this.lblMbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMbt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMbt.Location = new System.Drawing.Point(3, 0);
            this.lblMbt.Name = "lblMbt";
            this.lblMbt.Size = new System.Drawing.Size(175, 25);
            this.lblMbt.TabIndex = 42;
            this.lblMbt.Text = "MBT DIGITAL ID";
            // 
            // dgvMyShift
            // 
            this.dgvMyShift.AllowUserToResizeColumns = false;
            this.dgvMyShift.AllowUserToResizeRows = false;
            this.dgvMyShift.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(134)))));
            this.dgvMyShift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyShift.Location = new System.Drawing.Point(48, 50);
            this.dgvMyShift.Name = "dgvMyShift";
            this.dgvMyShift.RowHeadersWidth = 62;
            this.dgvMyShift.RowTemplate.Height = 28;
            this.dgvMyShift.Size = new System.Drawing.Size(849, 503);
            this.dgvMyShift.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.btnLogout.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.btnLogout.Font = new System.Drawing.Font("Nirmala Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(134)))));
            this.btnLogout.Image = global::HRIS.Properties.Resources.icons8_back_50;
            this.btnLogout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.Location = new System.Drawing.Point(9, 601);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(241, 39);
            this.btnLogout.TabIndex = 36;
            this.btnLogout.Text = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnHome
            // 
            this.btnHome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.btnHome.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnHome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHome.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.btnHome.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnHome.Font = new System.Drawing.Font("Nirmala Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(134)))));
            this.btnHome.Image = global::HRIS.Properties.Resources.icons8_home_50;
            this.btnHome.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHome.Location = new System.Drawing.Point(11, 13);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(241, 39);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "Home";
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCheckIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.btnCheckIn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnCheckIn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCheckIn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCheckIn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCheckIn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCheckIn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.btnCheckIn.Font = new System.Drawing.Font("Nirmala Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnCheckIn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(134)))));
            this.btnCheckIn.Image = global::HRIS.Properties.Resources.icons8_fingerprint_30;
            this.btnCheckIn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCheckIn.Location = new System.Drawing.Point(11, 113);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(241, 39);
            this.btnCheckIn.TabIndex = 1;
            this.btnCheckIn.Text = "Check-in";
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // btnSet
            // 
            this.btnSet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.btnSet.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnSet.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSet.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSet.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSet.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSet.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.btnSet.Font = new System.Drawing.Font("Nirmala Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnSet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(134)))));
            this.btnSet.Image = global::HRIS.Properties.Resources.icons8_settings_50;
            this.btnSet.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSet.Location = new System.Drawing.Point(11, 212);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(241, 39);
            this.btnSet.TabIndex = 4;
            this.btnSet.Text = "Profile";
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnShift
            // 
            this.btnShift.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnShift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.btnShift.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnShift.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShift.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShift.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShift.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShift.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.btnShift.Font = new System.Drawing.Font("Nirmala Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnShift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(134)))));
            this.btnShift.Image = global::HRIS.Properties.Resources.icons8_overtime_64;
            this.btnShift.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnShift.Location = new System.Drawing.Point(11, 63);
            this.btnShift.Name = "btnShift";
            this.btnShift.Size = new System.Drawing.Size(241, 39);
            this.btnShift.TabIndex = 3;
            this.btnShift.Text = "My Shift";
            this.btnShift.Click += new System.EventHandler(this.btnShift_Click);
            // 
            // btnTimeOff
            // 
            this.btnTimeOff.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTimeOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.btnTimeOff.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnTimeOff.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTimeOff.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTimeOff.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTimeOff.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTimeOff.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.btnTimeOff.Font = new System.Drawing.Font("Nirmala Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimeOff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(134)))));
            this.btnTimeOff.Image = global::HRIS.Properties.Resources.icons8_calendar_minus_32;
            this.btnTimeOff.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTimeOff.Location = new System.Drawing.Point(11, 162);
            this.btnTimeOff.Name = "btnTimeOff";
            this.btnTimeOff.Size = new System.Drawing.Size(241, 39);
            this.btnTimeOff.TabIndex = 2;
            this.btnTimeOff.Text = "Time Off";
            this.btnTimeOff.Click += new System.EventHandler(this.btnTimeOff_Click);
            // 
            // UserShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 692);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Panel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserShift";
            this.Text = "Shift";
            this.Load += new System.EventHandler(this.UserShift_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyShift)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnCheckIn;
        private Guna.UI2.WinForms.Guna2Button btnSet;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        private Guna.UI2.WinForms.Guna2Button btnShift;
        private Guna.UI2.WinForms.Guna2Button btnTimeOff;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblMbt;
        private System.Windows.Forms.DataGridView dgvMyShift;
    }
}