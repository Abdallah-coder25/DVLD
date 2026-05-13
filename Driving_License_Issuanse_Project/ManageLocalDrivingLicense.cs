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
        private void AvaibleOptions()
        {
            int ResultTest = 0;
            issueDrivingLicensefirstTimeToolStripMenuItem.Enabled = false;
            sechduleTestsToolStripMenuItem.Enabled = true;

            ResultTest = Convert.ToInt32(datagridview1.CurrentRow.Cells["PassedTests"].Value);

            if(ResultTest == 0)
            {
                sechduleVisionTestToolStripMenuItem.Enabled = true;
                sechduleWritenTestToolStripMenuItem.Enabled = false;
                sechduleStreetTestToolStripMenuItem.Enabled = false;
            }
            else if(ResultTest == 1)
            {
                sechduleVisionTestToolStripMenuItem.Enabled = false;
                sechduleWritenTestToolStripMenuItem.Enabled = true;
                sechduleStreetTestToolStripMenuItem.Enabled = false;
            }
            else if (ResultTest == 2)
            {

                sechduleVisionTestToolStripMenuItem.Enabled = false;
                sechduleWritenTestToolStripMenuItem.Enabled = false;
                sechduleStreetTestToolStripMenuItem.Enabled = true;
            }
            else
            {
                sechduleTestsToolStripMenuItem.Enabled = false;
                issueDrivingLicensefirstTimeToolStripMenuItem.Enabled = true;
            }

            int StatusRequest = 0;

        }
        private void LoadData()
        {
            dt = clsBLLocalDriving.localDriving();
            if(dt == null)
            {
                MessageBox.Show("there is no information on this page.\nGo to the Add Request page.");
                NewLocalDrivingLicense newRequest = new NewLocalDrivingLicense();
                newRequest.ShowDialog();
            }
            datagridview1.DataSource = dt;
            datagridview1.Columns["DrivingClass"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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
            LoadData();
        }
        private void datagridview1_SelectionChanged(object sender, EventArgs e)
        {
            if (datagridview1.CurrentRow == null)
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
              //  int LocalDrivingLicense = Convert.ToInt32(datagridview1.CurrentRow.Cells["LDLAppID"].Value);
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
            //int LocalDrivingLicense = Convert.ToInt32(datagridview1.CurrentRow.Cells["LDLAppID"].Value);
            IssuingALicnese License = new IssuingALicnese(_selectedLdlAppID);
            License.DataBack += IssuingLicense;
            License.ShowDialog();

        }
    }
}
