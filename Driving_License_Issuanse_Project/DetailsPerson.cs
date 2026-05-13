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
    public partial class DetailsPerson : Form
    {
        int ID;
        public DetailsPerson(int id)
        {
            InitializeComponent();
            ID = id;
        }
        private void LoadInfoPerson()
        {
            ctrPersonDetials1.DetailID = ID;
        }

        private void DetailsPerson_Load(object sender, EventArgs e)
        {
            LoadInfoPerson();
        }
    }
}
