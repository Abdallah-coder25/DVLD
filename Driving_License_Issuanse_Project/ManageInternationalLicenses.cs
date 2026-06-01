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
    public partial class ManageInternationalLicenses : Form
    {
        DataTable dt;
        public ManageInternationalLicenses()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dt = clsBLInternationalLiceneses.GetAllInternationLicense();
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("there is no information on this page.");
                return;
            }
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            lbNumber.Text = dt.Rows.Count.ToString();
            comboBox1.SelectedIndex = 0;
        }

        private void ManageInternationalLicenses_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowInternationalLicenseApp IntLincese = new ShowInternationalLicenseApp();
            IntLincese.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                textBox1.Visible = false;
                cbActive.Visible = false;
            }
            else if(comboBox1.SelectedIndex == 7)
            {
                textBox1.Visible = false;
                cbActive.Visible = true;
            }
            else
            {
                textBox1.Visible = true;
                cbActive.Visible = false;
            }
        }

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dt == null)
                return;

            DataView dv = dt.DefaultView;
            if (cbActive.SelectedIndex == 0)
            {
                dv.RowFilter = "";
            }
            else if(cbActive.SelectedIndex == 1)
            {
                dv.RowFilter = $"IsActive = true";
            }
            else
            {
                dv.RowFilter = $"IsActive = false";
            }
            lbNumber.Text = dv.Count.ToString();
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dt == null)
                return;

            DataView dv = dt.DefaultView;
            if (string.IsNullOrEmpty(textBox1.Text) || comboBox1.SelectedIndex == 0)
            {
                dv.RowFilter = "";
                lbNumber.Text = dv.Count.ToString();
                return;
            }
            if (comboBox1.SelectedIndex != 5 && comboBox1.SelectedIndex != 6)
            {
                if (ValidateTextBox())
                    return;
            }

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 1:
                        dv.RowFilter = $"Convert (InternationalLicenseID , 'System.String' ) like '%{textBox1.Text}%'";
                        break;
                    case 2:
                        dv.RowFilter = $"Convert (ApplicationID , 'System.String' ) like '%{textBox1.Text}%'";
                        break;
                    case 3:
                        dv.RowFilter = $"Convert (DriverID, 'System.String' ) LIKE '%{textBox1.Text}%'";
                        break;
                    case 4:
                        dv.RowFilter = $"Convert (IssuedUsingLocalLicenseID, 'System.String' ) LIKE '%{textBox1.Text}%'";
                        break;
                    case 5:
                        dv.RowFilter = $"Convert (IssueDate , 'System.String' ) like '%{textBox1.Text}%'";
                        break;
                    case 6:
                        dv.RowFilter = $"Convert (ExpirationDate , 'System.String' ) like '%{textBox1.Text}%'";
                        break;
                    case 8:
                        dv.RowFilter = $"Convert (CreatedByUserID , 'System.String' ) like '%{textBox1.Text}%'";
                        break;
                }

            }
            lbNumber.Text = dv.Count.ToString();
        }
    }
}
