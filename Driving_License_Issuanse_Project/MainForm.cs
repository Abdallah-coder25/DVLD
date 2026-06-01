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
      // LoginScreen _frmLogin;
      private  bool _isLoggingOut = false;
        public MainForm()
        {
            InitializeComponent();
            //_frmLogin = frm;
            this.FormClosing += MainForm_FormClosing;
        }
        
        private void OpenFormInPanel(Form form)
        {
            panel1.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;

            panel1.Controls.Add(form);

            form.StartPosition = FormStartPosition.Manual;

            form.Location = new Point(
                (panel1.Width - form.Width) / 2,
                (panel1.Height - form.Height) / 2
            );

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
            DialogResult result = MessageBox.Show( "Do you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                clsCurrentUser.currentuser = null;
                _isLoggingOut = true;
                this.Close();
            }
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

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new ManageDrivers());

        }

        private void internationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // OpenFormInPanel(new ShowInternationalLicenseApp());
            OpenFormInPanel(new ManageInternationalLicenses());
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new RenewLicenseApplication());
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new ReplacmentForDamagedLicense());
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new ManageLocalDrivingLicense());
        }

        private void detainLicenseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new DetainLicense());
        }

        private void releaseDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new ReleaseDetain());
        }

        private void manageDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new ManageDetainLicenses());
        }

        private void detainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new ReleaseDetain());
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new ShowInternationalLicenseApp());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isLoggingOut)
                Application.Exit();
        }
    }
}
