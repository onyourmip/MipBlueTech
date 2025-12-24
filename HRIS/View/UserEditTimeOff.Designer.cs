namespace HRIS.View
{
    partial class UserEditTimeOff
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
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.dtFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtTotalDay = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblLeaveType = new System.Windows.Forms.Label();
            this.cmbLeaveType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtDesc = new System.Windows.Forms.RichTextBox();
            this.dtTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblTotalDay = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClear.FillColor = System.Drawing.Color.Maroon;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Image = global::HRIS.Properties.Resources.icons8_clear_64;
            this.btnClear.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClear.Location = new System.Drawing.Point(612, 586);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(231, 39);
            this.btnClear.TabIndex = 49;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(134)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::HRIS.Properties.Resources.icons8_save_24;
            this.btnAdd.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAdd.Location = new System.Drawing.Point(365, 586);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(231, 39);
            this.btnAdd.TabIndex = 48;
            this.btnAdd.Text = "Save";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(240)))), ((int)(((byte)(226)))));
            this.btnBack.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.FillColor = System.Drawing.Color.White;
            this.btnBack.Font = new System.Drawing.Font("Nirmala Text", 9F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(88)))), ((int)(((byte)(134)))));
            this.btnBack.Image = global::HRIS.Properties.Resources.icons8_cancel_30;
            this.btnBack.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnBack.Location = new System.Drawing.Point(102, 48);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(163, 38);
            this.btnBack.TabIndex = 52;
            this.btnBack.Text = "Cancel";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // dtFrom
            // 
            this.dtFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(241)))), ((int)(((byte)(168)))));
            this.dtFrom.Checked = true;
            this.dtFrom.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(131)))), ((int)(((byte)(179)))));
            this.dtFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtFrom.ForeColor = System.Drawing.Color.White;
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtFrom.Location = new System.Drawing.Point(406, 287);
            this.dtFrom.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtFrom.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(487, 36);
            this.dtFrom.TabIndex = 4;
            this.dtFrom.Value = new System.DateTime(2025, 12, 19, 13, 18, 51, 264);
            // 
            // txtTotalDay
            // 
            this.txtTotalDay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.txtTotalDay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotalDay.DefaultText = "";
            this.txtTotalDay.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTotalDay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTotalDay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalDay.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalDay.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalDay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTotalDay.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalDay.Location = new System.Drawing.Point(406, 413);
            this.txtTotalDay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTotalDay.Name = "txtTotalDay";
            this.txtTotalDay.PlaceholderText = "";
            this.txtTotalDay.SelectedText = "";
            this.txtTotalDay.Size = new System.Drawing.Size(487, 37);
            this.txtTotalDay.TabIndex = 3;
            // 
            // lblLeaveType
            // 
            this.lblLeaveType.AutoSize = true;
            this.lblLeaveType.BackColor = System.Drawing.Color.White;
            this.lblLeaveType.Location = new System.Drawing.Point(295, 233);
            this.lblLeaveType.Name = "lblLeaveType";
            this.lblLeaveType.Size = new System.Drawing.Size(90, 20);
            this.lblLeaveType.TabIndex = 0;
            this.lblLeaveType.Text = "Leave Type";
            // 
            // cmbLeaveType
            // 
            this.cmbLeaveType.BackColor = System.Drawing.Color.Transparent;
            this.cmbLeaveType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.cmbLeaveType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeaveType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbLeaveType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbLeaveType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbLeaveType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbLeaveType.ItemHeight = 30;
            this.cmbLeaveType.Location = new System.Drawing.Point(406, 233);
            this.cmbLeaveType.Name = "cmbLeaveType";
            this.cmbLeaveType.Size = new System.Drawing.Size(487, 36);
            this.cmbLeaveType.TabIndex = 5;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(406, 468);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(487, 95);
            this.txtDesc.TabIndex = 6;
            this.txtDesc.Text = "";
            // 
            // dtTo
            // 
            this.dtTo.Checked = true;
            this.dtTo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(160)))), ((int)(((byte)(202)))));
            this.dtTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtTo.ForeColor = System.Drawing.Color.White;
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtTo.Location = new System.Drawing.Point(406, 351);
            this.dtTo.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtTo.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(487, 36);
            this.dtTo.TabIndex = 6;
            this.dtTo.Value = new System.DateTime(2025, 12, 19, 13, 18, 51, 264);
            // 
            // lblTotalDay
            // 
            this.lblTotalDay.AutoSize = true;
            this.lblTotalDay.BackColor = System.Drawing.Color.White;
            this.lblTotalDay.Location = new System.Drawing.Point(293, 404);
            this.lblTotalDay.Name = "lblTotalDay";
            this.lblTotalDay.Size = new System.Drawing.Size(84, 20);
            this.lblTotalDay.TabIndex = 7;
            this.lblTotalDay.Text = "Total Days";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.White;
            this.lblDescription.Location = new System.Drawing.Point(295, 468);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(89, 20);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Description";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.BackColor = System.Drawing.Color.White;
            this.lblFrom.Location = new System.Drawing.Point(295, 287);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(46, 20);
            this.lblFrom.TabIndex = 9;
            this.lblFrom.Text = "From";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.BackColor = System.Drawing.Color.White;
            this.lblTo.Location = new System.Drawing.Point(296, 340);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(27, 20);
            this.lblTo.TabIndex = 10;
            this.lblTo.Text = "To";
            // 
            // UserEditTimeOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.BackgroundImage = global::HRIS.Properties.Resources.bg_fEditRequest;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1187, 692);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblTotalDay);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.cmbLeaveType);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.lblLeaveType);
            this.Controls.Add(this.txtTotalDay);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "UserEditTimeOff";
            this.Text = "Edit Time-Off";
            this.Load += new System.EventHandler(this.UserEditTimeOff_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnBack;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtFrom;
        private Guna.UI2.WinForms.Guna2TextBox txtTotalDay;
        private System.Windows.Forms.Label lblLeaveType;
        private Guna.UI2.WinForms.Guna2ComboBox cmbLeaveType;
        private System.Windows.Forms.RichTextBox txtDesc;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtTo;
        private System.Windows.Forms.Label lblTotalDay;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
    }
}