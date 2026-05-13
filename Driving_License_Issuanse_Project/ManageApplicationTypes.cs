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
    public partial class ManageApplicationTypes : Form
    {
        public ManageApplicationTypes()
        {
            InitializeComponent();
        }
        private void _LoadData()
        {
            DataTable dt = clsBLApllicationType.GetInfoOfApplicationTyes();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["ApplicationTypeID"].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns["ApplicationTypeTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["ApplicationTypeID"].HeaderText = "Id";
            dataGridView1.Columns["ApplicationTypeTitle"].HeaderText = "Title";
            dataGridView1.Columns["ApplicationFees"].HeaderText = "Fees";
            lbNumber.Text = dt.Rows.Count.ToString();
        
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateApplication update = new UpdateApplication((int)dataGridView1.CurrentRow.Cells[0].Value);
            update.ShowDialog();
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}
