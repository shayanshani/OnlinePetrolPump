using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlinePetrolPump.BL;
using System.Data;
using Helper;
using System.Web.UI.HtmlControls;
namespace OnlinePetrolPump
{
    public partial class ViewAllExpenses :SpartansHelper
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
                Boolean isAdmin = Convert.ToBoolean(Session["IsAdmin"]);
                if (isAdmin)
                {
                    Thactions.Visible = true;
                    ThactionsEx.Visible = true;
                }
                    

                frmDate.SelectedDate = getDateTime();
                toDate.SelectedDate = getDateTime();
                loadExpenseHead();
                BIndExpenseHeads();
                BindExpenses();
            }
        }

        private void BindExpenses()
        {
            string query = "select * from vw_Expenses";
            BindDataSource(query, rptExpenses);
        }

        private void BIndExpenseHeads()
        {
            BindDataSource("select * from tbl_ExpenseHeads", rptExpenseHeads);
        }


        public void loadExpenseHead()
        {

            FillDropDown(ddlHead, "select * from tbl_ExpenseHeads", "Head", "HeadID", "--Select Expense Head--", "-1");
            FillDropDown(ddlReportHead, "select * from tbl_ExpenseHeads", "Head", "HeadID", "All Expense Head", "-1");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "Expense has been added!";

                TblExpense obj = new TblExpense();
                obj.IsNew = true;

                if (!String.IsNullOrEmpty(hdnExpenseID.Value))
                {
                    obj.IsNew = false;
                    obj = new TblExpense(hdnExpenseID.Value);
                    msg = "Expense has been Updated!";
                }
                obj.HeadID = Convert.ToInt32(ddlHead.SelectedValue);
                obj.UpdateBy = 1;//Use User session
                obj.DateX = getDateTime();
                obj.ExpenseDate = txtDate.SelectedDate;
                obj.Description = txtDescription.Text.Trim();
                obj.Amount = Convert.ToInt32(txtAmount.Text);
                obj.Save();
                hdnExpenseID.Value = null;
                lblmsg.Text = MessageBox.Show(msgDiv, msg, "alert alert-success alert-icon alert-dismissible", icon, "glyphicon glyphicon-ok-sign");

                BindExpenses();
                loadExpenseHead();
            }
            catch
            {

            }
        }

        protected void timer1_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }

        protected void btnAddHead_Click(object sender, EventArgs e)
        {
            string msg = "Expense Head has been added!";
            TblExpenseHead obj = new TblExpenseHead();
            obj.IsNew = true;

            if (!String.IsNullOrEmpty(hfExpenseHeadID.Value))
            {
                obj = new TblExpenseHead(hfExpenseHeadID.Value);
                obj.IsNew = false;
                msg = "Expense Head has been Updated!";
            }
            obj.Head = txtHeadName.Text;
            obj.Save();
            txtHeadName.Text = "";
            BIndExpenseHeads();
            hfExpenseHeadID.Value = null;
            lblPopUpMsg.Text = MessageBox.Show(msgDiv2, msg, "alert alert-success alert-icon alert-dismissible", iconid, "glyphicon glyphicon-ok-sign");
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton ExpenseHeadID = (LinkButton)sender;
            ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(ExpenseHeadID);
            TblExpenseHead.Delete(ExpenseHeadID.CommandArgument);
            lblPopUpMsg.Text = MessageBox.Show(msgDiv2, "Expense Head has been deleted", "alert alert-success alert-icon alert-dismissible", iconid, "glyphicon glyphicon-ok-sign");
            BIndExpenseHeads();
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton ExpenseHeadID = (LinkButton)sender;
            TblExpenseHead obj = new TblExpenseHead(ExpenseHeadID.CommandArgument);
            txtHeadName.Text = obj.Head;
            hfExpenseHeadID.Value = ExpenseHeadID.CommandArgument;
        }

        protected void btnEditEnpense_Click(object sender, EventArgs e)
        {
            LinkButton ExpenseID = (LinkButton)sender;
            TblExpense obj = new TblExpense(ExpenseID.CommandArgument);
            txtAmount.Text = obj.Amount.ToString();
            txtDescription.Text = obj.Description;
            txtDate.SelectedDate = obj.DateX;
            try
            {
                ddlHead.SelectedValue = string.IsNullOrEmpty(obj.HeadID.ToString()) ? "-1" : obj.HeadID.ToString();
            }
            catch
            {
                ddlHead.SelectedValue = "-1";
            }
           
            hdnExpenseID.Value = ExpenseID.CommandArgument;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('#formPopUp');", true);
        }

        protected void btnDeleteExpense_Click(object sender, EventArgs e)
        {
            LinkButton ExpenseID = (LinkButton)sender;
            TblExpense.Delete(ExpenseID.CommandArgument);
            lblmsg.Text = MessageBox.Show(msgDiv, "Expense Detail has been deleted", "alert alert-success alert-icon alert-dismissible", icon, "glyphicon glyphicon-ok-sign");
            BindExpenses();
        }

        protected void timer2_Tick(object sender, EventArgs e)
        {
            msgDiv2.Visible = false;
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            string pageurl = "Report/rptExpense.aspx?HeadID=" + ddlReportHead.SelectedValue + "&fd=" + Convert.ToDateTime(frmDate.SelectedDate).ToString("MM-dd-yyyy") + "&td=" + Convert.ToDateTime(toDate.SelectedDate).ToString("MM-dd-yyyy");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openReport", " window.open('" + pageurl + "','_blank');", true);

        }

        protected void rptExpenseHeads_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //Boolean isAdmin = Convert.ToBoolean(Session["IsAdmin"].ToString());

            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    HtmlTableCell tdActions = (HtmlTableCell)e.Item.FindControl("tdActions");
            //    if (isAdmin)
            //        tdActions.Visible = true;
            //}
        }

        protected void rptExpenses_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //Boolean isAdmin = Convert.ToBoolean(Session["IsAdmin"].ToString());

            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    HtmlTableCell tdActions = (HtmlTableCell)e.Item.FindControl("tdActionEx");
            //    if (isAdmin)
            //        tdActions.Visible = true;
            //}
        }
    }
}