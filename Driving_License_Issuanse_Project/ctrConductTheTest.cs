using clsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static clsBusinessLayer.clsBLApllicationType;
using static clsBusinessLayer.clsBLTestType;

namespace Driving_License_Issuanse_Project
{
    public partial class ctrConductTheTest : UserControl
    {
        int TestAppointmentID = 0;
        int TestType = 0;

        clsBLTestAppointments testAppointment;
        clsBLLocalDrivingLicenseApplications localDrivingLicenseApp;
        clsBLApplication App;
        clsBLPeople person;
        clsBLTestType testType;
        public ctrConductTheTest()
        {
            InitializeComponent();
        }

        private void Information()
        {
            testAppointment = clsBLTestAppointments.GetAllInfoTestAppointmentByID(TestAppointmentID);
            localDrivingLicenseApp = clsBLLocalDrivingLicenseApplications.InfoLocalDrivingLicenseApplication(testAppointment.LocalDrivingId);
            App = clsBLApplication.infoApplication(localDrivingLicenseApp.AppID);
            person = clsBLPeople.GetPersonByID(App.appPersonId);
            testType = clsBLTestType.GetInformationOfOneTestType(TestType);
        }
        private bool IsNull()
        {
            if (testAppointment == null || localDrivingLicenseApp == null || App == null || person == null || testType == null)
                return true;
            return false;
        }
        private void ShowInfo()
        {
            lbID.Text = localDrivingLicenseApp.LDLAppID.ToString();
            lbClass.Text = clsBLLicenseClasses.GetLicenseName(localDrivingLicenseApp.LicenseClassID);
            lbName.Text = $"{person.firstname + " " + person.secondname + " " + person.lastname}";
            lbDate.Text = testAppointment.AppointmentDate.ToString();
            lbFees.Text = testType.fees.ToString();
            int count = clsBLTestType.GetTrial(testAppointment.LocalDrivingId,testAppointment.TestTypeId);
            lbTrial.Text = (count + 1).ToString();
        }
        public void LoadData(int id,int Type)
        {
            TestAppointmentID = id;
            TestType = Type;
            if (TestAppointmentID <= 0)
                return;
            Information();
            if (IsNull())
            {
                MessageBox.Show("An error in Upload.");
                return;
            }
            ShowInfo();
        }
        private bool NotComledted()
        {
            if (!rbPass.Checked && !rbFail.Checked)
                return true;
            return false;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (NotComledted())
            {
                MessageBox.Show("Please put result of Test.");
                return;
            }
            bool result = false;
            result = rbPass.Checked;

            string Notes = textBox1.Text;
            int TestID = clsBLTest.AddNewTest(TestAppointmentID, result, clsCurrentUser.currentuser.userid, Notes);

            if (TestID > 0 && clsBLTestAppointments.UpdatedToLocked(TestAppointmentID))
            {
                MessageBox.Show("Added successfuly and TestAppointment become locked");
                btnAdd.Enabled = false;
                lbTestID.Text = TestID.ToString();
            }
            else
            {
                MessageBox.Show("Added Failed");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}
