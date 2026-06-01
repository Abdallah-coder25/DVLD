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
    public partial class ManageUsers : Form
    {
        DataTable dtUsers;
        public ManageUsers()
        {
            InitializeComponent();
        }
        private void _RefreshData()
        {
            dtUsers = clsBLUser.GetInfoUsers();
            dataGridView1.DataSource = dtUsers;
            lbNumber.Text = dtUsers.Rows.Count.ToString();
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
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModeOfUser edit = new ModeOfUser((int)dataGridView1.CurrentRow.Cells[0].Value);
            edit.ShowDialog();
            _RefreshData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsBLUser.UserUsed((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("This user cannot be deleted beceause it is used in invoiced", "Wraning", MessageBoxButtons.OK);
                return;
            }
            DialogResult ms = MessageBox.Show("Are you sure you want to delete this user?", "Delete person", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ms == DialogResult.Yes)
            {
                if (clsBLUser.Delete((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshData();
                    return;
                }
                else
                {
                    MessageBox.Show("Failed to delete user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword change = new ChangePassword((int)dataGridView1.CurrentRow.Cells[1].Value);
            change.ShowDialog();
            _RefreshData();
        }

        private void showDEtailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetailsUser details = new DetailsUser((int)dataGridView1.CurrentRow.Cells[1].Value);
            details.ShowDialog();
            _RefreshData();
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 5)
            {
                cbActive.Visible = true;
                textBox1.Visible = false;
            }
            else if (comboBox1.SelectedIndex == 0)
            {
                cbActive.Visible = false;
                textBox1.Visible = false;
            }
            else
            {
                textBox1.Visible = true;
                cbActive.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dtUsers == null)
                return;

            DataView dv = dtUsers.DefaultView;
            if (string.IsNullOrEmpty(textBox1.Text) || comboBox1.SelectedIndex == 0)
            {
                dv.RowFilter = "";
                lbNumber.Text = dv.Count.ToString();
                return;
            }
            if (comboBox1.SelectedIndex == 1 || comboBox1.SelectedIndex == 2)
            {
                if (ValidateTextBox())
                    return;
            }

            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 1:
                        dv.RowFilter = $"Convert (UserID , 'System.String' ) like '%{textBox1.Text}%'";
                        break;
                    case 2:
                        dv.RowFilter = $"Convert (PersonID , 'System.String' ) like '%{textBox1.Text}%'";
                        break;
                    case 3:
                        dv.RowFilter = $"UserName LIKE '%{textBox1.Text}%'";
                        break;
                    case 4:
                        dv.RowFilter = $"Password LIKE '%{textBox1.Text}%'";
                        break;
                }

            }
            lbNumber.Text = dv.Count.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ModeOfUser add = new ModeOfUser(-1);
            add.ShowDialog();
            _RefreshData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dtUsers == null)
                return;

            DataView dv = dtUsers.DefaultView;
            if (cbActive.SelectedIndex == 0)
                dv.RowFilter = "";
            else if (cbActive.SelectedIndex == 1)
                dv.RowFilter = $"IsActive = true";
            else
                dv.RowFilter = $"IsActive = false";
            lbNumber.Text = dv.Count.ToString();
        }
    }
}
