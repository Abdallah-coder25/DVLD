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
    public partial class ctrDriverLicenseInfo : UserControl
    {
        int LicenseID = 0;
        clsBLLicense License;
        clsBLPeople person;
        clsBLApplication Application;
        clsBLLicenseClasses LicenseClass;
        clsBLDetainedLicenses DetainLicense;
        string currentImagePath;
        public ctrDriverLicenseInfo()
        {
            InitializeComponent();
        }
        private  void FillData()
        {
            License = clsBLLicense.GetInfoLicenseByLicenseID(LicenseID);
            if( License == null )
            {
                MessageBox.Show("No data found for the given License ID.");
                return;
            }
            Application = clsBLApplication.infoApplication(License.AppID);
            if (Application == null)
            {
                 MessageBox.Show("No data found for the given Application ID.");
                 return;
            }

            LicenseClass = clsBLLicenseClasses.GetInfoLiceneClassByID(License.LicenseClassID);
            if (LicenseClass == null)
            {
                MessageBox.Show("No data found for the given License Class ID.");
                return;
            }

            person = clsBLPeople.GetPersonByID(Application.appPersonId);
            if(person == null)
            {
                MessageBox.Show("No data found for the given Person ID.");
                return;
            }
            int DriverID = clsBLDrivers.GetDrivierIdByPersonID(person.id);
            if(DriverID <= 0)
            {
                MessageBox.Show("No driver found for the given Person ID.");
                return;
            }

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
        private void DriverLicenseIndo()
        {
            lbClassName.Text = LicenseClass.licneseName;
            lbName.Text = $"{person.firstname} {person.secondname} {person.lastname}";
            lbLicenseID.Text = License.LicenseID.ToString();
            lbNationalNo.Text = person.national;
            lbGender.Text = person.gender == 0 ? "Male" : "Female";
            lbIssueDate.Text = License.IssueDate.ToShortDateString();
            lbIssueReason.Text = GetIssueReasonText(License.issueReason);
            lbNotes.Text = string.IsNullOrEmpty(License.Note) ? "No Notes" : License.Note;
            lbActive.Text = License.IsActive ? "Yes" : "No";
            lbDateOfBirth.Text = person.dateofbirth.ToShortDateString();
            lbDriverID.Text = License.DriverID.ToString();
            lbExpirationDate.Text = License.ExpirationDate.ToShortDateString();
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
            lbDetained.Text = clsBLDetainedLicenses.TheLicenseIsReserved(License.LicenseID) ? "Yes" : "NO";
        }
        private void RemplaceData()
        {
            FillData();
            DriverLicenseIndo();
        }
        public void LoadData(int id)
        {
            LicenseID = id;
            RemplaceData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}
