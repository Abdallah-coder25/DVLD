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
    public partial class ReplacmentForDamagedLicense : Form
    {
        int LicenseID;
        int DriverID;
        int ReplacmentId = 0;
        clsBLLicense License;
        clsBLApplication Application;
        clsBLApllicationType ApplicationType;
        clsBLPeople person;
        clsBLUser user;
        clsBLLicenseClasses LicenseClass;
        string currentImagePath;
        clsBLLicense Replacment;

        public ReplacmentForDamagedLicense()
        {
            InitializeComponent();
        }

        private int SelectTypeApplication()
        {
            int appTypeID = 0;

            if (rbDamaged.Checked)
                appTypeID = (int)clsBLApllicationType.ApplicationType.ReplacementForDamagedDrivingLicense;

            else if (rbLost.Checked)
                appTypeID = (int)clsBLApllicationType.ApplicationType.ReplacementForLostDrivingLicense;

            return appTypeID;
        }
        private int SelectIssueReason()
        {
            int reason = 0;
            if (rbDamaged.Checked)
                reason = (int)clsBLLicense.IsssueReasson.ReplacmentOfdameged;
            else if (rbLost.Checked)
                reason = (int)clsBLLicense.IsssueReasson.ReplacmentForLost;

            return reason;
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
        private void textBox1_Validating(object sender, CancelEventArgs e)
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
            btnReplacment.Enabled = false;
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
            lbapplicationDate.Text = "";
            lbNameOfCreatedUser.Text = "";
            lbAppFees.Text = "";
            lbName.Text = "";
            lbNational.Text = "";
            lbGender.Text = "";
            lbDateOfBirth.Text = "";
            pbImage.Image = Properties.Resources.Male_512;
            lkbLicenseHistory.Enabled = false;
            lkbNewLicenseInfo.Enabled = false;
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
         
            //ApplicationType = clsBLApllicationType.GetInformation((int)ApplicationType.ApplicationType.);
            //if (ApplicationType == null)
            //{
            //    MessageBox.Show("Error In ApplicationType Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

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
            lbLocalLicenseID.Text = License.LicenseID.ToString();
            lbNote.Text = License.Note == "" ? "nothing" : License.Note;
            lbDetain.Text = clsBLDetainedLicenses.TheLicenseIsReserved(License.LicenseID) ? "Yes" : "NO";
        }
        private void InfoApplication()
        {
            lbapplicationDate.Text = Application.appDate.ToShortDateString();
            lbNameOfCreatedUser.Text = user.username;
            lbAppFees.Text = Application.paidFees.ToString();
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
        private void LoadData()
        {
            RemplaceData();
            InfoLicense();
            InfoApplication();
            InFoPerson();
            btnReplacment.Enabled = true;
        }

        private void lkbLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory historyForm = new LicenseHistory(LicenseID);
            historyForm.ShowDialog();
        }
        private void lkbNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DriverLicenseInfo info = new DriverLicenseInfo(Replacment.LicenseID);
            info.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
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
            if (!clsBLLicense.LicenseIsActive(LicenseID))
            {
                MessageBox.Show("The license is not active and there fore cannot be replaced yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetControll();
                return;
            }
            LoadData();
            lkbLicenseHistory.Enabled = true;
            gbSelected.Enabled = true;
        }

        private bool IsDamagedOrLost()
        {
            if (rbDamaged.Checked || rbLost.Checked)
                return true;
            else
            {
                MessageBox.Show("Please select the reason for renewal (Damaged or Lost).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void AfterRenew()
        {
            Replacment = clsBLLicense.GetInfoLicenseByLicenseID(ReplacmentId);
            Application = clsBLApplication.infoApplication(Replacment.AppID);
            lbRenewLicenseID.Text = Replacment.LicenseID.ToString();
            lbRenewApplicationID.Text = Replacment.AppID.ToString();
            lbIssueReason.Text = GetIssueReasonText(Replacment.issueReason);
            btnReplacment.Enabled = false;
            lkbNewLicenseInfo.Enabled = true;
            bool updated = clsBLLicense.ConvertLicenseToInactive(LicenseID);
            if (updated)
            {
                License.IsActive = false;
            }
        }
        private void btnReplacment_Click_1(object sender, EventArgs e)
        {

            if (!IsDamagedOrLost())
                return;

            if (LicenseID > 0)
            {
                int TypeID = SelectTypeApplication();
                ApplicationType = clsBLApllicationType.GetInformation(TypeID);
                int NewApplicationID = clsBLApplication.AddApplication(person.id, DateTime.Now, TypeID, (int)clsBLApplication.appStatus.New, DateTime.Now, ApplicationType.fees, clsCurrentUser.currentuser.userid);
                decimal PaidFees =  ApplicationType.fees;
                bool isActive = true;
                int IssueReason = SelectIssueReason();

                ReplacmentId = clsBLLicense.AddNewLicense(NewApplicationID, License.DriverID, License.LicenseClassID, DateTime.Now, License.ExpirationDate, PaidFees, isActive, IssueReason, clsCurrentUser.currentuser.userid, tbNotes.Text);
                if (ReplacmentId > 0)
                {
                    MessageBox.Show("License replaced successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AfterRenew();
                }
                else
                {
                    MessageBox.Show("Failed to replace the license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetControll();
                }
            }
            else
            {
                MessageBox.Show("Please search for a valid license before attempting to replace.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetControll();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
