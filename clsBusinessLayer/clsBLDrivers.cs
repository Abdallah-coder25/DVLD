using clsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsBLDrivers
    {
        public int DriverID { get; }
        public int PersonID { get; set; }
        public int createdUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public clsBLDrivers()
        {
            this.DriverID = -1;
            this.PersonID = -1;
            this.createdUser = -1;
            this.CreatedDate = DateTime.Now;
        }
        private clsBLDrivers(int DreiverID,int PersonId,int CreatedUser,DateTime CreatedDate)
        {
            this.DriverID = DreiverID;
            this.PersonID = PersonId;
            this.createdUser = createdUser;
            this.CreatedDate = CreatedDate;
        }
        public static bool IsPersonFound(int id)
        {
            return clsDAL.IsPersonDriver(id);
        }
        public static int GetDrivierIdByPersonID(int id)
        {
            return clsDAL.GetDriversIdByPersonID(id);
        }
        public static int AddNewDrivers(int personID,int createdUserID,DateTime date)
        {
            return clsDAL.AddNewDrivers(personID, createdUserID, date);
        }
    }
}
