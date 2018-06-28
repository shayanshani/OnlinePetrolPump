using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlinePetrolPump.BL;
using Helper;
using System.Data;

namespace OnlinePetrolPump.Report
{
    public partial class rptMachineReading : SpartansHelper
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["val"] != null)
                {
                    loadrptMachineReading(Request.QueryString["val"], Request.QueryString["size"]);
                }
            }
        }

        public void loadrptMachineReading(string date, string size)
        {
            switch (size)
            {
                case "1":
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "js10", "<script>setSmallFont();</script>", false);
                    break;
                case "3":
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "js11", "<script>setLargeFont();</script>", false);
                    break;
            }

            SPs.SpMachineReadingReport(date);
            DataTable dt = SPs.SpMachineReadingReport(date).GetDataSet().Tables[0];
            rptMachineReadings.DataSource = dt;
            rptMachineReadings.DataBind();

            if(dt.Rows.Count > 0)
            {
                lblPMGUnits.Text = Convert.ToString(Convert.ToDouble(dt.Rows[0]["ConsumeUnit"]) + Convert.ToDouble(dt.Rows[1]["ConsumeUnit"]));
                lblPMGAmount.Text = Convert.ToString(Convert.ToDouble(dt.Rows[0]["Amount"]) + Convert.ToDouble(dt.Rows[1]["Amount"]));
                lblHSDUnits.Text = Convert.ToString(Convert.ToDouble(dt.Rows[2]["ConsumeUnit"]) + Convert.ToDouble(dt.Rows[3]["ConsumeUnit"]) + Convert.ToDouble(dt.Rows[4]["ConsumeUnit"]) + Convert.ToDouble(dt.Rows[5]["ConsumeUnit"]));
                lblHSDAmount.Text = Convert.ToString(Convert.ToDouble(dt.Rows[2]["Amount"]) + Convert.ToDouble(dt.Rows[3]["Amount"]) + Convert.ToDouble(dt.Rows[4]["Amount"]) + Convert.ToDouble(dt.Rows[5]["Amount"]));
                lblGrandTotal.Text = Convert.ToString(Convert.ToDouble(lblPMGAmount.Text) + Convert.ToDouble(lblHSDAmount.Text));
            }
        }
    }
}