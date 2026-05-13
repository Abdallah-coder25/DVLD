using clsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsBLTestType
    {
        public enum TestType { VisionTest = 1,WrittenTest =2,Street = 3};
        public TestType testtypeid { get; set; }
        public string testTypetitle { get; set; }
        public string testtypeDesription { get; set; }
        public Decimal fees { get; set; }
        public clsBLTestType()
        {
            this.testtypeid = (TestType)(-1);
            this.testTypetitle = "";
            this.testtypeDesription = "";
            this.fees = 0;
        }
        private clsBLTestType(int id, string title, string description, Decimal fees)
        {
            this.testtypeid = (TestType)(id);
            this.testTypetitle = title;
            this.testtypeDesription = description;
            this.fees = fees;
        }
        public static DataTable GetInfoOfTestTyes()
        {
            return clsDAL.GetAllInfoTestTypes();
        }
        public static clsBLTestType GetInformationOfOneTestType(int id)
        {
            string type = "";
            string Description = "";
            Decimal fees = 0;
            if (clsDAL.GetTestTypeOfId(id, ref type, ref Description, ref fees))
                return new clsBLTestType(id, type, Description, fees);
            else
                return null;
        }
        public static bool UpdateTestType(int id, string type, string Description, Decimal fees)
        {
            return clsDAL.UpdateInfoforTestType(id, type, Description, fees);
        }
    }
}
