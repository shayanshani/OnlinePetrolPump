using Helper;
using OnlinePetrolPump.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlinePetrolPump.DL;

namespace OnlinePetrolPump.Report
{
    public partial class rptProfit : SpartansHelper
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = SPs.SpSalePurchaseReport("04-01-2017", DateTime.Now.ToShortDateString()).GetDataSet();
                DataTable expense = SPs.SpGetExpenseReport(null, "04-01-2017", DateTime.Now.ToShortDateString()).GetDataSet().Tables[0];
                DataTable dtPMGTank = SPs.SpTankDetails(getDateTime().ToShortDateString(), 1).GetDataSet().Tables[0];
                DataTable dtPMGLastRate = Common.GetLatestRates(1);
                DataTable dtHSDTank = SPs.SpTankDetails(getDateTime().ToShortDateString(), 2).GetDataSet().Tables[0];
                DataTable dtHSDLastRate = Common.GetLatestRates(2);
                DataTable dtMBORate = Common.GetLatestRates(3);

                if (dtMBORate.Rows.Count > 0)
                    lblMBORate.Text = dtMBORate.Rows[0]["AvgPurchaseRate"].ToString();

                if (dtPMGTank.Rows.Count > 0)
                {
                    if (dtPMGLastRate.Rows.Count > 0)
                    {
                        lblPMGRate.Text = Convert.ToDecimal(dtPMGLastRate.Rows[0]["Rate"]).ToString();
                    }
                    lblAvailablePMG.Text = Convert.ToInt32(dtPMGTank.Rows[0]["Tank"]).ToString();
                    lblPMGAmount.Text = Convert.ToString(Convert.ToDecimal(dtPMGLastRate.Rows[0]["Rate"]) * Convert.ToInt32(dtPMGTank.Rows[0]["Tank"]));
                }

                if (dtHSDTank.Rows.Count > 0)
                {
                    if (dtHSDLastRate.Rows.Count > 0)
                    {
                        lblHSDRate.Text = Convert.ToDecimal(dtHSDLastRate.Rows[0]["Rate"]).ToString();
                    }
                    lblAvailableHSD.Text = Convert.ToInt32(dtHSDTank.Rows[0]["Tank"]).ToString();
                    lblHSDAmount.Text = Convert.ToString(Convert.ToDecimal(dtHSDLastRate.Rows[0]["Rate"]) * Convert.ToInt32(dtHSDTank.Rows[0]["Tank"]));
                }
                DataTable PMGSale = ds.Tables[0];
                if (PMGSale.Rows.Count > 0)
                {
                    txtSoldPMG.Text = Convert.ToString(PMGSale.Rows[0]["PMGtotalQTY"]);
                    txtSoldPMGPrice.Text = Convert.ToString(PMGSale.Rows[0]["PMGtotalPrice"]);
                }
                else
                {
                    txtSoldPMG.Text = "0";
                }


                DataTable HSDSale = ds.Tables[1];
                if (HSDSale.Rows.Count > 0)
                {
                    txtSoldHSD.Text = Convert.ToString(HSDSale.Rows[0]["HSDtotalQTY"]);
                    txtSoldHSDPrice.Text = Convert.ToString(HSDSale.Rows[0]["HSDtotalPrice"]);
                }
                else
                {
                    txtSoldHSD.Text = "0";
                }

                DataTable MbOSales = ds.Tables[2];

                if (MbOSales.Rows.Count > 0)
                {
                    txtSoldMobileOil.Text = Convert.ToString(MbOSales.Rows[0]["MoboiltotalQTY"]);
                    txtSoldMobilOilPrice.Text = Convert.ToString(MbOSales.Rows[0]["MoboilPrice"]);
                }
                else
                {
                    txtSoldMobilOilPrice.Text = "0";
                }
                DataTable PMGPurchases = ds.Tables[3];

