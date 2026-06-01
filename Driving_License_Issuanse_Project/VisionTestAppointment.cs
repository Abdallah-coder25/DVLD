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
    public partial class VisionTestAppointment : Form
    {
        int LDALID = 0;
        int TypeTest = 0;
        DataTable dt;
        public VisionTestAppointment(int id,int type)
        {
            InitializeComponent();
            LDALID = id;
            TypeTest = type;
        }

        private void RefreshGrid()
        {
           dt = clsBLTestAppointments.GetAvaibleInfoTestAppointmentByLocalDrIDANDTestTypeID(LDALID, TypeTest);

           if (dt == null || dt.Rows.Count == 0)
           {
               dataGridView1.DataSource = null;
               lbNumber.Text = "0";
               return;
           }

           dataGridView1.DataSource = dt;
           dataGridView1.Columns["TestTypeID"].Visible = false;
           dataGridView1.Columns["LocalDrivingLicenseApplicationID"].Visible = false;
           dataGridView1.Columns["PaidFees"].Visible = false;
           dataGridView1.Columns["CreatedByUserID"].Visible = false;

            lbNumber.Text = dt.Rows.Count.ToString();
        }
        private void LoadInformation()
        {
            ctrApplicationDetails1.DetailsID = LDALID;
            RefreshGrid();
            if (TypeTest == (int)clsBLTestType.TestType.VisionTest)
                lbTitle.Text = "Vision Test Appointment";
            else if (TypeTest == (int)clsBLTestType.TestType.WrittenTest)
                lbTitle.Text = "Written Test Appointment";
            else
                lbTitle.Text = "Street Test Appointment";
        }
        private void VisionTestAppointment_Load(object sender, EventArgs e)
        {
            LoadInformation();
        }

        private void OpenAddForm(int id,string mode,int type)
        {
            //error                                                
            SetADateVisionTest dateTest = new SetADateVisionTest(id,mode,type);
            dateTest.DataBack += VisionTestِAppointmentID;
            dateTest.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool hasTests = dt != null && dt.Rows.Count > 0;

            if (!hasTests)
            {
                OpenAddForm(LDALID, "Add",TypeTest);
                return;
            }
            DataRow lastRow = dt.Rows[dt.Rows.Count - 1];

            int testAppointmentID = Convert.ToInt32(lastRow["TestAppointmentID"]);
            int localDrivingId = Convert.ToInt32(lastRow["LocalDrivingLicenseApplicationID"]);

            bool isPassed = clsBLTest.HasPassed(localDrivingId, TypeTest);
            bool isFailed = clsBLTest.HasFailedInTest(localDrivingId, TypeTest);
            bool hasActiveAppointment = !Convert.ToBoolean(lastRow["IsLocked"]);

            if (isPassed)
            {
                MessageBox.Show("This person already passed the test.");
                return;
            }

            if (hasActiveAppointment)
            {
                MessageBox.Show("This person already has an active appointment.");
                return;
            }

            if (isFailed)
            {
                OpenAddForm(testAppointmentID, "Renew",TypeTest);
            }
            else
            {
                OpenAddForm(LDALID, "Add",TypeTest);
            }
        }

        private void VisionTestِAppointmentID(object sender, int TestAppointmentID)
        {
            RefreshGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointment = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TestAppointmentID"].Value);
            OpenAddForm(TestAppointment,"Edit",TypeTest);

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointment = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TestAppointmentID"].Value);

            if (clsBLTestAppointments.IsLocked(TestAppointment))
            {
                MessageBox.Show("he performed the test");
                return;
            }
            int localDrivingId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["LocalDrivingLicenseApplicationID"].Value);

            if (clsBLTest.NotYetTested(TestAppointment) || clsBLTest.HasFailedInTest(localDrivingId, TypeTest))
            {
                SetTakeResult test = new SetTakeResult(TestAppointment,TypeTest);
                test.ShowDialog();
                RefreshGrid();
            }
            else
            {
                MessageBox.Show("This person has already taken the test and passed");
            }
        }
    }
}
