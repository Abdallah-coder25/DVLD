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
    public partial class ManageTestType : Form
    {
        public ManageTestType()
        {
            InitializeComponent();
        }
        private void loadData()
        {
            DataTable dt = clsBLTestType.GetInfoOfTestTyes();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["TestTypeID"].SortMode = DataGridViewColumnSortMode.Automatic;
            dataGridView1.Columns["TestTypeID"].HeaderText = "Id";
            dataGridView1.Columns["TestTypeTitle"].HeaderText = "Title";
            dataGridView1.Columns["TestTypeDescription"].HeaderText = "Description";
            dataGridView1.Columns["TestTypeFees"].HeaderText = "Fees";
            dataGridView1.Columns["TestTypeTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["TestTypeDescription"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            lbNumber.Text = dt.Rows.Count.ToString();

        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTestType update = new UpdateTestType((int)dataGridView1.CurrentRow.Cells[0].Value);
            update.ShowDialog();
        }

        private void ManageTestType_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
