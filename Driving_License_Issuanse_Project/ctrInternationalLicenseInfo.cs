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
    public partial class ctrInternationalLicenseInfo : UserControl
    {
        int IntLicenseID = 0;
        clsBLInternationalLiceneses InterLicense;
        clsBLApplication Application;
        clsBLPeople person;
        string currentImagePath;
        public ctrInternationalLicenseInfo()
        {
            InitializeComponent();
        }
        private void InfoInternationalLicense()
        {
            lbLicenseID.Text = InterLicense.InternationalLicenseID.ToString();
            lbAppID.Text = Application.AppID.ToString();
            lbIssueDate.Text = InterLicense.IssueDate.ToShortDateString();
            lbExpirationDate.Text = InterLicense.ExpirationDate.ToShortDateString();
            lbDriverID.Text = InterLicense.DriverID.ToString();
            lbIsActive.Text = InterLicense.Active ? "Yes" : "No";
            lbGender.Text = person.gender == 0 ? "Male" : "female";
            lbNationalNo.Text = person.national;
            lbName.Text = $"{person.firstname}  {person.secondname} {person.lastname} ";
            lbDataOfBirth.Text = person.dateofbirth.ToShortDateString();
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
            InterLicense = clsBLInternationalLiceneses.GetInfoInternationalLicense(IntLicenseID);
            if(InterLicense == null)
            {
                MessageBox.Show("No se encontro la licencia internacional");
                return;
            }
            Application = clsBLApplication.infoApplication(InterLicense.AppID);
            if(Application == null)
            {
                MessageBox.Show("No se encontro la solicitud");
                return;
            }
            person = clsBLPeople.GetPersonByID(Application.appPersonId);
            if(person == null)
            {
                MessageBox.Show("No se encontro la persona");
                return;
            }
        }
        public void LoadData(int id)
        {
            this.IntLicenseID = id;
            RemplaceData();
            InfoInternationalLicense();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}
