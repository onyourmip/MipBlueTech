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
using QRCoder;
using System.IO;
using Guna.UI2.WinForms;
using System.Drawing.Drawing2D;


namespace HRIS.View
{
    public partial class UserIdCard : Form
    {
        private readonly EmployeeController ctrl = new EmployeeController();
        private long employeeId;

        public UserIdCard(long empId)
        {
            InitializeComponent();
            employeeId = empId;
            LoadUserData();
        }

        private void SetFonts()
        {

            label1.Font = FontManager.Bold(8);
            label10.Font = FontManager.Bold(8);
            label3.Font = FontManager.Bold(8);
            label4.Font = FontManager.Bold(8);
            label5.Font = FontManager.Bold(8);
            label6.Font = FontManager.Bold(8);
            label8.Font = FontManager.Bold(8);
            label7.Font = FontManager.Bold(8);
            label9.Font = FontManager.Bold(8);

            lblId.Font = FontManager.Bold(8);
            lblJoinDate.Font = FontManager.Bold(8);
            lblName.Font = FontManager.Bold(8);
            lblPhone.Font = FontManager.Bold(8);
            lblPosition.Font = FontManager.Bold(8);

            btnSave.Font = FontManager.Bold(8);
            
        }

        private void LoadUserData()
        {
            DataRow row = ctrl.GetEmployeeById(employeeId);
            if (row == null)
            {
                MessageBox.Show("Employee not found");
                return;
            }

            lblName.Text = row["full_name"].ToString();
            lblPosition.Text = row["position_name"].ToString();
            lblId.Text = row["employee_id"].ToString();
            lblJoinDate.Text = Convert
                .ToDateTime(row["join_date"])
                .ToString("dd MMM yyyy");
            lblPhone.Text = row["phone"].ToString();

            // PHOTO
            if (row["photo"] != DBNull.Value)
            {
                string fileName = row["photo"].ToString();

                string photoPath = Path.Combine(
                    Application.StartupPath,
                    "Photos",
                    fileName
                );

                if (File.Exists(photoPath))
                {
                    picProfile.Image = Image.FromFile(photoPath);
                }
                else
                {
                    picProfile.Image = Properties.Resources.defaultUser;
                }
            }
            else
            {
                picProfile.Image = Properties.Resources.defaultUser;
            }


            GenerateQrCode(employeeId.ToString());
        }

        private void GenerateQrCode(string text)
        {
            QRCodeGenerator gen = new QRCodeGenerator();
            QRCodeData data =
                gen.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);

            QRCode qr = new QRCode(data);
            picQr.Image = qr.GetGraphic(5);
            picQr.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveIdCard();
        }

        private void SaveIdCard()
        {
            Bitmap bmp = new Bitmap(panelIdCard.Width, panelIdCard.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(panelIdCard.BackColor);

                // 1️⃣ DRAW BACKGROUND PANEL
                DrawControl(panelIdCard, g);

                // 2️⃣ DRAW USER PHOTO
                DrawUserPhoto(g);

                // 3️⃣ DRAW QR CODE
                DrawPictureBox(picQr, g);

                // 4️⃣ DRAW LABELS
                DrawLabels(panelIdCard, g);


            }

            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "PNG Image|*.png",
                FileName = "IDCard.png"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    bmp.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    MessageBox.Show("ID Card saved successfully!");
                }
            }
        }


        private void DrawControl(Control control, Graphics g)
        {
            Bitmap bg = new Bitmap(control.Width, control.Height);
            control.DrawToBitmap(bg, new Rectangle(0, 0, bg.Width, bg.Height));
            g.DrawImage(bg, 0, 0);
        }

        private void DrawPictureBox(PictureBox pic, Graphics g)
        {
            if (pic.Image == null) return;

            g.DrawImage(
                pic.Image,
                pic.Left,
                pic.Top,
                pic.Width,
                pic.Height
            );
        }

        private void DrawLabels(Control parent, Graphics g)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Label lbl)
                {
                    g.DrawString(
                        lbl.Text,
                        lbl.Font,
                        new SolidBrush(lbl.ForeColor),
                        lbl.Left,
                        lbl.Top
                    );
                }
            }
        }

        private void DrawUserPhoto(Graphics g)
        {
            Image img = picProfile.Image ?? Properties.Resources.defaultUser;

            g.DrawImage(
                img,
                picProfile.Left,
                picProfile.Top,
                picProfile.Width,
                picProfile.Height
            );
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UserHome hm = new UserHome();
            hm.StartPosition = FormStartPosition.Manual;
            hm.Location = this.Location;
            hm.Show();
            this.Hide();
        }
    }
}
