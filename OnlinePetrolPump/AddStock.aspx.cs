using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlinePetrolPump.DL;
using OnlinePetrolPump.BL;
using Helper;
namespace OnlinePetrolPump
{
    public partial class AddCompany : SpartansHelper
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadStock();
        }

        private void loadStock()
        {
            rptStock.DataSource = SPs.SpGetStockDetials(null, null).GetDataSet().Tables[0];
            rptStock.DataBind();
        }

        protected void timer1_Tick(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            string pageurl = string.Format("Report/rptStockDetials.aspx?&fd={0}&td={1}", Convert.ToDateTime(frmDate.SelectedDate).ToString("yyyy-MM-dd"), Convert.ToDateTime(toDate.SelectedDate).ToString("yyyy-MM-dd"));
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openReport", " window.open('" + pageurl + "','_blank');", true);
        }





    }
}