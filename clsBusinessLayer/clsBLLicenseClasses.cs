using clsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsBLLicenseClasses
    {
        public enum ClassName { SmallMotorcycle = 1,HeavyMotorcycle = 2,OrdinarDriving = 3,Commercial = 4,Agricultural = 5,SmallAndMeduimBus = 6,TruckAndHeavyVehicle =7 };
        public int LicenceClasseID { get; }
        public string licneseName { get; set; }
        public string Desription { get; set; }
        public int MinimunAllowedAge { get; set; }
        public int DefaulValidityLength { get; set; }
        public Decimal ClassFees { get; set; }
        public clsBLLicenseClasses()
        {
            this.LicenceClasseID = -1;
            this.licneseName = "";
            this.Desription = "";
            this.MinimunAllowedAge = -1;
            this.DefaulValidityLength = -1;
            this.ClassFees = 0;
        }
        private clsBLLicenseClasses(int id, string className, string ClassDescription, int MinmumAllowedAge, int DefaultValiditytLength, Decimal ClassFees)
        {
            this.LicenceClasseID = id;
            this.licneseName = className;
            this.Desription = ClassDescription;
            this.MinimunAllowedAge = MinmumAllowedAge;
            this.DefaulValidityLength = DefaultValiditytLength;
            this.ClassFees = ClassFees;
        }
        public static DataTable LicenseClasses()
        {
            return clsDAL.GetLicenseClasses();
        }
        public static int GetLicenseClassIDByName(string className)
        {
            return clsDAL.GetLicenseClassIDByName(className);
        }
        public static string GetLicenseName(int Id)
        {
            return clsDAL.GetLicenseClassNameByID(Id);
        }
        public static clsBLLicenseClasses GetInfoLiceneClassByID(int id)
        {
            string className = "", ClassDp = "";
            int MinAllowedAge = 0, DefaultValidyLength = 0;
            Decimal ClassFees = 0;
            if (clsDAL.GetAllInfoLicenseClass(id, ref className, ref ClassDp, ref MinAllowedAge, ref DefaultValidyLength, ref ClassFees))
                return new clsBLLicenseClasses(id, className, ClassDp, MinAllowedAge, DefaultValidyLength, ClassFees);
            else
                return null;
        }
    }
}
