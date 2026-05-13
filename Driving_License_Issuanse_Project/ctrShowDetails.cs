using clsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Issuanse_Project
{
    public partial class ctrShowDetails : UserControl
    {
        int ID;
        clsBLUser user;
        clsBLPeople person;
        string currentImagePath;
        public ctrShowDetails()
        {
            InitializeComponent();
        }
        public int DetailID
        {
            get { return ID; }
            set
            {
                ID = value;
                _LoadInfo();
            }
        }
        private void _LoadInfo()
        {
            if (ID <= 0)
                return;

            user = clsBLUser.GETUserByPersonID(ID);
            person = clsBLPeople.GetPersonByID(ID);
            lkbEdit.Enabled = false;
            if (person != null && user != null)
            {
                lbInfoNational.Text = person.national;
                lbInfoName.Text = $"{person.firstname} {person.secondname} {person.lastname}";
                lbInfoId.Text = person.id.ToString();
                lbInfoGender.Text = person.gender == 0 ? "Male" : "female";
                lbInfoDate.Text = person.dateofbirth.ToShortDateString();
                lbInfoAddres.Text = person.adress;
                lbInfoPhone.Text = person.phone;
                lbInfoCountry.Text = clsBLPeople.GetCountryName(person.nationalcountry);
                lbInfoEmail.Text = person.email;
                lbInfoUser.Text = user.userid.ToString();
                lbInfoUserName.Text = user.username;
                lbInfoStatus.Text = user.isactive ? "Yes" : "No";
                if (!string.IsNullOrEmpty(person.imagePath) && File.Exists(person.imagePath))
                {
                    pbImage.ImageLocation = person.imagePath;
                    currentImagePath = person.imagePath;
                }
                else
                {
                    currentImagePath = "";
                    pbImage.Image = (person.gender == 0) ? Properties.Resources.Male_512 : Properties.Resources.Female_512;
                }
            }
            else
            {
                MessageBox.Show("An error occurred while loading info person or user information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }
    }
}
