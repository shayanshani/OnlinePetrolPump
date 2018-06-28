using OnlinePetrolPump.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Helper;
namespace OnlinePetrolPump
{
    public partial class Login : SpartansHelper
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["AdminName"] != null && Request.Cookies["Password"] != null)
                {
                    txtUserName.Text = Request.Cookies["AdminName"].Value;
                    txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = SPs.SpAdminLogin(txtUserName.Text, txtPassword.Text).GetDataSet().Tables[0];

            if (dt.Rows.Count > 0)
            {
                if (chkremember.Checked)
                {
                    Response.Cookies["AdminName"].Value = txtUserName.Text;
                    Response.Cookies["Password"].Value = txtPassword.Text;
                    Response.Cookies["AdminName"].Expires = DateTime.Now.AddDays(30);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                }
                Session.Clear();
                Session["AdminID"] = dt.Rows[0]["AdminID"].ToString();
                Session["AdminName"] = dt.Rows[0]["AdminName"].ToString();
                Response.Redirect("index.aspx");
            }
            else
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = "Invalid UserName or Password!";
            }
        }

        protected void chkremember_CheckedChanged(object sender, EventArgs e)
        {
            if (chkremember.Checked)
            {
                chkremember.Attributes["class"] = "icheckbox_flat-green checked";

            }
            else
            {
                chkremember.Attributes["class"] = "icheckbox_flat-green";

            }
        }

        protected void btnForGotPass_Click(object sender, EventArgs e)
        {
            lblHeading.ForeColor = Color.Black;
            lblHeading.Text = "Please put valid information";
            h1.InnerText = "Enter your Pin!";
            divLogin.Visible = false;
            divReset.Visible = true;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            TblAdmin obj = new TblAdmin(TblAdmin.Columns.Contact, txtContact.Text);

            if (ConfigurationManager.AppSettings["PinCode"] == txtPinCode.Text)
            {
                if (!String.IsNullOrEmpty(obj.Contact))
                {
                    obj.IsNew = false;
                    obj.VerificationCode = generateRandomCode(6);
                   // SendSms.SendMessage(txtContact.Text, "Your password verification code is " + obj.VerificationCode);
                    obj.Save();
                    lblHeading.Text = "Please fill out these fields!";
                    divReset.Visible = false;
                    divPasswordUpdate.Visible = true;
                    h1.InnerText = "Update your password!";
                    lblmsg.Text = "";
                }
                else
                {
                    lblmsg.ForeColor = Color.Red;
                    lblmsg.Text = "Invalid account contact no!";
                }
            }
            else
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = "Invalid Pin code!";
            }
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            TblAdmin obj = new TblAdmin(TblAdmin.Columns.Contact, txtContact.Text);
            if (!String.IsNullOrEmpty(obj.Contact))
            {
                if (obj.VerificationCode == txtCode.Text)
                {
                    obj.IsNew = false;
                    obj.Password = txtNewPassword.Text;
                    obj.Save();
                    h1.InnerText = "Login Form!";
                    lblHeading.Text = "Please sign in to your account";
                    divReset.Visible = false;
                    divPasswordUpdate.Visible = false;
                    divLogin.Visible = true;
                    lblmsg.ForeColor = Color.Green;
                    lblmsg.Text = "Password has been updated!";
                }
                else
                {
                    lblmsg.ForeColor = Color.Red;
                    lblmsg.Text = "Invalid Code.!";
                }
            }
            else
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = "Invalid account contact no.!";
            }
        }
    }
}