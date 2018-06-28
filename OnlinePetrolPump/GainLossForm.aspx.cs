using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlinePetrolPump.BL;
using Helper;

namespace OnlinePetrolPump
{
    public partial class GainLossForm : SpartansHelper
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
                BindData();
            }
        }

        private void BindData()
        {
            rptGainLoss.DataSource = ExecutePlainQuery("select * from tbl_TankGainLoss");
            rptGainLoss.DataBind();
        }

        protected void timer1_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TblTankGainLoss obj = new TblTankGainLoss();
            obj.CategoryID = Convert.ToInt32(ddlCatagory.SelectedValue);
            obj.Type = Convert.ToInt32(ddlType.SelectedValue);
            obj.Qty = Convert.ToDecimal(txtQTY.Text);
            obj.DateX = Convert.ToDateTime(Convert.ToDateTime(txtDate.SelectedDate).ToShortDateString() + " " + getDateTime().ToString("h:mm:ss"));
            obj.Save();
            TblTank objTank = new TblTank(TblTank.Columns.Catagoryid, obj.CategoryID);
            if (ddlType.SelectedValue == "0")//Loss
            {
                objTank.Quantity -= Convert.ToInt32(obj.Qty);
            }
            else//Gain
            {
                objTank.Quantity += Convert.ToInt32(obj.Qty);
            }
            objTank.Save();
            lblmsg.Text = MessageBox.Show(msgDiv, "Data has been added!", "alert alert-success alert-icon alert-dismissible", icon, "glyphicon glyphicon-ok-sign");
            BindData();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string[] values = btn.CommandArgument.Split(',');
            TblTank objTank = new TblTank(TblTank.Columns.Catagoryid, values[2]);
            if (values[1] == "0")//Loss
            {
                objTank.Quantity += Convert.ToDouble(values[3]);
            }
            else//Gain
            {
                objTank.Quantity -= Convert.ToDouble(values[3]);
            }
            objTank.Save();
            TblTankGainLoss.Delete(values[0]);
            lblmsg.Text = MessageBox.Show(msgDiv, "Data has been deleted!", "alert alert-success alert-icon alert-dismissible", icon, "glyphicon glyphicon-ok-sign");
            BindData();
        }
    }
}