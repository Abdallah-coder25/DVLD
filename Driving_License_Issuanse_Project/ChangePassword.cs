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
    public partial class ChangePassword : Form
    {
        int ID;
        clsBLUser user;
        public ChangePassword(int id)
        {
            InitializeComponent();
            ID = id;
        }
        private void _LoadData()
        {
            if (ID <= 0)
                return;

            user = clsBLUser.GETUserByPersonID(ID);
            if (user == null)
            {
                MessageBox.Show("User Not Found !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrShowDetails1.DetailID = ID;
        }
        private bool _WrongInInformation()
        {
            if (string.IsNullOrEmpty(txCurent.Text) || string.IsNullOrEmpty(txPass.Text) || string.IsNullOrEmpty(txConf.Text))
            {
                MessageBox.Show("fill is impty or Wrong in Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_WrongInInformation())
            {
                return;
            }
            if (!this.ValidateChildren())
                return;
            if (user.password != txCurent.Text)
            {
                MessageBox.Show("Current password is incorrect");
                return;
            }
            if (clsBLUser.ChangePassword(user.userid, txPass.Text))
            {
                MessageBox.Show("Password changed successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Change failed!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Reset()
        {
            txCurent.Text = string.Empty;
            txPass.Text = string.Empty;
            txConf.Text = string.Empty;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void txCurent_Validating(object sender, CancelEventArgs e)
        {
            if (txCurent.Text != user.password)
            {
                errorProvider1.SetError(txCurent, "Enter the correct password");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txCurent, "");
        }

        private void txPass_Validating(object sender, CancelEventArgs e)
        {
            if (txPass.Text == user.password || string.IsNullOrWhiteSpace(txPass.Text))
            {
                errorProvider1.SetError(txPass, "Enter a new password");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txPass, "");
        }

        private void txConf_Validating(object sender, CancelEventArgs e)
        {
            if (txConf.Text != txPass.Text)
            {
                errorProvider1.SetError(txConf, "Confirm the new password");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txConf, "");
        }
    }
}
