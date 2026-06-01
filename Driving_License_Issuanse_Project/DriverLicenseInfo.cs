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
    public partial class DriverLicenseInfo : Form
    {
        int ID = 0;
        public DriverLicenseInfo(int id)
        {
            InitializeComponent();
            ID = id;
        }
        private void LoadData()
        {
            ctrDriverLicenseInfo1.LoadData(ID);
        }

        private void DriverLicenseInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
