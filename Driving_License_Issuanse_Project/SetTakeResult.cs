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
    public partial class SetTakeResult : Form
    {
        int ID = 0;
        int TypeTest = 0;
        public SetTakeResult(int id,int Type)
        {
            InitializeComponent();
            ID = id;
            TypeTest = Type;
        }
        private void LoadData()
        {
            ctrConductTheTest1.LoadData(ID,TypeTest);

        }
        private void SetTakeResult_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
