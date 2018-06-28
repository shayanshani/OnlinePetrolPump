using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlinePetrolPump.BL;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using System.Reflection;
using System.Data.SqlClient;

namespace OnlinePetrolPump
{
    public partial class ViewClientDetails : SpartansHelper
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.IsLocal)
            {
                Session["AdminID"] = 1;
            }
            if (Session["AdminID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                ClientHeaderInfo.Visible = false;
                FillDropDowns();
                if (Request.QueryString["ClientId"] != null)
                {
                    ddlClientName.SelectedValue = Request.QueryString["ClientId"];
                    ddlRecievedClientName.SelectedValue = Request.QueryString["ClientId"];
                    ddlPaidClientName.SelectedValue = Request.QueryString["ClientId"];
                    GetClientInfo(Request.QueryString["ClientId"]);
                    BindGrid(Convert.ToInt32(Request.QueryString["ClientId"]));
                }

            }
        }

        private void BindGrid(int ClientID)
        {
            SqlParameter[] prm = new SqlParameter[1];

            rptClientDetails.DataSource = TblClient.GetAccountDetails(ClientID);
            rptClientDetails.DataBind();
        }

        private void FillDropDowns()
        {
            string qry = "select * from tbl_client where isactive=1 order by clientid desc";
            FillDropDown(ddlClientName, qry, "ClientName", "ClientId", "Select Client", "-1");
            FillDropDown(ddlRecievedClientName, qry, "ClientName", "ClientId", "Select Client", "-1");
            FillDropDown(ddlPaidClientName, qry, "ClientName", "ClientId", "Select Client", "-1");

        }

        private void GetClientInfo(string clientID)
        {
            ClientHeaderInfo.Visible = true;
            DataTable dt = ExecutePlainQuery("select ClientName,Contact from tbl_Client where ClientId=" + clientID);
            lblClientName.Text = dt.Rows[0]["ClientName"].ToString();
            lblClientContact.Text = dt.Rows[0]["Contact"].ToString();
            ddlRecievedClientName.SelectedValue = ddlClientName.SelectedValue;
            ddlPaidClientName.SelectedValue = ddlClientName.SelectedValue;
            BindGrid(Convert.ToInt32(clientID));
        }

        protected void timer1_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TblClientAccount obj = new TblClientAccount();
            string msg = "Client detail has been added!";
            obj.IsNew = true;
            if (!String.IsNullOrEmpty(hfSerialNo.Value))
            {
                obj.IsNew = false;
                obj = new TblClientAccount(hfSerialNo.Value);
                msg = "Client detail has been updated!";
            }

            obj.Clientid = Convert.ToInt32(ddlClientName.SelectedValue);
            obj.ReciptNo = Convert.ToInt32(txtRecieptNo.Text);
            obj.DateX = Convert.ToDateTime(Convert.ToDateTime(txtPetrolDate.SelectedDate).ToShortDateString() + " " + getDateTime().ToString("h:mm:ss"));
            obj.VehicleNo = txtVehicleNo.Text;
            obj.Liters = Convert.ToDouble(txtLiters.Text);
            obj.Rate = Convert.ToDecimal(txtRate.Text);
            obj.Amount = Convert.ToDecimal(Convert.ToDouble(txtLiters.Text) * Convert.ToDouble(txtRate.Text));
            obj.Received = null;
            obj.Dsicount = Convert.ToDecimal(txtDiscount.Text);
            obj.Description = txtPetrolDescription.Text;
            obj.Save();
            lblmsg.Text = MessageBox.Show(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "glyphicon glyphicon-ok-sign");
            string id = ddlClientName.SelectedValue;
            ClearInputs(Page.Controls);
            ddlClientName.SelectedValue = id;
            hfSerialNo.Value = null;
            BindGrid(Convert.ToInt32(ddlClientName.SelectedValue));
            txtPetrolDate.SelectedDate = null;
            txtTotalAmount.Text = string.Empty;
        }

        protected void ddlClientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetClientInfo(ddlClientName.SelectedValue);
        }

        protected void btnRecieveAmmount_Click(object sender, EventArgs e)
        {
            TblClientAccount obj = new TblClientAccount();

            string msg = "Client detail has been added!";
            obj.IsNew = true;
            if (!String.IsNullOrEmpty(hfSerialNo.Value))
            {
                obj.IsNew = false;
                obj = new TblClientAccount(hfSerialNo.Value);
                msg = "Client detail has been updated!";
            }

            obj.Clientid = Convert.ToInt32(ddlRecievedClientName.SelectedValue);
            obj.ReciptNo = Convert.ToInt32(txtRecievdReceiptNo.Text);
            obj.DateX = Convert.ToDateTime(Convert.ToDateTime(txtRecivedDate.SelectedDate).ToShortDateString() + " " + getDateTime().ToString("h:mm:ss"));
            obj.VehicleNo = txtVehicleNo.Text;
            obj.Liters = null;
            obj.Rate = null;
            obj.Amount = null;
            obj.Received = Convert.ToDecimal(txtRecivedAmmount.Text);
            obj.Dsicount = null;
            obj.Description = txtRecivedDescription.Text;
            obj.Save();
            lblmsg.Text = MessageBox.Show(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "glyphicon glyphicon-ok-sign");
            string id = ddlClientName.SelectedValue;
            ClearInputs(Page.Controls);
            ddlClientName.SelectedValue = id;
            hfSerialNo.Value = null;
            BindGrid(Convert.ToInt32(ddlClientName.SelectedValue));
        }

        protected void btnPaidAmmount_Click(object sender, EventArgs e)
        {
            TblClientAccount obj = new TblClientAccount();

            string msg = "Client detail has been added!";
            obj.IsNew = true;
            if (!String.IsNullOrEmpty(hfSerialNo.Value))
            {
                obj.IsNew = false;
                obj = new TblClientAccount(hfSerialNo.Value);
                msg = "Client detail has been updated!";
            }

            obj.Clientid = Convert.ToInt32(ddlPaidClientName.SelectedValue);
            obj.ReciptNo = Convert.ToInt32(txtPaidReciept.Text);
            obj.DateX = Convert.ToDateTime(Convert.ToDateTime(txtPaidDate.SelectedDate).ToShortDateString() + " " + getDateTime().ToString("h:mm:ss")); 
            obj.VehicleNo = txtVehiclePaid.Text;
            obj.Liters = null;
            obj.Rate = null;
            obj.Amount = Convert.ToDecimal(txtPaidAmmount.Text);
            obj.Received = null;
            obj.Dsicount = null;
            obj.Description = txtPaidDescription.Text;
            obj.Save();
            lblmsg.Text = MessageBox.Show(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "glyphicon glyphicon-ok-sign");
            string id = ddlClientName.SelectedValue;
            ClearInputs(Page.Controls);
            ddlClientName.SelectedValue = id;
            hfSerialNo.Value = null;
            BindGrid(Convert.ToInt32(ddlClientName.SelectedValue));
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            TblClientAccount obj = new TblClientAccount(btn.CommandArgument);
            if (String.IsNullOrEmpty(obj.Liters.ToString()) && !String.IsNullOrEmpty(obj.Amount.ToString())) //ShowPaidPopUp
            {
                txtPaidDescription.Text = obj.Description;
                txtPaidAmmount.Text = obj.Amount.ToString();
                txtPaidReciept.Text = obj.ReciptNo.ToString();
                ddlPaidClientName.SelectedValue = obj.Clientid.ToString();
                txtVehiclePaid.Text = Convert.ToString(obj.VehicleNo);
                txtPaidDate.SelectedDate = obj.DateX;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('#PaidformPopUp');", true);
            }
            else if (!String.IsNullOrEmpty(obj.Liters.ToString()) && !String.IsNullOrEmpty(obj.Amount.ToString()))   //MainForm
            {
                txtTotalAmount.Text = obj.Amount.ToString();
                txtDiscount.Text = obj.Dsicount.ToString();
                txtVehicleNo.Text = obj.VehicleNo;
                txtPetrolDescription.Text = obj.Description;
                txtRate.Text = obj.Rate.ToString();
                txtRecieptNo.Text = obj.ReciptNo.ToString();
                txtLiters.Text = obj.Liters.ToString();
                ddlClientName.SelectedValue = obj.Clientid.ToString();
                txtPetrolDate.SelectedDate = obj.DateX;
            }
            else if (!String.IsNullOrEmpty(obj.Received.ToString())) //ShowRecievedPopUp
            {
                ddlRecievedClientName.SelectedValue = obj.Clientid.ToString();
                txtRecievdReceiptNo.Text = obj.ReciptNo.ToString();
                txtRecivedAmmount.Text = obj.Received.ToString();
                txtRecivedDescription.Text = obj.Description;
                txtRecivedDate.SelectedDate = obj.DateX;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('#RecivedformPopUp');", true);
            }
            hfSerialNo.Value = btn.CommandArgument;
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            TblClientAccount obj = new TblClientAccount(btn.CommandArgument);
            if (obj.Fid != null)
            {
                TblFarwordAmount.Delete(obj.Fid);
            }
            TblClientAccount.Delete(btn.CommandArgument);
            lblmsg.Text = MessageBox.Show(msgDiv, "Record has been deleted!", "alert alert-success alert-icon alert-dismissible", icon, "glyphicon glyphicon-ok-sign");
            string id = ddlClientName.SelectedValue;
            ClearInputs(Page.Controls);
            ddlClientName.SelectedValue = id;
            BindGrid(Convert.ToInt32(ddlClientName.SelectedValue));
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            string pageurl = null;
            if (ddlReportType.SelectedValue == "0")
            {
                pageurl = "report/rptClientAccount.aspx?id=" + ddlClientName.SelectedValue + "&val=" + Request.Form["txtReportDate"] + "&vno=" + txtRVehicleNo.Text + "&size=" + ddlReportSize.SelectedValue;
            }
            else if (ddlReportType.SelectedValue == "1")
            {
                pageurl = "report/rptClientVehicleBill.aspx?id=" + ddlClientName.SelectedValue + "&val=" + Request.Form["txtReportDate"] + "&size=" + ddlReportSize.SelectedValue;
            }
            else if (ddlReportType.SelectedValue == "2")
            {
                pageurl = "report/rptMonthlyStatement.aspx?id=" + ddlClientName.SelectedValue + "&val=" + Request.Form["txtReportDate"] + "&size=" + ddlReportSize.SelectedValue;
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openReport", " window.open('" + pageurl + "','_blank');", true);
        }

        protected void ddlReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlReportType.SelectedValue == "0")
            {
                divVihcleNo.Visible = true;
            }
            else
            {
                divVihcleNo.Visible = false;
            }
        }
    }
}