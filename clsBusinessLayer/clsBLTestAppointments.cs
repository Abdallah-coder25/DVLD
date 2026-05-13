using clsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsBLTestAppointments
    {
        public int TestAppointmentId { get; }
        public int TestTypeId { get; set; }
        public int LocalDrivingId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Decimal PaidFees { get; set; }
        public int UserCreating { get; set; }
        public bool Locked { get; set; }

        public clsBLTestAppointments()
        {
            this.TestAppointmentId = -1;
            this.TestTypeId = -1;
            this.LocalDrivingId = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.UserCreating = -1;
            this.Locked = false;
        }
        private clsBLTestAppointments(int TestAppointmentId, int TestTypeId, int LocalDrivingId, DateTime AppointmentDate,Decimal PaidFees,int UserCreating, bool Locked)
        {
            this.TestAppointmentId = TestAppointmentId;
            this.TestTypeId = TestTypeId;
            this.LocalDrivingId = LocalDrivingId;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.UserCreating = UserCreating;
            this.Locked = Locked;
        }
        public static DataTable GetAvaibleInfoTestAppointmentByLocalDrIDANDTestTypeID(int ldalid,int ttypid)
        {
            return clsDAL.AvaibleInfoByLDALIDANDTestTypeID(ldalid, ttypid);
        }
        public static int AddNewTestAppointment(int TestTypeId, int LocalDrivingId, DateTime AppointmentDate, Decimal PaidFees, int UserCreating, bool Locked)
        {
            return clsDAL.AddNewTestAppointmentByTestAppoID(TestTypeId, LocalDrivingId, AppointmentDate, PaidFees, UserCreating, Locked);
        } 
        public static bool UpdatedToLocked(int id)
        {
            return clsDAL.ConvertingTestAppointmentToLockedByTestAppoiID(id);
        }
        public static clsBLTestAppointments GetAllInfoTestAppointmentByID(int id)
        {
            int TestTypeid = 0, localDrivingLID = 0, UserCreating = 0;
            DateTime AppoDate = DateTime.Now;
            Decimal fees = 0;
            bool locked = false;
            if (clsDAL.GetAllInfoTestAppointmenByTestAppoID(id, ref TestTypeid, ref localDrivingLID, ref AppoDate, ref fees, ref UserCreating, ref locked))
                return new clsBLTestAppointments(id, TestTypeid, localDrivingLID, AppoDate, fees, UserCreating, locked);
            else
                return null;
        }

        public static bool UpdateDate(int id , DateTime dt)
        {
            return clsDAL.UpdateDateByTestAppoID(id, dt);
        }
        public static bool IsLocked(int id)
        {
            return clsDAL.IsLocked(id);
        }
       public static bool IsFirstTest(int TAppoId,int LDALID,int TyTestID)
        {
            return clsDAL.IsFirstTest(TAppoId, LDALID, TyTestID);
        }
    }
}
