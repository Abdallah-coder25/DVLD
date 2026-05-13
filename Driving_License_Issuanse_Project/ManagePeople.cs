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
    public partial class ManagePeople : Form
    {
        DataTable dvPerson;
        public ManagePeople()
        {
            InitializeComponent();
        }

        private void _RefreshData()
        {
            dvPerson = clsBLPeople.GetInfoPeople();
            dataGridView1.DataSource = dvPerson;
            lbNumber.Text = dvPerson.Rows.Count.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ModeOfPerosn mode = new ModeOfPerosn(-1);
            mode.ShowDialog();
            _RefreshData();
        }

        private void cbSerach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSerach.SelectedIndex != 0)
                txSearch.Visible = true;
            else
                txSearch.Visible = false;
        }

        private void ManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void txSearch_TextChanged(object sender, EventArgs e)
        {
            if (dvPerson == null)
                return;

            DataView dv = dvPerson.DefaultView;
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
                        dv.RowFilter = $"Convert (PersonID , 'System.String' ) like '%{txSearch.Text}%'";
                        break;
                    case 2:
                        dv.RowFilter = $"NationalNo LIKE '%{txSearch.Text}%'";
                        break;
                    case 3:
                        dv.RowFilter = $"FirstName LIKE '%{txSearch.Text}%'";
                        break;
                    case 4:
                        dv.RowFilter = $"SecondName LIKE '%{txSearch.Text}%'";
                        break;
                    case 5:
                        dv.RowFilter = $"ThirdName LIKE '%{txSearch.Text}%'";
                        break;
                    case 6:
                        dv.RowFilter = $"LastName LIKE '%{txSearch.Text}%'";
                        break;
                    case 7:
                        dv.RowFilter = $"Convert(DateOfBirth , 'System.String') like  '%{txSearch.Text}%'";
                        break;
                    case 8:
                        dv.RowFilter = $"Convert (Gendor , 'System.String' ) LIKE '%{txSearch.Text}%'";
                        break;
                    case 9:
                        dv.RowFilter = $"Address LIKE '%{txSearch.Text}%'";
                        break;
                    case 10:
                        dv.RowFilter = $"Phone LIKE '%{txSearch.Text}%'";
                        break;
                    case 11:
                        dv.RowFilter = $"Email LIKE '%{txSearch.Text}%'";
                        break;
                    case 12:
                        dv.RowFilter = $"Convert (NationalityCountryID , 'System.String') like '%{txSearch.Text}%'";
                        break;
                    default:
                        dv.RowFilter = "";
                        break;
                }
            }
            lbNumber.Text = dv.Count.ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModeOfPerosn mode = new ModeOfPerosn((int)dataGridView1.CurrentRow.Cells[0].Value);
            mode.ShowDialog();
            _RefreshData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsBLPeople.IsPErsonUsed((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("This people cannot be deleted beceause it is used in invoiced", "Wraning", MessageBoxButtons.OK);
                return;
            }
            DialogResult ms = MessageBox.Show("Are you sure you want to delete this person?", "Delete person", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ms == DialogResult.Yes)
            {
                clsBLPeople.Delete((int)dataGridView1.CurrentRow.Cells[0].Value);
                _RefreshData();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
