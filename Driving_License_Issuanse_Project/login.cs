using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using clsBusinessLayer;

namespace Driving_License_Issuanse_Project
{
    public partial class LoginScreen : Form
    {
        private string tokenFilePath = "Token.txt";
        public LoginScreen()
        {
            InitializeComponent();
        }
        private void _SaveUser()
        {
            File.WriteAllText(tokenFilePath, txName.Text);
        }
        private void _DeleteUser()
        {
            if (File.Exists(tokenFilePath))
                File.Delete(tokenFilePath);
        }
        private void LoadData()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            if (File.Exists(tokenFilePath))
            {
                txName.Text = File.ReadAllText(tokenFilePath);
                checkBox1.Checked = true;
            }

        }
        private bool IsEmpty()
        {
            return (string.IsNullOrWhiteSpace(txName.Text) || string.IsNullOrWhiteSpace(txPassword.Text));
        }
        private void btnExist_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsEmpty() || !clsBLUser.FoundUserActive(txName.Text, txPassword.Text))
            {
                
               MessageBox.Show("Invalid username or password or not active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            clsCurrentUser.currentuser = clsBLUser.CurrentUser(txName.Text, txPassword.Text);

            if (checkBox1.Checked)
                _SaveUser();
            else
                _DeleteUser();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void LoginScreen_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

