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
    public partial class ctrApplicationDetails : UserControl
    {
        int ID = 0;

        clsBLLocalDrivingLicenseApplications LDLApp;
        clsBLApplication App;
        clsBLApllicationType AppType;
        clsBLPeople person;
        clsBLUser user;
        public ctrApplicationDetails()
        {
            InitializeComponent();
        }
        public int DetailsID
        {
            get { return ID; }
            set
            {
                ID = value;
                _LoadInfo();
            }
        }
        private void lkbInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           DetailsPerson person = new DetailsPerson(App.appPersonId);
            person.ShowDialog();
        }
        private void _LoadInfo()
        {
            LDLApp = clsBLLocalDrivingLicenseApplications.InfoLocalDrivingLicenseApplication(ID);
            if (LDLApp == null) return;

            App = clsBLApplication.infoApplication(LDLApp.AppID);
            if (App == null) return;

            AppType = clsBLApllicationType.GetInformation(App.appTypeId);
            if (AppType == null) return;

            person = clsBLPeople.GetPersonByID(App.appPersonId);
            if (person == null) return;

            user = clsBLUser.GetUser(App.usercreated);
            if (user == null) return;

            lbDLAID.Text = LDLApp.LDLAppID.ToString();
            lbClassName.Text = clsBLLicenseClasses.GetLicenseName(LDLApp.LicenseClassID);
            lbPasTest.Text = $"{clsBLLocalDriving.PassedResult(LDLApp.LDLAppID)}/3";
            lbAppID.Text = App.AppID.ToString();
            lbStatusApp.Text = App.status.ToString();
            lbFees.Text = AppType.fees.ToString();
            lbType.Text = AppType.applicationTitletype;
            lbApplicant.Text = $"{person.firstname} {person.secondname} {person.lastname}";
            lbDate.Text = App.appDate.ToString();
            lbStatusDate.Text = App.lastStatusDate.ToString();
            lbCreateBy.Text = user.username;
        }
    }
}
