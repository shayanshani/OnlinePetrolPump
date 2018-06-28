using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OnlinePetrolPump.BL
{
    public partial class TblCompany
    {
        public static DataTable GetAccountDetails(int CompanyID)
        {
            return SPs.SpGetCompanyAccountDetials(CompanyID).GetDataSet().Tables[0];
        }
    }
}