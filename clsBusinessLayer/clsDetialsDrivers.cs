using clsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsDetialsDrivers
    {
        public static DataTable GetInfoDetailsDrivers()
        {
            return clsDAL.GetAllInfoDetailsDrivers();
        }
    }
}
