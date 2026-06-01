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
using static clsBusinessLayer.clsBLApllicationType;
using static clsBusinessLayer.clsBLTestType;

namespace Driving_License_Issuanse_Project
{
    public partial class ctrScheduleTest : UserControl
    {
         int AdddWithLDALID = 0;
         int EditWithtestApponID = 0;
         int AddRenewAppoID = 0;

        clsBLTestAppointments testAppointment ;
        clsBLLocalDrivingLicenseApplications localDrivingLicenseApp;
        clsBLApplication App;
        clsBLPeople person;
        clsBLTestType testType;
        clsBLApllicationType AppType;
        enum enMode { Add = 1 , Edit = 2,Renew = 3};
        enMode Mode;
        int TypeTest = 0;
        public int newTestAppointmentId = 0;
        public ctrScheduleTest()
        {
            InitializeComponent();
        }

        public void SetAdd(int id,int Type)
        {
            AdddWithLDALID = id;
            Mode = enMode.Add;
            TypeTest = Type;
            InformationInModeAdd();
        }
        public void SetEdit(int id, int Type)
        {
            EditWithtestApponID = id;
            Mode = enMode.Edit;
            TypeTest = Type;
            InformationInModeEdit();
        }
        public void SetRenew(int id, int Type)
        {
            AddRenewAppoID = id;
            Mode = enMode.Renew;
            TypeTest = Type;
            LoadInformationModeRenew();
        }

        private bool IsNull()
        {
            if (localDrivingLicenseApp == null || App == null || person == null || testType == null)
                return true;
            else
                return false;
        }
        private void LoadBasicInfo()
        {
            App = clsBLApplication.infoApplication(localDrivingLicenseApp.AppID);
            person = clsBLPeople.GetPersonByID(App.appPersonId);
            testType = clsBLTestType.GetInformationOfOneTestType(TypeTest);
        }
        private int GetTrial()
        {
            return clsBLTestType.GetTrial(localDrivingLicenseApp.LDLAppID, TypeTest);
        }


        private void LoadDataInModeAdd()
        {
            lbID.Text = AdddWithLDALID.ToString();
            lbClassName.Text = clsBLLicenseClasses.GetLicenseName(localDrivingLicenseApp.LicenseClassID);
            lbName.Text = $"{person.firstname + " " + person.secondname +" "+ person.lastname}";
            dateTimePicker1.Value = DateTime.Now;
            lbFees.Text = testType.fees.ToString();
            lbTotalFees.Text = testType.fees.ToString();
            lbTrial.Text = (GetTrial()+1).ToString();
        }
        private void InformationInModeAdd()
        {
            //error
            localDrivingLicenseApp = clsBLLocalDrivingLicenseApplications.InfoLocalDrivingLicenseApplication(AdddWithLDALID);
            LoadBasicInfo();

            if (IsNull())
            {
                MessageBox.Show("A problem in load");
                return;
            }

            LoadDataInModeAdd();
            //DataForRenewTest();
           
        }


        private void LoadInfoInModeEdit()
        {
            lbID.Text = localDrivingLicenseApp.LDLAppID.ToString();
            lbClassName.Text = clsBLLicenseClasses.GetLicenseName(localDrivingLicenseApp.LicenseClassID);
            lbName.Text = $"{person.firstname + " " + person.secondname + " " + person.lastname}";
            lbFees.Text = testType.fees.ToString();
            dateTimePicker1.Value = testAppointment.AppointmentDate;
            lbNA.Text = EditWithtestApponID.ToString();
            button1.Enabled = true;

            bool isFirst = clsBLTestAppointments.IsFirstTest(EditWithtestApponID, testAppointment.LocalDrivingId, testAppointment.TestTypeId);
            decimal renew = 0;

            if (!isFirst)
            {
                AppType = clsBLApllicationType.GetInformation((int)ApplicationType.RenewLocalDrivingLicense);
                renew = AppType.fees;
                lbTrial.Text = GetTrial().ToString();
            }
            else
            {
                lbTrial.Text = "1";
            }
            lbRenewAppFees.Text = renew.ToString();
            lbTotalFees.Text = (testType.fees + renew).ToString();

                if (clsBLTestAppointments.IsLocked(EditWithtestApponID))
                {
                    lbLocked.Visible = true;
                    lbLocked.Text = "This person is took the test previously.";
                    dateTimePicker1.Enabled = false;
                }
            }
        private void InformationInModeEdit()
        {
            testAppointment = clsBLTestAppointments.GetAllInfoTestAppointmentByID(EditWithtestApponID);

            if (testAppointment == null)
            {
                MessageBox.Show("Test appointment is null");
                return;
            }
            //error
            localDrivingLicenseApp = clsBLLocalDrivingLicenseApplications.InfoLocalDrivingLicenseApplication(testAppointment.LocalDrivingId);
            if(localDrivingLicenseApp == null)
            {
                MessageBox.Show("Local Driving license is null");
                return;
            }
            LoadBasicInfo();

            if(testAppointment == null || IsNull())
            {
                MessageBox.Show("A problem in load");
                return;
            }
            LoadInfoInModeEdit();
            // A probleme
            //DataForRenewTest();
        }


