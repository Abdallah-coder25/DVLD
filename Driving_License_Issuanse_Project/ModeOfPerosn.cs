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
    public partial class ModeOfPerosn : Form
    {
        int ID;
        public ModeOfPerosn(int id)
        {
            InitializeComponent();
            ID = id;
        }
        private void UpdateInfo()
        {
            ctrPerson1.id = ID;
        }

        private void ModeOfPerosn_Load(object sender, EventArgs e)
        {
            UpdateInfo();
        }
    }
}
