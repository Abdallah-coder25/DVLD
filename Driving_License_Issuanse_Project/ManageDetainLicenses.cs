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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Driving_License_Issuanse_Project
{
    public partial class ManageDetainLicenses : Form
    {
        DataTable dt;
        int LicenseID = 0;
        public ManageDetainLicenses()
        {
            InitializeComponent();
        }
        private void Disable()
        {
            LicenseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["LicenseID"].Value);
            bool isReleased = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["IsReleased"].Value);
            releaseDetainLicenseToolStripMenuItem.Enabled = !isReleased;
        }
        private void RefreshData()
        {
            dt = clsBLDetailsDetain.GEtAllInfoDetailsLicense();
            if (dt != null && dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                lbNumber.Text = dt.Rows.Count.ToString();
                cbFilter.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No Detains.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbFilter.Enabled = false;
                return;
            }
        }
        private bool ValidateTextBox()
        {
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (!char.IsDigit(textBox1.Text[i]))
                {
                    errorProvider1.SetError(textBox1, "Please enter only numbers for PersonID");
                    return true;
                }
            }
            return false;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilter.SelectedIndex == 0)
            {
                textBox1.Visible = false;
                cbRelease.Visible = false;
                DataView dv = dt.DefaultView;
                dv.RowFilter = "";
            }
            else if(cbFilter.SelectedIndex == 4)
            {
                textBox1.Visible = false;
                cbRelease.Visible = true;
            }
            else
            {
                textBox1.Visible = true;
                cbRelease.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dt == null)
                return;

            DataView dv = dt.DefaultView;
            if (string.IsNullOrEmpty(textBox1.Text) || cbFilter.SelectedIndex == 0)
            {
                dv.RowFilter = "";
                lbNumber.Text = dv.Count.ToString();
                return;
            }
            if (cbFilter.SelectedIndex == 1 || cbFilter.SelectedIndex == 2 || cbFilter.SelectedIndex == 9)
            {
                if (ValidateTextBox())
                    return;
            }
           
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                switch (cbFilter.SelectedIndex)
                {
                    case 1:
                        dv.RowFilter = $"Convert (DetainID , 'System.String' ) like '%{textBox1.Text}%'";
                        break;
                    case 2:
                        dv.RowFilter = $"Convert (LicenseID , 'System.String' ) like '%{textBox1.Text}%'";
                        break;
                    case 3:
                        dv.RowFilter = $"Convert (DetainDate,'System.String' ) LIKE '%{textBox1.Text}%'";
                        break;
                    case 5:
                        dv.RowFilter = $"Convert (FineFees,'System.String' ) LIKE '%{textBox1.Text}%'";
                        break;
                    case 6:
                        dv.RowFilter = $"Convert (ReleasedDate,'System.String' ) LIKE '%{textBox1.Text}%'";
                        break;
                    case 7:
                        dv.RowFilter = $"NationalNo LIKE '%{textBox1.Text}%'";
                        break;
                    case 8:
                        dv.RowFilter = $"FullName LIKE '%{textBox1.Text}%'";
                        break;
                    case 9:
                        dv.RowFilter = $"Convert (ReleaseApplicationID,'System.String' ) LIKE '%{textBox1.Text}%'";
                        break;
                }

            }
            lbNumber.Text = dv.Count.ToString();
        }

        private void cbRelease_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dt == null)
                return;

            DataView dv = dt.DefaultView;

            if (cbRelease.SelectedIndex == 0)
                dv.RowFilter = "";
            else if (cbRelease.SelectedIndex == 1)
                dv.RowFilter = $"IsReleased = true";
            else
                dv.RowFilter = $"IsReleased = false";

            lbNumber.Text = dv.Count.ToString();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NO = dataGridView1.CurrentRow.Cells["NationalNo"].Value.ToString();
            int personID = clsBLPeople.GetPersonIdByNationalNumber(NO);
            DetailsPerson person = new DetailsPerson(personID);
            person.ShowDialog();
            RefreshData();
        }
        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriverLicenseInfo infoLicense = new DriverLicenseInfo(LicenseID);
            infoLicense.ShowDialog();
            RefreshData();
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clsBLLicense License = clsBLLicense.GetInfoLicenseByLicenseID(LicenseID);
            //int LocalLicenseID = clsBLLocalDrivingLicenseApplications.GetLocalLicenseID(License.AppID, License.LicenseClassID);
            LicenseHistory history = new LicenseHistory(LicenseID);
            history.ShowDialog();
            RefreshData();
        }
        private void releaseDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReleaseDetain release = new ReleaseDetain();
            release.SendLicenseID(LicenseID);
            release.ShowDialog();
            RefreshData();
        }

        private void ManageDetainLicenses_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            Disable();
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            ReleaseDetain release = new ReleaseDetain();
            release.ShowDialog();
            Refresh();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            DetainLicense detain = new DetainLicense();
            detain.ShowDialog();
            RefreshData();
        }
    }
}
