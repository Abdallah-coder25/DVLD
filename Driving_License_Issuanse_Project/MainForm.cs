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
    public partial class MainForm : Form
    {
       LoginScreen _frmLogin;
        public MainForm(LoginScreen frm)
        {
            InitializeComponent();
            _frmLogin = frm;
        }
        private void OpenFormInPanel(Form form)
        {
            panel1.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panel1.Controls.Add(form);
            panel1.Tag = form;

            form.Show();
        }
        private void peoplesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new ManagePeople());
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new ManageUsers());
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ChangePassword change = new ChangePassword(clsCurrentUser.currentuser.personid);
            change.ShowDialog();
        }

        private void currentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetailsUser user = new DetailsUser(clsCurrentUser.currentuser.personid);
            user.ShowDialog();
        }
        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to logout?","Logout",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                clsCurrentUser.currentuser = null;
                _frmLogin.Show();
                this.Close();
            }
            else
                return;
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new NewLocalDrivingLicense());
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new ManageApplicationTypes());
        }

        private void localDrivingLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new ManageLocalDrivingLicense());
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new ManageTestType());
        }
    }
}
