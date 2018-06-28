using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using OnlinePetrolPump.BL;
using System.Data;

namespace OnlinePetrolPump.Report
{
    public partial class rptDailyStatement : SpartansHelper
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["val"] != null)
                    LoadData(Request.QueryString["val"]);
                else
                    LoadData(getDateTime().ToShortDateString());
            }
        }

        private void LoadData(string Date)
        {
            ltrDate.Text = Date;
            DataTable dtExpenses = null, dtInvoiceExpenses = null, dtPaidInvoice = null, dtAmountrecieved = null, dtLoans = null, dtTotalPaidCompany = null;
            MachineReadingsRecord(Date);
            GetNozleReadings(Date);

            dtExpenses = SPs.SpDailyStatementReport(Date).GetDataSet().Tables[0];
            if (dtExpenses.Rows.Count > 0)
            {
                rptExpenses.DataSource = dtExpenses;
                rptExpenses.DataBind();
                ltrTotalExpense.Text = String.Format("{0:0}", Convert.ToDouble(dtExpenses.Rows[dtExpenses.Rows.Count - 1]["total"]));
            }
            dtInvoiceExpenses = SPs.SpDailyStatementReport(Date).GetDataSet().Tables[1];

            if (dtInvoiceExpenses.Rows.Count > 0)
            {
                rptInvoiceExpenses.DataSource = dtInvoiceExpenses;
                rptInvoiceExpenses.DataBind();
                ltrInvoiceExpenses.Text = String.Format("{0:0}", Convert.ToDouble(dtInvoiceExpenses.Rows[dtInvoiceExpenses.Rows.Count - 1]["TotalOtherExpense"]));
            }


            dtPaidInvoice = SPs.SpDailyStatementReport(Date).GetDataSet().Tables[2];
            if (dtPaidInvoice.Rows.Count > 0)
            {
                rptInvoicePaid.DataSource = dtPaidInvoice;
                rptInvoicePaid.DataBind();
                ltrInvoicePaid.Text = String.Format("{0:0}", Convert.ToDouble(dtPaidInvoice.Rows[dtPaidInvoice.Rows.Count - 1]["TotalPaidInvoice"]));
            }

            dtAmountrecieved = SPs.SpDailyStatementReport(Date).GetDataSet().Tables[3];

            if (dtAmountrecieved.Rows.Count > 0)
            {
                rptClientRecievedAmount.DataSource = dtAmountrecieved;
                rptClientRecievedAmount.DataBind();
                ltrClienRecievedAmount.Text = String.Format("{0:0}", Convert.ToDouble(dtAmountrecieved.Rows[dtAmountrecieved.Rows.Count - 1]["TotalRecovery"]));
            }

            dtLoans = SPs.SpDailyStatementReport(Date).GetDataSet().Tables[4];

            if (dtLoans.Rows.Count > 0)
            {
                RptLoans.DataSource = dtLoans;
                RptLoans.DataBind();
                ltrLoans.Text = String.Format("{0:0}", Convert.ToDouble(dtLoans.Rows[dtLoans.Rows.Count - 1]["TotalPaidClient"]));
            }

            dtTotalPaidCompany = SPs.SpDailyStatementReport(Date).GetDataSet().Tables[5];

            if (dtTotalPaidCompany.Rows.Count > 0)
            {
                rptCompanyPaidAmount.DataSource = dtTotalPaidCompany;
                rptCompanyPaidAmount.DataBind();
                ltrTotalPaidCompany.Text = String.Format("{0:0}", Convert.ToDouble(dtTotalPaidCompany.Rows[dtTotalPaidCompany.Rows.Count - 1]["TotalPaidCompany"]));
            }

            //Income
            ltrTotalIncome.Text = Convert.ToString(Convert.ToDouble(string.IsNullOrEmpty(ltrClienRecievedAmount.Text) ? "0" : ltrClienRecievedAmount.Text) + Convert.ToDouble(string.IsNullOrEmpty(lblGrandTotal.Text) ? "0" : lblGrandTotal.Text) + Convert.ToDouble(string.IsNullOrEmpty(ltrTotalPaidCompany.Text) ? "0" : ltrTotalPaidCompany.Text));

            //OutGoing
            LtrTotalOutGoing.Text = Convert.ToString(Convert.ToDouble(string.IsNullOrEmpty(ltrTotalExpense.Text) ? "0" : ltrTotalExpense.Text) + Convert.ToDouble(string.IsNullOrEmpty(ltrInvoiceExpenses.Text) ? "0" : ltrInvoiceExpenses.Text) + Convert.ToDouble(string.IsNullOrEmpty(ltrInvoicePaid.Text) ? "0" : ltrInvoicePaid.Text) + Convert.ToDouble(string.IsNullOrEmpty(ltrLoans.Text) ? "0" : ltrLoans.Text));

            //Subtract
            ltrSubMinus.Text = Convert.ToString(Convert.ToDouble(string.IsNullOrEmpty(ltrTotalIncome.Text) ? "0" : ltrTotalIncome.Text) - Convert.ToDouble(string.IsNullOrEmpty(LtrTotalOutGoing.Text) ? "0" : LtrTotalOutGoing.Text));
        }

        private void MachineReadingsRecord(string Date)
        {
            DataTable dt = SPs.SpMachineReadingReport(Date).GetDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                lblPMGUnits.Text = Convert.ToString(Convert.ToDouble(dt.Rows[0]["ConsumeUnit"]) + Convert.ToDouble(dt.Rows[1]["ConsumeUnit"]));
                lblPMGAmount.Text = Convert.ToString(Convert.ToDouble(dt.Rows[0]["Amount"]) + Convert.ToDouble(dt.Rows[1]["Amount"]));
                lblHSDUnits.Text = Convert.ToString(Convert.ToDouble(dt.Rows[2]["ConsumeUnit"]) + Convert.ToDouble(dt.Rows[3]["ConsumeUnit"]) + Convert.ToDouble(dt.Rows[4]["ConsumeUnit"]) + Convert.ToDouble(dt.Rows[5]["ConsumeUnit"]));
                lblHSDAmount.Text = Convert.ToString(Convert.ToDouble(dt.Rows[2]["Amount"]) + Convert.ToDouble(dt.Rows[3]["Amount"]) + Convert.ToDouble(dt.Rows[4]["Amount"]) + Convert.ToDouble(dt.Rows[5]["Amount"]));
                //SaveTempData(dt);
            }

            DataTable dtOilSales = SPs.SpMachineReadingReport(Date).GetDataSet().Tables[1];
            if (dtOilSales.Rows.Count > 0)
            {
                lblOilLIters.Text = Convert.ToString(Convert.ToDouble(dtOilSales.Rows[0]["TotalLiters"]));
                lblOilAmount.Text = Convert.ToString(Convert.ToDouble(dtOilSales.Rows[0]["SaleTotal"]));
            }
            else
            {
                lblOilLIters.Text = "0";
                lblOilAmount.Text = "0";
            }
            lblGrandTotal.Text = Convert.ToString(Convert.ToDouble(string.IsNullOrEmpty(lblPMGAmount.Text) ? "0" : lblPMGAmount.Text) + Convert.ToDouble(string.IsNullOrEmpty(lblHSDAmount.Text) ? "0" : lblHSDAmount.Text) + Convert.ToDouble(string.IsNullOrEmpty(lblOilAmount.Text) ? "0" : lblOilAmount.Text));
        }

        private void SaveTempData(DataTable dt)
        {
            TblSale objPMGSale = new TblSale();
            objPMGSale.IsNew = true;
            objPMGSale.Qty = Convert.ToDouble(lblPMGUnits.Text);
            objPMGSale.Rate = Convert.ToDecimal(dt.Rows[0]["Rate"]);
            objPMGSale.Price = Convert.ToDecimal(objPMGSale.Qty * Convert.ToDouble(objPMGSale.Rate));
            objPMGSale.CategoryID = 1;
            objPMGSale.DateX = Convert.ToDateTime(dt.Rows[0]["Date"]);
            objPMGSale.Save();

            TblSale objHSDSale = new TblSale();
            objHSDSale.IsNew = true;
            objHSDSale.Qty = Convert.ToDouble(lblHSDUnits.Text);
            objHSDSale.Rate = Convert.ToDecimal(dt.Rows[2]["Rate"]);
            objHSDSale.Price = Convert.ToDecimal(objHSDSale.Qty * Convert.ToDouble(objHSDSale.Rate));
            objHSDSale.CategoryID = 2;
            objHSDSale.DateX = Convert.ToDateTime(dt.Rows[2]["Date"]);
            objHSDSale.Save();
        }

        private void GetNozleReadings(string Date)
        {
            DataTable dtN1 = SPs.SpMachineReading(Convert.ToDateTime(Date)).GetDataSet().Tables[0];//N1
            if (dtN1.Rows.Count > 0)
            {
                lblN1CurrentReading.Text = dtN1.Rows[0]["CurrentReading"].ToString();
                lblN1PrevReading.Text = dtN1.Rows[0]["PreviousReading"].ToString();
                lblTotalN1.Text = dtN1.Rows[0]["TotalN1"].ToString();
            }


            DataTable dtN2 = SPs.SpMachineReading(Convert.ToDateTime(Date)).GetDataSet().Tables[1];//N2
            if (dtN2.Rows.Count > 0)
            {
                lblN2CurrentReading.Text = dtN2.Rows[0]["CurrentReading"].ToString();
                lblN2PrevReading.Text = dtN2.Rows[0]["PreviousReading"].ToString();
                lblTotalN2.Text = dtN2.Rows[0]["TotalN2"].ToString();
            }
            DataTable dtN3 = SPs.SpMachineReading(Convert.ToDateTime(Date)).GetDataSet().Tables[2];//N3
            if (dtN3.Rows.Count > 0)
            {
                lblN3CurrentReading.Text = dtN3.Rows[0]["CurrentReading"].ToString();
                lblN3PrevReading.Text = dtN3.Rows[0]["PreviousReading"].ToString();
                lblTotalN3.Text = dtN3.Rows[0]["TotalN3"].ToString();
            }
            DataTable dtN4 = SPs.SpMachineReading(Convert.ToDateTime(Date)).GetDataSet().Tables[3];//N4
            if (dtN4.Rows.Count > 0)
            {
                lblN4CurrentReading.Text = dtN4.Rows[0]["CurrentReading"].ToString();
                lblN4PrevReading.Text = dtN4.Rows[0]["PreviousReading"].ToString();
                lblTotalN4.Text = dtN4.Rows[0]["TotalN4"].ToString();
            }
            DataTable dtN5 = SPs.SpMachineReading(Convert.ToDateTime(Date)).GetDataSet().Tables[4];//N5
            if (dtN5.Rows.Count > 0)
            {

                lblN5CurrentReading.Text = dtN5.Rows[0]["CurrentReading"].ToString();
                lblN5PrevReading.Text = dtN5.Rows[0]["PreviousReading"].ToString();
                lblTotalN5.Text = dtN5.Rows[0]["TotalN5"].ToString();
            }
            DataTable dtN6 = SPs.SpMachineReading(Convert.ToDateTime(Date)).GetDataSet().Tables[5];//N6
            if (dtN6.Rows.Count > 0)
            {
                lblN6CurrentReading.Text = dtN6.Rows[0]["CurrentReading"].ToString();
                lblN6PrevReading.Text = dtN6.Rows[0]["PreviousReading"].ToString();
                lblTotalN6.Text = dtN6.Rows[0]["TotalN6"].ToString();
            }
        }
    }
}