using clsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Issuanse_Project
{
    public partial class ManageLocalDrivingLicense : Form
    {
        DataTable dt;
        int _selectedLdlAppID = 0;
        public ManageLocalDrivingLicense()
        {
            InitializeComponent();
        }
        private void DisableOption()
        {
            editApplicationToolStripMenuItem.Enabled = false;
            deleteApplicationToolStripMenuItem.Enabled = false;
            cancelApplicationToolStripMenuItem.Enabled = false;
            showPersonLicenseHistoryToolStripMenuItem.Enabled = false;
            sechduleTestsToolStripMenuItem.Enabled = false;
            issueDrivingLicensefirstTimeToolStripMenuItem.Enabled = false;
            showApplicationDetailsToolStripMenuItem.Enabled = false;
            sToolStripMenuItem.Enabled = false;
        }
        private void CompletedStatus()
        {
            editApplicationToolStripMenuItem.Enabled = false;
            deleteApplicationToolStripMenuItem.Enabled = false;
            cancelApplicationToolStripMenuItem.Enabled = false;
            sechduleTestsToolStripMenuItem.Enabled = false;
            issueDrivingLicensefirstTimeToolStripMenuItem.Enabled = false;
            showApplicationDetailsToolStripMenuItem.Enabled = true;
            showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
            sToolStripMenuItem.Enabled = true;
        }
        private void EnableOption()
        {
            issueDrivingLicensefirstTimeToolStripMenuItem.Enabled = false;
            sechduleTestsToolStripMenuItem.Enabled = true;
            editApplicationToolStripMenuItem.Enabled = true;
            deleteApplicationToolStripMenuItem.Enabled = true;
            cancelApplicationToolStripMenuItem.Enabled = true;
            sechduleStreetTestToolStripMenuItem.Enabled = true;
            showApplicationDetailsToolStripMenuItem.Enabled = true;
            showPersonLicenseHistoryToolStripMenuItem.Enabled = true;
            sToolStripMenuItem.Enabled = false;
        }
        private void AnyPassed()
        {
            sechduleVisionTestToolStripMenuItem.Enabled = true;
            sechduleWritenTestToolStripMenuItem.Enabled = false;
            sechduleStreetTestToolStripMenuItem.Enabled = false;
        }
        private void VisionPassed()
        {
            editApplicationToolStripMenuItem.Enabled = false;
            sechduleVisionTestToolStripMenuItem.Enabled = false;
            sechduleWritenTestToolStripMenuItem.Enabled = true;
            sechduleStreetTestToolStripMenuItem.Enabled = false;
        }
        private void WrittenPassed()
        {
            editApplicationToolStripMenuItem.Enabled = false;
            sechduleVisionTestToolStripMenuItem.Enabled = false;
            sechduleWritenTestToolStripMenuItem.Enabled = false;
            sechduleStreetTestToolStripMenuItem.Enabled = true;
        }
        private void StreetPassed()
        {
            editApplicationToolStripMenuItem.Enabled = false;
            sechduleTestsToolStripMenuItem.Enabled = false;
            issueDrivingLicensefirstTimeToolStripMenuItem.Enabled = true;
        }
        private void AvaibleOptions()
        {
            EnableOption();

            int ResultTest = 0;
            ResultTest = Convert.ToInt32(datagridview1.CurrentRow.Cells["PassedTests"].Value);
            if(ResultTest == 0)
            {
                AnyPassed();
            }
            else if(ResultTest == 1)
            {
                VisionPassed();
            }
            else if (ResultTest == 2)
            {

                WrittenPassed();
            }
            else
            {
                StreetPassed();
            }

            string StatusRequest = "";
            StatusRequest = datagridview1.CurrentRow.Cells["Status"].Value.ToString();
            if (string.Equals(StatusRequest,"Completed"))
            {
                CompletedStatus();
            }
            else if((string.Equals(StatusRequest, "Canceled")))
            {
                DisableOption();
            }
        }
        private void LoadData()
        {
            dt = clsBLLocalDriving.localDriving();
            if(dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("there is no information on this page.\nGo to the Add Request page.");
                return;
            }
            datagridview1.DataSource = dt;

            datagridview1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

           // datagridview1.Columns["DrivingClass"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            lbNumber.Text = dt.Rows.Count.ToString();
           
        }
        private void cbSerach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSerach.SelectedIndex != 0)
                txSearch.Visible = true;
            else
            {
                txSearch.Visible = false;
                DataView dv = dt.DefaultView;
                lbNumber.Text = dv.Count.ToString();
                dv.RowFilter = "";
            }
        }
        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            if (dt == null)
                return;
            DataView dv = dt.DefaultView;
            if (string.IsNullOrEmpty(txSearch.Text) || cbSerach.SelectedIndex == 0)
            {
                dv.RowFilter = "";
                lbNumber.Text = dv.Count.ToString();
                return;
            }

            if (!string.IsNullOrEmpty(txSearch.Text))
            {
                switch (cbSerach.SelectedIndex)
                {
                    case 1:
                        dv.RowFilter = $"Convert (LDLAppID , 'System.String' ) like '%{txSearch.Text}%'";
                        break;
                    case 2:
                        dv.RowFilter = $"NationalNo LIKE '%{txSearch.Text}%'";
                        break;
                    case 3:
                        dv.RowFilter = $"FullName LIKE '%{txSearch.Text}%'";
                        break;
                    case 4:
                        dv.RowFilter = $"Status LIKE '%{txSearch.Text}%'";
                        break;

                }
            }
            lbNumber.Text = dv.Count.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ManageLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            NewLocalDrivingLicense newLocalDrivingLicense = new NewLocalDrivingLicense();
            newLocalDrivingLicense.ShowDialog();
            LoadData();
        }
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //int ldlAppID = Convert.ToInt32(datagridview1.CurrentRow.Cells["LDLAppID"].Value);

            string status = datagridview1.CurrentRow.Cells["Status"].Value.ToString();

            if (status == "New")
            {
                if (clsBLApplication.CancelApplication(_selectedLdlAppID))
                {
                    //sechduleTestsToolStripMenuItem.Enabled = false;
                    //issueDrivingLicensefirstTimeToolStripMenuItem.Enabled = false;
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cancel failed!");
                }
            }
            else
            {
                MessageBox.Show("This status application not new!");
            }
        }
        private void datagridview1_SelectionChanged(object sender, EventArgs e)
        {
            if (datagridview1.CurrentRow == null)
                return;
            if (datagridview1.CurrentRow.IsNewRow)
                return;
            _selectedLdlAppID = Convert.ToInt32(datagridview1.CurrentRow.Cells["LDLAppID"].Value);
            AvaibleOptions();
        }
        private void OpenTest(int testTypeId)
        {
            //int LocalDrivingLicense = Convert.ToInt32(datagridview1.CurrentRow.Cells["LDLAppID"].Value);

            VisionTestAppointment testAppointment = new VisionTestAppointment(_selectedLdlAppID, testTypeId);
            testAppointment.ShowDialog();
            LoadData();
        }
        private void sechduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTest((int)clsBLTestType.TestType.VisionTest);
        }
        private void sechduleWritenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTest((int)clsBLTestType.TestType.WrittenTest);
        }
        private void sechduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTest((int)clsBLTestType.TestType.Street);
        }
        private void IssuingLicense(object sender, int NewLicenseID)
        {
            if (NewLicenseID > 0)
            {
                bool Update = clsBLApplication.CompletedRequest(_selectedLdlAppID);
                if (Update)
                {

                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Failed to update application status.");
            }
        }
        private void issueDrivingLicensefirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssuingALicnese License = new IssuingALicnese(_selectedLdlAppID);
            License.DataBack += IssuingLicense;
            License.ShowDialog();

        }
        private int LicenseID()
        {
            int LicenseID = 0;

            string nationalNo = datagridview1.CurrentRow.Cells["NationalNo"].Value.ToString();
            string ClassNAme = datagridview1.CurrentRow.Cells["DrivingClass"].Value.ToString();
            int peronID = clsBLPeople.GetPersonIdByNationalNumber(nationalNo);

            int driverID = clsBLDrivers.GetDrivierIdByPersonID(peronID);
            int LicenseClassID = clsBLLicenseClasses.GetLicenseClassIDByName(ClassNAme);

            LicenseID = clsBLLicense.LastLicenseIDByDriverIDAndLicenseClassID(driverID, LicenseClassID);
            return LicenseID;
        }
        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriverLicenseInfo License = new DriverLicenseInfo(LicenseID());
            License.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenseHistory licenseHistory = new LicenseHistory(LicenseID());
            licenseHistory.ShowDialog();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDetailsApplication details = new ShowDetailsApplication(_selectedLdlAppID);
            details.ShowDialog();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Confirm",MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                if (clsBLLocalDriving.DeleteApplication(_selectedLdlAppID))
                {
                    MessageBox.Show("Deleted succussfly", "Confirm", MessageBoxButtons.OK);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Deleted failed", "Confirm", MessageBoxButtons.OK);
                }
            }
            else
                return;
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditLicenseClasse edit = new EditLicenseClasse(_selectedLdlAppID);
            edit.ShowDialog();
            LoadData();
        }
    }
}
