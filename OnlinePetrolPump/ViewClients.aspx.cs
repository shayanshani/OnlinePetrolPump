using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using OnlinePetrolPump.BL;
using System.Web.UI.HtmlControls;
using System.Data;

namespace OnlinePetrolPump
{
    public partial class ViewClients : SpartansHelper
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindClients();
            }
        }

        private void BindClients()
        {
            rptClients.DataSource = SPs.SpRptGetClients().GetDataSet().Tables[0];
            rptClients.DataBind();
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton ClientID = (LinkButton)sender;
            TblClient obj = new TblClient(ClientID.CommandArgument);
            hfClientID.Value = ClientID.CommandArgument;
            txtName.Text = obj.ClientName;
            txtContact.Text = obj.Contact;
            txtCNIC.Text = obj.Cnic;
            txtLimit.Text = obj.Limit.ToString();
            lblPopUpHeading.Text = "Update Client";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('#formPopUp');", true);
            BindClients();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton ClientID = (LinkButton)sender;
            string msg = "This client can not be deleted!";
            // TblClientAccount obj = new TblClientAccount(ClientID.CommandArgument);
            //if (String.IsNullOrEmpty(obj.Clientid.ToString()))
            //{
            DataTable dt = ExecutePlainQuery("select * from tbl_ClientAccount where Clientid=" + ClientID.CommandArgument);
            if (dt.Rows.Count == 0)
            {
                TblClient.Delete(ClientID.CommandArgument);
                msg = "Client has been deleted!";
            }
            else
            {
                msg = "This client can not be deleted!";
            }
            lblmsg.Text = MessageBox.Show(msgDiv, msg, "alert alert-danger alert-icon alert-dismissible", icon, "glyphicon glyphicon-warning-sign");
            //  }
            BindClients();
        }
        protected void MsgTime_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsExist("Tbl_Client", "ClientName,Contact", txtName.Text + "," + txtContact.Text, hfClientID.Value))
                {
                    lblmsg.Text = MessageBox.Show(msgDiv, "Record with this contact already exists!", "alert alert-danger alert-icon alert-dismissible", icon, "glyphicon glyphicon-warning-sign");
                }
                else
                {
                    string msg = "Client detail has been added!";
                    TblClient obj = new TblClient();
                    obj.IsNew = true;
                    if (!String.IsNullOrEmpty(hfClientID.Value))
                    {
                        obj.IsNew = false;
                        obj = new TblClient(hfClientID.Value);
                        msg = "Client detail has been updated!";
                    }

                    obj.ClientName = txtName.Text;
                    obj.Contact = txtContact.Text;
                    obj.Cnic = txtCNIC.Text;
                    obj.Limit = Convert.ToInt32(txtLimit.Text);
                    obj.IsActive = 1;

                    if (obj.IsNew)
                        obj.DateX = getDateTime();

                    obj.Save();
                    lblmsg.Text = MessageBox.Show(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "glyphicon glyphicon-ok-sign");
                    ClearInputs(Page.Controls);
                    hfClientID.Value = null;
                    lblPopUpHeading.Text = "Add Client";
                    BindClients();
                }
            }
            catch { }
        }

        protected void btnViewReport_Click(object sender, EventArgs e)
        {
            string pageurl = "Report/rptClients.aspx";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openReport", " window.open('" + pageurl + "','_blank');", true);
        }
    }
}