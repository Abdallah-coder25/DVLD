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
    public partial class UpdateApplication : Form
    {
        int ID;
        public UpdateApplication(int id)
        {
            InitializeComponent();
            ID = id;
        }
        private void CalleUserControl()
        {
            ctrEditApplicationType1.TypeID = ID;
        }

        private void UpdateApplication_Load(object sender, EventArgs e)
        {
            CalleUserControl();
        }
    }
}
