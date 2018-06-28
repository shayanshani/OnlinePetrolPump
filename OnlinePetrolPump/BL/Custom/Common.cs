using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helper;
using System.Data;
namespace OnlinePetrolPump.BL
{
    public class Common : SpartansHelper
    {

        public static DataTable GetLatestRates(int CategoryID)
        {
            if (CategoryID == 3)
            {
                return ExecutePlainQuery(string.Format(@"select AVG(Rate) as AvgPurchaseRate from tbl_CompanyAccountDetails where CategoryID={0} and Rate is not null", CategoryID));
            }
            return ExecutePlainQuery(string.Format(@"select * from tbl_CompanyAccountDetails where CategoryID={0} 
                                     and SerialNo=(Select max(SerialNo) from tbl_CompanyAccountDetails 
                                        where Rate is not null and CategoryID={0})", CategoryID));
        }

        public static DataTable GetPreviousCash()
        {
            return ExecutePlainQuery("select * from tbl_Totals");
        }
    }
}