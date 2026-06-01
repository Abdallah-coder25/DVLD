using clsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsBusinessLayer
{
    public class clsBLDetailsDetain
    {
        public static DataTable GEtAllInfoDetailsLicense()
        {
            return clsDAL.GetDetailsDetainLicenses();
        }
    }
}