                if (PMGPurchases.Rows.Count > 0)
                {
                    txtTotalPurchasedPMG.Text = Convert.ToString(PMGPurchases.Rows[0]["PMGPurchaseQTY"]);
                    txtPurchasedPMGPrice.Text = Convert.ToString(PMGPurchases.Rows[0]["PMGPurchasePrice"]);
                    txtPurchasesPMGExpense.Text = Convert.ToString(PMGPurchases.Rows[0]["PMGOtherExpense"]);
                }
                else
                {
                    txtPurchasedPMGPrice.Text = "0";
                }

                DataTable HSDPurchases = ds.Tables[4];
                if (HSDPurchases.Rows.Count > 0)
                {
                    txtTotalPurchasedHSD.Text = Convert.ToString(HSDPurchases.Rows[0]["HSDPurchaseQTY"]);
                    txtPurchasedHSDPrice.Text = Convert.ToString(HSDPurchases.Rows[0]["HSDPurchasePrice"]);
                    txtPurchasesHSDExpense.Text = Convert.ToString(HSDPurchases.Rows[0]["HSDOtherExpense"]);
                }
                else
                {
                    txtPurchasedHSDPrice.Text = "0";
                }

                DataTable MbOPurchases = ds.Tables[5];
                if (MbOPurchases.Rows.Count > 0)
                {
                    txtPurchaseMobilOil.Text = Convert.ToString(MbOPurchases.Rows[0]["OILPurchaseQTY"]);
                    txtPurchaseMobileOilPrice.Text = Convert.ToString(MbOPurchases.Rows[0]["OILPurchasePrice"]);
                    txtPurchasesMbOExpense.Text = Convert.ToString(MbOPurchases.Rows[0]["OILOtherExpense"]);
                }
                else
                {
                    txtPurchaseMobileOilPrice.Text = "0";
                }
                if (expense.Rows.Count > 0)
                {
                    lblTotalExpense.Text = Convert.ToString(expense.Rows[0]["TotalExpense"]);

                }
                else
                {
                    lblTotalExpense.Text = "0";
                }

                lblTotalPurchases.Text = Convert.ToString((Convert.ToDouble(PMGPurchases.Rows[0]["PMGPurchasePrice"]))
                    + (Convert.ToDouble(HSDPurchases.Rows[0]["HSDPurchasePrice"]))
                    + (Convert.ToDouble(MbOPurchases.Rows[0]["OILPurchasePrice"]))
                    + (Convert.ToDouble(PMGPurchases.Rows[0]["PMGOtherExpense"]))
                    + (Convert.ToDouble(HSDPurchases.Rows[0]["HSDOtherExpense"]))
                    + (Convert.ToDouble(MbOPurchases.Rows[0]["OILOtherExpense"])));

                ltrTotalPurchase.Text = Convert.ToString((Convert.ToDouble(PMGPurchases.Rows[0]["PMGPurchasePrice"]))
                    + (Convert.ToDouble(HSDPurchases.Rows[0]["HSDPurchasePrice"]))
                    + (Convert.ToDouble(MbOPurchases.Rows[0]["OILPurchasePrice"]))
                    + (Convert.ToDouble(PMGPurchases.Rows[0]["PMGOtherExpense"]))
                    + (Convert.ToDouble(HSDPurchases.Rows[0]["HSDOtherExpense"]))
                    + (Convert.ToDouble(MbOPurchases.Rows[0]["OILOtherExpense"])));

                lblTotalSales.Text = Convert.ToString((Convert.ToDouble(MbOSales.Rows[0]["MoboilPrice"]))
                    + (Convert.ToDouble(PMGSale.Rows[0]["PMGtotalPrice"])
                    + (Convert.ToDouble(HSDSale.Rows[0]["HSDtotalPrice"]))));

                LtrTotalSales.Text = Convert.ToString((Convert.ToDouble(MbOSales.Rows[0]["MoboilPrice"]))
                    + (Convert.ToDouble(PMGSale.Rows[0]["PMGtotalPrice"])
                    + (Convert.ToDouble(HSDSale.Rows[0]["HSDtotalPrice"]))));

