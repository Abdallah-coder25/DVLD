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
    public partial class DetailsUser : Form
    {
        int ID;
        public DetailsUser(int id)
        {
            InitializeComponent();
            ID = id;
        }
        private void LoadData()
        {
            ctrShowDetails1.DetailID = ID;
        }

        private void DetailsUser_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
