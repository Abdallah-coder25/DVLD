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
    public partial class InternationalLicenseInfo : Form
    {
        int InterLinceseID = 0;
        public InternationalLicenseInfo(int id)
        {
            InitializeComponent();
            InterLinceseID = id;
        }
        private void LoadData()
        {
            ctrInternationalLicenseInfo1.LoadData(InterLinceseID);
        }

        private void InternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