        private void InformationInModerenew()
        {

            lbID.Text = localDrivingLicenseApp.LDLAppID.ToString();
            lbClassName.Text = clsBLLicenseClasses.GetLicenseName(localDrivingLicenseApp.LicenseClassID);
            lbName.Text = $"{person.firstname + " " + person.secondname + " " + person.lastname}";
            dateTimePicker1.Value = DateTime.Now;
            lbFees.Text = testType.fees.ToString();
            testAppointment.PaidFees = testType.fees + clsBLApllicationType.GetInformation((int)ApplicationType.RenewLocalDrivingLicense).fees;
            lbRenewAppFees.Text = clsBLApllicationType.GetInformation((int)ApplicationType.RenewLocalDrivingLicense).fees.ToString();
            lbTotalFees.Text = testAppointment.PaidFees.ToString();
            lbTrial.Text = (GetTrial()+1).ToString();
        }
        private void LoadInformationModeRenew()
        {
            testAppointment = clsBLTestAppointments.GetAllInfoTestAppointmentByID(AddRenewAppoID);
            if (testAppointment == null)
            {
                MessageBox.Show("Test appointment is null");
                return;
            }
            localDrivingLicenseApp = clsBLLocalDrivingLicenseApplications.InfoLocalDrivingLicenseApplication(testAppointment.LocalDrivingId);
            if (localDrivingLicenseApp == null)
            {
                MessageBox.Show("Local Driving license is null");
                return;
            }
            LoadBasicInfo();
            if (testAppointment == null || IsNull())
            {
                MessageBox.Show("A problem in load");
                return;
            }
            InformationInModerenew();
            //DataForRenew();
        }


        private bool ChekDateChange()
        {
            if (dateTimePicker1.Value != testAppointment.AppointmentDate)
                return true;
            else
                return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.Add)
            {
                newTestAppointmentId = clsBLTestAppointments.AddNewTestAppointment(TypeTest, AdddWithLDALID, dateTimePicker1.Value, testType.fees, clsCurrentUser.currentuser.userid, false);
                if (newTestAppointmentId > 0)
                {
                    MessageBox.Show("Added successfuly.");
                    button1.Enabled = false;
                    lbNA.Text = newTestAppointmentId.ToString();
                    return;
                }
                else
                {
                    MessageBox.Show("Added failed");
                    return;
                }
            }
            else if (Mode == enMode.Edit)
            {
                if (ChekDateChange())
                {
                    if (clsBLTestAppointments.UpdateDate(EditWithtestApponID, dateTimePicker1.Value))
                    {
                        MessageBox.Show("Update Successfuly.");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Update failed.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("No changes were made to the date.");
                }
            }
            else
            {
                newTestAppointmentId = clsBLTestAppointments.AddNewTestAppointment(TypeTest, localDrivingLicenseApp.LDLAppID, dateTimePicker1.Value, testAppointment.PaidFees, clsCurrentUser.currentuser.userid, false);
                if (newTestAppointmentId > 0)
                {
                    MessageBox.Show("Added successfuly.");
                    button1.Enabled = false;
                    lbNA.Text = newTestAppointmentId.ToString();
                    return;
                }
                else
                {
                    MessageBox.Show("Added failed");
                    return;
                }
            }

        }
    }
 }

