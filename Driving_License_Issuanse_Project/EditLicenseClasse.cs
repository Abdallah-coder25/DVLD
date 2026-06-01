using clsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Issuanse_Project
{
    public partial class EditLicenseClasse : Form
    {
        int ID = 0;
        clsBLLocalDrivingLicenseApplications local;
        clsBLLicenseClasses LicenseClass;
        clsBLLicenseClasses newClass;
        clsBLApplication App;
        clsBLPeople person;
        bool change = false;
        public EditLicenseClasse(int id)
        {
            InitializeComponent();
            ID = id;
        }
        private void _FillClassLicense()
        {
           DataTable dt = clsBLLicenseClasses.LicenseClasses();
           comboBox1.DisplayMember = "ClassName";
           comboBox1.ValueMember = "LicenseClassID";
           comboBox1.DataSource = dt;
           comboBox1.SelectedValue = local.LicenseClassID;
        }
        private void BasicData()
        {
            local = clsBLLocalDrivingLicenseApplications.InfoLocalDrivingLicenseApplication(ID);
            LicenseClass = clsBLLicenseClasses.GetInfoLiceneClassByID(local.LicenseClassID);
            App = clsBLApplication.infoApplication(local.AppID);
            person = clsBLPeople.GetPersonByID(App.appPersonId);
        }
        private void LoadData()
        {
            BasicData();
            _FillClassLicense();
            lbLDID.Text = local.LDLAppID.ToString();
            lbAppID.Text = App.AppID.ToString();
            lbName.Text = $"{person.firstname} {person.secondname} {person.lastname}";
            lbAppDate.Text = App.appDate.ToShortDateString();
            lbCurrentClass.Text = LicenseClass.licneseName;
            lbCurrentFees.Text = LicenseClass.ClassFees.ToString();
            lbDifference.Text = "0";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null)
                return;

            int id = (int)comboBox1.SelectedValue;
            newClass = clsBLLicenseClasses.GetInfoLiceneClassByID(id);
            lbNewFees.Text = newClass.ClassFees.ToString();
            lbDifference.Text = (newClass.ClassFees - LicenseClass.ClassFees).ToString();
            change = (newClass.LicenceClasseID != LicenseClass.LicenceClasseID);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!change)
            {
                MessageBox.Show("Please choise another License Class");
                return;
            }
            if (clsBLApplication.HasActiveApplication(person.id, newClass.LicenceClasseID) || clsBLLicense.HasLicense(person.id,newClass.LicenceClasseID))
            {
                MessageBox.Show("This person already has a pre_application of this License Class");
                return;
            }
            DialogResult result = MessageBox.Show( "Are you sure you want to change the license class?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (clsBLLocalDrivingLicenseApplications.UpdateOldLicenseClasse(local.LDLAppID, newClass.LicenceClasseID))
                    MessageBox.Show("Updated successfuly.");
                else
                    MessageBox.Show("Updated failed.");
            }
            else
                return;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void EditLicenseClasse_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
