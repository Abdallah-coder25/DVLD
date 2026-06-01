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
    public partial class LicenseHistory : Form
    {
        int LicenseID = 0;
        clsBLLicense License;
        clsBLApplication App;
        clsBLPeople person;
        int driverID;
        public LicenseHistory(int id)
        {
            InitializeComponent();
            LicenseID = id;
        }
        private void GetInfo()
        {
            License = clsBLLicense.GetInfoLicenseByLicenseID(LicenseID);
            App = clsBLApplication.infoApplication(License.AppID);
            person = clsBLPeople.GetPersonByID(App.appPersonId);
            driverID = clsBLDrivers.GetDrivierIdByPersonID(person.id);
        }
        private void LicenseInfo()
        {
            DataTable dt = clsBLLicense.GEtAllInfoForOneLicense(driverID);// localDrivingLicense.LicenseClassID);
            DGVLocal.DataSource = dt;
            DGVLocal.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.AllCells;
            DGVLocal.Columns["DriverID"].Visible = false;
            DGVLocal.Columns["Notes"].Visible = false;
            DGVLocal.Columns["IssueReason"].Visible = false;
            DGVLocal.Columns["CreatedByUserID"].Visible = false;
            DGVLocal.Columns["PaidFees"].Visible = false;
            if(DGVLocal != null)
            {
                DataTable dt2 = clsBLInternationalLiceneses.GetInternationalLicenseByDriverID(driverID);
                if(dt2 != null && dt2.Rows.Count > 0)
                {
                    DGVInternational.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    DGVInternational.DataSource = dt2;
                    DGVInternational.Columns["DriverID"].Visible = false;
                    DGVInternational.Columns["CreatedByUserID"].Visible = false;
                }
            }
        }
        private void LoadInfoPerson()
        {
            //int LDID = clsBLLocalDrivingLicenseApplications.GetLocalLicenseID(License.AppID, License.LicenseClassID);
            ctrFoundPerson1.LoadPersonByLocalDrivingLicenseID(LicenseID);
            GetInfo();
            LicenseInfo();
        }
        private void LicenseHistory_Load(object sender, EventArgs e)
        {
            LoadInfoPerson();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = Convert.ToInt32(DGVLocal.CurrentRow.Cells[0].Value);
            DriverLicenseInfo info = new DriverLicenseInfo(LicenseID);
            info.ShowDialog();
        }

        private void showLicenseInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = Convert.ToInt32(DGVInternational.CurrentRow.Cells[0].Value);
            InternationalLicenseInfo info = new InternationalLicenseInfo(InternationalLicenseID);
            info.ShowDialog();
        }
    }
}
