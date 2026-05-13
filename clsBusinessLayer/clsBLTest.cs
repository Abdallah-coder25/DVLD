using clsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsBLTest
    {
        public int TestID { get; }
        public int TestAppointmentID { get; set; }
        public int TestResult { get; set; }
        public string Note { get; set; }
        public int CreatedUser { get; set; }
        public clsBLTest()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = -1;
            this.Note = "";
            this.CreatedUser = -1;
        }
        private clsBLTest(int testID, int testAppointmentID, int testResult, string note, int createdUser)
        {
            TestID = testID;
            TestAppointmentID = testAppointmentID;
            TestResult = testResult;
            Note = note;
            CreatedUser = createdUser;
        }
        public static int AddNewTest(int TestAppointmentID, bool TestResult, int CreatedUserID, string Note = "")
        {
            return clsDAL.AddNewTest(TestAppointmentID, TestResult, CreatedUserID, Note);
        }
        public static bool NotYetTested(int idTestAppo)
        {
            return clsDAL.NoYetTestedByTAppoID(idTestAppo);
        }
        public static bool HasFailedInTest(int LDALID,int TestType)
        {
            return clsDAL.HasFailedTestByLocalDrivingID(LDALID, TestType);
        }
        public static bool HasPassed(int ldID, int testTypeid)
        {
            return clsDAL.HasPassedTest(ldID, testTypeid);
        }
    }
}
