using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using System.Data.SqlClient;
using OnlinePetrolPump.BL;

namespace OnlinePetrolPump
{
    public partial class MobilOilSale : SpartansHelper
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
                BindGrid(getDateTime().ToShortDateString());
                FillDropDown(ddlProduct, "select * from Tbl_Product order by Productid desc", "Product", "Productid", "Select Product", "-1");
            }
        }
        private void BindGrid(string Date)
        {
            rptSaleInfo.DataSource = ExecutePlainQuery(string.Format("select * from vw_MobilOilSales where Date='{0}'", Date));
            rptSaleInfo.DataBind();
        }

        protected void timer1_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TblMobilOilSale obj = new TblMobilOilSale();

            string msg = "Product has been sold out!";
            obj.IsNew = true;
            if (!String.IsNullOrEmpty(hfSerialNo.Value))
            {
                obj.IsNew = false;
                obj = new TblMobilOilSale(hfSerialNo.Value);
                msg = "Product sale has been updated!";
            }

            obj.Productid = Convert.ToInt32(ddlProduct.SelectedValue);
            obj.RecieptNo = txtRecieptNo.Text;
            obj.DateX = Convert.ToDateTime(txtDate.SelectedDate).ToShortDateString();
            obj.Liters = Convert.ToDouble(txtLiters.Text);
            obj.PerPrice = Convert.ToDouble(txtRate.Text);
            obj.Total = Convert.ToDouble(Convert.ToDouble(txtLiters.Text) * Convert.ToDouble(txtRate.Text));
            obj.Discount = Convert.ToDouble(txtDiscount.Text);
            obj.Description = txtDescription.Text;
            obj.Save();
            lblmsg.Text = MessageBox.Show(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "glyphicon glyphicon-ok-sign");
            ClearInputs(Page.Controls);
            hfSerialNo.Value = null;
            BindGrid(Convert.ToDateTime(txtDate.SelectedDate).ToShortDateString());
            txtDate.SelectedDate = null;
            txtTotalAmount.Text = string.Empty;
        }

        protected void RadDatePicker1_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            BindGrid(Convert.ToDateTime(e.NewDate).ToShortDateString());
        }
    }
}