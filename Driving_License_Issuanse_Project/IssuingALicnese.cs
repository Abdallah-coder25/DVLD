using clsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Issuanse_Project
{
    public partial class IssuingALicnese : Form
    {
        int LocalDrivingLicenseID = 0;

        clsBLLocalDrivingLicenseApplications LDLApp;
        clsBLApplication App;
        clsBLLicenseClasses licenseClasses;
        clsBLPeople person;

        public delegate void DataBackEventHandler(object sender, int LicenseID);
        public event DataBackEventHandler DataBack;

        public int LicenseID = 0;

        public IssuingALicnese(int id)
        {
            InitializeComponent();
            LocalDrivingLicenseID = id;
        }
        private void LoadData()
        {
            ctrApplicationDetails1.DetailsID = LocalDrivingLicenseID;
            if (!BasicInfo())
            {
                MessageBox.Show("Error in loading data.");
                this.Close();
                return;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, LicenseID);
            this.Close();
        }
        private void IssuingALicnese_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private bool BasicInfo()
        {
            LDLApp = clsBLLocalDrivingLicenseApplications.InfoLocalDrivingLicenseApplication(LocalDrivingLicenseID);
            if (LDLApp == null)
            {
                MessageBox.Show("Error LDLApp");
                return false;
            }

            App = clsBLApplication.infoApplication(LDLApp.AppID);
            if (App == null)
            {
                MessageBox.Show("Error App");
                return false;
            }

            licenseClasses = clsBLLicenseClasses.GetInfoLiceneClassByID(LDLApp.LicenseClassID);
            if (licenseClasses == null)
            {
                MessageBox.Show("Error LicenseClasses");
                return false;
            }

            person = clsBLPeople.GetPersonByID(App.appPersonId);
            if (person == null) 
            {
                MessageBox.Show("Error Person");
                return false;
            }

            return true;
        }
        private bool HasLicense()
        {

            if (clsBLLicense.HasLicense(person.id, licenseClasses.LicenceClasseID))
            {
                MessageBox.Show("This person has a License befor.");
                return true;
            }
            return false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (HasLicense())
                return;

            int LicenseDuration = licenseClasses.DefaulValidityLength;
            DateTime LastDeadline = DateTime.Now.AddYears(LicenseDuration);
            int CreatingUser = clsCurrentUser.currentuser.userid;
            int DriverID = 0;
            if (clsBLDrivers.IsPersonFound(person.id))
            {
                //MessageBox.Show("this person already is a drivers");
                //return;
                if (clsBLDrivers.GetDrivierIdByPersonID(person.id) > -1)
                {
                    DriverID = clsBLDrivers.GetDrivierIdByPersonID(person.id);
                }
                else
                {
                    MessageBox.Show("Error in getting driver id");
                    return;
                }
            }
            else
            {
                DriverID = clsBLDrivers.AddNewDrivers(person.id, CreatingUser, DateTime.Now);
            }
            int IssueReason = (int)clsBLLicense.IsssueReasson.FirstTime;
            string Notes = textBox1.Text;
            bool IsAvtive = true;

            LicenseID = clsBLLicense.AddNewLicense(App.AppID, DriverID, licenseClasses.LicenceClasseID, DateTime.Now, LastDeadline, licenseClasses.ClassFees, IsAvtive, IssueReason, CreatingUser, Notes);
            if (LicenseID > 0)
            {
                MessageBox.Show("Added Successufly");
                btnAdd.Enabled = false;
            }
            else
            {
                MessageBox.Show("Added Failed");
            }
        }
    }
}
