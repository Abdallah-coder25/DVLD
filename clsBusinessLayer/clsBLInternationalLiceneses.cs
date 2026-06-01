using clsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsBLInternationalLiceneses
    {
        public int InternationalLicenseID { get; }
        public int AppID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool Active { get; set; }
        public int CreatedByUserID { get; set; }


        public clsBLInternationalLiceneses()
        {
            this.IssuedUsingLocalLicenseID = -1;
            this.AppID = -1;
            this.DriverID = -1;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.Active = false;
            this.CreatedByUserID = -1;
        }
        private clsBLInternationalLiceneses(int InternationalLicenseID, int AppID, int DriverID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool Active, int CreatedByUserID)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.AppID = AppID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Active = Active;
            this.CreatedByUserID = CreatedByUserID;
        }
        public static int AddIternationalLicense(int AppID, int DrID, int IssuedUsingLocalLicenseID, DateTime IssueDate, DateTime ExpirationDate, bool Active, int CreatingUser)
        {
            return clsDAL.AddNewInternationalLicense(AppID, DrID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, Active, CreatingUser);

        }
        public static clsBLInternationalLiceneses GetInfoInternationalLicense(int id)
        {
            int AppID= 0, DrID = 0, IssuedUsingLocalLicenseID = 0, CreatedByUserID = 0;
            DateTime IssueDate = DateTime.MinValue, ExpirationDate = DateTime.MinValue;
            bool Active = false;
            if(clsDAL.GetInfoInternationalLicenseByID(id, ref AppID, ref DrID, ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate, ref Active, ref CreatedByUserID))
                return new clsBLInternationalLiceneses(id, AppID, DrID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, Active, CreatedByUserID);
            else
                return null;
        }
        public static DataTable GetInternationalLicenseByDriverID(int id)
        {
            return clsDAL.GetInfoInternationalLicenseByDriverID(id);
        }
        public static bool hasInternationalLicense(int id)
        {
            return clsDAL.PreExistingInternationalLicense(id);
        }
        public static DataTable GetAllInternationLicense()
        {
            return clsDAL.GetAllInternationalLicense();
        }
    }
}
