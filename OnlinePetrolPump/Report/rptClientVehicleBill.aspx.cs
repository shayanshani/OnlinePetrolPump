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
    public partial class rptClientVehicleBill : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null & Request.QueryString["val"] != null)
                {
                    loadInvoice(Convert.ToInt32(Request.QueryString["id"]), Request.QueryString["val"].ToString(), Request.QueryString["size"].ToString());
                }
            }
        }
        public void loadInvoice(int ClientID, string val, string size)
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

            double total = 0;
            TblClient obj = new TblClient(ClientID);
            ltrName.Text = obj.ClientName;
            ltrContact.Text = obj.Contact;
            ltrDate.Text = val;
            string[] date = val.Split('-');
            DataTable dt = TblClient.GetVehicleBill(ClientID, date[0], date[1]);
            rptClientVehicle.DataSource = dt;
            rptClientVehicle.DataBind();
            if (dt.Rows.Count > 0)
            {



                ltrTotal.Text = String.Format(Convert.ToInt32(dt.Rows[0]["GrandTotal"]).ToString());
            }
            else
            {
                ltrTotal.Text = "0";
            }

        }

    }
}