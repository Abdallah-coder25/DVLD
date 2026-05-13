using clsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsBLApplication
    {
        public int AppID { get; }
        public int appPersonId { get; set; }
        public int appTypeId { get; set; }
        public DateTime appDate { get; set; }
        public enum appStatus { New =1, Canceled = 2, Completed = 3 }
        public appStatus status { get; set; }
        public DateTime lastStatusDate { get; set; }
        public Decimal paidFees { get; set; }
        public int usercreated { get; set; }

        public clsBLApplication()
        {
            this.AppID = -1;
            this.appPersonId = -1;
            this.appTypeId = -1;
            this.appDate = DateTime.Now;
            this.status = appStatus.New;
            this.lastStatusDate = DateTime.Now;
            this.paidFees = 0;
            this.usercreated = -1;
        }
        private clsBLApplication(int AppID,int appPersonId, DateTime appDate, int appTypeId, appStatus status, DateTime lastStatusDate, Decimal paidFees, int usercreated)
        {
            this.AppID = AppID;
            this.appPersonId = appPersonId;
            this.appTypeId = appTypeId;
            this.appDate = appDate;
            this.status = status;
            this.lastStatusDate = lastStatusDate;
            this.paidFees = paidFees;
            this.usercreated = usercreated;
        }
        public static int AddApplication(int personID, DateTime date, int apptypeid, int applicationStatus, DateTime laststatusdate, decimal Paidfees, int CreateByUser)
        {
            return clsDAL.AddNewApplication( personID, date,apptypeid,applicationStatus,laststatusdate, Paidfees,CreateByUser);
        }
        public static bool HasActiveApplication(int personID,int licenseClassID)
        {
            return clsDAL.HasActiveApplication(personID,licenseClassID);
        }
        public static bool CancelApplication(int ldlAppID)
        {
            return clsDAL.ConvertingNewRequestToCanceled(ldlAppID);
        }
        public static clsBLApplication infoApplication(int id)
        {
            int IDperson = 0, IdAppType = 0,StatusApp = 0 ,UserCreating = 0;
            DateTime OneDate = DateTime.Now, LastDate = DateTime.Now;
            Decimal Fees = 0;

            if (clsDAL.GetInfoApplicationByID(id, ref IDperson, ref OneDate, ref IdAppType, ref StatusApp, ref LastDate, ref Fees, ref UserCreating))
                return new clsBLApplication(id, IDperson, OneDate, IdAppType, (appStatus)StatusApp, LastDate, Fees, UserCreating);
            else 
                return null;
            
        }
        public static bool CompletedRequest(int id)
        {
            return clsDAL.UpdateRequestToCompleted(id);
        }
    }
}
