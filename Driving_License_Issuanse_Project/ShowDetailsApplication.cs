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
    public partial class ShowDetailsApplication : Form
    {
        int ID = 0;
        public ShowDetailsApplication(int id)
        {
            InitializeComponent();
            ID = id;
        }
        private void LoadData()
        {
            ctrApplicationDetails1.DetailsID = ID;
        }

        private void ShowDetailsApplication_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
