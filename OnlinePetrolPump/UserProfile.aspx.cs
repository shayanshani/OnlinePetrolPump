using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using OnlinePetrolPump.BL;

namespace OnlinePetrolPump
{
    public partial class UserProfile : SpartansHelper
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                TblAdmin obj = new TblAdmin(Session["AdminID"]);
                txtAdminName.Text = obj.AdminName;
                txtUserName.Text = obj.AdminEmail;
                txtContact.Text = obj.Contact;
                hfCurrentPassword.Value = obj.Password;
                cmpPass.ValueToCompare = obj.Password;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            TblAdmin obj = new TblAdmin(Session["AdminID"]);
            obj.IsNew = false;
            obj.AdminName = txtAdminName.Text;
            obj.AdminEmail = txtUserName.Text;
            obj.Contact = txtContact.Text;
            obj.Save();
            lblmsg.Text = MessageBox.Show(msgDiv, "Profile has been updated!", "alert alert-success");
        }

        protected void btnSavePassword_Click(object sender, EventArgs e)
        {
            TblAdmin obj = new TblAdmin(Session["AdminID"]);
            obj.IsNew = false;
            obj.Password = txtNewPassword.Text;
            obj.Save();
            lblmsg.Text = MessageBox.Show(msgDiv, "Password has been updated!", "alert alert-success");
        }
    }
}