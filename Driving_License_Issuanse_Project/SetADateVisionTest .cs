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
    public partial class SetADateVisionTest : Form
    {
        int ID = 0;
        int TypeTest = 0;
        string Mode = "";

        public delegate void DataBackEventHandler(object sender, int TestAppointmentID);
        public event DataBackEventHandler DataBack;

        private void CheckMode(int id,string mode,int type)
        {
            if (string.Equals(mode, "Add", StringComparison.OrdinalIgnoreCase))
                ctrScheduleTest1.SetAdd(ID,type);

            else if(string.Equals(mode, "Edit", StringComparison.OrdinalIgnoreCase))
                ctrScheduleTest1.SetEdit(ID,type);

            else
                ctrScheduleTest1.SetRenew(ID,type);
        }

        public SetADateVisionTest(int id,string mode,int type)
        {
            InitializeComponent();
            ID = id;
            Mode = mode;
            TypeTest = type;
        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            if(Mode == "Add")
            {
                DataBack?.Invoke(this, ctrScheduleTest1.newTestAppointmentId);
            }
            else
            {
                DataBack ?.Invoke(this, ID);
            }
            this.Close();
        }

        private void SetADateVisionTest_Load(object sender, EventArgs e)
        {
            CheckMode(ID, Mode,TypeTest);
        }
    }
}
