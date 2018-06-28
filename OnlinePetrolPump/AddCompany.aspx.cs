using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlinePetrolPump.BL;

namespace OnlinePetrolPump
{
    public partial class AddCompany1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadCompany();

            }
        }

        protected void timer1_Tick(object sender, EventArgs e)
        {
            msgDiv.Visible = false;
        }
        public void loadCompany()
        {
            rptCompany.DataSource = SPs.SpGetCompany().GetDataSet().Tables[0];
            rptCompany.DataBind();

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            TblCompany obj = new TblCompany();
            obj.IsNew = true;
            if (!string.IsNullOrEmpty(hfCompany.Value))
            {
                 obj = new TblCompany(hfCompany.Value);
                 obj.IsNew = false;
            }
            obj.Company = txtName.Text;
            obj.Contact = txtContact.Text;
            obj.IsActive = Convert.ToInt32(ddlStatus.SelectedValue);
            obj.Save();
            btnSave.Text = "Save";
            loadCompany();
        }

        protected void lnkEdit_Click(object sender, EventArgs e)
        {
            LinkButton CompanyId = (LinkButton)sender;
            TblCompany obj = new TblCompany(CompanyId.CommandArgument);
            hfCompany.Value =CompanyId.CommandArgument;
            txtName.Text = obj.Company;
            txtContact.Text = obj.Contact;
            ddlStatus.SelectedValue = obj.IsActive.ToString();
            btnSave.Text = "Update";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal('#formPopUp');", true);
            loadCompany();

        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            
        }
    }
}