using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlinePetrolPump.BL;
using System.Data;
namespace OnlinePetrolPump.Report
{
    public partial class rptExpense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["HeadID"] != null & Request.QueryString["fd"] != null & Request.QueryString["td"] != null)
                {
                    ViewReport(Convert.ToInt32(Request.QueryString["HeadID"]), Convert.ToString(Request.QueryString["fd"]), Convert.ToString(Request.QueryString["td"]));
                }
            }
        }
        public void ViewReport(int HeadID, string fromDate, string toDate)
        {
            DataTable dt = TblExpense.GetExpenseReport(HeadID, (fromDate.Replace("-", "/")), (toDate.Replace("-", "/")));
            rptExpenses.DataSource = dt;
            rptExpenses.DataBind();
            if (dt.Rows.Count > 0)
            { 
                ltrTotal.Text = Convert.ToString(dt.Rows[0]["TotalExpense"]);
                }
        }
    }
}