using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlinePetrolPump.BL;

namespace OnlinePetrolPump.Report
{
    public partial class rptSalePurchase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                loadSalePruchase(Convert.ToString(Request.QueryString["val"]), Convert.ToString(Request.QueryString["typ"]), Convert.ToString(Request.QueryString["opt"]));
            }
        }
        public void loadSalePruchase(string Date, string Type, string ReportType)
        {
            string[] date = Date.Split(',');
            ltrFromDate.Text = Convert.ToDateTime(date[0]).ToString("dd-MM-yyyy");
            ltrToDate.Text = Convert.ToDateTime(date[1]).ToString("dd-MM-yyyy");

            DataSet ds = SPs.SpSalePurchaseReport(date[0], date[1]).GetDataSet();
            if (ReportType == "1")
            {
                lblHeading.Text = "Sale Report";
                if (Type == "1")
                {
                   
                    PMG.Visible = true;
                    rptPMGSale.DataSource = ds.Tables[0];
                    rptPMGSale.DataBind();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ltrPMGSaleQTy.Text = Convert.ToString(ds.Tables[0].Rows[0]["PMGtotalQTY"]);
                        ltrPMGSalePrice.Text = String.Format("{0:0}", (Convert.ToDouble(ds.Tables[0].Rows[0]["PMGtotalPrice"])));
                    }

                }
                else if (Type == "2")
                {
                    
                    HSD.Visible = true;
                    rptHSDSale.DataSource = ds.Tables[1];
                    rptHSDSale.DataBind();

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        ltrHSDSaleQTy.Text = Convert.ToString(ds.Tables[1].Rows[0]["HSDtotalQTY"]);
                        ltrHSDSalePrice.Text = String.Format("{0:0}", (Convert.ToDouble(ds.Tables[1].Rows[0]["HSDtotalPrice"])));
                    }
                }
                else if (Type == "3")
                {
                   
                    Oil.Visible = true;
                    rptMoboilSale.DataSource = ds.Tables[2];
                    rptMoboilSale.DataBind();
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        ltrMoboiltotalQTY.Text = Convert.ToString(ds.Tables[2].Rows[0]["MoboiltotalQTY"]);
                        ltrMoboilPrice.Text = String.Format("{0:0}", (Convert.ToDouble(ds.Tables[2].Rows[0]["MoboilPrice"])));

                    }
                }
                else if (Type == "4")
                {
                   
                    PMG.Visible = true;
                    HSD.Visible = true;
                    Oil.Visible = true;
                    rptPMGSale.DataSource = ds.Tables[0];
                    rptPMGSale.DataBind();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ltrPMGSaleQTy.Text = Convert.ToString(ds.Tables[0].Rows[0]["PMGtotalQTY"]);
                        ltrPMGSalePrice.Text = String.Format("{0:0}", (Convert.ToDouble(ds.Tables[0].Rows[0]["PMGtotalPrice"])));
                    }
                    rptHSDSale.DataSource = ds.Tables[1];
                    rptHSDSale.DataBind();

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        ltrHSDSaleQTy.Text = Convert.ToString(ds.Tables[1].Rows[0]["HSDtotalQTY"]);
                        ltrHSDSalePrice.Text = String.Format("{0:0}", (Convert.ToDouble(ds.Tables[1].Rows[0]["HSDtotalPrice"])));
                    }
                    rptMoboilSale.DataSource = ds.Tables[2];
                    rptMoboilSale.DataBind();
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        ltrMoboiltotalQTY.Text = Convert.ToString(ds.Tables[2].Rows[0]["MoboiltotalQTY"]);
                        ltrMoboilPrice.Text = String.Format("{0:0}", (Convert.ToDouble(ds.Tables[2].Rows[0]["MoboilPrice"])));

                    }

                }
            }
            else if (ReportType == "2")
            {
                lblHeading.Text = "Purchase Report";
                if (Type == "1")
                {
                    
                    PMGPurchase.Visible = true;
                    rptPMGPurchase.DataSource = ds.Tables[3];
                    rptPMGPurchase.DataBind();
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        ltrPMGPurchaseQTY.Text = Convert.ToString(ds.Tables[3].Rows[0]["PMGPurchaseQTY"]);
                        ltrPMGPurchasePrices.Text = String.Format("{0:0}", (Convert.ToDouble(ds.Tables[3].Rows[0]["PMGPurchasePrice"])));
                    }

                }
                else if (Type == "2")
                {
                    
                    HSDpurchase.Visible = true;
                    rptHSDPurchase.DataSource = ds.Tables[4];
                    rptHSDPurchase.DataBind();

                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        ltrHSDPurchaseQTY.Text = Convert.ToString(ds.Tables[4].Rows[0]["HSDPurchaseQTY"]);
                        ltrHSDPurchasePrice.Text = String.Format("{0:0}", (Convert.ToDouble(ds.Tables[4].Rows[0]["HSDPurchasePrice"])));
                    }
                }
                else if (Type == "3")
                {
                     
                    OilPurchase.Visible = true;
                    rptOilPurchase.DataSource = ds.Tables[5];
                    rptOilPurchase.DataBind();
                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        ltrOilPurchaseQTY.Text = Convert.ToString(ds.Tables[5].Rows[0]["OILPurchaseQTY"]);
                        ltrOilPurchasePrice.Text = String.Format("{0:0}", (Convert.ToDouble(ds.Tables[5].Rows[0]["OILPurchasePrice"])));

                    }
                }
                else if (Type == "4")
                {
                   
                    PMGPurchase.Visible = true;
                    HSDpurchase.Visible = true;
                    OilPurchase.Visible = true;
                    rptPMGPurchase.DataSource = ds.Tables[3];
                    rptPMGPurchase.DataBind();
                    if (ds.Tables[3].Rows.Count > 0)
                    {
                        ltrPMGPurchaseQTY.Text = Convert.ToString(ds.Tables[3].Rows[0]["PMGPurchaseQTY"]);
                        ltrPMGPurchasePrices.Text = String.Format("{0:0}", (Convert.ToDouble(ds.Tables[3].Rows[0]["PMGPurchasePrice"])));
                    }
                    rptHSDPurchase.DataSource = ds.Tables[4];
                    rptHSDPurchase.DataBind();

                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        ltrHSDPurchaseQTY.Text = Convert.ToString(ds.Tables[4].Rows[0]["HSDPurchaseQTY"]);
                        ltrHSDPurchasePrice.Text = String.Format("{0:0}", (Convert.ToDouble(ds.Tables[4].Rows[0]["HSDPurchasePrice"])));
                    }
                    rptOilPurchase.DataSource = ds.Tables[5];
                    rptOilPurchase.DataBind();
                    if (ds.Tables[5].Rows.Count > 0)
                    {
                        ltrOilPurchaseQTY.Text = Convert.ToString(ds.Tables[5].Rows[0]["OILPurchaseQTY"]);
                        ltrOilPurchasePrice.Text = String.Format("{0:0}", (Convert.ToDouble(ds.Tables[5].Rows[0]["OILPurchasePrice"])));

                    }

                }




            }


        }
    }
}