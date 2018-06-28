using OnlinePetrolPump.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using System.Configuration;

namespace OnlinePetrolPump
{
    public partial class DynamicMachines : SpartansHelper
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = ExecutePlainQuery("select top 1 Date from tbl_MachineReading order by date desc");
                if (dt.Rows.Count > 0)
                {
                    txtPetrolDate.Enabled = false;
                    txtPetrolDate.SelectedDate = Convert.ToDateTime(dt.Rows[0]["Date"]);
                }
                GenerateDynamicMachines();
                GetPreviousReading();
            }
        }

        private void GenerateDynamicMachines()
        {
            DataTable dtMachines = new DataTable("Machines");
            DataColumn dc;
            DataRow dr;
            dc = new DataColumn("MachineNo");
            dc.DataType = System.Type.GetType("System.String");
            dc.Caption = "MachineNo";
            dtMachines.Columns.Add(dc);
            dc = new DataColumn("Category");
            dc.DataType = System.Type.GetType("System.String");
            dc.Caption = "Category";
            dtMachines.Columns.Add(dc);
            dc = new DataColumn("CategoryID");
            dc.DataType = System.Type.GetType("System.String");
            dc.Caption = "CategoryID";
            dtMachines.Columns.Add(dc);
            dc = new DataColumn("NozleNO");
            dc.DataType = System.Type.GetType("System.String");
            dc.Caption = "NozleNO";
            dtMachines.Columns.Add(dc);
            int MachineNo = 0, NozleID = 0;
            for (int i = 1; i <= Convert.ToInt32(ConfigurationManager.AppSettings["PMG_Machines"]); i++)
            {
                MachineNo++;
                dr = dtMachines.NewRow();
                dr["MachineNo"] = MachineNo;
                dr["Category"] = "Petrol";
                dr["CategoryID"] = "1";
                for (int j = 1; j <= 2; j++)
                {
                    NozleID++;
                    dr["NozleNO"] += NozleID + ",";
                }
                dtMachines.Rows.Add(dr);
            }

            for (int i = 1; i <= Convert.ToInt32(ConfigurationManager.AppSettings["HSD_Machines"]); i++)
            {
                MachineNo++;
                dr = dtMachines.NewRow();
                dr["MachineNo"] = MachineNo;
                dr["Category"] = "Deisel";
                dr["CategoryID"] = "2";
                for (int j = 1; j <= 2; j++)
                {
                    NozleID++;
                    dr["NozleNO"] += NozleID + ",";
                }
                dtMachines.Rows.Add(dr);
            }
            rptMachines.DataSource = dtMachines;
            rptMachines.DataBind();
        }
        private void GetPreviousReading()
        {
            DataTable dtN1 = null, dtN2 = null;
            TextBox txtPreviousReadingN1 = null, txtPreviousReadingN2 = null;
            HiddenField hfMachineID = null, hfNozleNo = null;
            for (int i = 0; i < rptMachines.Items.Count; i++)
            {
                txtPreviousReadingN1 = (TextBox)rptMachines.Items[i].FindControl("txtPreviousReadingN1");
                txtPreviousReadingN2 = (TextBox)rptMachines.Items[i].FindControl("txtPreviousReadingN2");
                hfNozleNo = (HiddenField)rptMachines.Items[i].FindControl("hfNozleNo");
                hfMachineID = (HiddenField)rptMachines.Items[i].FindControl("hfMachineID");
                dtN1 = SPs.SpDynamicMachineReading(Convert.ToInt32(hfMachineID.Value), Convert.ToInt32(hfNozleNo.Value.Split(',')[0]), txtPetrolDate.SelectedDate).GetDataSet().Tables[0];
                dtN2 = SPs.SpDynamicMachineReading(Convert.ToInt32(hfMachineID.Value), Convert.ToInt32(hfNozleNo.Value.Split(',')[1]), txtPetrolDate.SelectedDate).GetDataSet().Tables[0];
                if (dtN1.Rows.Count > 0)
                {
                    txtPreviousReadingN1.Text = dtN1.Rows[0]["CurrentReading"].ToString();
                    txtPreviousReadingN2.Text = dtN2.Rows[0]["CurrentReading"].ToString();
                }
            }
        }
        TblMachineReading obj = null;
        protected void btnSaveReading_Click(object sender, EventArgs e)
        {
            HiddenField hfMachineID = null, hfNozleNo = null, hfCategoryID = null;
            double PMGQuantity = 0, HSDQuantity = 0, N1, N2;
            TextBox txtPreviousReadingN1 = null, txtCurrentReadingN1 = null, txtTestUnitsN1 = null,
                txtPreviousReadingN2 = null, txtCurrentReadingN2 = null, txtTestUnitsN2 = null;
            for (int i = 0; i < rptMachines.Items.Count; i++)
            {
                hfNozleNo = (HiddenField)rptMachines.Items[i].FindControl("hfNozleNo");
                hfMachineID = (HiddenField)rptMachines.Items[i].FindControl("hfMachineID");
                hfCategoryID = (HiddenField)rptMachines.Items[i].FindControl("hfCategoryID");
                //First Nozle 
                txtPreviousReadingN1 = (TextBox)rptMachines.Items[i].FindControl("txtPreviousReadingN1");
                txtCurrentReadingN1 = (TextBox)rptMachines.Items[i].FindControl("txtCurrentReadingN1");
                txtTestUnitsN1 = (TextBox)rptMachines.Items[i].FindControl("txtTestUnitsN1");
                //Second Nozle
                txtPreviousReadingN2 = (TextBox)rptMachines.Items[i].FindControl("txtPreviousReadingN2");
                txtCurrentReadingN2 = (TextBox)rptMachines.Items[i].FindControl("txtCurrentReadingN2");
                txtTestUnitsN2 = (TextBox)rptMachines.Items[i].FindControl("txtTestUnitsN2");

                //First Nozle
                obj = new TblMachineReading();
                obj.MachineID = Convert.ToInt32(hfMachineID.Value);
                obj.PreviousReading = Convert.ToDecimal(txtPreviousReadingN1.Text);
                obj.CurrentReading = Convert.ToDecimal(txtCurrentReadingN1.Text);
                if (txtPetrolDate.Enabled)
                    obj.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate).ToShortDateString();
                else
                    obj.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate).AddDays(1).ToShortDateString();
                obj.TestLiter = Convert.ToDecimal(txtTestUnitsN1.Text);
                obj.IsActive = true;
                obj.CategoryID = Convert.ToInt32(hfCategoryID.Value);
                obj.NozleID = Convert.ToInt32(hfNozleNo.Value.Split(',')[0]);
                obj.Rate = obj.CategoryID == 1 ? Convert.ToDecimal(txtPetrolRate.Text) : Convert.ToDecimal(txtDesialRate.Text);
                obj.Save();

                //Second Nozle
                obj = new TblMachineReading();
                obj.MachineID = Convert.ToInt32(hfMachineID.Value);
                obj.PreviousReading = Convert.ToDecimal(txtPreviousReadingN2.Text);
                obj.CurrentReading = Convert.ToDecimal(txtCurrentReadingN2.Text);
                if (txtPetrolDate.Enabled)
                    obj.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate).ToShortDateString();
                else
                    obj.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate).AddDays(1).ToShortDateString();
                obj.TestLiter = Convert.ToDecimal(txtTestUnitsN2.Text);
                obj.IsActive = true;
                obj.CategoryID = Convert.ToInt32(hfCategoryID.Value);
                obj.NozleID = Convert.ToInt32(hfNozleNo.Value.Split(',')[1]);
                obj.Rate = obj.CategoryID == 1 ? Convert.ToDecimal(txtPetrolRate.Text) : Convert.ToDecimal(txtDesialRate.Text);
                obj.Save();
                if (obj.CategoryID == 1)
                {
                    N1 = Convert.ToDouble(Convert.ToDecimal(txtCurrentReadingN1.Text) - Convert.ToDecimal(txtPreviousReadingN1.Text));
                    N2 = Convert.ToDouble(Convert.ToDecimal(txtCurrentReadingN2.Text) - Convert.ToDecimal(txtPreviousReadingN2.Text));
                    PMGQuantity += N1 + N2;
                }
                else
                {
                    N1 = Convert.ToDouble(Convert.ToDecimal(txtCurrentReadingN1.Text) - Convert.ToDecimal(txtPreviousReadingN1.Text));
                    N2 = Convert.ToDouble(Convert.ToDecimal(txtCurrentReadingN2.Text) - Convert.ToDecimal(txtPreviousReadingN2.Text));
                    HSDQuantity += N1 + N2;
                }
            }

            TblSale objPMGSale = new TblSale();
            objPMGSale.IsNew = true;
            objPMGSale.Qty = PMGQuantity;
            objPMGSale.Rate = Convert.ToDecimal(txtPetrolRate.Text);
            objPMGSale.Price = Convert.ToDecimal(objPMGSale.Qty * Convert.ToDouble(objPMGSale.Rate));
            objPMGSale.CategoryID = 1;
            objPMGSale.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate);
            objPMGSale.Save();

            TblSale objHSDSale = new TblSale();
            objHSDSale.IsNew = true;
            objHSDSale.Qty = HSDQuantity;
            objHSDSale.Rate = Convert.ToDecimal(txtDesialRate.Text);
            objHSDSale.Price = Convert.ToDecimal(objHSDSale.Qty * Convert.ToDouble(objHSDSale.Rate));
            objHSDSale.CategoryID = 2;
            objHSDSale.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate);
            objHSDSale.Save();
            Response.Redirect("MachineReading.aspx");
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            string pageurl = "report/rptMachineReading.aspx?val=" + Convert.ToDateTime(txtReportDate.SelectedDate).ToShortDateString() + "&size=" + ddlReportSize.SelectedValue;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openReport", " window.open('" + pageurl + "','_blank');", true);
        }
    }
}