                lblAvailableMBO.Text = Convert.ToString(Convert.ToDecimal(txtPurchaseMobilOil.Text) - Convert.ToDecimal(txtSoldMobileOil.Text));
                lblMBOAmount.Text = Convert.ToString(Convert.ToDecimal(lblAvailableMBO.Text) * Convert.ToDecimal(lblMBORate.Text));
                DataTable TotalExpense = ds.Tables[6];

                DataTable dtFrwrdAmountHSD = ds.Tables[7];
                if (dtFrwrdAmountHSD.Rows.Count > 0)
                {
                    double Rate = 0;
                    for (int i = 0; i < dtFrwrdAmountHSD.Rows.Count; i++)
                    {
                        Rate += Convert.ToDouble(Convert.ToDecimal(dtFrwrdAmountHSD.Rows[i]["Rate"]) * Convert.ToDecimal(dtFrwrdAmountHSD.Rows[i]["Quantity"]));
                    }
                    txtforwardedHSD.Text = Convert.ToString(dtFrwrdAmountHSD.Rows[0]["TotalfrwdedHSDQty"]);
                    txtforwardedHSDRate.Text = Rate.ToString();
                }
                else
                {
                    txtforwardedHSD.Text = "0";
                    txtforwardedHSDRate.Text = "0";
                }

                DataTable dtFrwrdAmountPMG = ds.Tables[8];
                if (dtFrwrdAmountPMG.Rows.Count > 0)
                {
                    double Rate = 0;
                    for (int i = 0; i < dtFrwrdAmountPMG.Rows.Count; i++)
                    {
                        Rate += Convert.ToDouble(Convert.ToDecimal(dtFrwrdAmountPMG.Rows[i]["Rate"]) * Convert.ToDecimal(dtFrwrdAmountPMG.Rows[i]["Quantity"]));
                    }
                    txtforwardedPMG.Text = Convert.ToString(dtFrwrdAmountPMG.Rows[0]["TotalfrwdedPMGQty"]);
                    txtforwardedPMGRate.Text = Rate.ToString();
                }
                else
                {
                    txtforwardedPMG.Text = "0";
                    txtforwardedPMGRate.Text = "0";
                }
                DataTable dtCash = Common.GetPreviousCash();
                if (dtCash.Rows.Count > 0)
                {
                    lblTotalPurchases.Text = Convert.ToString(Convert.ToDouble(lblTotalPurchases.Text) + Convert.ToDouble(dtCash.Rows[0]["TotalPurchase"]));
                    lblTotalSales.Text = Convert.ToString(Convert.ToDouble(lblTotalSales.Text) + Convert.ToDouble(dtCash.Rows[0]["TotalSale"]));
                    lblTotalExpense.Text = Convert.ToString(Convert.ToDouble(lblTotalExpense.Text) + Convert.ToDouble(dtCash.Rows[0]["TotalExpense"]));
                }

                lblProfit.Text = Convert.ToString(Convert.ToDouble(lblTotalSales.Text) - (Convert.ToDouble(lblTotalPurchases.Text) + Convert.ToDouble(lblTotalExpense.Text)));
                loadExpenseDetails();
            }
        }

        public void loadExpenseDetails()
        {
            DataTable dt = ExecutePlainQuery("select *, isnull((select sum(amount) from tbl_Expenses where HeadID=tbl_ExpenseHeads.HeadID and ExpenseDate<='" + getDateTime().ToString("yyyy-MM-dd") + "'),0) as Amount,isnull((select sum(amount) from tbl_Expenses where ExpenseDate<='" + getDateTime().ToString("yyyy-MM-dd") + "'),0) as TotalExpenses from tbl_ExpenseHeads");
            if (dt.Rows.Count > 0)
            {
                rptExpense.DataSource = dt;
                rptExpense.DataBind();
                ltrTotalExpense.Text = dt.Rows[0]["TotalExpenses"].ToString();
            }
        }
    }

}