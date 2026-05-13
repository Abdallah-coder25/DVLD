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
    public partial class UpdateTestType : Form
    {
        int ID = 0;
        public UpdateTestType(int id)
        {
            InitializeComponent();
            ID = id;
        }
        private void CalleUserControle()
        {
            ctrTestType1.TypeID = ID;
        }
        private void UpdateTestType_Load(object sender, EventArgs e)
        {
            CalleUserControle();
        }
    }
}
