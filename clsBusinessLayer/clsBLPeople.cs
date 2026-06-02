using clsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsBLPeople
    {
        public int id { get; }
        public string national { get; set; }
        public string firstname { get; set; }
        public string secondname { get; set; }
        public string thirdname { get; set; }
        public string lastname { get; set; }
        public DateTime dateofbirth { get; set; }
        public int gender { get; set; }
        public string adress { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int nationalcountry { get; set; }
        public string imagePath { get; set; }
        public clsBLPeople()
        {
            this.id = -1;
            this.national = "";
            this.firstname = "";
            this.secondname = "";
            this.thirdname = "";
            this.lastname = "";
            this.dateofbirth = DateTime.Now;
            this.gender = 0;
            this.adress = "";
            this.email = "";
            this.imagePath = "";
        }
        private clsBLPeople(int id, string national, string firstname, string secondname, string thirdname, string lastname, DateTime dateofbirth, int gendor, string adress, string phone, string email, int Nationalcountry, string imagePath)
        {
            this.id = id;
            this.national = national;
            this.firstname = firstname;
            this.secondname = secondname;
            this.thirdname = thirdname;
            this.lastname = lastname;
            this.dateofbirth = dateofbirth;
            this.gender = gendor;
            this.adress = adress;
            this.phone = phone;
            this.email = email;
            this.nationalcountry = Nationalcountry;
            this.imagePath = imagePath;
        }


        //People
        public static DataTable GetInfoPeople()
        {
            return clsDAL.GetAllInfoPeople();
        }
        public static bool IsPErsonUsed(int id)
        {
            return clsDAL.IsPersontUsed(id);
        }
        public static clsBLPeople GetPersonByID(int id)
        {
            string national = "", firstname = "", secondname = "", thirdname = "", lastname = "", adress = "", email = "", phone = "", imagePath = "";
            DateTime dateofbirth = DateTime.Now;
            int gendor = 0, Nationalcountry = 0;

            if (clsDAL.FoundPersonByID(id, ref national, ref firstname, ref secondname, ref thirdname, ref lastname, ref dateofbirth, ref gendor, ref adress, ref phone, ref email, ref Nationalcountry, ref imagePath))
                return new clsBLPeople(id, national, firstname, secondname, thirdname, lastname, dateofbirth, gendor, adress, phone, email, Nationalcountry, imagePath);
            else
                return null;

        }
        public static bool AddPerson(string nat, string fn, string sn, string ln, DateTime db, int g, string a, string p, int natc, string ip, string e = "", string tn = "")
        {
            return clsDAL.AddNewPerson(nat, fn, sn, ln, db, g, a, p, natc, ip, e, tn);
        }
        public static bool Update(int ID, string nat, string fn, string sn, string ln, DateTime db, int g, string a, string p, int natc, string ip, string e, string tn = "")
        {
            return clsDAL.UpdatePeople(ID, nat, fn, sn, ln, db, g, a, p, natc, ip,e,tn);
        }
        public static bool Delete(int id)
        {
            return clsDAL.DeletePeople(id);
        }
        public static int GetPersonIdByNationalNumber(string nat)
        {
            return clsDAL.GetPersonIdByNationalNumber(nat);
        }
        public static string GetCountryName(int id)
        {
            return clsDAL.GetCountryNameByID(id);
        }        
        public static bool UpdateImage(int id,string image)
        {
            return clsDAL.UpdateImage(id, image);
        }


        //Countries
        public static DataTable GetCountries()
        {
            return clsDAL.GetAllCountrie();
        }

       
    }
}
