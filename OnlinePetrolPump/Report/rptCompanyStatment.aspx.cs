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
    public partial class rptCompanyStatment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(Request.QueryString["val"]!=null && Request.QueryString["id"]!=null)
           {
               loadrptCompanyStatment(Convert.ToString(Request.QueryString["val"]),Convert.ToInt32(Request.QueryString["id"]));
           }
        }

        private void loadrptCompanyStatment(string val,int Companyid)
        {
            TblCompany obj=new TblCompany(Companyid);
            ltrName.Text = obj.Company;
            ltrContact.Text = obj.Contact;
            string[] date = val.Split('-');
            DataTable dt = SPs.SpGetCompanyMonthlyStatment(Convert.ToInt32(Companyid), date[0], date[1]).GetDataSet().Tables[0];
            if (dt.Rows.Count>0)
            {
                ltrPrv.Text = Convert.ToString(-(Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["PrevRemaining"])));
                ltrTotal.Text = Convert.ToString(-(Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["Remaining"])));
                ltrBalance.Text = Convert.ToString(-(Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["Balance"])));
            }
            rptrCompanyStatment.DataSource = dt;
            rptrCompanyStatment.DataBind();
        }
    }
}