using clsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Issuanse_Project
{
    public partial class ctrFoundPerson : UserControl
    {
        int LicenseID = 0;
        clsBLLicense License;
        clsBLApplication Application;
        clsBLPeople _Person;

        string currentImagePath = "";
        public ctrFoundPerson()
        {
            InitializeComponent();
        }
        
        private bool _IsEmpty()
        {
            if (string.IsNullOrEmpty(txFilter.Text) || cbSearch.SelectedIndex == 0)
                return true;
            return false;
        }
        private bool _IsNumber(string sentence)
        {
            return sentence.All(char.IsDigit);
        }
        private void Reset()
        {
            _Person = null;
            lbInfoId.Text = "???";
            pbImage.Image = Properties.Resources.Male_512;
            lbInfoId.Text = "???";
            lbInfoCountry.Text = "???";
            lbInfoAddres.Text = "???";
            lbInfoDate.Text = "???";
            lbInfoEmail.Text = "???";
            lbInfoName.Text = "???";
            lbInfoPhone.Text = "???";
            lbInfoNational.Text = "???";
            lbInfoGender.Text = "???";
            txFilter.Text = "???";
        }

        private void InfoPerson()
        {
            if (_Person == null)
            {
                MessageBox.Show("Person not found");
                Reset();
                return;
            }
           
            lbInfoId.Text = _Person.id.ToString();
            lbInfoNational.Text = _Person.national;
            lbInfoName.Text = $"{_Person.firstname} {_Person.secondname}\n {_Person.lastname}";
            lbInfoDate.Text = _Person.dateofbirth.ToShortDateString();
            lbInfoGender.Text = (_Person.gender == 0) ? "Male" : "Female";
            lbInfoAddres.Text = _Person.adress;
            lbInfoPhone.Text = _Person.phone;
            lbInfoEmail.Text = _Person.email;
            lbInfoCountry.Text = clsBLPeople.GetCountryName(_Person.nationalcountry);
            if (!string.IsNullOrEmpty(_Person.imagePath) && File.Exists(_Person.imagePath))
            {
                pbImage.ImageLocation = _Person.imagePath;
                currentImagePath = _Person.imagePath;
            }
            else
            {
                currentImagePath = "";
                pbImage.Image = (_Person.gender == 0) ? Properties.Resources.Male_512 : Properties.Resources.Female_512;
            }
        }


        private void DisableSearch()
        {
            cbSearch.Enabled = false;
            txFilter.Enabled = false;
            pbSearch.Enabled = false;
            cbSearch.SelectedIndex = 2;
            txFilter.Text = _Person.id.ToString();
            
        }
        private void RemplaceInfo()
        {
            License = clsBLLicense.GetInfoLicenseByLicenseID(LicenseID);
            if (License == null)
            {
                MessageBox.Show("Local Driving License Application not found");
                return;
            }
            Application = clsBLApplication.infoApplication(License.AppID);
            if (Application == null)
            {
                MessageBox.Show("Application not found");
                return;
            }
            _Person = clsBLPeople.GetPersonByID(Application.appPersonId);
        }
        public void LoadPersonByLocalDrivingLicenseID(int LicenseID)
        {
            this.LicenseID = LicenseID;
            RemplaceInfo();
            InfoPerson();
            DisableSearch();
        }


        private void EnaableSearch()
        {
            cbSearch.Enabled = true;
            txFilter.Enabled = true;
            pbSearch.Enabled = true;
            cbSearch.SelectedIndex = 0;
        }
        public void OnlySearchInfoPerson()
        {
            EnaableSearch();
            
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            if (_IsEmpty())
            {
                MessageBox.Show("Please select a search method and enter a value to search");
                return;
            }

            _Person = null;

            if (cbSearch.SelectedIndex == 1)
            {
                int personID = clsBLPeople.GetPersonIdByNationalNumber(txFilter.Text);

                if (personID <= 0)
                {
                    MessageBox.Show("National not found.");
                    Reset();
                    return;
                }

                _Person = clsBLPeople.GetPersonByID(personID);
            }

            else if (cbSearch.SelectedIndex == 2)
            {
                if (!int.TryParse(txFilter.Text, out int personID))
                {
                    MessageBox.Show("Invalid ID.");
                    Reset();
                    return;
                }

                _Person = clsBLPeople.GetPersonByID(personID);
            }


            if (_Person == null)
            {
                MessageBox.Show("Person not found.");
                Reset();
                return;
            }

            InfoPerson();
        }
        private void pbPerson_Click(object sender, EventArgs e)
        {
            ModeOfPerosn mode = new ModeOfPerosn(-1);
            mode.ShowDialog();
        }

        private void txFilter_Validating(object sender, CancelEventArgs e)
        {
            if (cbSearch.SelectedIndex == 2)
            {
                if (!_IsNumber(txFilter.Text))
                {
                    errorProvider1.SetError(txFilter, "Please enter only number");
                    e.Cancel = true;
                }
                else
                    errorProvider1.SetError(txFilter, "");
            }
        }
    }
}
