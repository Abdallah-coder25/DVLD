using clsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsBLApllicationType
    {
        public  enum ApplicationType 
        {
            NewLocalDrivingLicense = 1,
            RenewLocalDrivingLicense = 2,
            ReplacementForLostDrivingLicense = 3,
            ReplacementForDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicense = 5,
            NewInternationalLicense = 6
        }
        public ApplicationType applicationid { get;}
        public string applicationTitletype { get; set; }
        public Decimal fees { get; set; }
        public clsBLApllicationType()
        {
            this.applicationid = (ApplicationType)(-1);
            this.applicationTitletype = "";
            this.fees = 0;
        }
        private clsBLApllicationType(int applicationid, string applicationtype, Decimal fees)
        {
            this.applicationid = (ApplicationType)applicationid;
            this.applicationTitletype = applicationtype;
            this.fees = fees;
        }
        public static DataTable GetInfoOfApplicationTyes()
        {
            return clsDAL.GetAllInfoApplicationTypes();
        }
        public static clsBLApllicationType GetInformation(int id)
        {
            string type = "";
            Decimal fees = 0;
            if (clsDAL.GetApplicationTypeOfId(id, ref type, ref fees))
                return new clsBLApllicationType(id, type, fees);
            else
                return null;
        }
        public static bool UpdateApplicationType(int id, string type, Decimal fees)
        {
            return clsDAL.UpdateNameOfTypeOrFess(id, type, fees);
        }

    }
}
