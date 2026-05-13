using clsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsBLLocalDriving
    {
        public static DataTable localDriving()
        {
            return clsDAL.GetInfoForLocalDriving();
        }
        public static int PassedResult(int id)
        {
            return clsDAL.GetPassedTest(id);
        }
    }
}
