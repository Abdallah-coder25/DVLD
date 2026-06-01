using clsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Issuanse_Project
{
    public partial class RenewLicenseApplication : Form
    {

        int LicenseID;
        int DriverID;
        int RenewLicenseID = 0;
        clsBLLicense License;
        clsBLApplication Application;
        clsBLApllicationType ApplicationType;
        clsBLPeople person;
        clsBLUser user;
        clsBLLicenseClasses LicenseClass;
        string currentImagePath;
        clsBLLicense RenewLicense;


        public RenewLicenseApplication()
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

        private void ResetControll()
        {
            tbNotes.Enabled = false;
            textBox1.Clear();
            lbClass.Text = "";
            lbLicenseID.Text = "";
            lbIssueDate.Text = "";
            lbExpirationDateLicense.Text = "";
            lbIsActive.Text = "";
            lbDriverID.Text = "";
            lbIssueReason.Text = "";
            lbLocalLicenseID.Text = "";
            lbNote.Text = "";
            lbLicenseFees.Text = "";
            lbTotalFees.Text = "";
            lbapplicationDate.Text = "";
            lbIssueDateApp.Text = "";
            lbNameOfCreatedUser.Text = "";
            lbAppFees.Text = "";
            lbExpDateApp.Text = "";
            lbName.Text = "";
            lbNational.Text = "";
            lbGender.Text = "";
            lbDateOfBirth.Text = "";
            lbDetain.Text = "";
            pbImage.Image = Properties.Resources.Male_512;
            btnRenew.Enabled = false;
            lkbLicenseHistory.Enabled = false;
            lkbNewLicenseInfo.Enabled = false;
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
            lbIssueDate.Text = License.IssueDate.ToShortDateString();
            lbExpirationDateLicense.Text = License.ExpirationDate.ToShortDateString();
            lbIsActive.Text = License.IsActive ? "Yes" : "No";
            lbDriverID.Text = DriverID.ToString();
            lbIssueReason.Text = GetIssueReasonText(License.issueReason);
            lbLocalLicenseID.Text = License.LicenseID.ToString();
            lbNote.Text = License.Note == "" ? "nothing" : License.Note;
            lbLicenseFees.Text = License.PaidFees.ToString();
            lbTotalFees.Text = (License.PaidFees + Application.paidFees).ToString();
            lbDetain.Text = clsBLDetainedLicenses.TheLicenseIsReserved(License.LicenseID) ? "Yes" : "NO";
        }
        private void InfoApplication()
        {
            lbapplicationDate.Text = Application.appDate.ToString();
            lbIssueDateApp.Text = Application.appDate.ToShortDateString();
            lbNameOfCreatedUser.Text = user.username;
            lbAppFees.Text = Application.paidFees.ToString();
            lbExpDateApp.Text = Application.lastStatusDate.ToShortDateString();
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

            ApplicationType = clsBLApllicationType.GetInformation((int)clsBLApllicationType.ApplicationType.RenewLocalDrivingLicense);
            if (ApplicationType == null)
            {
                MessageBox.Show("Error In ApplicationType Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application = clsBLApplication.infoApplication(License.AppID);
            if (Application == null)
            {
                MessageBox.Show("Error In Application Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            user = clsBLUser.GetUser(Application.usercreated);
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
        private void LoadData()
        {
            RemplaceData();
            InfoLicense();
            InfoApplication();
            InFoPerson();
            btnRenew.Enabled = true;
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
            LoadData();
            lkbLicenseHistory.Enabled = true;
            if (!clsBLLicense.IsLicenseExpired(LicenseID))
            {
                MessageBox.Show("The license is still valid and cannot be renewed yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetControll();
                return;
            }
            LoadData();
            lkbLicenseHistory.Enabled = true;
        }

        private void AfterRenew()
        {
            RenewLicense = clsBLLicense.GetInfoLicenseByLicenseID(RenewLicenseID);
            Application = clsBLApplication.infoApplication(RenewLicense.AppID);
            lbRenewLicenseID.Text = RenewLicense.LicenseID.ToString();
            lbRenewApplicationID.Text = RenewLicense.AppID.ToString();
            lbIssueReason.Text = GetIssueReasonText(RenewLicense.issueReason);
            btnRenew.Enabled = false;
            lkbNewLicenseInfo.Enabled = true;
            bool updated = clsBLLicense.ConvertLicenseToInactive(LicenseID);
            if (updated)
            {
                License.IsActive = false;
            }
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            if(LicenseID > 0)
            {
                int NewApplicationID = clsBLApplication.AddApplication(person.id, DateTime.Now, (int)clsBLApllicationType.ApplicationType.RenewLocalDrivingLicense, (int)clsBLApplication.appStatus.New, DateTime.Now, ApplicationType.fees, clsCurrentUser.currentuser.userid);
                int LastDate = LicenseClass.DefaulValidityLength;
                decimal TotalFees = License.PaidFees + Application.paidFees;
                bool isActive = true;
                int IssueReason = (int)clsBLLicense.IsssueReasson.RenewLicense;


                RenewLicenseID = clsBLLicense.AddNewLicense(NewApplicationID, License.DriverID, License.LicenseClassID, DateTime.Now, DateTime.Now.AddYears(LastDate), TotalFees, isActive, IssueReason, clsCurrentUser.currentuser.userid, tbNotes.Text);
                if(RenewLicenseID > 0)
                {
                    MessageBox.Show("License renewed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AfterRenew();
                }
                else
                {
                    MessageBox.Show("Failed to renew the license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetControll();
                }
            }
            else
            {
                MessageBox.Show("Please search for a valid license before attempting to renew.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetControll();
            }
        }

        private void lkbNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DriverLicenseInfo info = new DriverLicenseInfo(RenewLicense.LicenseID);
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
