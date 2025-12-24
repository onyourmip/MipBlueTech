using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HRIS.Controller;
using HRIS.Helper;
using HRIS.View.User;

namespace HRIS.View
{
    public partial class UserProfile : Form
    {
        private readonly EmployeeController controller = new EmployeeController();
        private readonly long employeeId;
        public UserProfile(long employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            LoadProfile();
            DisableInput();
            SetFonts();
        }
        private void SetFonts()
        {
            btnLogout.Font = FontManager.Bold(8);
            btnCheckIn.Font = FontManager.Bold(8);
            btnHome.Font = FontManager.Bold(8);
            btnSet.Font = FontManager.Bold(8);
            btnShift.Font = FontManager.Bold(8);
            btnTimeOff.Font = FontManager.Bold(8);
            btnEdit.Font = FontManager.Bold(8);

            label1.Font = FontManager.Bold(8);
            label2.Font = FontManager.Bold(8);
            label3.Font = FontManager.Bold(8);
            label4.Font = FontManager.Bold(8);
            label5.Font = FontManager.Bold(8);
            label6.Font = FontManager.Bold(8);
            label7.Font = FontManager.Bold(8);
            label8.Font = FontManager.Bold(8);
            label9.Font = FontManager.Bold(8);
            label10.Font = FontManager.Bold(8);
            label11.Font = FontManager.Bold(8);
            label12.Font = FontManager.Bold(8);
            label13.Font = FontManager.Bold(8);
            label14.Font = FontManager.Bold(8);
            label15.Font = FontManager.Bold(8);

            txtAddress.Font = FontManager.Bold(8);
            txtBirthDate.Font = FontManager.Bold(8);
            txtBirthPlace.Font = FontManager.Bold(8);
            txtEducation.Font = FontManager.Bold(8);
            txtGender.Font = FontManager.Bold(8);
            txtNationality.Font = FontManager.Bold(8);
            txtPhone.Font = FontManager.Bold(8);


            lblDepartmentName.Font = FontManager.Bold(8);
            lblEmployeeNumber.Font = FontManager.Bold(8);
            lblEmploymentStatus.Font = FontManager.Bold(8);
            lblFullName.Font = FontManager.Bold(8);
            lblJoinDate.Font = FontManager.Bold(8);
            lblPositionName.Font = FontManager.Bold(8);
        }


        private void LoadProfile()
        {
            DataRow row = controller.GetEmployeeById(employeeId);
            if (row == null) return;

            lblFullName.Text = row["full_name"].ToString();
            lblEmployeeNumber.Text = row["employee_number"].ToString();
            lblDepartmentName.Text = row["department_name"].ToString();
            lblPositionName.Text = row["position_name"].ToString();
            lblJoinDate.Text = Convert.ToDateTime(row["join_date"]).ToString("dd MMM yyyy");
            lblEmploymentStatus.Text = row["employment_status"].ToString();

            txtBirthPlace.Text = row["birth_place"].ToString();
            txtBirthDate.Text = row["birth_date"].ToString();
            txtGender.Text = row["gender"].ToString();
            txtNationality.Text = row["nationality"].ToString();
            txtAddress.Text = row["address"].ToString();
            txtPhone.Text = row["phone"].ToString();
            txtEducation.Text = row["education"].ToString();

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





        private void DisableInput()
        {
            txtBirthPlace.ReadOnly = true;
            txtBirthDate.ReadOnly = true;
            txtGender.ReadOnly = true;
            txtNationality.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtPhone.ReadOnly = true;
            txtEducation.ReadOnly = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UserEditProfile frm = new UserEditProfile(employeeId);
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = this.Location;
            frm.Show();
            this.Close();
            LoadProfile();

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            UserHome hm = new UserHome();
            hm.StartPosition = FormStartPosition.Manual;
            hm.Location = this.Location;
            hm.Show();
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

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            UserCheckIn form = new UserCheckIn();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = this.Location;
            form.Show();
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
            UserProfile profile = new UserProfile(Session.CurrentUser.EmployeeId);
            profile.StartPosition = FormStartPosition.Manual;
            profile.Location = this.Location;
            profile.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
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
    }

}
