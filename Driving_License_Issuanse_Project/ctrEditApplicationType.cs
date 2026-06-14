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
    public partial class ctrEditApplicationType : UserControl
    {
        int ID;
        clsBLApllicationType application;
        decimal fees;
        public ctrEditApplicationType()
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
            if (txType.Text == "" || txFees.Text == "")
            {
                MessageBox.Show("Please fill in all the boxes");
                return true;
            }
            return false;
        }
        private bool IsChanged()
        {
            if (application == null)
                return false;

            if (!decimal.TryParse(txFees.Text, out decimal newFees))
                return false;

            return (txType.Text != application.applicationTitletype || newFees != application.fees);
        }
        private void LoadInformation()
        {
            if (ID <= 0)
                return;

            application = clsBLApllicationType.GetInformation(ID);
         
            if (application != null)
            {
                lbvalue.Text = application.applicationTypeid.ToString();
                txType.Text = application.applicationTitletype;
                txFees.Text = application.fees.ToString();
            }
            else
            {
                MessageBox.Show("Error in upload data", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Reset()
        {
            txType.Text = "";
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
            if (clsBLApllicationType.UpdateApplicationType(ID, txType.Text, fees))
            {
                MessageBox.Show("Updated Successfly !", "Passed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
                MessageBox.Show("Updated Failed !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Reset();
           
        }

        private void txType_Validating(object sender, CancelEventArgs e)
        {
            if (!txType.Text.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                errorProvider1.SetError(txType, "Only letters are allowed");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txType, "");
        }

        private void txFees_Validating(object sender, CancelEventArgs e)
        {
            decimal temp;
            {
                if (!Decimal.TryParse(txFees.Text, out temp))
                {
                    errorProvider1.SetError(txFees, "Only digits are allowed");
                    e.Cancel = true;
                }
                else
                    errorProvider1.SetError(txFees, "");
            }
        }
    }
}
