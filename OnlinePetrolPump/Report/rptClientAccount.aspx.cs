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
    public partial class rptClientAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null & Request.QueryString["val"] != null)
                {
                    loadInvoice(Convert.ToInt32(Request.QueryString["id"]), Request.QueryString["val"].ToString(), Convert.ToString(Request.QueryString["vno"]), Request.QueryString["size"].ToString());
                }
            }
        }
        public void loadInvoice(int ClientID, string val, string VehicleNo, string size)
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
            ltrDate.Text = val;
            string[] date = val.Split('-');
            DataTable dt = TblClient.GetInvoieDetails(ClientID, date[0], date[1], VehicleNo);
            rptInvoiceDetails.DataSource = dt;
            rptInvoiceDetails.DataBind();
            if (dt.Rows.Count > 0)
            {
                double discount = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    discount += Convert.ToDouble(dt.Rows[i]["DiscountAmount"]);
                }
                ltrTotal.Text = String.Format("{0:0}", (Convert.ToDouble(dt.Rows[0]["Total"]) - discount));
            }
            else
            {
                ltrTotal.Text = "0";
            }

        }
    }
}