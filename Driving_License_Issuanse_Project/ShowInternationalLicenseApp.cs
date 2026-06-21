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
using static clsBusinessLayer.clsBLApllicationType;

namespace Driving_License_Issuanse_Project
{
    public partial class ShowInternationalLicenseApp : Form
    {
        int LicenseID;
        int DriverID;
        int InternationalLicenseID = 0;
        clsBLLicense License;
        clsBLApplication Application;
        clsBLPeople person;
        clsBLUser user;
        clsBLLicenseClasses LicenseClass;
        string currentImagePath;
        public ShowInternationalLicenseApp()
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
            lbIssueDate.Text = License.IssueDate.ToShortDateString();
            lbExpirationDate.Text = License.ExpirationDate.ToShortDateString();
            lbIsActive.Text = License.IsActive ? "Yes" : "No";
            lbDriverID.Text =DriverID.ToString();
            lbIssueReason.Text = GetIssueReasonText(License.issueReason);
            lbLocalLicenseID.Text = License.LicenseID.ToString();
            lbNote.Text = License.Note == "" ? "nothing" : License.Note;
            lbDetain.Text = clsBLDetainedLicenses.TheLicenseIsReserved(License.LicenseID) ? "Yes" : "NO";
        }
        private void InfoApplication()
        {
            lbapplicationDate.Text = Application.appDate.ToString();
            lbNameOfCreatedUser.Text = user.username;
            lbFees.Text = Application.paidFees.ToString();
            lbIssueDateApp.Text = Application.appDate.ToShortDateString();
        }
        private void InFoPerson()
        {
            lbName.Text = $"{person.firstname} {person.secondname} {person.lastname}";
            lbNational.Text = person.national;
            lbGender.Text = person.gender == 0 ? "Male" : "female";
            lbDateOfBirth.Text = person.dateofbirth.ToShortDateString();
            lbFees.Text = Application.paidFees.ToString();
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
            btnIssue.Enabled = true;
        }
        private void ResetControl()
        {
            lbClass.Text = "";
            lbLicenseID.Text = "";
            textBox1.Clear();
            lbIssueDate.Text = "";
            lbExpirationDate.Text = "";
            lbIsActive.Text = "";
            lbDriverID.Text = "";
            lbIssueReason.Text = "";
            lbLocalLicenseID.Text = "";
            lbNote.Text = "";
            lbapplicationDate.Text = "";
            lbNameOfCreatedUser.Text = "";
            lbFees.Text = "";
            lbIssueDateApp.Text = "";
            lbName.Text = "";
            lbNational.Text = "";
            lbGender.Text = "";
            lbDateOfBirth.Text = "";
            pbImage.Image = Properties.Resources.Male_512;
            lkbLicenseHistory.Enabled = false;
            lkbLicenseInfo.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(TextBoxIsEmpty())
                return;

            LicenseID = int.Parse(textBox1.Text);
            if (!clsBLLicense.FoundLicenseByLicenseID(LicenseID))
            {
                MessageBox.Show("Invalid License ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetControl();
                return;
            }
            if (clsBLInternationalLiceneses.hasInternationalLicense(LicenseID))
            {
                MessageBox.Show("An international license has already been issued and is active for this local license .", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetControl();
                return;
            }
            LoadData();
            if (LicenseClass.LicenceClasseID != (int)clsBLLicenseClasses.ClassName.OrdinarDriving)
            {
                MessageBox.Show("International licenses can only be issued for ordinary driving licenses. Please ensure the local license is of the ordinary driving class before issuing an international license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetControl();
                return;
            }
            lkbLicenseHistory.Enabled = true;
        }

        private void EnableControl()
        {
            lkbLicenseHistory.Enabled = true;
            lkbLicenseInfo.Enabled = true;
            btnIssue.Enabled = false;
        }
        private void AfterIssue()
        {
            clsBLInternationalLiceneses InterLicense = clsBLInternationalLiceneses.GetInfoInternationalLicense(InternationalLicenseID);
            lbInternationalLicenseID.Text = InterLicense.InternationalLicenseID.ToString();
            lbExpDataInternational.Text = InterLicense.ExpirationDate.ToShortDateString();
            lbInternationalApplicationID.Text = InterLicense.AppID.ToString();
            //btnIssue.Enabled = false;
            EnableControl();
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (LicenseID  > -1)
            {
                if (clsBLLicense.IsLicenseActiveAndNotExpired(LicenseID))
                {
                    clsBLApllicationType AppType = clsBLApllicationType.GetInformation((int)clsBLApllicationType.ApplicationType.NewInternationalLicense);
                    int NewApplicationID = clsBLApplication.AddApplication(person.id, DateTime.Now, (int)AppType.applicationTypeid, (int)clsBLApplication.appStatus.New, DateTime.Now, AppType.fees, clsCurrentUser.currentuser.userid);
                    bool IsActive = true;
                    InternationalLicenseID = clsBLInternationalLiceneses.AddIternationalLicense(NewApplicationID, DriverID, LicenseID, DateTime.Now, DateTime.Now.AddYears(1), IsActive, clsCurrentUser.currentuser.userid);
                    if (InternationalLicenseID > 0)
                    {
                        MessageBox.Show("International License Issued Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AfterIssue();
                    }
                    else
                    {
                        MessageBox.Show("Error In Issuing International License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetControl();
                    }
                }
                else
                {
                    MessageBox.Show("The local license is either inactive or expired. Please ensure the local license is active and not expired before issuing an international license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetControl();
                }
                }
            else
            {
                MessageBox.Show("Please search for a valid local license before issuing an international license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lkbLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
            LicenseHistory historyForm = new LicenseHistory(LicenseID);
            historyForm.ShowDialog();
        }
        private void lkbLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InternationalLicenseInfo view = new InternationalLicenseInfo(InternationalLicenseID);
            view.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
