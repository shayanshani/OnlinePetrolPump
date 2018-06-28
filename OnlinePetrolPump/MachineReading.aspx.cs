using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;
using OnlinePetrolPump.BL;
using System.Data;

namespace OnlinePetrolPump
{
    public partial class MachineReading : SpartansHelper
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
                GetPreviousReading();
            }
        }

        TblMachineReading obj = null;

        protected void btnSaveReading_Click(object sender, EventArgs e)
        {
            decimal m2n1 = Convert.ToDecimal(txtCurrentM2N1.Text) - Convert.ToDecimal(txtPreviousM2N1.Text) - Convert.ToDecimal(txtTestM2N1.Text),
                    m2n2 = Convert.ToDecimal(txtCurrentM2N2.Text) - Convert.ToDecimal(txtPreviousM2N2.Text) - Convert.ToDecimal(txtTestM2N2.Text),
                    m3n1 = Convert.ToDecimal(txtCurrentM3N1.Text) - Convert.ToDecimal(txtPreviousM3N1.Text) - Convert.ToDecimal(txtTestM3N1.Text),
                    m3n2 = Convert.ToDecimal(txtCurrentM3N2.Text) - Convert.ToDecimal(txtPreviousM3N2.Text) - Convert.ToDecimal(txtTestM3N2.Text);

            SaveMachine1Data();//Save Machine no.1 Data

            TblSale objPMGSale = new TblSale();
            objPMGSale.IsNew = true;
            objPMGSale.Qty = Convert.ToDouble((Convert.ToDecimal(txtCurrentM1N1.Text) - Convert.ToDecimal(txtPreviousM1N1.Text) - Convert.ToDecimal(txtTestM1N1.Text)) + (Convert.ToDecimal(txtCurrentM1N2.Text) - Convert.ToDecimal(txtPreviousM1N2.Text) - Convert.ToDecimal(txtTestM1N2.Text)));
            objPMGSale.Rate = Convert.ToDecimal(txtPetrolRate.Text);
            objPMGSale.Price = Convert.ToDecimal(objPMGSale.Qty * Convert.ToDouble(objPMGSale.Rate));
            objPMGSale.CategoryID = 1;
            objPMGSale.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate);

            objPMGSale.Save();

            SaveMachine2Data();//Save Machine no.2 Data
            SaveMachine3Data();//Save Machine no.3 Data

            TblSale objHSDSale = new TblSale();
            objHSDSale.IsNew = true;
            objHSDSale.Qty = Convert.ToDouble(m2n1 + m2n2 + m3n1 + m3n2);
            objHSDSale.Rate = Convert.ToDecimal(txtDesialRate.Text);
            objHSDSale.Price = Convert.ToDecimal(objHSDSale.Qty * Convert.ToDouble(objHSDSale.Rate));
            objHSDSale.CategoryID = 2;
            objHSDSale.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate);
            objHSDSale.Save();
            Response.Redirect("MachineReading.aspx");
        }

        private void SaveMachine1Data()
        {
            obj = new TblMachineReading();
            obj.MachineID = 1;
            obj.PreviousReading = Convert.ToDecimal(txtPreviousM1N1.Text);
            obj.CurrentReading = Convert.ToDecimal(txtCurrentM1N1.Text);
            if (txtPetrolDate.Enabled)
                obj.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate).ToShortDateString();
            else
                obj.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate).AddDays(1).ToShortDateString();
            obj.IsActive = true;
            obj.CategoryID = 1;
            obj.TestLiter = Convert.ToDecimal(txtTestM1N1.Text);
            obj.NozleID = 1;
            obj.Rate = Convert.ToDecimal(txtPetrolRate.Text);
            obj.Save();


            obj = new TblMachineReading();
            obj.MachineID = 1;
            obj.PreviousReading = Convert.ToDecimal(txtPreviousM1N2.Text);
            obj.CurrentReading = Convert.ToDecimal(txtCurrentM1N2.Text);

            if (txtPetrolDate.Enabled)
                obj.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate).ToShortDateString();
            else
                obj.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate).AddDays(1).ToShortDateString();

            obj.IsActive = true;
            obj.CategoryID = 1;
            obj.TestLiter = Convert.ToDecimal(txtTestM1N2.Text);
            obj.NozleID = 2;
            obj.Rate = Convert.ToDecimal(txtPetrolRate.Text);
            obj.Save();

        }
        private void SaveMachine2Data()
        {
            obj = new TblMachineReading();
            obj.MachineID = 2;
            obj.PreviousReading = Convert.ToDecimal(txtPreviousM2N1.Text);
            obj.CurrentReading = Convert.ToDecimal(txtCurrentM2N1.Text);

            if (txtPetrolDate.Enabled)
                obj.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate).ToShortDateString();
            else
                obj.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate).AddDays(1).ToShortDateString();

            obj.IsActive = true;
            obj.CategoryID = 2;
            obj.TestLiter = Convert.ToDecimal(txtTestM2N1.Text);
            obj.NozleID = 3;
            obj.Rate = Convert.ToDecimal(txtDesialRate.Text);
            obj.Save();

            obj = new TblMachineReading();
            obj.MachineID = 2;
            obj.PreviousReading = Convert.ToDecimal(txtPreviousM2N2.Text);
            obj.CurrentReading = Convert.ToDecimal(txtCurrentM2N2.Text);

            if (txtPetrolDate.Enabled)
                obj.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate).ToShortDateString();
            else
                obj.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate).AddDays(1).ToShortDateString();

            obj.IsActive = true;
            obj.CategoryID = 2;
            obj.TestLiter = Convert.ToDecimal(txtTestM2N2.Text);
            obj.NozleID = 4;
            obj.Rate = Convert.ToDecimal(txtDesialRate.Text);
            obj.Save();


        }
        private void SaveMachine3Data()
        {
            obj = new TblMachineReading();
            obj.MachineID = 3;
            obj.PreviousReading = Convert.ToDecimal(txtPreviousM3N1.Text);
            obj.CurrentReading = Convert.ToDecimal(txtCurrentM3N1.Text);

            if (txtPetrolDate.Enabled)
                obj.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate).ToShortDateString();
            else
                obj.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate).AddDays(1).ToShortDateString();

            obj.IsActive = true;
            obj.CategoryID = 2;
            obj.TestLiter = Convert.ToDecimal(txtTestM3N1.Text);
            obj.NozleID = 5;
            obj.Rate = Convert.ToDecimal(txtDesialRate.Text);
            obj.Save();

            obj = new TblMachineReading();
            obj.MachineID = 3;
            obj.PreviousReading = Convert.ToDecimal(txtPreviousM3N2.Text);
            obj.CurrentReading = Convert.ToDecimal(txtCurrentM3N2.Text);

            if (txtPetrolDate.Enabled)
                obj.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate).ToShortDateString();
            else
                obj.DateX = Convert.ToDateTime(txtPetrolDate.SelectedDate).AddDays(1).ToShortDateString();

            obj.IsActive = true;
            obj.CategoryID = 2;
            obj.TestLiter = Convert.ToDecimal(txtTestM3N2.Text);
            obj.NozleID = 6;
            obj.Rate = Convert.ToDecimal(txtDesialRate.Text);
            obj.Save();


        }


        private void GetPreviousReading()
        {
            if (getM1N1PreviousReading().Rows.Count > 0)
            {
                txtPreviousM1N1.Text = getM1N1PreviousReading().Rows[0]["CurrentReading"].ToString();
                txtPreviousM1N2.Text = getM1N2PreviousReading().Rows[0]["CurrentReading"].ToString();
                txtPreviousM2N1.Text = getM2N1PreviousReading().Rows[0]["CurrentReading"].ToString();
                txtPreviousM2N2.Text = getM2N2PreviousReading().Rows[0]["CurrentReading"].ToString();
                txtPreviousM3N1.Text = getM3N1PreviousReading().Rows[0]["CurrentReading"].ToString();
                txtPreviousM3N2.Text = getM3N2PreviousReading().Rows[0]["CurrentReading"].ToString();
            }
        }

        private DataTable getM1N1PreviousReading()
        {
            return SPs.SpMachineReading(txtPetrolDate.SelectedDate).GetDataSet().Tables[0];
        }

        private DataTable getM1N2PreviousReading()
        {
            return SPs.SpMachineReading(txtPetrolDate.SelectedDate).GetDataSet().Tables[1];
        }

        private DataTable getM2N1PreviousReading()
        {
            return SPs.SpMachineReading(txtPetrolDate.SelectedDate).GetDataSet().Tables[2];
        }

        private DataTable getM2N2PreviousReading()
        {
            return SPs.SpMachineReading(txtPetrolDate.SelectedDate).GetDataSet().Tables[3];
        }

        private DataTable getM3N1PreviousReading()
        {
            return SPs.SpMachineReading(txtPetrolDate.SelectedDate).GetDataSet().Tables[4];
        }

        private DataTable getM3N2PreviousReading()
        {
            return SPs.SpMachineReading(txtPetrolDate.SelectedDate).GetDataSet().Tables[5];
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            string pageurl = "report/rptMachineReading.aspx?val=" + Convert.ToDateTime(txtReportDate.SelectedDate).ToShortDateString() + "&size=" + ddlReportSize.SelectedValue;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openReport", " window.open('" + pageurl + "','_blank');", true);
        }
    }
}