using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePetrolPump
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsLocal)
            {
                Session["AdminID"] = 1;
            }
            if (Session["AdminID"] == null)
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session["AdminID"] = null;
            Response.Redirect("Login.aspx");
        }
        public void logoff()
        {
            Session["AdminID"] = null;
            Response.Redirect("Login.aspx");
        }
        protected void btnLogoutT_Click(object sender, EventArgs e)
        {
            logoff();
        }

        protected void btnLogOUt_Click(object sender, EventArgs e)
        {
            logoff();
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {

        }
    }
}