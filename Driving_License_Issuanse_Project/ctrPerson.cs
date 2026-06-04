using clsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Issuanse_Project
{
    public partial class ctrPerson : UserControl
    {
        public ctrPerson()
        {
            InitializeComponent();
        }
        enum enMode { Add, Update };
        private enMode Mode;
        clsBLPeople People;
        int ID;
        // string currentImagePath = "";
        string currentImagePath = null;
        public int id
        {
            get { return ID; }
            set
            {
                ID = value;
                LoadData();
            }
        }
        private void GetCountries()
        {
            txFirstName.Focus();
            DataTable dt = clsBLPeople.GetCountries();
            cbCountry.DataSource = dt;
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
            dateTimePicker1.MaxDate = DateTime.Now.AddYears(-18);
        }
        private bool _IsMale()
        {
            if (People == null)
                return true;

            return People.gender == 0;
        }
        private void DefaultImage()
        {
            if (_IsMale())
                pbImagePerson.Image = Properties.Resources.Male_512;
            else
                pbImagePerson.Image = Properties.Resources.Female_512;
        }
        private void InfoPerson()
        {
            Mode = enMode.Update;
            lbTitle.Text = "Edit Person";
            People = clsBLPeople.GetPersonByID(ID);
            if (People == null)
            {
                MessageBox.Show("Person not found , or error in load data", "Error");
                return;
            }
            lbpersonid.Text = People.id.ToString();
            txFirstName.Text = People.firstname;
            txSecondName.Text = People.secondname;
            txThirdName.Text = People.thirdname;
            txLastName.Text = People.lastname;
            dateTimePicker1.Value = People.dateofbirth;
            txNational.Text = People.national;
            txPhone.Text = People.phone;
            txAddress.Text = People.adress;

            //if (_IsMale())
            //    rbMale.Checked = true;
            //else
            //    rbFemal.Checked = true;
            rbMale.Checked = _IsMale();
            rbFemal.Checked = !_IsMale();

            if (People.email != null)
                txEmail.Text = People.email;

            //if (!string.IsNullOrEmpty(People.imagePath) && File.Exists(People.imagePath))
            //{
            //    pbImagePerson.ImageLocation = People.imagePath;
            //    currentImagePath = People.imagePath;
            //    lkbRemove.Visible = true;
            //}
            //else
            //{
            //    lkbRemove.Visible = false;
            //    DefaultImage();
            //}
            if (!string.IsNullOrEmpty(People.imagePath) && File.Exists(People.imagePath))
            {
                using (Image img = Image.FromFile(People.imagePath))
                {
                    pbImagePerson.Image = new Bitmap(img);
                }

                currentImagePath = null; // لا يوجد تغيير بعد التحميل
                lkbRemove.Visible = true;
            }
            else
            {
                DefaultImage();
                lkbRemove.Visible = false;
            }
        }

        private void LoadData()
        {
            GetCountries();
            cbCountry.SelectedIndex = 0;
            if (ID == -1)
            {
                Mode = enMode.Add;
                lbTitle.Text = "Add New Person";
                pbImagePerson.Image = Properties.Resources.Male_512;
                lbpersonid.Text = "???";
                lkbRemove.Visible = false;
                return;
            }
            if (ID > 0)
                InfoPerson();
        }
        private void ResetControls(Control parent)
        {
            if (People != null)
            {
                People = null;
                currentImagePath = "";
            }
            pbImagePerson.Image = Properties.Resources.Male_512;
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox txt)
                    txt.Clear();

                else if (ctrl is DateTimePicker dt)
                    dt.Value = dt.MaxDate;

                else if (ctrl is RadioButton rb)
                    rb.Checked = false;

                else if (ctrl is ComboBox cb && cb.Items.Count > 0)
                    cb.SelectedIndex = 0;

                if (ctrl.HasChildren)
                    ResetControls(ctrl);
            }

            lkbRemove.Visible = false;
        }

        public void SetReadOnly(bool readOnly)
        {
            ApplyReadOnly(this, readOnly);
        }
        private void ApplyReadOnly(Control parent, bool readOnly)
        {
            foreach (Control ctl in parent.Controls)
            {
                if (ctl is TextBox tb)
                    tb.ReadOnly = readOnly;

                else if (ctl is ComboBox cb)
                    cb.Enabled = !readOnly;

                else if (ctl is CheckBox chk)
                    chk.Enabled = !readOnly;

                else if (ctl is RadioButton rb)
                    rb.Enabled = !readOnly;

                else if (ctl is DateTimePicker dtp)
                    dtp.Enabled = !readOnly;

                else if (ctl is Button btn)
                    btn.Enabled = !readOnly;

                else if (ctl is LinkLabel ll)
                    ll.Enabled = !readOnly;

                if (ctl.HasChildren)
                    ApplyReadOnly(ctl, readOnly);
            }
        }

        private bool _IsEmpty()
        {
            if (string.IsNullOrEmpty(txAddress.Text) || string.IsNullOrEmpty(txFirstName.Text) || string.IsNullOrEmpty(txSecondName.Text)
                || string.IsNullOrEmpty(txLastName.Text) || string.IsNullOrEmpty(txNational.Text) || string.IsNullOrEmpty(txPhone.Text))
            {
                MessageBox.Show("Please fill in all fields,except the email and third name fields, which are not mandatory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }
        private bool _CheckPhone(string sentence)
        {
            if (sentence.Length > 11 || sentence.Length < 6)
            {
                errorProvider1.SetError(txPhone, "Phone number must be between 6 and 11 digits.");
                return false;
            }

            for (int i = 0; i < sentence.Length; i++)
            {
                if (!char.IsDigit(sentence[i]))
                {
                    errorProvider1.SetError(txPhone, "Phone number must contain only digits.");
                    return false;
                }
            }
            return true;
        }
        private bool _CHeckEmail(string sentence)
        {
            //@gmail.com
            //bool isValid = false;
            //int start = sentence.Length;
            // if (start < 10)
            //     return isValid;
            //                        //M      @
            // if (sentence.Substring(start - 10 , 10) == "@gmail.com")
            //       isValid = true;
            // return isValid;

            if (sentence.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
                return true;
            else
            {
                errorProvider1.SetError(txEmail, "this email does not contain @gmail.com.");
                return false;
            }
        }

      
        private string UpdateImage()
        {
            //if (string.IsNullOrEmpty(currentImagePath))
            //{
            //    if (!string.IsNullOrEmpty(People.imagePath) && File.Exists(People.imagePath))
            //        clsImageManager.DeleteImage(People.imagePath);

            //    return "";
            //}

            //if (currentImagePath != People.imagePath)
            //    return clsImageManager.UpdateImage(People.imagePath, currentImagePath);

            //return People.imagePath;
            if (currentImagePath == "DELETE")
            {
                if (!string.IsNullOrEmpty(People.imagePath) &&
                    File.Exists(People.imagePath))
                {
                    clsImageManager.DeleteImage(People.imagePath);
                }

                return "";
            }

            if (string.IsNullOrEmpty(currentImagePath))
                return People.imagePath;

            if (currentImagePath != People.imagePath)
            {
                string newPath = clsImageManager.SaveImage(currentImagePath);

                if (!string.IsNullOrEmpty(newPath))
                {
                    if (!string.IsNullOrEmpty(People.imagePath))
                        clsImageManager.DeleteImage(People.imagePath);

                    return newPath;
                }
            }

            return People.imagePath;
        }
        private string SaveNewImage()
        {
            //if (string.IsNullOrEmpty(currentImagePath))
            //    return "";

            //return clsImageManager.SaveImage(currentImagePath);
            if (string.IsNullOrEmpty(currentImagePath) || currentImagePath == "DELETE")
                return "";

            return clsImageManager.SaveImage(currentImagePath);
        }
        
        private void AfterSave()
        {
            btnSave.Enabled = false;
            lkbSet.Enabled = false;
            lkbRemove.Enabled = false;
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (_IsEmpty())
                return;


            int selectid = Convert.ToInt32(cbCountry.SelectedValue), gendor = -1;
            DateTime date = dateTimePicker1.Value;
            string image = "";

            if (rbMale.Checked)
                gendor = 0;
            else
                gendor = 1;

            if (Mode == enMode.Add)
            {
                image = SaveNewImage();
                if (clsBLPeople.AddPerson(txNational.Text, txFirstName.Text, txSecondName.Text, txLastName.Text, date, gendor,
                                    txAddress.Text, txPhone.Text, selectid, image, txEmail.Text, txThirdName.Text))
                {
                    MessageBox.Show("Added Successfuly!", "Passed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AfterSave();
                }
                else
                    MessageBox.Show("Added Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                image = UpdateImage();
                if (clsBLPeople.Update(ID, txNational.Text, txFirstName.Text,txSecondName.Text, txLastName.Text, date, gendor,
                                    txAddress.Text, txPhone.Text, selectid, image,txEmail.Text , txThirdName.Text))
                    MessageBox.Show("Updated Successfuly!", "Passed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Updated Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AfterReset()
        {
            btnSave.Enabled = true;
            lkbSet.Enabled = true;
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            ResetControls(this);
            AfterReset();
        }

        private void lkbSet_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string path = clsImageManager.SelectImage(pbImagePerson);

            if (path != null)
            {
                currentImagePath = path;
                lkbRemove.Visible = true;
            }
        }
        private void lkbRemove_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (People != null && !string.IsNullOrEmpty(People.imagePath) && File.Exists(People.imagePath))
            {
                clsImageManager.DeleteImage(People.imagePath);
            }
            pbImagePerson.Image = Properties.Resources.Male_512;
            currentImagePath = "DELETE";
            lkbRemove.Visible = false;

        }

        private void txEmail_Validating_1(object sender, CancelEventArgs e)
        {
            if (!_CHeckEmail(txEmail.Text))
                e.Cancel = true;
            else
                errorProvider1.SetError(txEmail, "");
        }
        private void txPhone_Validating(object sender, CancelEventArgs e)
        {
            if (!_CheckPhone(txPhone.Text))
                e.Cancel = true;
            else
                errorProvider1.SetError(txPhone, "");
        }

        private void ValidateName(TextBox textBox, CancelEventArgs e)
        {
            for (short i = 0; i < textBox.Text.Length; i++)
            {
                if (!char.IsLetter(textBox.Text[i]) && !char.IsWhiteSpace(textBox.Text[i]))
                {
                    errorProvider1.SetError(textBox, "Name must contain only letters and spaces.");
                    e.Cancel = true;
                    return;
                }
            }
            errorProvider1.SetError(textBox, "");
        }
        private void ValidateName(object sender, CancelEventArgs e)
        {
            ValidateName(sender as TextBox, e);
        }
        private void txNational_Validating(object sender, CancelEventArgs e)
        {
            if (Mode == enMode.Add)
            {
                if (clsBLPeople.GetPersonIdByNationalNumber(txNational.Text) > 0)
                {
                    errorProvider1.SetError(txNational, "This national already exsit");
                    e.Cancel = true;
                    return;
                }
            }
            errorProvider1.SetError(txNational, "");
        }
    }
}
