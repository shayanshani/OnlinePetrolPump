using OnlinePetrolPump.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePetrolPump.Report
{
    public partial class rptCompanies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadrptCompany();
            }
        }

        private void loadrptCompany()
        {
            int amount = 0;
            DataTable dt = SPs.SpRptGetCompany().GetDataSet().Tables[0];
            rptClientsinfo.DataSource = dt;
            rptClientsinfo.DataBind();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    amount += Convert.ToInt32(dt.Rows[i]["Remaining"]);
                }
                ltrTotal.Text = String.Format("{0:0}", amount);
            }
            else
            {
                ltrTotal.Text = "0";
            }
        }
    }
}