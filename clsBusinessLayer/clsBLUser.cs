using clsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsBLUser
    {
        public int userid { get; }
        public int personid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool isactive { get; set; }
        public clsBLUser()
        {
            this.userid = -1;
            this.personid = 0;
            this.username = "";
            this.password = "";
            this.isactive = false;
        }
        private clsBLUser(int userid, int personid, string username, string password, bool isactive)
        {
            this.userid = userid;
            this.personid = personid;
            this.username = username;
            this.password = password;
            this.isactive = isactive;
        }
        public static DataTable GetInfoUsers()
        {
            return clsDAL.GetAllInfoUsers();
        }
        public static bool UserUsed(int id)
        {
            return clsDAL.UserUsed(id);
        }
        public static bool FoundUserActive(string username, string password)
        {
            return clsDAL.IsUserFoundAndActive(username, password);
        }
        public static clsBLUser GetUser(int id)
        {
            string name = "", password = "";
            int personid = 0;
            bool active = false;

            if (clsDAL.GetUserByID(id, ref personid, ref name, ref password, ref active))
                return new clsBLUser(id, personid, name, password, active);
            else
                return null;

        }
        public static bool Add(int peronid, string name, string password, bool active)
        {
            return clsDAL.AddNewUser(peronid, name, password, active);
        }
        public static bool Update(int ID, int personid, string name, string password, bool active)
        {
            return clsDAL.UpdateUser(ID, personid, name, password, active);
        }
        public static bool Delete(int id)
        {
            return clsDAL.DeleteUser(id);
        }
        public static bool IsPeopleIsUser(int id)
        {
            return clsDAL.IsPeopleIsUSer(id);
        }
        public static clsBLUser GETUserByPersonID(int id)
        {
            string name = "", password = "";
            int userid = 0;
            bool active = false;
            if (clsDAL.GetUserByPersonId(id, ref userid, ref name, ref password, ref active))
            {
                return new clsBLUser(userid, id, name, password, active);
            }
            else
            {

                return null;
            }
        }
        public static clsBLUser CurrentUser(string name, string password)
        {
            int userid = 0, personid = 0;
            bool active = false;
            if (clsDAL.GetCurrentUser(name, password, ref userid, ref personid, ref active))
            {
                return new clsBLUser(userid, personid, name, password, active);
            }
            else
            {
                return null;
            }
        }
        public static bool ChangePassword(int id, string newPassword)
        {
            return clsDAL.UpdatePassword(id, newPassword);
        }
    }
}
