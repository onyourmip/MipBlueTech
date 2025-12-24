using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
    public partial class UserEditProfile : Form
    {
        EmployeeController ctrl = new EmployeeController();
        private readonly long employeeId;
        private string selectedPhotoPath = string.Empty;
        public UserEditProfile(long employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
        }



        private void SetFonts()
        {
            btnLogout.Font = FontManager.Bold(8);
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
            label11.Font = FontManager.Bold(8);
            label15.Font = FontManager.Bold(8);
            label13.Font = FontManager.Bold(8);
            label7.Font = FontManager.Bold(8);
            label9.Font = FontManager.Bold(8);

            txtAddress.Font = FontManager.Regular(8);
            dtBirthDate.Font = FontManager.Regular(8);
            txtBirthPlace.Font = FontManager.Regular(8);
            cbEducation.Font = FontManager.Regular(8);
            rbFemale.Font = FontManager.Regular(8);
            rbMale.Font = FontManager.Regular(8);
            txtNationality.Font = FontManager.Regular(8);
            txtPhone.Font = FontManager.Regular(8);

            lblDepartmentName.Font = FontManager.Bold(8);
            lblEmployeeNumber.Font = FontManager.Bold(8);
            lblEmploymentStatus.Font = FontManager.Bold(8);
            lblFullName.Font = FontManager.Bold(8);
            lblJoinDate.Font = FontManager.Bold(8);
            lblPositionName.Font = FontManager.Bold(8);
        }

        private void UserEditProfile_Load(object sender, EventArgs e)
        {
            SetFonts();
            LoadEducation();
            LoadData();
        }

        private void LoadEducation()
        {
            cbEducation.Items.Clear();
            cbEducation.Items.AddRange(new string[]
            {
                "SD","SMP","SMA / SMK","D1 / D2 / D3","S1","S2","S3"
            });
        }

        private void LoadData()
        {
            DataRow row = ctrl.GetEmployeeById(employeeId);
            if (row == null) return;

            lblFullName.Text = row["full_name"].ToString();
            lblEmployeeNumber.Text = row["employee_number"].ToString();
            lblDepartmentName.Text = row["department_name"].ToString();
            lblPositionName.Text = row["position_name"].ToString();
            lblJoinDate.Text = Convert.ToDateTime(row["join_date"]).ToString("dd MMM yyyy");
            lblEmploymentStatus.Text = row["employment_status"].ToString();

            txtBirthPlace.Text = row["birth_place"].ToString();
            dtBirthDate.Value = Convert.ToDateTime(row["birth_date"]);
            txtNationality.Text = row["nationality"].ToString();
            txtAddress.Text = row["address"].ToString();
            txtPhone.Text = row["phone"].ToString();
            cbEducation.Text = row["education"].ToString();

            // ===== GENDER =====
            string gender = row["gender"].ToString().ToLower();
            rbMale.Checked = gender == "male" || gender == "laki-laki";
            rbFemale.Checked = gender == "female" || gender == "perempuan";

            // ===== LOAD PHOTO =====
            string photoFile = row["photo"]?.ToString();

            if (!string.IsNullOrWhiteSpace(photoFile))
            {
                string photoPath = PhotoHelper.GetPhotoPath(photoFile);

                if (File.Exists(photoPath))
                {
                    picProfile.Image?.Dispose();
                    picProfile.Image = Image.FromFile(photoPath);
                }
            }


        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!ctrl.ValidateEditProfile(
                txtBirthPlace.Text,
                txtNationality.Text,
                txtAddress.Text,
                txtPhone.Text,
                cbEducation.Text,
                rbMale.Checked,
                rbFemale.Checked,
                out string error))
            {
                MessageBox.Show(error);
                return;
            }

            string genderValue = rbMale.Checked ? "Male" : "Female";

            bool success = ctrl.UpdatePersonalData(
                employeeId,
                txtBirthPlace.Text,
                dtBirthDate.Value.Date,
                genderValue,
                txtNationality.Text,
                txtAddress.Text,
                txtPhone.Text,
                cbEducation.Text
            );

            if (!success)
            {
                MessageBox.Show("Failed to update profile");
                return;
            }

            // ===== SAVE PHOTO =====
            if (!string.IsNullOrEmpty(selectedPhotoPath))
            {
                string fileName = SaveProfilePhoto(selectedPhotoPath);
                ctrl.UpdateProfilePhoto(employeeId, fileName);
            }


            MessageBox.Show("Profile updated successfully");
            UserProfile profile = new UserProfile(Session.CurrentUser.EmployeeId);
            profile.StartPosition = FormStartPosition.Manual;
            profile.Location = this.Location;
            profile.Show();
            this.Hide();


        }


        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png",
                Title = "Select Profile Photo"
            };

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            if (!ctrl.ValidateProfilePhoto(dlg.FileName, out string error))
            {
                MessageBox.Show(error);
                return;
            }

            selectedPhotoPath = dlg.FileName;

            picProfile.Image?.Dispose();
            picProfile.Image = Image.FromFile(selectedPhotoPath);
        }


        private string SaveProfilePhoto(string sourcePath)
        {
            string fileName = $"user_{employeeId}_{DateTime.Now.Ticks}.jpg";
            string destPath = PhotoHelper.GetPhotoPath(fileName);

            File.Copy(sourcePath, destPath, true);
            return fileName;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                   "Are you sure you want to clear all input fields?",
                   "Confirm Clear",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
               );

            if (result != DialogResult.Yes)
                return;

            // ===== CLEAR TEXT INPUTS =====
            txtBirthPlace.Clear();
            txtNationality.Clear();
            txtAddress.Clear();
            txtPhone.Clear();

            // ===== RESET DATE =====
            dtBirthDate.Value = DateTime.Today;

            // ===== RESET GENDER =====
            rbMale.Checked = false;
            rbFemale.Checked = false;

            // ===== RESET EDUCATION =====
            cbEducation.SelectedIndex = -1;
            cbEducation.Text = string.Empty;

            // ===== RESET PHOTO =====
            selectedPhotoPath = string.Empty;

            if (picProfile.Image != null)
            {
                picProfile.Image.Dispose();
                picProfile.Image = null;
            }

            MessageBox.Show(
                "All input fields have been cleared.",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
