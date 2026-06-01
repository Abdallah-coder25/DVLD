using clsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsBLLocalDrivingLicenseApplications
    {
        public int LDLAppID { get;}
        public int AppID { get;}
        public int LicenseClassID { get;}
        public clsBLLocalDrivingLicenseApplications()
        {
            this.LDLAppID = 0;
            this.AppID = 0;
            this.LicenseClassID = 0;
        }
        private clsBLLocalDrivingLicenseApplications(int LDLAppID, int AppID, int LicenseClassID)
        {
            this.LDLAppID = LDLAppID;
            this.AppID = AppID;
            this.LicenseClassID = LicenseClassID;
        }
        public static int AddLocalDrivingLicenseApplication(int AppID, int LicenseClassID)
        {
                return clsDAL.AddNewLocalDrivingLicenseApp(AppID, LicenseClassID);
        }
        public static clsBLLocalDrivingLicenseApplications InfoLocalDrivingLicenseApplication(int id)
        {
            int appID = 0, licenseClassID = 0;

            if (clsDAL.GetInfoLocalDrivingLicenseByID(id, ref appID, ref licenseClassID))
                return new clsBLLocalDrivingLicenseApplications(id, appID, licenseClassID);
            else
                return null;
        }
        public static int GetLocalLicenseID(int AppID,int LCID)
        {
            return clsDAL.LocalLicneseIDByAppIDAndLicenseClassID(AppID, LCID);
        }
        public static bool UpdateOldLicenseClasse(int id,int LCID)
        {
            return clsDAL.UpdatedLicenseClass(id, LCID);
        }
    }
}
