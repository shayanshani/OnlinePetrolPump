using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using OnlinePetrolPump.BL;
using System.Data;
using System.Data.SqlClient;

namespace OnlinePetrolPump
{
    public partial class ViewCompanyDetails : SpartansHelper
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["AdminID"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
            if (!IsPostBack)
            {
                CompanyHeaderInfo.Visible = false;
                FillDropDowns();
                if (Request.QueryString["CompanyId"] != null)
                {
                    ddlCompanyName.SelectedValue = Request.QueryString["CompanyId"];
                    ddlRecievedCompanyName.SelectedValue = Request.QueryString["CompanyId"];
                    ddlPaidCompanyName.SelectedValue = Request.QueryString["CompanyId"];
                    GetCompanyInfo(Request.QueryString["CompanyId"]);
                    BindGrid(Convert.ToInt32(Request.QueryString["CompanyId"]));
                }

            }
        }

        private void LoadFrwdAmount(int SerialNo)
        {
            BindDataSource("select * from vw_FrwdAmount where SerialNo=" + SerialNo, rptFrwdAmounts);
        }
        public int PopUpID { get; set; }

        private void FillDropDowns()
        {
            string qry = "select * from tbl_Company where isactive=1 order by Companyid desc";
            FillDropDown(ddlCompanyName, qry, "Company", "CompanyId", "Select Company", "-1");
            FillDropDown(ddlRecievedCompanyName, qry, "Company", "CompanyId", "Select Company", "-1");
            FillDropDown(ddlPaidCompanyName, qry, "Company", "CompanyId", "Select Company", "-1");
            FillDropDown(ddlProducts, "select * from tbl_Product", "Product", "Productid", "Select Product", "-1");
            FillDropDown(ddlCLient, "select * from Tbl_Client where isActive=1", "ClientName", "CLientID", "Select CLient", "-1");

        }

        private void BindGrid(int CompanyID)
        {
            SqlParameter[] prm = new SqlParameter[1];
            rptCompanyDetails.DataSource = TblCompany.GetAccountDetails(CompanyID);
            rptCompanyDetails.DataBind();
        }

        protected void timer1_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        private void GetCompanyInfo(string CompanyID)
        {
            Session["CompanyID"] = null;
            CompanyHeaderInfo.Visible = true;
            DataTable dt = ExecutePlainQuery("select Company,Contact from tbl_Company where CompanyId=" + CompanyID);
            lblCompanyName.Text = dt.Rows[0]["Company"].ToString();
            lblCompanyContact.Text = dt.Rows[0]["Contact"].ToString();
            ddlRecievedCompanyName.SelectedValue = ddlCompanyName.SelectedValue;
            ddlPaidCompanyName.SelectedValue = ddlCompanyName.SelectedValue;
            BindGrid(Convert.ToInt32(CompanyID));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TblCompanyAccountDetail obj = new TblCompanyAccountDetail();

            string msg = "Company detail has been added!";
            obj.IsNew = true;
            if (!String.IsNullOrEmpty(hfSerialNo.Value))
            {
                obj.IsNew = false;
                obj = new TblCompanyAccountDetail(hfSerialNo.Value);
                msg = "Company detail has been updated!";
            }

            obj.Companyid = Convert.ToInt32(ddlCompanyName.SelectedValue);
            obj.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
            obj.ReciptNo = Convert.ToInt32(txtRecieptNo.Text);
            obj.DateX = Convert.ToDateTime(Convert.ToDateTime(txtPetrolDate.SelectedDate).ToShortDateString() + " " + getDateTime().ToString("h:mm:ss"));
            obj.VehcleNo = txtVehicleNo.Text;
            obj.Liters = Convert.ToDouble(txtLiters.Text);
            obj.Rate = Convert.ToDecimal(txtRate.Text);
            obj.Amount = Convert.ToDecimal(Convert.ToDecimal(obj.Rate) * Convert.ToDecimal(obj.Liters));
            obj.Received = null;
            obj.OtherExpense = Convert.ToDecimal(txtOtherExpense.Text);
            obj.Description = txtPetrolDescription.Text;

            if (Convert.ToInt32(ddlProducts.SelectedValue) > 0)
                obj.Productid = Convert.ToInt32(ddlProducts.SelectedValue);
            else
                obj.Productid = null;

            obj.Save();
            lblmsg.Text = MessageBox.Show(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "glyphicon glyphicon-ok-sign");
            string id = ddlCompanyName.SelectedValue;
            ClearInputs(Page.Controls);
            ddlCompanyName.SelectedValue = id;
            hfSerialNo.Value = null;
            BindGrid(Convert.ToInt32(ddlCompanyName.SelectedValue));
            txtPetrolDate.SelectedDate = null;
            txtTotalAmount.Value = string.Empty;
        }

