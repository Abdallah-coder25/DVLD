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
    public partial class ManageDrivers : Form
    {
        DataTable dt;
        public ManageDrivers()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dt = clsDetialsDrivers.GetInfoDetailsDrivers();
            if(dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("There is no driver yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Enabled = false;
                return;
            }
            dataGridView1.DataSource = dt;
            comboBox1.SelectedIndex = 0;
            lbNumber.Text = dt.Rows.Count.ToString();
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageDrivers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                textBox1.Visible = false;
            else if (comboBox1.SelectedIndex == 6)
            {
                comboBox2.Visible = true;
                textBox1.Visible = false;
            }
            else
            {
                comboBox2.Visible = false;
                textBox1.Visible = true;
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
            if(comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2)
            {
                if (ValidateTextBox())
                    return;
            }

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 1:
                        dv.RowFilter = $"Convert (DriverID , 'System.String' ) like '%{textBox1.Text}%'";
                        break;
                    case 2:
                        dv.RowFilter = $"Convert (PersonID , 'System.String' ) like '%{textBox1.Text}%'";
                        break;
                    case 3:
                        dv.RowFilter = $"NationalNo LIKE '%{textBox1.Text}%'";
                        break;
                    case 4:
                        dv.RowFilter = $"FullName LIKE '%{textBox1.Text}%'";
                        break;
                    case 5:
                        dv.RowFilter = $"Convert(Date , 'System.String') like  '%{textBox1.Text}%'";
                        break;
                }
            }
            lbNumber.Text = dv.Count.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dt == null)
                return;

            DataView dv = dt.DefaultView;
            if (comboBox2.SelectedIndex == 0)
                dv.RowFilter = "";
            else if (comboBox2.SelectedIndex == 1)
                dv.RowFilter = $"ActiveLicense = true";
            else
                dv.RowFilter = $"ActiveLicense = false";
            lbNumber.Text = dv.Count.ToString();
        }
    }
}
