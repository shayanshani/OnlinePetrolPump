using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using System.Data;
using OnlinePetrolPump.BL;
namespace OnlinePetrolPump
{
    public partial class Index : SpartansHelper
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
            loadExpenseDetails();
            if(!IsPostBack)
            {
                DataTable dtCash = ExecutePlainQuery("select * from tbl_Totals");

                if (dtCash.Rows.Count > 0)
                {
                    hfCashID.Value = dtCash.Rows[0]["TotalID"].ToString();
                    txtTotalPurchase.Text = dtCash.Rows[0]["TotalPurchase"].ToString();
                    txtTotalSale.Text = dtCash.Rows[0]["TotalSale"].ToString();
                    txtTotalExpense.Text = dtCash.Rows[0]["TotalExpense"].ToString();
                }
            }

            DataTable dtPMGTank = SPs.SpTankDetails(getDateTime().ToShortDateString(), 1).GetDataSet().Tables[0];
            DataTable dtHSDTank = SPs.SpTankDetails(getDateTime().ToShortDateString(), 2).GetDataSet().Tables[0];

            if (dtPMGTank.Rows.Count > 0)
            {
                double TotalLiters, TotalTank, ConsumeUnits;
                TotalLiters = Convert.ToDouble(String.IsNullOrEmpty(dtPMGTank.Rows[0]["TotaLiters"].ToString()) ? "0" : dtPMGTank.Rows[0]["TotaLiters"]);
                TotalTank = Convert.ToDouble(String.IsNullOrEmpty(dtPMGTank.Rows[0]["TotalTank"].ToString()) ? "0" : dtPMGTank.Rows[0]["Tank"]);
                ConsumeUnits = Convert.ToDouble(String.IsNullOrEmpty(dtPMGTank.Rows[0]["ConsumeUnits"].ToString()) ? "0" : dtPMGTank.Rows[0]["ConsumeUnits"]);
                lblRemaining.Text = Convert.ToString(Convert.ToDouble((TotalLiters + TotalTank) - ConsumeUnits));
                lblConsumeUnts.Text = ConsumeUnits.ToString();
                hfPMGTank.Value = TotalTank.ToString();
            }

            if (dtHSDTank.Rows.Count > 0)
            {
                double TotalTank = Convert.ToDouble(String.IsNullOrEmpty(dtHSDTank.Rows[0]["TotalTank"].ToString()) ? "0" : dtHSDTank.Rows[0]["Tank"]);
                hfHSDTank.Value = TotalTank.ToString();
            }

        }
        public void loadExpenseDetails()
        {
            string query = " select *, isnull((select sum(amount) from tbl_Expenses where HeadID=tbl_ExpenseHeads.HeadID and ExpenseDate='" + getDateTime().ToString("yyyy-MM-dd") + "'),0) as Amount from tbl_ExpenseHeads ";
            rptExpense.DataSource = ExecutePlainQuery(query);
            rptExpense.DataBind();

        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            string pageurl = string.Format("Report/rptDailyStatement.aspx?val={0}", Convert.ToDateTime(txtDate.SelectedDate).ToString("yyyy-MM-dd"));
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openReport", " window.open('" + pageurl + "','_blank');", true);
        }

        protected void btnSalePurchaseReport_Click(object sender, EventArgs e)
        {
            string pageurl = string.Format("Report/rptSalePurchase.aspx?val={0}", Convert.ToDateTime(RadDatePicker1.SelectedDate).ToString("yyyy-MM-dd") + "," + Convert.ToDateTime(RadDatePicker2.SelectedDate).ToString("yyyy-MM-dd") + "&typ=" + ddlReportType.SelectedValue + "&opt=" + ddlReportOption.SelectedValue);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openReport", " window.open('" + pageurl + "','_blank');", true);

        }

        protected void btnAddCashDetails_Click(object sender, EventArgs e)
        {
            TblTotal obj = new TblTotal();
            if (!String.IsNullOrEmpty(hfCashID.Value))
            {
                obj = new TblTotal(hfCashID.Value);
                obj.IsNew = false;
            }
            obj.TotalPurchase = Convert.ToDecimal(txtTotalPurchase.Text);
            obj.TotalSale = Convert.ToDecimal(txtTotalSale.Text);
            obj.TotalExpense = Convert.ToDecimal(txtTotalExpense.Text);
            obj.Save();
        }
    }
}