        protected void ddlCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCompanyInfo(ddlCompanyName.SelectedValue);
        }

        protected void btnRecieveAmmount_Click(object sender, EventArgs e)
        {
            TblCompanyAccountDetail obj = new TblCompanyAccountDetail();

            string msg = "Company detail has been added!";
            obj.IsNew = true;
            if (!String.IsNullOrEmpty(hfSerialNo.Value))
            {
                obj.IsNew = false;
                obj = new TblCompanyAccountDetail(hfSerialNo.Value);
                msg = "Company detail has been updated!";
            }

            obj.Companyid = Convert.ToInt32(ddlRecievedCompanyName.SelectedValue);

            obj.ReciptNo = Convert.ToInt32(txtRecievdReceiptNo.Text);
            obj.DateX = Convert.ToDateTime(Convert.ToDateTime(txtRecivedDate.SelectedDate).ToShortDateString() + " " + getDateTime().ToString("h:mm:ss"));
            obj.VehcleNo = txtVehicleNo.Text;
            obj.Liters = null;
            obj.Rate = null;
            obj.Amount = Convert.ToDecimal(txtRecivedAmmount.Text);
            obj.Received = null;
            obj.OtherExpense = null;
            obj.Description = txtRecivedDescription.Text;
            obj.Save();
            lblmsg.Text = MessageBox.Show(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "glyphicon glyphicon-ok-sign");
            string id = ddlCompanyName.SelectedValue;
            ClearInputs(Page.Controls);
            ddlCompanyName.SelectedValue = id;
            hfSerialNo.Value = null;
            BindGrid(Convert.ToInt32(ddlCompanyName.SelectedValue));
        }

        protected void btnPaidAmmount_Click(object sender, EventArgs e)
        {
            TblCompanyAccountDetail obj = new TblCompanyAccountDetail();

            string msg = "Company detail has been added!";
            obj.IsNew = true;
            if (!String.IsNullOrEmpty(hfSerialNo.Value))
            {
                obj.IsNew = false;
                obj = new TblCompanyAccountDetail(hfSerialNo.Value);
                msg = "Company detail has been updated!";
            }

            obj.Companyid = Convert.ToInt32(ddlPaidCompanyName.SelectedValue);
            obj.ReciptNo = Convert.ToInt32(txtPaidReciept.Text);
            obj.DateX = Convert.ToDateTime(Convert.ToDateTime(txtPaidDate.SelectedDate).ToShortDateString() + " " + getDateTime().ToString("h:mm:ss"));
            obj.VehcleNo = txtVehiclePaid.Text;
            obj.Liters = null;
            obj.Rate = null;
            obj.Amount = null;
            obj.Received = Convert.ToDecimal(txtPaidAmmount.Text);
            obj.OtherExpense = null;
            obj.Description = txtPaidDescription.Text;
            obj.Save();
            lblmsg.Text = MessageBox.Show(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "glyphicon glyphicon-ok-sign");
            string id = ddlCompanyName.SelectedValue;
            ClearInputs(Page.Controls);
            ddlCompanyName.SelectedValue = id;
            hfSerialNo.Value = null;
            BindGrid(Convert.ToInt32(ddlCompanyName.SelectedValue));
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            TblCompanyAccountDetail obj = new TblCompanyAccountDetail(btn.CommandArgument);
            if (String.IsNullOrEmpty(obj.Liters.ToString()) && !String.IsNullOrEmpty(obj.Amount.ToString())) //ShowPaidPopUp
            {
                txtPaidDescription.Text = obj.Description;
                txtPaidAmmount.Text = obj.Amount.ToString();
                txtPaidReciept.Text = obj.ReciptNo.ToString();
                ddlPaidCompanyName.SelectedValue = obj.Companyid.ToString();
                txtVehiclePaid.Text = Convert.ToString(obj.VehcleNo);
                txtPaidDate.SelectedDate = obj.DateX;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('#PaidformPopUp');", true);
            }
            else if (!String.IsNullOrEmpty(obj.Liters.ToString()) && !String.IsNullOrEmpty(obj.Amount.ToString()))   //MainForm
            {
                obj.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
                txtTotalAmount.Value = obj.Amount.ToString();
                txtOtherExpense.Text = obj.OtherExpense.ToString();
                txtVehicleNo.Text = obj.VehcleNo;
                txtPetrolDescription.Text = obj.Description;
                txtRate.Text = obj.Rate.ToString();
                txtRecieptNo.Text = obj.ReciptNo.ToString();
                txtLiters.Text = obj.Liters.ToString();
                ddlCompanyName.SelectedValue = obj.Companyid.ToString();
                txtPetrolDate.SelectedDate = obj.DateX;
            }
            else if (!String.IsNullOrEmpty(obj.Received.ToString())) //ShowRecievedPopUp
            {
                ddlRecievedCompanyName.SelectedValue = obj.Companyid.ToString();
                txtRecievdReceiptNo.Text = obj.ReciptNo.ToString();
                txtRecivedAmmount.Text = obj.Received.ToString();
                txtRecivedDescription.Text = obj.Description;
                txtRecivedDate.SelectedDate = obj.DateX;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('#RecivedformPopUp');", true);
            }
            hfSerialNo.Value = btn.CommandArgument;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            TblProduct obj = new TblProduct();
            obj.IsNew = true;
            obj.Product = txtProduct.Text;
            obj.Save();
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedValue == "3")
                productsRow.Visible = true;
            else
                productsRow.Visible = false;
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            string pageurl = null;
            if (ddlReportType.SelectedValue == "0")
            {
                pageurl = "report/rptCompanyInvoice.aspx?val=" + Request.Form["txtReportDate"] + "&Id=" + ddlCompanyName.SelectedValue;
            }
            else if (ddlReportType.SelectedValue == "1")
            {
                pageurl = "report/rptCompanyStatment.aspx?val=" + Request.Form["txtReportDate"] + "&Id=" + ddlCompanyName.SelectedValue;
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openReport", " window.open('" + pageurl + "','_blank');", true);

        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            DataTable dt = ExecutePlainQuery("select * from tbl_FarwordAmount where SerialNo=" + btn.CommandArgument);
            if (dt.Rows.Count > 0)
            {
                lblmsg.Text = MessageBox.Show(msgDiv, "This record cannot be deleted because this has been already forwaded!", "alert alert-danger alert-icon alert-dismissible", icon, "glyphicon glyphicon-remove");
            }
            else
            {
                TblCompanyAccountDetail.Delete(btn.CommandArgument);
                lblmsg.Text = MessageBox.Show(msgDiv, "Record has been deleted!", "alert alert-success alert-icon alert-dismissible", icon, "glyphicon glyphicon-ok-sign");
                string id = ddlCompanyName.SelectedValue;
                ClearInputs(Page.Controls);
                ddlCompanyName.SelectedValue = id;
                BindGrid(Convert.ToInt32(ddlCompanyName.SelectedValue));
            }
        }

        protected void btnFrwrdAmount_Click(object sender, EventArgs e)
        {
            #region
            //TblFarwordAmount obj = new TblFarwordAmount();
            //TblClientAccount objClientAcount = new TblClientAccount();
            //obj.IsNew = true;
            //objClientAcount.IsNew = true;

            //DataTable dt = ExecutePlainQuery("select * from tbl_FarwordAmount where SerialNo=" + hfCompanyID.Value);

            //if (dt.Rows.Count > 0)
            //{
            //    obj.IsNew = false;
            //    objClientAcount.IsNew = false;
            //    obj = new TblFarwordAmount(TblFarwordAmount.Columns.SerialNo, hfCompanyID.Value);

            //}

            //obj.Rate = Convert.ToDouble(txtfrwrdRate.Text);
            //obj.Quantity = Convert.ToDouble(txtfrwrdQuantity.Text);
            //obj.SerialNo = Convert.ToInt32(hfCompanyID.Value);
            //obj.ClientID = Convert.ToInt32(ddlCLient.SelectedValue);
            //obj.Save();
            //TblCompanyAccountDetail objCmpAc = new TblCompanyAccountDetail(hfCompanyID.Value);
            //objClientAcount.Liters = Convert.ToDouble(obj.Quantity);
            //objClientAcount.Clientid = Convert.ToInt32(ddlCLient.SelectedValue);
            //objClientAcount.Rate = Convert.ToDecimal(txtfrwrdRate.Text);
            //objClientAcount.Description = objCmpAc.CategoryID == 1 ? "Forwaded PMG" : "Forwaded HSD";
            //objClientAcount.Amount = Convert.ToDecimal(obj.Quantity * obj.Rate);
            //objClientAcount.Fid = obj.Fid;
            //objClientAcount.DateX = objCmpAc.DateX;
            //objClientAcount.Save();
            //TblClient objClientName = new TblClient(ddlCLient.SelectedValue);
            #endregion
            int CompanyID = Convert.ToInt32(Session["FrCompanyID"]);
            int FrwdID = Convert.ToInt32(Session["FID"]);
            TblCompanyAccountDetail objCmpAc = new TblCompanyAccountDetail(CompanyID);
            TblFarwordAmount obj = new TblFarwordAmount();
            TblClientAccount objClientAcount = new TblClientAccount();
            string msg = "Amount has been forwaded to " + ddlCLient.SelectedItem.Text;
            if (Session["FID"] != null)
            {
                obj = new TblFarwordAmount(FrwdID);
                obj.IsNew = false;
                objClientAcount = new TblClientAccount(TblClientAccount.Columns.Fid, FrwdID);
                objClientAcount.IsNew = false;
                msg = "Farwaded amount detail has been updated!";
            }
            obj.Rate = Convert.ToDouble(txtfrwrdRate.Text);
            obj.Quantity = Convert.ToDouble(txtfrwrdQuantity.Text);
            obj.SerialNo = Convert.ToInt32(CompanyID);
            obj.ClientID = Convert.ToInt32(ddlCLient.SelectedValue);
            obj.CategoryID = objCmpAc.CategoryID;
            obj.Save();

            objClientAcount.Liters = Convert.ToDouble(txtfrwrdQuantity.Text);
            objClientAcount.Clientid = Convert.ToInt32(ddlCLient.SelectedValue);
            objClientAcount.Rate = Convert.ToDecimal(txtfrwrdRate.Text);
            objClientAcount.Description = objCmpAc.CategoryID == 1 ? "Forwaded PMG" : "Forwaded HSD";
            objClientAcount.Amount = Convert.ToDecimal(obj.Quantity * obj.Rate);
            objClientAcount.Fid = obj.Fid;
            objClientAcount.DateX = Convert.ToDateTime(Convert.ToDateTime(objCmpAc.DateX).ToShortDateString() + " " + getDateTime().ToString("h:mm:ss"));
            objClientAcount.Save();
            lblmsg2.Text = MessageBox.Show(msgDiv2, msg, "alert alert-success alert-icon alert-dismissible", icon, "glyphicon glyphicon-ok-sign");
            LoadFrwdAmount(objCmpAc.SerialNo);
            Session["FID"] = null;
            //Session["CompanyID"] = null;
            ClearInputs(Controls);
        }

        protected void btnFrwrdAmountPopUp_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Session["FrCompanyID"] = btn.CommandArgument;
            LoadFrwdAmount(Convert.ToInt32(btn.CommandArgument));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('#frwdAmount');", true);
        }

        protected void btnEditFamoun_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(btn);
            Session["FID"] = btn.CommandArgument;
            TblFarwordAmount obj = new TblFarwordAmount(btn.CommandArgument);
            ddlCLient.SelectedValue = obj.ClientID.ToString();
            txtfrwrdQuantity.Text = obj.Quantity.ToString();
            txtfrwrdRate.Text = obj.Rate.ToString();
            txtFrwrdAmount.Text = Convert.ToDouble(obj.Quantity * obj.Rate).ToString();
        }

        protected void timer2_Tick(object sender, EventArgs e)
        {
            msgDiv2.Visible = false;
        }

        protected void lnkFrwdDelete_Click(object sender, EventArgs e)
        {
            int CompanyID = Convert.ToInt32(Session["FrCompanyID"]);
            LinkButton btn = (LinkButton)sender;
            TblCompanyAccountDetail objCmpAc = new TblCompanyAccountDetail(CompanyID);
            ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(btn);
            TblClientAccount.Delete(TblClientAccount.Columns.Fid, btn.CommandArgument);
            TblFarwordAmount.Delete(btn.CommandArgument);
            lblmsg2.Text = MessageBox.Show(msgDiv2, "Record has been deleted!", "alert alert-success alert-icon alert-dismissible", icon, "glyphicon glyphicon-ok-sign");
            LoadFrwdAmount(objCmpAc.SerialNo);
        }
    }
}