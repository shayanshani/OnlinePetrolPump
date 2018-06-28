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
    public partial class rptClients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadrptClient();
            }
        }
        public void loadrptClient()
        {
            int amount = 0;
            DataTable dt = TblClient.GetClients();
            rptClientsinfo.DataSource = dt;
            rptClientsinfo.DataBind();
            if (dt.Rows.Count>0)
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