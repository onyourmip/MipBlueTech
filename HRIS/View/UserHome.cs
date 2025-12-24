using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRIS.Controller;
using HRIS.Helper;
using HRIS.View.User;
using System.IO;
using Guna.UI2.AnimatorNS;



namespace HRIS.View
{
    public partial class UserHome : Form
    {
        private UserSession user;
        EmployeeController ctrl = new EmployeeController();



        public UserHome()
        {
            InitializeComponent();
            user = Session.CurrentUser;
        }

        private void UserHome_Load(object sender, EventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Session expired. Please login again.");
                new Login().Show();
                this.Close();
                return;
            }

            lblName.Text = user.FullName;
            lblPosition.Text = user.Position;
            lblTime.Text = DateTime.Now.ToString(
                "dddd, dd MMMM yyyy",
                new CultureInfo("id-ID"));

            LoadData();
            SetFonts();
        }


        private void SetFonts()
        {
            btnLogOut.Font = FontManager.Bold(8);
            btnCheckIn.Font = FontManager.Bold(8);
            btnHome.Font = FontManager.Bold(8);
            btnSet.Font = FontManager.Bold(8);
            btnShift.Font = FontManager.Bold(8);
            btnTimeOff.Font = FontManager.Bold(8);

            label1.Font = FontManager.Bold(8);
            label10.Font = FontManager.Bold(8);
            label12.Font = FontManager.Bold(8);
            label3.Font = FontManager.Bold(8);
            label4.Font = FontManager.Bold(8);
            label5.Font = FontManager.Bold(8);
            label6.Font = FontManager.Bold(8);
            label8.Font = FontManager.Bold(8);

            lblBusinessTrip.Font = FontManager.Bold(8);
            lblEnd.Font = FontManager.Bold(8);
            lblExcused.Font = FontManager.Bold(8);
            lblName.Font = FontManager.Bold(14);
            lblPosition.Font = FontManager.Bold(8);
            lblPresent.Font = FontManager.Bold(8);
            lblSick.Font = FontManager.Bold(8);
            lblStart.Font = FontManager.Bold(8);
            lblTime.Font = FontManager.Bold(8);

            dgvCheckIn.Font = FontManager.Bold(8);
        }

        private void LoadData()
        {
            DataRow row = ctrl.GetEmployeeById(user.EmployeeId);
            if (row == null) return;

            (string masuk, string pulang) jam =
                ctrl.GetAbsensiHariIni(user.EmployeeId);

            lblStart.Text = jam.masuk;
            lblEnd.Text = jam.pulang;

            Dictionary<string, int> rekap =
                ctrl.GetRekapBulanan(user.EmployeeId);

            lblPresent.Text = rekap.ContainsKey("Present")
                ? rekap["Present"].ToString()
                : "0";

            lblSick.Text = rekap.ContainsKey("Sick")
                ? rekap["Sick"].ToString()
                : "0";

            lblExcused.Text = rekap.ContainsKey("Excused")
                ? rekap["Excused"].ToString()
                : "0";

            lblBusinessTrip.Text = rekap.ContainsKey("BusinessTrip")
                ? rekap["BusinessTrip"].ToString()
                : "0";

            dgvCheckIn.DataSource =
                ctrl.GetRiwayatTerbaru(user.EmployeeId);

            LoadPhoto(row["photo"]?.ToString());

        }

        private void LoadPhoto(string photo)
        {
            if (string.IsNullOrWhiteSpace(photo))
            {
                picProfile.Image = Properties.Resources.defaultUser;
                return;
            }

            string path = PhotoHelper.GetPhotoPath(photo);

            if (File.Exists(path))
            {
                picProfile.Image?.Dispose();
                picProfile.Image = Image.FromFile(path);
            }
            else
            {
                picProfile.Image = Properties.Resources.defaultUser;
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            UserCheckIn form = new UserCheckIn();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.Show();
            this.Hide();
        }

        private void btnShift_Click(object sender, EventArgs e)
        {
            UserShift shift = new UserShift(Session.CurrentUser.EmployeeId);
            shift.StartPosition = FormStartPosition.Manual;
            shift.Location = this.Location;
            shift.Show();
            this.Hide();
        }

        private void btnTimeOff_Click(object sender, EventArgs e)
        {
            UserTimeOff timeOff = new UserTimeOff();
            timeOff.StartPosition = FormStartPosition.Manual;
            timeOff.Location = this.Location;
            timeOff.Show();
            this.Hide();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser == null)
            {
                MessageBox.Show("Session expired. Please login again.");
                return;
            }

            UserProfile profile = new UserProfile(Session.CurrentUser.EmployeeId);
            profile.StartPosition = FormStartPosition.Manual;
            profile.Location = this.Location;
            profile.Show();
            this.Hide();

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Are you sure you want to log out?",
                    "Confirm Logout",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                login.StartPosition = FormStartPosition.Manual;
                login.Location = this.Location;
                login.Show();
                this.Hide();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            UserHome hm = new UserHome();
            hm.StartPosition = FormStartPosition.Manual;
            hm.Location = this.Location;
            hm.Show();
            this.Hide();
        }

        private void picIdCard_Click(object sender, EventArgs e)
        {
            UserIdCard card =
            new UserIdCard(Session.CurrentUser.EmployeeId);

            card.StartPosition = FormStartPosition.Manual;
            card.Location = this.Location;
            card.Show();
            this.Hide();
        }
    }
}
