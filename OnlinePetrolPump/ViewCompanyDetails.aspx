<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewCompanyDetails.aspx.cs" Inherits="OnlinePetrolPump.ViewCompanyDetails" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function add_number() {

            var first_number = parseFloat(document.getElementById("<%=txtRate.ClientID%>").value);
            var second_number = parseFloat(document.getElementById("<%=txtLiters.ClientID%>").value);
            var result = first_number * second_number;
            document.getElementById("<%=txtTotalAmount.ClientID%>").value = result;
        }

        function frwrdAmount() {
            var frwrdRate = parseFloat(document.getElementById("<%=txtfrwrdRate.ClientID%>").value);
            var FrwrdLiters = parseFloat(document.getElementById("<%=txtfrwrdQuantity.ClientID%>").value);
            var Frwrdresult = frwrdRate * FrwrdLiters;
            document.getElementById("<%=txtFrwrdAmount.ClientID%>").value = Frwrdresult;
        }
    </script>

    <link href="Select2/select2.min.css" rel="stylesheet" />
    <script src="Select2/select2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#<%= ddlCLient.ClientID%>").select2({
                //data: country
            });
        });
        function pageLoad(sender, args) {
            $("#<%= ddlCLient.ClientID%>").select2({
                //data: country
            });
        }
    </script>
    <link href="Select2/CustomCss.css" rel="stylesheet" />
    <style>
        .select2 {
            width: 100% !important;
        }
    </style>


    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2 style="width: 35%!important;">
                        <div class="row" id="CompanyHeaderInfo" runat="server">
                            <div class="col-lg-12">
                                <div class="row" style="margin-bottom: 17px!important">
                                    <div class="col-lg-6">
                                        Company Name:
                                    </div>
                                    <div class="col-lg-6">
                                        <code>
                                            <asp:Label ID="lblCompanyName" runat="server" Style="color: #000!important"></asp:Label>
                                        </code>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-6">
                                        Contact:
                                    </div>
                                    <div class="col-lg-6">
                                        <code>
                                            <asp:Label ID="lblCompanyContact" runat="server" Style="color: #000!important"></asp:Label>
                                        </code>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </h2>
                    <div class="clearfix"></div>
                </div>

                <asp:HiddenField ID="hfSerialNo" runat="server" />
                <div class="x_content">

                    <div class="row">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12"></label>

                        <div class="col-lg-12">

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Timer runat="server" ID="timer1" Interval="10000" OnTick="timer1_Tick"></asp:Timer>
                                    <div aria-live="assertive" id="msgDiv" runat="server" visible="false" style="width: 100%; right: 36px; top: 36px; cursor: auto; text-align: left">
                                        <div class="ui-pnotify-icon"><span id="icon" runat="server"></span></div>
                                        <div class="ui-pnotify-text">
                                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>


                    <div class="row">
                        <div class="col-lg-7">
                            <div class="row">
                                <div class="col-lg-12">

                                    <div class="form-group">
                                        <label class="control-label col-md-6">
                                            Select Company: <span class="required">
                                                <asp:RequiredFieldValidator ID="req" runat="server" ValidationGroup="Validation" ControlToValidate="ddlCompanyName" InitialValue="-1" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator></span>
                                        </label>
                                        <div class="col-md-12">
                                            <asp:DropDownList ID="ddlCompanyName" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCompanyName_SelectedIndexChanged" AutoPostBack="true" TabIndex="1">
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">

                                    <asp:UpdatePanel ID="pnlDropDowns" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>

                                            <div class="row">
                                                <div class="col-lg-12">

                                                    <div class="form-group">
                                                        <label class="control-label col-md-6">
                                                            Select Category: <span class="required">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ValidationGroup="Validation" ControlToValidate="ddlCategory" InitialValue="-1" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator></span>
                                                        </label>
                                                        <div class="col-md-12">
                                                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control" TabIndex="2" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true">
                                                                <asp:ListItem Value="-1">Select Category</asp:ListItem>
                                                                <asp:ListItem Value="1">PMG</asp:ListItem>
                                                                <asp:ListItem Value="2">HSD</asp:ListItem>
                                                                <asp:ListItem Value="3">Mobil Oil</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                </div>


                                            </div>

                                            <div class="row" id="productsRow" runat="server" visible="false">
                                                <div class="col-lg-12">

                                                    <div class="form-group">
                                                        <label class="control-label col-md-6">
                                                            Select Product: <span class="required">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ValidationGroup="Validation" ControlToValidate="ddlProducts" InitialValue="-1" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator></span>
                                                        </label>
                                                        <div class="col-md-12">
                                                            <asp:DropDownList ID="ddlProducts" runat="server" CssClass="form-control" TabIndex="2">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>

                                                </div>

                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>


                                    <div class="row">
                                        <div class="col-lg-6">

                                            <div class="form-group">
                                                <label class="control-label col-md-6">
                                                    RecieptNo: <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Validation" ControlToValidate="txtRecieptNo" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator></span>
                                                </label>
                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtRecieptNo" runat="server" CssClass="form-control has-feedback-left" TabIndex="3"></asp:TextBox>
                                                    <span class="fa fa-newspaper-o form-control-feedback left" aria-hidden="true"></span>
                                                </div>
                                            </div>




                                        </div>

                                        <div class="col-lg-6">

                                            <div class="form-group">
                                                <label class="control-label col-md-6">
                                                    Qty(Liters): <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Validation" ControlToValidate="txtLiters" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator></span>
                                                </label>
                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtLiters" runat="server" CssClass="form-control has-feedback-left" onchange="add_number();" TabIndex="2"></asp:TextBox>
                                                    <span class="fa fa-sort-amount-asc form-control-feedback left" aria-hidden="true"></span>
                                                </div>
                                            </div>

                                        </div>


                                    </div>


                                    <div class="row">

                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label class="control-label col-md-6">
                                                    Rate: <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Validation" ControlToValidate="txtRate" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator></span>
                                                </label>
                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtRate" runat="server" CssClass="form-control has-feedback-left" onchange="add_number();" TabIndex="4"></asp:TextBox>
                                                    <span class="fa fa-money form-control-feedback left" aria-hidden="true"></span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label class="control-label col-md-6">
                                                    Amount: 
                                                </label>
                                                <div class="col-md-12">
                                                    <input type="text" id="txtTotalAmount" runat="server" class="form-control has-feedback-left" disabled />
                                                    <span class="fa fa-money form-control-feedback left" aria-hidden="true"></span>
                                                </div>
                                            </div>

                                        </div>


                                    </div>


                                    <div class="row">

                                        <div class="col-lg-6">
                                            <div class="form-group">
                                                <label class="control-label col-md-6">
                                                    Date:&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ValidationGroup="Validation" ControlToValidate="txtPetrolDate" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                </label>
                                                <div class="col-md-12">
                                                    <telerik:RadDatePicker RenderMode="Lightweight" ID="txtPetrolDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr" TabIndex="5">
                                                        <DateInput runat="server" DateFormat="dd-MM-yyyy">
                                                        </DateInput>
                                                    </telerik:RadDatePicker>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-lg-6">

                                            <div class="form-group">
                                                <label class="control-label col-md-6">
                                                    Vehicle No: <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="Validation" ControlToValidate="txtVehicleNo" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator></span>
                                                </label>
                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtVehicleNo" runat="server" CssClass="form-control has-feedback-left" TabIndex="7"></asp:TextBox>
                                                    <span class="fa fa-automobile form-control-feedback left" aria-hidden="true"></span>
                                                </div>

                                            </div>
                                        </div>


                                    </div>
                                    <div class="row">

                                        <div class="col-lg-6">

                                            <div class="form-group">
                                                <label class="control-label col-md-6">
                                                    Other Expense: <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="Validation" ControlToValidate="txtOtherExpense" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator></span>
                                                </label>
                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtOtherExpense" runat="server" CssClass="form-control has-feedback-left" TabIndex="6"></asp:TextBox>
                                                    <span class="fa fa-money form-control-feedback left" aria-hidden="true"></span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">


                                        <div class="col-lg-12">

                                            <div class="form-group">
                                                <label class="control-label col-md-6">
                                                    Description(if any): 
                                                </label>
                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtPetrolDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" Style="resize: none!important" TabIndex="8"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">

                                    <div class="col-lg-1 col-lg-offset-1" style="margin-top: 12px">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClientClick="if (!Page_ClientValidate('Validation')){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" OnClick="btnSave_Click" ValidationGroup="Validation" />
                                    </div>


                                </div>
                                <div class="col-lg-6">
                                    <br />
                                    <br />
                                    <!--Paid Ammount Pop up -->
                                    <div class="modal fade bs-example-modal-sm openPaidPopUp" tabindex="-1" role="dialog" aria-hidden="true" id="PaidformPopUp">
                                        <div class="modal-dialog modal-sm">
                                            <div class="modal-content">

                                                <div class="modal-header">
                                                    <button type="button" class="close" id="cls" data-dismiss="modal">
                                                        <span aria-hidden="true">×</span>
                                                    </button>
                                                    <h4 class="modal-title" id="myModalLabel">
                                                        <asp:Label ID="lblPopUpHeading" runat="server">Paid Amount</asp:Label></h4>
                                                </div>
                                                <div class="modal-body">
                                                    <!-- Content  -->
                                                    <div class="x_content" style="float: none!important">

                                                        <div class="row">
                                                            <div class="form-group">
                                                                <div class="col-md-12">
                                                                    <label>
                                                                        Company Name :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ValidationGroup="ValidationPaid" ControlToValidate="ddlPaidCompanyName" InitialValue="-1" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                                    </label>

                                                                </div>
                                                                <br />
                                                                <div class="col-md-12">
                                                                    <asp:DropDownList ID="ddlPaidCompanyName" runat="server" CssClass="form-control"></asp:DropDownList>
                                                                </div>

                                                            </div>

                                                        </div>

                                                        <div class="row">
                                                            <div class="form-group">
                                                                <div class="col-md-12">
                                                                    <label>
                                                                        RecieptNo :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ValidationGroup="ValidationPaid" ControlToValidate="txtPaidReciept" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                                    </label>

                                                                </div>
                                                                <br />
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ID="txtPaidReciept" runat="server" CssClass="form-control has-feedback-left"></asp:TextBox>
                                                                    <span class="fa fa-newspaper-o form-control-feedback left" aria-hidden="true"></span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="from-group">
                                                                <div class="col-md-12">
                                                                    <label style="margin-top: 8px!important;" class="control-label col-md-2">
                                                                        Vehicle No: <span class="required">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="ValidationPaid" ControlToValidate="txtVehiclePaid" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator></span>
                                                                    </label>
                                                                </div>
                                                                <br />
                                                                <div class="col-md-12">

                                                                    <asp:TextBox ID="txtVehiclePaid" runat="server" CssClass="form-control has-feedback-left" TabIndex="7"></asp:TextBox>
                                                                    <span class="fa fa-automobile form-control-feedback left" aria-hidden="true"></span>

                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="row">
                                                            <div class="form-group">
                                                                <div class="col-md-12">
                                                                    <label>
                                                                        Amount :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="ValidationPaid" ControlToValidate="txtPaidAmmount" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                                    </label>

                                                                </div>
                                                                <br />
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ID="txtPaidAmmount" runat="server" CssClass="form-control has-feedback-left"></asp:TextBox>
                                                                    <span class="fa fa-money form-control-feedback left" aria-hidden="true"></span>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="row">
                                                            <div class="form-group">
                                                                <div class="col-md-12">
                                                                    <label>
                                                                        Date:&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ValidationGroup="ValidationPaid" ControlToValidate="txtPaidDate" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                                    </label>
                                                                </div>
                                                                <br />
                                                                <div class="col-md-12">
                                                                    <telerik:RadDatePicker RenderMode="Lightweight" ID="txtPaidDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
                                                                        <DateInput runat="server" DateFormat="dd-MM-yyyy">
                                                                        </DateInput>
                                                                    </telerik:RadDatePicker>
                                                                </div>

                                                            </div>
                                                        </div>

                                                        <div class="clearfix"></div>

                                                        <div class="row">
                                                            <div class="form-group">
                                                                <div class="col-md-12">
                                                                    <label>
                                                                        Description:&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="ValidationPaid" ControlToValidate="txtPaidDescription" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                                    </label>
                                                                </div>
                                                                <br />
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ID="txtPaidDescription" runat="server" CssClass="form-control" Rows="4" TextMode="MultiLine" Style="resize: none!important"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="clearfix"></div>

                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal" id="cls1">Close</button>
                                                    <asp:Button ID="btnPaidAmmount" runat="server" OnClick="btnPaidAmmount_Click" Text="Save" CssClass="btn btn-primary" OnClientClick="if (!Page_ClientValidate('ValidationPaid')){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" ValidationGroup="ValidationPaid" />
                                                </div>

                                            </div>
                                        </div>
                                    </div>

                                    <!-- Recieved Ammount Pop up -->
                                    <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-hidden="true" id="RecivedformPopUp">
                                        <div class="modal-dialog modal-sm">
                                            <div class="modal-content">

                                                <div class="modal-header">
                                                    <button type="button" class="close" id="cls3" data-dismiss="modal">
                                                        <span aria-hidden="true">×</span>
                                                    </button>
                                                    <h4 class="modal-title">
                                                        <asp:Label ID="Label1" runat="server">Recived Amount</asp:Label></h4>
                                                </div>
                                                <div class="modal-body">
                                                    <!-- Content  -->
                                                    <div class="x_content" style="float: none!important">

                                                        <div class="row">
                                                            <div class="form-group">
                                                                <div class="col-md-12">
                                                                    <label>
                                                                        Company Name :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ValidationGroup="ValidationRecieved" ControlToValidate="ddlRecievedCompanyName" InitialValue="-1" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                                    </label>

                                                                </div>
                                                                <br />
                                                                <div class="col-md-12">
                                                                    <asp:DropDownList ID="ddlRecievedCompanyName" runat="server" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="row">
                                                            <div class="form-group">
                                                                <div class="col-md-12">
                                                                    <label>
                                                                        Receipt No :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="ValidationRecieved" ControlToValidate="txtRecievdReceiptNo" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                                    </label>

                                                                </div>
                                                                <br />
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ID="txtRecievdReceiptNo" runat="server" CssClass="form-control has-feedback-left"></asp:TextBox>
                                                                    <span class="fa fa-newspaper-o form-control-feedback left" aria-hidden="true"></span>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="row">
                                                            <div class="form-group">
                                                                <div class="col-md-12">
                                                                    <label>
                                                                        Amount :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="ValidationRecieved" ControlToValidate="txtRecivedAmmount" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                                    </label>

                                                                </div>
                                                                <br />
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ID="txtRecivedAmmount" runat="server" CssClass="form-control has-feedback-left"></asp:TextBox>
                                                                    <span class="fa fa-money form-control-feedback left" aria-hidden="true"></span>
                                                                </div>

                                                            </div>


                                                        </div>

                                                        <div class="row">
                                                            <div class="form-group">
                                                                <div class="col-md-12">
                                                                    <label>
                                                                        Description:&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="ValidationRecieved" ControlToValidate="txtRecivedDescription" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                                    </label>
                                                                </div>
                                                                <br />
                                                                <div class="col-md-12">
                                                                    <asp:TextBox ID="txtRecivedDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" Style="resize: none!important"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="clearfix"></div>
                                                        <div class="row">
                                                            <div class="form-group">
                                                                <div class="col-md-12">
                                                                    <label>
                                                                        Date:&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ValidationGroup="ValidationRecieved" ControlToValidate="txtRecivedDate" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                                    </label>
                                                                </div>
                                                                <br />
                                                                <div class="col-md-12">
                                                                    <telerik:RadDatePicker RenderMode="Lightweight" ID="txtRecivedDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
                                                                        <DateInput runat="server" DateFormat="dd-MM-yyyy">
                                                                        </DateInput>
                                                                    </telerik:RadDatePicker>
                                                                </div>

                                                            </div>
                                                        </div>

                                                        <div class="clearfix"></div>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal" id="cls2">Close</button>
                                                    <asp:Button ID="btnRecieveAmmount" runat="server" OnClick="btnRecieveAmmount_Click" Text="Save" CssClass="btn btn-primary" OnClientClick="if (!Page_ClientValidate('ValidationRecieved')){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" ValidationGroup="ValidationRecieved" />
                                                </div>

                                            </div>
                                        </div>
                                    </div>

                                    <!-- Report PopUp -->
                                    <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-hidden="true" id="GenerateReport">
                                        <div class="modal-dialog modal-sm">
                                            <div class="modal-content">

                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal">
                                                        <span aria-hidden="true">×</span>
                                                    </button>
                                                    <h4 class="modal-title">
                                                        <asp:Label ID="Label2" runat="server">Company Detail Report</asp:Label></h4>
                                                </div>
                                                <div class="modal-body">
                                                    <!-- Content  -->
                                                    <div class="x_content" style="float: none!important">

                                                        <div class="row">
                                                            <div class="form-group">
                                                                <asp:UpdatePanel ID="pnl" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>

                                                                        <div class="col-md-12">
                                                                            <label>
                                                                                Select Report:<asp:RequiredFieldValidator ValidationGroup="rpt1" runat="server" ID="rqddlReportTpye" ControlToValidate="ddlReportType" ErrorMessage="*" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                                            </label>

                                                                            <br />
                                                                            <div class="col-md-12">

                                                                                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlReportType" AutoPostBack="true">
                                                                                    <asp:ListItem Value="-1">Select Report Type</asp:ListItem>
                                                                                    <asp:ListItem Value="0">Invoice Report</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Statment Report</asp:ListItem>
                                                                                </asp:DropDownList>

                                                                            </div>
                                                                        </div>
                                                                        <div id="divVihcleNo" runat="server" visible="false">
                                                                            <div class="col-md-12">

                                                                                <label>
                                                                                    Vehicle No:<%--<asp:RequiredFieldValidator ValidationGroup="rpt1" runat="server" ID="RequiredFieldValidator5" ControlToValidate="txtRVehcleNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                                </label>
                                                                            </div>
                                                                            <div class="col-md-12">

                                                                                <label>
                                                                                    <label>
                                                                                        <asp:TextBox ID="txtRVehcleNo" runat="server" CssClass="form-control has-feedback-left" TabIndex="7"></asp:TextBox>
                                                                                        <span class="fa fa-automobile form-control-feedback left" aria-hidden="true"></span>
                                                                                    </label>
                                                                                </label>
                                                                            </div>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                                <div class="col-md-12">

                                                                    <label>
                                                                        Select Date:
                                                                    </label>
                                                                </div>
                                                                <br />
                                                                <div class="col-md-12">

                                                                    <div class="form-horizontal">
                                                                        <fieldset>
                                                                            <div class="control-group">
                                                                                <div class="controls">
                                                                                    <div class="input-prepend input-group">
                                                                                        <span class="add-on input-group-addon"><i class="glyphicon glyphicon-calendar fa fa-calendar"></i></span>
                                                                                        <input type="text" style="width: 200px" name="txtReportDate" id="reservation" class="form-control" />
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </fieldset>
                                                                    </div>

                                                                </div>

                                                            </div>


                                                        </div>
                                                        <div class="clearfix"></div>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                    <asp:Button ID="btnShowReport" OnClick="btnShowReport_Click" runat="server" Text="Show Report" OnClientClick="if (!Page_ClientValidate('rpt1')){ return false; } this.disabled = true; this.value = 'Please wait...';" UseSubmitBehavior="false" CssClass="btn btn-primary" ValidationGroup="rpt1" />
                                                </div>

                                            </div>
                                        </div>
                                    </div>

                                    <!-- Add Products -->
                                    <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-hidden="true" id="AddProducts">
                                        <div class="modal-dialog modal-sm">
                                            <div class="modal-content">

                                                <div class="modal-header">
                                                    <button type="button" class="close" data-dismiss="modal">
                                                        <span aria-hidden="true">×</span>
                                                    </button>
                                                    <h4 class="modal-title">
                                                        <asp:Label ID="Label3" runat="server">Add Product</asp:Label></h4>
                                                </div>
                                                <div class="modal-body">
                                                    <!-- Content  -->
                                                    <div class="x_content" style="float: none!important">

                                                        <div class="row">
                                                            <div class="form-group">

                                                                <div class="col-lg-12">

                                                                    <div class="form-group">
                                                                        <label class="control-label col-md-6">
                                                                            Product: <span class="required">
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ValidationGroup="rptPro" ControlToValidate="txtProduct" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator></span>
                                                                        </label>
                                                                        <div class="col-md-12">
                                                                            <asp:TextBox ID="txtProduct" runat="server" CssClass="form-control has-feedback-left" TabIndex="7"></asp:TextBox>
                                                                            <span class="fa fa-automobile form-control-feedback left" aria-hidden="true"></span>
                                                                        </div>

                                                                    </div>
                                                                </div>

                                                            </div>


                                                        </div>
                                                        <div class="clearfix"></div>
                                                    </div>
                                                </div>
                                                <div class="modal-footer">
                                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClientClick="if (!Page_ClientValidate('rptPro')){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" OnClick="btnSubmit_Click" ValidationGroup="rptPro" />
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                    <!-- frwd Amount -->
                                    <div class="modal fade bs-example-modal-lg" role="dialog" aria-hidden="true" id="frwdAmount">
                                        <div class="modal-dialog modal-lg">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button type="button" class="close" id="cls4" data-dismiss="modal">
                                                        <span aria-hidden="true">×</span>
                                                    </button>
                                                    <h4 class="modal-title">
                                                        <asp:Label ID="Label4" runat="server">Farword Amount</asp:Label></h4>
                                                </div>
                                                <asp:HiddenField ID="hfFID" runat="server" />
                                                <asp:UpdatePanel ID="pnlHeads" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <div class="modal-body">
                                                            <!-- Content  -->
                                                            <div class="x_content" style="float: none!important">
                                                                <div class="row">
                                                                    <label class="control-label col-md-3 col-sm-3 col-xs-12"></label>

                                                                    <div class="col-lg-12">

                                                                       <%-- <asp:Timer runat="server" ID="timer2" Interval="10000" OnTick="timer2_Tick"></asp:Timer>--%>
                                                                        <div aria-live="assertive" id="msgDiv2" runat="server" visible="false" style="width: 100%; right: 36px; top: 36px; cursor: auto; text-align: left">
                                                                            <div class="ui-pnotify-icon"><span id="Span1" runat="server"></span></div>
                                                                            <div class="ui-pnotify-text">
                                                                                <asp:Label ID="lblmsg2" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>


                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <label>
                                                                                Client :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ValidationGroup="ValidationFrwrd" ControlToValidate="ddlCLient" InitialValue="-1" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                                            </label>

                                                                        </div>
                                                                        <br />
                                                                        <div class="col-md-12">
                                                                            <asp:DropDownList ID="ddlCLient" runat="server" CssClass="form-control">
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="row">
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <label>
                                                                                Quantity :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ValidationGroup="ValidationFrwrd" ControlToValidate="txtfrwrdQuantity" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                                            </label>

                                                                        </div>
                                                                        <br />
                                                                        <div class="col-md-12">
                                                                            <asp:TextBox ID="txtfrwrdQuantity" runat="server" CssClass="form-control has-feedback-left" onchange="frwrdAmount();"></asp:TextBox>
                                                                            <span class="fa fa-newspaper-o form-control-feedback left" aria-hidden="true"></span>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="row">
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <label>
                                                                                Rate :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ValidationGroup="ValidationFrwrd" ControlToValidate="txtfrwrdRate" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                                            </label>

                                                                        </div>
                                                                        <br />
                                                                        <div class="col-md-12">
                                                                            <asp:TextBox ID="txtfrwrdRate" runat="server" CssClass="form-control has-feedback-left" onchange="frwrdAmount();"></asp:TextBox>
                                                                            <span class="fa fa-newspaper-o form-control-feedback left" aria-hidden="true"></span>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="row">
                                                                    <div class="form-group">
                                                                        <div class="col-md-12">
                                                                            <label>
                                                                                Amount :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ValidationGroup="ValidationFrwrd" ControlToValidate="txtFrwrdAmount" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                                            </label>

                                                                        </div>
                                                                        <br />
                                                                        <div class="col-md-12">
                                                                            <asp:TextBox ID="txtFrwrdAmount" runat="server" CssClass="form-control has-feedback-left"></asp:TextBox>
                                                                            <span class="fa fa-money form-control-feedback left" aria-hidden="true"></span>
                                                                        </div>

                                                                    </div>
                                                                    <br />
                                                                    <br />
                                                                    <br />

                                                                    <table id="datatable-responsive1" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                                                                        <thead>
                                                                            <tr>
                                                                                <th>Client Name</th>
                                                                                <th>Date</th>
                                                                                <th>Liters</th>
                                                                                <th>Rate</th>
                                                                                <th>Amount</th>
                                                                                <th>Description</th>
                                                                                <th id="ThactionsHeads" runat="server">Action(s)</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <asp:Repeater ID="rptFrwdAmounts" runat="server">
                                                                                <ItemTemplate>
                                                                                    <tr>
                                                                                        <td><%# Eval("ClientName") %></td>
                                                                                        <td><%# Eval("Date","{0:dd/MM/yyyy}") %></td>
                                                                                        <td>
                                                                                            <%# Eval("Liters") %>
                                                                                        </td>
                                                                                        <td>
                                                                                            <%# Eval("Rate") %>
                                                                                        </td>
                                                                                        <td><%# Eval("Amount") %></td>

                                                                                        <td><%# Eval("Description") %></td>

                                                                                        <td id="tdActionsHeads" runat="server">
                                                                                            <asp:LinkButton ID="btnEditFamoun" runat="server" CommandArgument='<%# Eval("FID") %>' OnClick="btnEditFamoun_Click" Style="font-size: 15px!important">
                                                <i class="fa fa-edit"></i>
                                                                                            </asp:LinkButton>
                                                                                            &nbsp; | &nbsp;
                                            <asp:LinkButton ID="lnkFrwdDelete" runat="server" CommandArgument='<%# Eval("FID") %>' OnClick="lnkFrwdDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this record?')" Style="font-size: 15px!important">
                                                <i class="fa fa-trash"></i>
                                            </asp:LinkButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>
                                                                        </tbody>
                                                                    </table>



                                                                </div>

                                                                <div class="clearfix"></div>


                                                            </div>
                                                        </div>
                                                        <div class="modal-footer">
                                                            <button type="button" class="btn btn-default" data-dismiss="modal" id="clsfrwrd">Close</button>
                                                            <asp:Button ID="btnFrwrdAmount" runat="server" OnClick="btnFrwrdAmount_Click" UseSubmitBehavior="false" OnClientClick="if (!Page_ClientValidate('ValidationFrwrd')){ return false; } this.disabled = true; this.value = 'Saving...';" Text="Save" CssClass="btn btn-primary" ValidationGroup="ValidationFrwrd" />
                                                        </div>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="clearfix"></div>
                        </div>
                        <div class="col-lg-3">
                            <br />
                            <br />

                            <div class="row">
                                <div class="col-lg-12">
                                    <button type="button" class="btn btn-round btn-dark" style="width: 100%" data-toggle="modal" data-target="#AddProducts">Add new product</button>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-lg-12">
                                    <button type="button" class="btn btn-round btn-success" style="width: 100%" data-toggle="modal" data-target="#PaidformPopUp">Paid Cash to Company</button>
                                </div>
                            </div>

                            <br />

                            <div class="row">
                                <div class="col-lg-12">
                                    <button type="button" class="btn btn-round btn-info" style="width: 100%" data-toggle="modal" data-target="#RecivedformPopUp">Receive Cash from Company</button>
                                </div>
                            </div>

                            <br />



                            <div class="row">
                                <div class="col-lg-12">

                                    <button type="button" class="btn btn-round btn-danger" style="width: 100%" data-toggle="modal" data-target="#GenerateReport">Generate report</button>

                                </div>
                            </div>


                        </div>

                        <asp:HiddenField ID="hfCompanyID" runat="server" />
                        <table id="datatable-responsive" class="table table-striped table-bordered dt-responsive nowrap" style="text-align: center!important" cellspacing="0" width="100%">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Date</th>
                                    <th>Description</th>
                                    <th>Qty(Liters)</th>
                                    <th>VehicleNo</th>
                                    <th>RecieptNo</th>
                                    <th>Rate</th>
                                    <th>Paid Amount</th>
                                    <th>Amount</th>
                                    <th>Forward Amount</th>
                                    <th>Remaining</th>
                                    <th>Action(s)</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptCompanyDetails" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("RNo") %></td>
                                            <td><%# Convert.ToDateTime( Eval("Date")).ToString("dd-MM-yyyy") %></td>
                                            <td><%# String.IsNullOrEmpty(Eval("Description").ToString()) ? "-" : Eval("Description") %></td>
                                            <td><%# String.IsNullOrEmpty(Eval("Liters").ToString()) ? "-" : Eval("Liters") %></td>
                                            <td><%# String.IsNullOrEmpty(Eval("VehcleNo").ToString()) ? "-" : Eval("VehcleNo") %></td>
                                            <td><%# String.IsNullOrEmpty(Eval("ReciptNo").ToString()) ? "-" : Eval("ReciptNo") %></td>

                                            <td><%# String.IsNullOrEmpty(Eval("Rate").ToString()) ? "-" :  String.Format("{0:0.00}",Eval("Rate"))  %></td>
                                            <td><%# String.IsNullOrEmpty(Eval("Received").ToString()) ? "-" :String.Format("{0:0}",Eval("Received"))%></td>
                                            <td><%# String.IsNullOrEmpty(Eval("Amount").ToString()) ? "-" :String.Format("{0:0}",Eval("Amount")) %></td>

                                            <td>
                                                <asp:LinkButton ID="btnFrwrdAmountPopUp" runat="server" Visible='<%# !String.IsNullOrEmpty(Eval("CategoryID").ToString()) %>' CommandArgument='<%# Eval("SerialNo") %>' OnClick="btnFrwrdAmountPopUp_Click" Style="color: #0094ff"><i class="fa fa-eye"></i> <%# Convert.ToInt32(Eval("frwdAmount")) > 0 ? "Forward" : "View" %></asp:LinkButton>
                                            </td>

                                            <td><%# String.IsNullOrEmpty(Eval("Remaining").ToString()) ? "-" : Convert.ToInt32(Eval("Remaining")) < 0 ?  "<span style='color:green'>"+String.Format("{0:0}",-(Convert.ToInt32(Eval("Remaining"))))+"</span>" : "<span style='color:red'>"+String.Format("{0:0}",-(Convert.ToInt32(Eval("Remaining"))))+"</span>"%></td>
                                            <td>
                                                <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click" CommandArgument='<%# Eval("SerialNo") %>' Style="font-size: 15px!important">
                                                <i class="fa fa-edit"></i>
                                                </asp:LinkButton>
                                                &nbsp; | &nbsp;
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("SerialNo") %>' OnClick="lnkDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this record?')" Style="font-size: 15px!important">
                                                <i class="fa fa-trash"></i>
                                            </asp:LinkButton>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#datatable-responsive').dataTable({
                "bSort": false
            });
        });
        function openModal(id) {
            $(id).modal('show');
        }
    </script>

</asp:Content>
