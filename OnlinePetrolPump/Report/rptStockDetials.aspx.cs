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
    public partial class rptStockInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["fd"] != null & Request.QueryString["td"] != null)
                {
                    ViewReport(Convert.ToString(Request.QueryString["fd"]), Convert.ToString(Request.QueryString["td"]));
                }
            }
        }
        public void ViewReport(string fd, string td)
        {
            DataTable dt = SPs.SpStockInvoice(fd, td).GetDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                rptStock.DataSource = dt;
                rptStock.DataBind();

                ltrTotal.Text = dt.Rows[0]["Total"].ToString();
            }
        }
    }
}