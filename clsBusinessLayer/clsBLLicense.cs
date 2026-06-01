using clsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsBLLicense
    {
        public enum IsssueReasson { FirstTime = 1, RenewLicense = 2, ReplacmentOfdameged = 3, ReplacmentForLost = 4 };
        public int LicenseID { get; }
        public int AppID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public IsssueReasson issueReason { get; set; }
        public int CreatingUser { get; set; }
        public string Note { get; set; }
        public clsBLLicense()
        {
            this.LicenseID = -1;
            this.AppID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.IssueDate = DateTime.Now;
            this.ExpirationDate = DateTime.Now;
            this.PaidFees = 0;
            this.IsActive = false;
            this.issueReason = (IsssueReasson)(-1);
            this.CreatingUser = -1;
            this.Note = "";
        }
        private clsBLLicense(int LicenseID, int AppID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate, Decimal PaidFees, bool IsActive, int issuereason, int CreatingUser, string Note)
        {
            this.LicenseID = LicenseID;
            this.AppID = AppID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            this.issueReason = (IsssueReasson)(issuereason);
            this.CreatingUser = CreatingUser;
            this.Note = Note;
        }
        public static int AddNewLicense(int AppID, int DrID, int LC, DateTime issueDate, DateTime ExpirationDate, Decimal PaidFees, bool Active, int IssueReason, int CreatingUser, string Note = "")
        {
            return clsDAL.AddNewLicense(AppID, DrID, LC, issueDate, ExpirationDate, PaidFees, Active, IssueReason, CreatingUser, Note);
        }
        public static bool HasLicense(int PersonID, int licenseClasssID)
        {
            return clsDAL.HasLicense(PersonID, licenseClasssID);
        }
        public static clsBLLicense GetInfoLicenseByDIdAndLCID(int AppID,int DriverID, int LicenseClassID)
        {
            int LicenseID = 0, IssueReason = 0, CreatingUser = 0;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            Decimal PaidFees = 0;
            bool IsActive = false;
            string Note = "";
            if (clsDAL.GetInfoLicenseByDriverIDAndLicenseClassID(ref LicenseID, AppID, DriverID, LicenseClassID, ref IssueDate, ref ExpirationDate, ref PaidFees, ref IsActive, ref IssueReason, ref CreatingUser, ref Note))
            {
                return new clsBLLicense(LicenseID, AppID, DriverID, LicenseClassID, IssueDate, ExpirationDate, PaidFees, IsActive, IssueReason, CreatingUser, Note);
            }
            else
            {
                return null;
            }
        }
        public static DataTable GEtAllInfoForOneLicense(int DriverID)// int LicenseClassID)
        {
            return clsDAL.GetInfoByDriverIDAndLicenseClassID(DriverID);// LicenseClassID);
        }
        public static clsBLLicense GetInfoLicenseByLicenseID(int LicenseID)
        {
            int DriverID = 0, AppID = 0, LicenseClassID = 0, IssueReason = 0, CreatingUser = 0;
            DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
            Decimal PaidFees = 0;
            bool IsActive = false;
            string Note = "";
            if (clsDAL.GetInfoLicenseByLicenseID(LicenseID, ref AppID, ref DriverID, ref LicenseClassID, ref IssueDate, ref ExpirationDate, ref PaidFees, ref IsActive, ref IssueReason, ref CreatingUser, ref Note))
                return new clsBLLicense(LicenseID, AppID, DriverID, LicenseClassID, IssueDate, ExpirationDate, PaidFees, IsActive, IssueReason, CreatingUser, Note);
            else
                return null;

        }
        public static bool FoundLicenseByLicenseID(int id)
        {
            return clsDAL.IsFoundLicense(id);
        }
        public static bool IsLicenseActiveAndNotExpired(int LicenseID)
        {
            return clsDAL.LicenseIsActiveAndNotExpired(LicenseID);
        }
        public static bool IsLicenseExpired(int LicenseID)
        {
            return clsDAL.LicenseExpiret(LicenseID);
        }
        public static bool ConvertLicenseToInactive(int LicenseID)
        {
            return clsDAL.ConvertingLicenseToInactive(LicenseID);
        }
        public static int LastLicenseIDByDriverIDAndLicenseClassID(int driverID,int lcID)
        {
            return clsDAL.GetLastLicenseIDByDriverIDAndClassID(driverID, lcID);
        }
        public static bool LicenseIsActive(int LicenseID)
        {
            return clsDAL.checkActiveLicense(LicenseID);
        }
    }
}
