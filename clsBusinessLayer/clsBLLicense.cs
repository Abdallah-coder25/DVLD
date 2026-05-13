using clsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsBLLicense
    {
        public enum IsssueReasson { FirstTime = 1,RenewLicense = 2,ReplacmentOfdameged =3,ReplacmentForLost = 4};

        public static int AddNewLicense(int AppID, int DrID, int LC, DateTime issueDate, DateTime ExpirationDate, Decimal PaidFees, bool Active, int IssueReason, int CreatingUser, string Note = "")
        {
            return clsDAL.AddNewLicense(AppID, DrID, LC, issueDate, ExpirationDate, PaidFees, Active, IssueReason, CreatingUser, Note);
        }
        public static bool HasLicense(int PersonID,int licenseClasssID)
        {
            return clsDAL.HasLicense(PersonID, licenseClasssID);
        }
    }
}
