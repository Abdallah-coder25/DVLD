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
    public partial class DetainLicense : Form
    {
        int LicenseID;
        int DriverID;
        int DetainID = 0;
        Decimal FineFees = 0;
        clsBLLicense License;
        clsBLApplication Application;
        clsBLApllicationType ApplicationType;
        clsBLPeople person;
        clsBLUser user;
        clsBLLicenseClasses LicenseClass;
        string currentImagePath;
        clsBLDetainedLicenses Detain;
        public DetainLicense()
        {
            InitializeComponent();
        }
      
        private bool TextBoxIsEmpty(TextBox txt)
        {
            if (string.IsNullOrEmpty(txt.Text))
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
            btnDetain.Enabled = false;
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
        }
        private void InfoDetain()
        {
            lbLicenseIDInDetain.Text = License.LicenseID.ToString();
            lbNameOfCreatedUser.Text = user.username;
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
            InfoDetain();
            InFoPerson();
            btnDetain.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (TextBoxIsEmpty(textBox1))
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
            if (clsBLDetainedLicenses.TheLicenseIsReserved(LicenseID))
            {
                MessageBox.Show("The license is already detained and therefore cannot be detained.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDetain.Enabled = false;
                lkbNewLicenseInfo.Enabled = false;
                return;
            }
        }


        private void txFees_Validating(object sender, CancelEventArgs e)
        {
            if(Decimal.TryParse(txFees.Text,out FineFees))
                errorProvider1.SetError(txFees, "");
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(txFees, "Please enter a valid number");
            }
        }
        private void AfterDetain()
        {
            Detain = clsBLDetainedLicenses.GetInfoDetainLicense(DetainID);
            lbDetainID.Text = Detain.DetainID.ToString();
            lbDetainDate.Text = Detain.DetainDate.ToShortDateString();
            btnDetain.Enabled = false;
            gbFilter.Enabled = false;
            lkbNewLicenseInfo.Enabled = true;
        }
        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (TextBoxIsEmpty(txFees))
                return;

            if (LicenseID > 0)
            {
               
               DetainID = clsBLDetainedLicenses.AddDetain(LicenseID, DateTime.Now, FineFees, clsCurrentUser.currentuser.userid, false);

                if (DetainID > 0)
                {
                    MessageBox.Show("License Detain successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AfterDetain();
                }
                else
                {
                    MessageBox.Show("Failed to Detain the license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetControll();
                }
            }
            else
            {
                MessageBox.Show("Please search for a valid license before attempting to Detain.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetControll();
            }
        }


        private void lkbLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LicenseHistory historyForm = new LicenseHistory(LicenseID);
            historyForm.ShowDialog();
        }
        private void lkbNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DriverLicenseInfo info = new DriverLicenseInfo(Detain.LicenseID);
            info.ShowDialog();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
