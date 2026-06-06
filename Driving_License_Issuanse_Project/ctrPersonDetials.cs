using clsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Driving_License_Issuanse_Project
{
    public partial class ctrPersonDetials : UserControl
    {
        int ID;
        clsBLPeople person;
        string currentImagePath;
        public ctrPersonDetials()
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

            person = clsBLPeople.GetPersonByID(ID);
            if (person != null)
            {
                lbInfoNational.Text = person.national;
                lbInfoName.Text = $"{person.firstname} {person.secondname}\n {person.lastname}";
                lbInfoId.Text = person.id.ToString();
                lbInfoGender.Text = person.gender == 0 ? "Male" : "female";
                lbInfoDate.Text = person.dateofbirth.ToShortDateString();
                lbInfoAddres.Text = person.adress;
                lbInfoPhone.Text = person.phone;
                lbInfoCountry.Text = clsBLPeople.GetCountryName(person.nationalcountry);
                lbInfoEmail.Text = person.email;
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
                MessageBox.Show("An error occurred while loading info person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void lkbEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ModeOfPerosn mode = new ModeOfPerosn(person.id);
            mode.ShowDialog();
            _LoadInfo();
        }
    }
}

