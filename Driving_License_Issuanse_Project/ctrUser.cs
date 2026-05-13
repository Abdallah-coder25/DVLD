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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Driving_License_Issuanse_Project
{
    public partial class ctrUser : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        clsBLPeople _Person;
        int _UserID = -1;
        clsBLUser _User;
        bool isNextPressed = false;
        string currentImagePath = "";
        public ctrUser()
        {
            InitializeComponent();
        }
        public int UserID
        {
            get { return _UserID; }
            set
            {
                _UserID = value;
                LoadUser();
            }
        }
        private void LoadUser()
        {
            if (_UserID == -1)
            {
                _Mode = enMode.AddNew;
                _User = new clsBLUser();
                _Person = new clsBLPeople();
                ModeAdd();
                return;
            }
            _Mode = enMode.Update;
            _User = clsBLUser.GetUser(_UserID);

            if (_User == null)
            {
                MessageBox.Show("User not found");
                return;
            }

            _Person = clsBLPeople.GetPersonByID(_User.personid);
            if (_Person == null)
            {
                MessageBox.Show("Associated person not found");
                return;
            }
            ModeUpdate();
            _FillInfoOfPerson();
            _FillInfoOfUser();
        }
        private void _FillInfoOfPerson()
        {
            if (cbSearch.SelectedIndex == 1) 
                txFilter.Text = _Person.national;
            else
                txFilter.Text = _Person.id.ToString();

            lbInfoId.Text = _Person.id.ToString();
            lbInfoNational.Text = _Person.national;
            lbInfoName.Text = $"{_Person.firstname} {_Person.secondname} \n{_Person.lastname}";
            lbInfoDate.Text = _Person.dateofbirth.ToShortDateString();
            lbInfoGender.Text = (_Person.gender == 0) ? "Male" : "Female";
            lbInfoAddres.Text = _Person.adress;
            lbInfoPhone.Text = _Person.phone;
            lbInfoEmail.Text = _Person.email;
            lbInfoDate.Text = _Person.dateofbirth.ToShortDateString();
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
        private void _FillInfoOfUser()
        {
            txName.Text = _User.username;
            txPassword.Text = _User.password;
            checkBox1.Checked = _User.isactive;
        }
        private void ModeAdd()
        {
            lbTitle.Text = "Add New User";
            cbSearch.Enabled = true;
            cbSearch.SelectedIndex = 0;
            txFilter.Enabled = true;
            lkbEdit.Enabled = false;

        }
        private void ModeUpdate()
        {
            lbTitle.Text = "Update User";
            cbSearch.Enabled = false;
            cbSearch.SelectedIndex = 2;
            txFilter.Enabled = false;
            btnNext.Enabled = true;
            lkbEdit.Enabled = true;
        }
        private string HandleImage()
        {
            if (_Person == null)
                return "";

            // Add
            if (_Mode == enMode.AddNew)
            {
                if (!string.IsNullOrEmpty(currentImagePath))
                    return clsImageManager.SaveImage(currentImagePath);
                else
                    return "";
            }

            // Update
            if (_Mode == enMode.Update)
            {
                if (currentImagePath != _Person.imagePath)
                    return clsImageManager.UpdateImage(_Person.imagePath, currentImagePath);
                else
                    return _Person.imagePath;
            }

            return "";
        }
        private bool _ComparePassword()
        {
            if (txPassword.Text != txConfirm.Text)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool _IsEmpty()
        {
            if (string.IsNullOrWhiteSpace(txName.Text) || string.IsNullOrWhiteSpace(txPassword.Text) || string.IsNullOrWhiteSpace(txConfirm.Text))
            {
                MessageBox.Show("Please fill all required fields..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
        private void Reset()
        {
            _Person = null;
            lbInfoId.Text = "???";
            pbImage.Image = Properties.Resources.Male_512;
            lbInfo.Text = "???";
            lbInfoCountry.Text = "???";
            lbInfoAddres.Text = "???";
            lbInfoDate.Text = "???";
            lbInfoEmail.Text = "???";
            lbInfoName.Text = "???";
            lbInfoPhone.Text = "???";
            lbInfoNational.Text = "???";
            lbInfoGender.Text = "???";
            txFilter.Text = "";
            cbSearch.SelectedIndex = 0;
            txName.Text = "";
            txPassword.Text = "";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.AddNew)
                Reset();
            else
            {
                txName.Text = "";
                txPassword.Text = "";
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Person == null )
            {
                MessageBox.Show("Please search and select a person first.", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                isNextPressed = false;
                return;
            }
            if (_Mode == enMode.AddNew && clsBLUser.IsPeopleIsUser(_Person.id))
            {

                MessageBox.Show("This person is already a user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            isNextPressed = true;
            tbPrincipal.SelectedTab = tpLogin;
            txName.Focus();
        }

        private void SaveUpdatephoto(string imagePath)
        {
            if (_Person == null) return;

            if (imagePath != _Person.imagePath)
                clsBLPeople.UpdateImage(_Person.id, imagePath);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_IsEmpty() || !_ComparePassword() || !ValidateChildren())
                return;


            bool isActive = checkBox1.Checked;
            string imagePath = HandleImage();

            if (_Mode == enMode.AddNew)
            {

                if (clsBLUser.Add(_Person.id, txName.Text, txPassword.Text, isActive))
                {
                    SaveUpdatephoto(imagePath);
                    MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.FindForm().Close();
                }
                else
                    MessageBox.Show("Failed to add user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (clsBLUser.Update(_UserID, _Person.id, txName.Text, txPassword.Text, isActive))
                {
                    SaveUpdatephoto(imagePath);
                    MessageBox.Show("User updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.FindForm().Close();
                }
                else
                    MessageBox.Show("Failed to update user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbSearch_Click(object sender, EventArgs e)
        {
            if(cbSearch.SelectedIndex == 0 || string.IsNullOrWhiteSpace(txFilter.Text))
                return;

            if (_Mode == enMode.AddNew)
            {
                // 🔹 Search by National
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

                    if (_Person == null)
                    {
                        MessageBox.Show("Person not found.");
                        return;
                    }
                }
            }
                
            _FillInfoOfPerson();
             btnNext.Enabled = true;
        }

        private void pbAdd_Click(object sender, EventArgs e)
        {
            ModeOfPerosn add = new ModeOfPerosn(-1);
            add.ShowDialog();
        }

        private void tbPrincipal_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tpLogin)
            {
                if (!isNextPressed)
                {
                    MessageBox.Show("Click Next first.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void txName_Validating(object sender, CancelEventArgs e)
        {
            if (isNextPressed)
                return;
            if (string.IsNullOrWhiteSpace(txName.Text))
            {
                errorProvider1.SetError(txName, "Please enter a name");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txName, "");
        }

        private void txPassword_Validating(object sender, CancelEventArgs e)
        {
            if (isNextPressed)
                return;
            if (string.IsNullOrWhiteSpace(txPassword.Text))
            {
                errorProvider1.SetError(txPassword, "Please enter a password");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txPassword, "");
        }

        private void txConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (isNextPressed)
                return;
            if (string.IsNullOrWhiteSpace(txConfirm.Text))
            {
                errorProvider1.SetError(txConfirm, "Please confirm the password");
                e.Cancel = true;
            }
            else if (txPassword.Text != txConfirm.Text)
            {
                errorProvider1.SetError(txConfirm, "Passwords do not match");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txConfirm, "");
        }

        private void lkbEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = clsImageManager.SelectImage(pbImage);

            if (path != null)
                currentImagePath = path;
        }

        private void tbPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            isNextPressed = false;
        }
    }
}

