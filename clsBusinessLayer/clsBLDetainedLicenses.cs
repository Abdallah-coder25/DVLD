using clsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsBLDetainedLicenses
    {
        public int DetainID { get; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public Decimal FineFees { get; set; }
        public int CreatedByUser { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleasedDate {get;set;}
        public int ReleasedByUserID { get; set; }
        public int ReleasedByAppID { get; set; }

        public clsBLDetainedLicenses()
        {
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.MinValue;
            this.FineFees = 0;
            this.CreatedByUser = -1;
            this.ReleasedDate = DateTime.MinValue;
            this.ReleasedByUserID = -1;
            this.ReleasedByAppID = -1;
        }
        private clsBLDetainedLicenses(int id,int licenseid,DateTime dateinDate,decimal fees,int createdByUserid,bool isReleased,DateTime releasedate,int releasedByUserid,int releasedByappid)
        {
            this.DetainID = id;
            this.LicenseID = licenseid;
            this.DetainDate = dateinDate;
            this.FineFees = fees;
            this.CreatedByUser = createdByUserid;
            this.IsReleased = isReleased;
            this.ReleasedDate = releasedate;
            this.ReleasedByUserID = releasedByUserid;
            this.ReleasedByAppID = releasedByappid;
        }
        public static int AddDetain( int licenseid, DateTime dateinDate, decimal fees, int createdByUserid, bool isReleased)
        {
            return clsDAL.AddNewDetainLicese(licenseid, dateinDate, fees, createdByUserid, isReleased);
        }
        public static bool TheLicenseIsReserved(int LicenseID)
        {
            return clsDAL.IsLicenseDetained(LicenseID);
        }
        public static clsBLDetainedLicenses GetInfoDetainLicense(int id)
        {
            int LicenseID = 0, createdByUserID = 0, releasedByUserID = 0, releasedApplicationID = 0;
            DateTime detainDate = DateTime.MinValue, releasedDate = DateTime.MinValue;
            Decimal Fees = 0;
            bool IsReleased = false;
            if (clsDAL.GetInfoDetainLicense(id, ref LicenseID, ref detainDate, ref Fees, ref createdByUserID, ref IsReleased, ref releasedDate, ref releasedByUserID, ref releasedApplicationID))
                return new clsBLDetainedLicenses(id, LicenseID, detainDate, Fees, createdByUserID, IsReleased, releasedDate, releasedByUserID, releasedApplicationID);
            else
                return null;
            
        }
        public static bool ReleaseDetainedLicense(int LicenseID,int ReleasedUserID,int ReleasedAppID)
        {
            return clsDAL.LicenseRelease(LicenseID ,ReleasedUserID, ReleasedAppID);
        }
        public static clsBLDetainedLicenses GetInfoDetainLicenseByLicenseID(int LicenseID)
        {
            int DetainID = 0, createdByUserID = 0, releasedByUserID = 0, releasedApplicationID = 0;
            DateTime detainDate = DateTime.MinValue, releasedDate = DateTime.MinValue;
            Decimal Fees = 0;
            bool IsReleased = false;
            if (clsDAL.GetLastDetainInfoByLicenseID(LicenseID, ref DetainID, ref detainDate, ref Fees, ref createdByUserID,ref IsReleased, ref releasedDate, ref releasedByUserID, ref releasedApplicationID))
                return new clsBLDetainedLicenses(DetainID, LicenseID, detainDate, Fees, createdByUserID, IsReleased, releasedDate, releasedByUserID, releasedApplicationID);
            else
                return null;

        }
    }
}
