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
    public partial class rptMonthlyStatement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null & Request.QueryString["val"] != null)
                {
                    loadrptClient(Convert.ToInt32(Request.QueryString["id"]), Request.QueryString["val"].ToString(), Request.QueryString["size"].ToString());
                }
            }
        }
        public void loadrptClient(int ClientID, string val, string size)
        {
            switch (size)
            {
                case "1":
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "js10", "<script>setSmallFont();</script>", false);
                    break;
                case "3":
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "js11", "<script>setLargeFont();</script>", false);
                    break;
            }

            TblClient obj = new TblClient(ClientID);
            ltrName.Text = obj.ClientName;
            ltrContact.Text = obj.Contact;
            string[] date = val.Split('-');
            DataTable dt = TblClient.GetMonthlyStatement(ClientID, date[0], date[1]);
            rptClientsinfo.DataSource = dt;
            rptClientsinfo.DataBind();
            if (dt.Rows.Count > 0)
            {
                lblPrv.Text = String.Format("{0:0}", Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["PrevRemaining"]));
                ltrTotal.Text = String.Format("{0:0}", Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["Remaining"]));
                lblbalance.Text = String.Format("{0:0}", Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["Balance"]));
                ltrCash.Text = String.Format("{0:0}", Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["CashPaid"]));
                ltrQTY.Text = String.Format("{0:0}", Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["TotalLiters"]));
            }
            else
            {
                ltrTotal.Text = "0";
                lblPrv.Text = "0";
                lblbalance.Text = "0";

            }
        }
    }
}