using System; 
using System.Text; 
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration; 
using System.Xml; 
using System.Xml.Serialization;
using SubSonic; 
using SubSonic.Utilities;
namespace OnlinePetrolPump.BL
{
	 
	public partial class TblExpense
	{
		 
        public static DataTable GetExpenseReport(int? HeadID,string FromDate,string ToDate)
        {
            if (HeadID==-1)
            {
                HeadID = null;
            }
            return SPs.SpGetExpenseReport(HeadID,FromDate,ToDate).GetDataSet().Tables[0];
        }
         
	}
}
