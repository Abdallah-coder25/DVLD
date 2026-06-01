using clsBusinessLayer;
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
using System.Xml.Linq;

namespace Driving_License_Issuanse_Project
{
    public partial class ctrLocalDrivingLicense : UserControl
    {
        clsBLPeople _Person;
        bool isNextPressed = false;
        string currentImagePath = "";
        public ctrLocalDrivingLicense()
        {
            InitializeComponent();
        }
        private void _FillClassLicense()
        {
            DataTable dt = clsBLLicenseClasses.LicenseClasses();
            cbType.DisplayMember = "ClassName";
            cbType.ValueMember = "LicenseClassID";
            cbType.DataSource = dt;
            cbType.SelectedIndex = 0;
            cbSearch.SelectedIndex = 0;
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
            lbCreate.Text = clsCurrentUser.currentuser.username;
            lbDate.Text = DateTime.Now.ToString();
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
            isNextPressed = true;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!isNextPressed)
            {
                return;
            }
            btnSave.Enabled = true;
            tabControl1.SelectedTab = tbApplicationInfo;
        }
        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset();
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
        private void pbPerson_Click(object sender, EventArgs e)
        {
            ModeOfPerosn mode = new ModeOfPerosn(-1);
            mode.ShowDialog();
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
            //if (cbSearch.SelectedIndex == 1) // National
            //{
            //    int national = clsBLPeople.NationalUsed(txFilter.Text);

            //    _Person = clsBLPeople.IsPersonFound(national);
            //}
            //else if (cbSearch.SelectedIndex == 2) // ID
            //{
            //    if (int.TryParse(txFilter.Text, out int id))
            //        _Person = clsBLPeople.IsPersonFound(id);
            //}

            //if (_Person == null)
            //{
            //    MessageBox.Show("Person not found");
            //    RestForm();
            //    return;
            //}
        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tbApplicationInfo)
            {
                if (_Person == null)
                {
                    MessageBox.Show("You must select a person first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
            btnSave.Enabled = true;
        }
        private void ctrLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            _FillClassLicense();
        }
        private void Reset()
        {
            _Person = null;
            isNextPressed = false;
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
            txFilter.Text = "";
            lbID.Text = "???";
            lbDate.Text = "???";
            cbType.SelectedIndex = 0;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
        private int CreateApplication()
        {

            int appTypeID = (int)clsBLApllicationType.ApplicationType.NewLocalDrivingLicense;
            decimal fees = clsBLApllicationType.GetInformation(appTypeID).fees;
            DateTime dateDuringCreate = DateTime.Now;
            int appStatus = (int)clsBLApplication.appStatus.New;

            return clsBLApplication.AddApplication(
                _Person.id,
                dateDuringCreate,
                appTypeID,
                appStatus,
                dateDuringCreate,
                fees,
                clsCurrentUser.currentuser.userid);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int licenseClassID = Convert.ToInt32(cbType.SelectedValue);

            if (clsBLApplication.HasActiveApplication(_Person.id,licenseClassID))
            {
                 MessageBox.Show("This person already has a pre_application of this License Class");
                 return;
            }

            int appID = CreateApplication();
            if ( appID <= 0)
            {
                MessageBox.Show("Failed to create application");
                return;
            }

            if (clsBLLocalDrivingLicenseApplications.AddLocalDrivingLicenseApplication(appID, licenseClassID) > 0)
            {
                MessageBox.Show("Successfuly Added!", "Passed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbID.Text = appID.ToString();
                return;
            }
            else
            {
                MessageBox.Show("Failed Added!", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
