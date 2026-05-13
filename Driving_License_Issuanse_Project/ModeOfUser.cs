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
    public partial class ModeOfUser : Form
    {
        int ID;
        public ModeOfUser(int id)
        {
            InitializeComponent();
            ID = id;
        }
        public void UpdateUser()
        {
            ctrUser1.UserID = ID;
        }

        private void ModeOfUser_Load(object sender, EventArgs e)
        {
            UpdateUser();
        }
    }
}
