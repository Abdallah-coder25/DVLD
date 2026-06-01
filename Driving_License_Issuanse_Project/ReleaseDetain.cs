using clsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Issuanse_Project
{
    public partial class ReleaseDetain : Form
    {
        int LicenseID;
        int DriverID;
        int Newapplication = 0;
        clsBLDetainedLicenses DetainLicense;
        clsBLLicense License;
        clsBLApplication Application;
        clsBLApllicationType ApplicationType;
        clsBLPeople person;
        clsBLUser user;
        clsBLLicenseClasses LicenseClass;
        string currentImagePath;
        public ReleaseDetain()
        {
            InitializeComponent();
        }

        private bool TextBoxIsEmpty()
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please fill in the required field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
                return false;
        }
        private void textBox1_Validating_1(object sender, CancelEventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int result))
                errorProvider1.SetError(textBox1, "");
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Please enter a valid number");
            }
        }
        private void RemplaceData()
        {
            License = clsBLLicense.GetInfoLicenseByLicenseID(LicenseID);
            if (License == null)
            {
                MessageBox.Show("Error In License Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LicenseClass = clsBLLicenseClasses.GetInfoLiceneClassByID(License.LicenseClassID);
            if (LicenseClass == null)
            {
                MessageBox.Show("Error In LicenseClass Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ApplicationType = clsBLApllicationType.GetInformation((int)clsBLApllicationType.ApplicationType.ReleaseDetainedDrivingLicense);
            if (ApplicationType == null)
            {
                MessageBox.Show("Error In Application Type Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application = clsBLApplication.infoApplication(License.AppID);
            if (Application == null)
            {
                MessageBox.Show("Error In Application Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            user = clsBLUser.GetUser(License.CreatingUser);
            if (user == null)
            {
                MessageBox.Show("Error In User Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            person = clsBLPeople.GetPersonByID(Application.appPersonId);
            if (person == null)
            {
                MessageBox.Show("Error In Person Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DriverID = clsBLDrivers.GetDrivierIdByPersonID(person.id);
        }

        private string GetIssueReasonText(clsBLLicense.IsssueReasson reason)
        {
            switch (reason)
            {
                case clsBLLicense.IsssueReasson.FirstTime:
                    return "First Time";
                case clsBLLicense.IsssueReasson.RenewLicense:
                    return "Renew License";
                case clsBLLicense.IsssueReasson.ReplacmentOfdameged:
                    return "Replacement of Damaged";
                case clsBLLicense.IsssueReasson.ReplacmentForLost:
                    return "Replacement for Lost";
                default:
                    return "Unknown Reason";
            }
        }
        private void InfoLicense()
        {
            lbClass.Text = LicenseClass.licneseName;
            lbLicenseID.Text = License.LicenseID.ToString();
            lbIssueDate.Text = License.IssueDate.ToString();
            lbExpirationDateLicense.Text = License.ExpirationDate.ToString();
            lbIsActive.Text = License.IsActive ? "Yes" : "No";
            lbDriverID.Text = DriverID.ToString();
            lbIssueReason.Text = GetIssueReasonText(License.issueReason);
            lbNote.Text = License.Note == "" ? "nothing" : License.Note;
            lbDetain.Text = clsBLDetainedLicenses.TheLicenseIsReserved(License.LicenseID) ? "Yes" : "NO";
        }
        private void InFoPerson()
        {
            lbName.Text = $"{person.firstname} {person.secondname} {person.lastname}";
            lbNational.Text = person.national;
            lbGender.Text = person.gender == 0 ? "Male" : "female";
            lbDateOfBirth.Text = person.dateofbirth.ToString();
            if (!string.IsNullOrEmpty(person.imagePath) && File.Exists(person.imagePath))
            {
                pbImage.ImageLocation = person.imagePath;
                currentImagePath = person.imagePath;
            }
            else
            {
                currentImagePath = "";
                pbImage.Image = (person.gender == 0) ? Properties.Resources.Male_512 : Properties.Resources.Female_512;
            }
        }
        private void InfoDetain()
        {
            //if(LicenseID > 0)
            lbDetainID.Text = DetainLicense.DetainID.ToString();
            lbDetainDate.Text = DetainLicense.DetainDate.ToString();
            lbLicenseIDInDetain.Text = License.LicenseID.ToString();
            lbNameOfCreatedUser.Text = user.username;
            lbAppFees.Text = ApplicationType.fees.ToString();
            lbFineFees.Text = DetainLicense.FineFees.ToString();
            lbTotalFees.Text = (DetainLicense.FineFees + ApplicationType.fees).ToString();
        }

        private void LoadData()
        {
            RemplaceData();
            DetainLicense = clsBLDetainedLicenses.GetInfoDetainLicenseByLicenseID(LicenseID);
            if (DetainLicense == null)
                return;
            InfoLicense();
            InfoDetain();
            InFoPerson();

        }
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (TextBoxIsEmpty())
                return;

            LicenseID = int.Parse(textBox1.Text);
            if (!clsBLLicense.FoundLicenseByLicenseID(LicenseID))
            {
                MessageBox.Show("Invalid License ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetControll();
                return;
            }
            if (clsBLDetainedLicenses.TheLicenseIsReserved(LicenseID))
            {
                LoadData();
                lkbLicenseHistory.Enabled = true;
                btnRelease.Enabled = true;
            }
            else
            {
                MessageBox.Show("The license is not detained.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRelease.Enabled = false;
                lkbNewLicenseInfo.Enabled = false;
            }
        }

        private void ResetControll()
        {
            textBox1.Clear();
            lbClass.Text = "";
            lbLicenseID.Text = "";
            lbIssueDate.Text = "";
            lbExpirationDateLicense.Text = "";
            lbIsActive.Text = "";
            lbDriverID.Text = "";
            lbIssueReason.Text = "";
            lbNote.Text = "";
            lbDetainDate.Text = "";
            lbNameOfCreatedUser.Text = "";
            lbName.Text = "";
            lbNational.Text = "";
            lbGender.Text = "";
            lbDateOfBirth.Text = "";
            lbLicenseIDInDetain.Text = "";
            pbImage.Image = Properties.Resources.Male_512;
            lkbLicenseHistory.Enabled = false;
            lkbNewLicenseInfo.Enabled = false;
            btnRelease.Enabled = false;
        }

        private void UpdateUISate()
        {
            gbFilter.Enabled = false;
            lkbLicenseHistory.Enabled = true;
            btnRelease.Enabled = true;
        }
        public void SendLicenseID(int id)
        {
            textBox1.Text = id.ToString();
            LicenseID = id;

            bool found = clsBLLicense.FoundLicenseByLicenseID(LicenseID);

            if (found)
            {
                LoadData();
                UpdateUISate();
            }
            else
                return;
        }

        private void AfterReleasedDetain()
        {
            Application = clsBLApplication.infoApplication(Newapplication);
           // LoadData();
            btnRelease.Enabled = false;
            lkbNewLicenseInfo.Enabled = true;
            lbDetain.Text = DetainLicense.IsReleased ? "Yes" : "No";
            lbAppID.Text = Application.AppID.ToString();
        }
        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (LicenseID > 0)
            {
                int status = (int)clsBLApplication.appStatus.New;
                int userid = clsCurrentUser.currentuser.userid;
                int AppTypeID = (int)clsBLApllicationType.ApplicationType.ReleaseDetainedDrivingLicense;

                Newapplication = clsBLApplication.AddApplication(person.id, DateTime.Now, AppTypeID, status, DateTime.Now, ApplicationType.fees, userid);
                bool Update = clsBLDetainedLicenses.ReleaseDetainedLicense(License.LicenseID ,userid, Newapplication);

                if (Update)
                {
                    MessageBox.Show("License released successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AfterReleasedDetain();
                }
                else
                {
                    MessageBox.Show("Failed to release the license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetControll();
                }
            }
            else
            {
                MessageBox.Show("Please search for a valid license before attempting to Detain.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetControll();
            }
        }

        private void lkbNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DriverLicenseInfo info = new DriverLicenseInfo(DetainLicense.LicenseID);
            info.ShowDialog();
        }
        private void lkbLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory historyForm = new LicenseHistory(LicenseID);
            historyForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }

}
