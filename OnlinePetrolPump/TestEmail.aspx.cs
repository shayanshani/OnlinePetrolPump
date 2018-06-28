using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlinePetrolPump.DL;

namespace OnlinePetrolPump
{
    public partial class TestEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Click(object sender, EventArgs e)
        {
            SendEmail.Mail(txtToEmail.Text, "Test", txtMessage.Text);
            txtToEmail.Text = "";
            txtMessage.Text = "";
        }
    }
}