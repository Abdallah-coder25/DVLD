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
    public partial class ctrTestType : UserControl
    {
        int ID = 0;
        clsBLTestType test;
        decimal fees;
        public ctrTestType()
        {
            InitializeComponent();
        }
           public int TypeID
        {
            get { return ID; }
            set
            {
                ID = value;
                LoadInformation();
            }
        }
        private bool isEmpty()
        {
            if (string.IsNullOrEmpty(txTitle.Text) || string.IsNullOrEmpty(txFees.Text) || string.IsNullOrEmpty(txDescription.Text))
            {
                MessageBox.Show("Please fill in all the boxes");
                return true;
            }
            return false;
        }
        private bool IsChanged()
        {
            if (!decimal.TryParse(txFees.Text, out decimal newFees))
                return false;

            return (txTitle.Text != test.testTypetitle ||
                    newFees != test.fees ||
                    txDescription.Text != test.testtypeDesription);
        }
        private void LoadInformation()
        {
            if (ID <= 0)
                return;

            test = clsBLTestType.GetInformationOfOneTestType(ID);
            if (test != null)
            {
                lbInfoId.Text = test.testtypeid.ToString();
                txTitle.Text = test.testTypetitle;
                txDescription.Text = test.testtypeDesription;
                txFees.Text = test.fees.ToString();
            }
            else
            {
                MessageBox.Show("Error in upload data", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Reset()
        {
            txTitle.Text = "";
            txDescription.Text = "";
            txFees.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEmpty() || !ValidateChildren())
                return;

            if (!IsChanged())
            {
                MessageBox.Show("No change detected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            fees = Convert.ToDecimal(txFees.Text);
            if (clsBLTestType.UpdateTestType(ID, txTitle.Text, txDescription.Text, fees))
            {
                MessageBox.Show("Updated Successfly !", "Passed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
                MessageBox.Show("Updated Failed !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void txTitle_Validating(object sender, CancelEventArgs e)
        {
            for (short i = 0; i < txTitle.Text.Length; i++)
            {
                if (char.IsDigit(txTitle.Text[i]))
                {
                    errorProvider1.SetError(txTitle, "Only word are allowed");
                    e.Cancel = true;
                    return;
                }
            }
            errorProvider1.SetError(txTitle, "");
        }

        private void txDescription_Validating(object sender, CancelEventArgs e)
        {
            for (short i = 0; i < txDescription.Text.Length; i++)
            {
                if (char.IsDigit(txDescription.Text[i]))
                {
                    errorProvider1.SetError(txDescription, "Only word are allowed");
                    e.Cancel = true;
                    return;
                }
            }
            errorProvider1.SetError(txDescription, "");
        }

        private void txFees_Validating(object sender, CancelEventArgs e)
        {
            if (!Decimal.TryParse(txFees.Text, out _))
            {
                errorProvider1.SetError(txFees, "Only digits are allowed");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txFees, "");
        }
    }
}
