<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewClientDetails.aspx.cs" Inherits="OnlinePetrolPump.ViewClientDetails" %>

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
    </script>

    <link href="Select2/select2.min.css" rel="stylesheet" />
    <script src="Select2/select2.min.js"></script>
    <link href="Select2/CustomCss.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {
            $(".serarchableDropDown").select2({
                //data: country
            });
            $("#ContentPlaceHolder1_ddlPaidClientName").select2({
                //data: country
                // dropdownParent: "#PaidformPopUp"
            });

            $("#ContentPlaceHolder1_ddlRecievedClientName").select2({
                //data: country
                // dropdownParent: "#RecivedformPopUp"
            });
        });
    </script>

    <style>
        .select2 {
            width: 100% !important;
        }
    </style>

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>
                        <div class="row" id="ClientHeaderInfo" runat="server">
                            <div class="col-lg-2">
                                Name:
                            </div>
                            <div class="col-lg-4">
                                <code>
                                    <asp:Label ID="lblClientName" runat="server" Style="color: #000!important"></asp:Label>
                                </code>
                            </div>

                            <div class="col-lg-2">
                                Contact:
                            </div>
                            <div class="col-lg-4">
                                <code>
                                    <asp:Label ID="lblClientContact" runat="server" Style="color: #000!important"></asp:Label>
                                </code>
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
                        <div class="col-lg-12">

                            <div class="form-group">
                                <label style="margin-top: 8px!important;" class="control-label col-md-2">
                                    Select Client Name: <span class="required">
                                        <asp:RequiredFieldValidator ID="req" runat="server" ValidationGroup="Validation" ControlToValidate="ddlClientName" InitialValue="-1" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator></span>
                                </label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddlClientName" runat="server" CssClass="form-control serarchableDropDown" AutoPostBack="true" TabIndex="1" OnSelectedIndexChanged="ddlClientName_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div class="form-group">
                                <label style="margin-top: 8px!important;" class="control-label col-md-2">
                                    Liters: <span class="required">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Validation" ControlToValidate="txtLiters" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator></span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtLiters" runat="server" CssClass="form-control has-feedback-left" onchange="add_number();" TabIndex="2"></asp:TextBox>
                                    <span class="fa fa-sort-amount-asc form-control-feedback left" aria-hidden="true"></span>
                                </div>
                            </div>

                        </div>
                    </div>


                    <div class="row">
                        <div class="col-lg-12">

                            <div class="form-group">
                                <label style="margin-top: 8px!important;" class="control-label col-md-2">
                                    RecieptNo: <span class="required">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Validation" ControlToValidate="txtRecieptNo" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator></span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtRecieptNo" runat="server" CssClass="form-control has-feedback-left" TabIndex="3"></asp:TextBox>
                                    <span class="fa fa-newspaper-o form-control-feedback left" aria-hidden="true"></span>
                                </div>
                            </div>

                            <div class="form-group">
                                <label style="margin-top: 8px!important;" class="control-label col-md-2">
                                    Rate: <span class="required">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Validation" ControlToValidate="txtRate" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator></span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtRate" runat="server" CssClass="form-control has-feedback-left" onchange="add_number();" TabIndex="4"></asp:TextBox>
                                    <span class="fa fa-money form-control-feedback left" aria-hidden="true"></span>
                                </div>
                            </div>

                        </div>
                    </div>


                    <div class="row">
                        <div class="col-lg-12">

                            <div class="form-group">
                                <label style="margin-top: 8px!important;" class="control-label col-md-2">
                                    Date:&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ValidationGroup="Validation" ControlToValidate="txtPetrolDate" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                </label>
                                <div class="col-md-4">
                                    <telerik:RadDatePicker RenderMode="Lightweight" ID="txtPetrolDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr" TabIndex="5">
                                        <DateInput runat="server" DateFormat="dd-MM-yyyy">
                                        </DateInput>
                                    </telerik:RadDatePicker>
                                </div>
                            </div>


                            <div class="form-group">
                                <label style="margin-top: 8px!important;" class="control-label col-md-2">
                                    Amount: 
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox type="text" ID="txtTotalAmount" runat="server" class="form-control has-feedback-left" disabled></asp:TextBox>
                                    <span class="fa fa-money form-control-feedback left" aria-hidden="true"></span>
                                </div>
                            </div>

                        </div>
                    </div>


                    <div class="row">
                        <div class="col-lg-12">

                            <div class="form-group">
                                <label style="margin-top: 8px!important;" class="control-label col-md-2">
                                    Discount: <span class="required">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="Validation" ControlToValidate="txtDiscount" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator></span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control has-feedback-left" TabIndex="6"></asp:TextBox>
                                    <span class="fa fa-money form-control-feedback left" aria-hidden="true"></span>
                                </div>
                            </div>


                            <div class="form-group">

                                <label style="margin-top: 8px!important;" class="control-label col-md-2">
                                    Vehicle No: <span class="required">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="Validation" ControlToValidate="txtVehicleNo" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator></span>
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtVehicleNo" runat="server" CssClass="form-control has-feedback-left" TabIndex="7"></asp:TextBox>
                                    <span class="fa fa-automobile form-control-feedback left" aria-hidden="true"></span>
                                </div>

                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-12">

                            <div class="form-group">
                                <label style="margin-top: 8px!important;" class="control-label col-md-2">
                                    Description(if any): 
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtPetrolDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" Style="resize: none!important" TabIndex="8"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <br />

                    <div class="row">
                        <div class="col-lg-6 col-lg-offset-2">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="if (!Page_ClientValidate('Validation')){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" CssClass="btn btn-primary" ValidationGroup="Validation" />
                        </div>

                        <div class="col-lg-6 col-lg-offset-2 pull-right">

                            <!--Paid Ammount Pop up -->
                            <div class="modal fade bs-example-modal-sm openPaidPopUp" role="dialog" aria-hidden="true" id="PaidformPopUp">
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
                                                                Client Name :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ValidationGroup="ValidationPaid" ControlToValidate="ddlPaidClientName" InitialValue="-1" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </label>

                                                        </div>
                                                        <br />
                                                        <div class="col-md-12">
                                                            <asp:DropDownList ID="ddlPaidClientName" runat="server" CssClass="form-control"></asp:DropDownList>
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
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="Validation" ControlToValidate="txtVehicleNo" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator></span>
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
                                            <asp:Button ID="btnPaidAmmount" OnClick="btnPaidAmmount_Click" runat="server" Text="Save" OnClientClick="if (!Page_ClientValidate('ValidationPaid')){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" CssClass="btn btn-primary" ValidationGroup="ValidationPaid" />
                                        </div>

                                    </div>
                                </div>
                            </div>

                            <!-- Recieved Ammount Pop up -->
                            <div class="modal fade bs-example-modal-sm" role="dialog" aria-hidden="true" id="RecivedformPopUp">
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
                                                                Client Name :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ValidationGroup="ValidationRecieved" ControlToValidate="ddlRecievedClientName" InitialValue="-1" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </label>

                                                        </div>
                                                        <br />
                                                        <div class="col-md-12">
                                                            <asp:DropDownList ID="ddlRecievedClientName" runat="server" CssClass="form-control">
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
                                            <asp:Button ID="btnRecieveAmmount" OnClick="btnRecieveAmmount_Click" runat="server" OnClientClick="if (!Page_ClientValidate('ValidationRecieved')){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" Text="Save" CssClass="btn btn-primary" ValidationGroup="ValidationRecieved" />
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
                                                <asp:Label ID="Label2" runat="server">Client Detail Report</asp:Label></h4>
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

                                                                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlReportType" OnSelectedIndexChanged="ddlReportType_SelectedIndexChanged" AutoPostBack="true">
                                                                            <asp:ListItem Value="-1">Select Report Type</asp:ListItem>
                                                                            <asp:ListItem Value="0">Invoice Report</asp:ListItem>
                                                                            <asp:ListItem Value="1">Vehicle Bills</asp:ListItem>
                                                                            <asp:ListItem Value="2">Statment Report</asp:ListItem>
                                                                        </asp:DropDownList>

                                                                    </div>
                                                                </div>
                                                                <div id="divVihcleNo" runat="server" visible="false">
                                                                    <div class="col-md-12">

                                                                        <label>
                                                                            Vehicle No:<%--<asp:RequiredFieldValidator ValidationGroup="rpt1" runat="server" ID="RequiredFieldValidator5" ControlToValidate="txtRVehicleNo" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                                                        </label>
                                                                    </div>
                                                                    <div class="col-md-12">

                                                                        <label>
                                                                            <label>
                                                                                <asp:TextBox ID="txtRVehicleNo" runat="server" CssClass="form-control has-feedback-left" TabIndex="7"></asp:TextBox>
                                                                                <span class="fa fa-automobile form-control-feedback left" aria-hidden="true"></span>
                                                                            </label>
                                                                        </label>
                                                                    </div>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>

                                                        <div class="col-md-12">
                                                            <label>
                                                                Select Report size:<asp:RequiredFieldValidator ValidationGroup="rpt1" runat="server" ID="RequiredFieldValidator18" ControlToValidate="ddlReportType" ErrorMessage="*" ForeColor="Red" InitialValue="-1"></asp:RequiredFieldValidator>
                                                            </label>

                                                            <br />
                                                            <div class="col-md-12">

                                                                <asp:DropDownList runat="server" CssClass="form-control" ID="ddlReportSize">
                                                                    <asp:ListItem Value="1">Small</asp:ListItem>
                                                                    <asp:ListItem Value="2" Selected="True">Medium</asp:ListItem>
                                                                    <asp:ListItem Value="3">Large</asp:ListItem>
                                                                </asp:DropDownList>

                                                            </div>
                                                        </div>

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
                                            <asp:Button ID="btnShowReport" runat="server" Text="Show Report" OnClientClick="if (!Page_ClientValidate('rpt1')){ return false; } this.disabled = true; this.value = 'Please wait...';" UseSubmitBehavior="false" OnClick="btnShowReport_Click" CssClass="btn btn-primary" ValidationGroup="rpt1" />
                                        </div>

                                    </div>
                                </div>
                            </div>

                            <button type="button" class="btn btn-round btn-success" data-toggle="modal" data-target="#PaidformPopUp">Paid Cash to client</button>
                            &nbsp&nbsp&nbsp
                            <button type="button" class="btn btn-round btn-info" data-toggle="modal" data-target="#RecivedformPopUp">Receive Cash from client</button>
                            &nbsp
                            <button type="button" class="btn btn-round btn-danger" data-toggle="modal" data-target="#GenerateReport">Generate Report</button>

                        </div>
                    </div>



                    <div class="clearfix"></div>
                </div>

                <table id="datatable-responsive" class="table table-striped table-bordered dt-responsive nowrap" style="text-align: center!important" cellspacing="0" width="100%">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Date</th>

                            <th>Description</th>
                            <th>Liters</th>
                            <th>VehicleNo</th>
                            <th>RecieptNo</th>
                            <th>Rate</th>
                            <th>Recieved</th>
                            <th>Amount</th>
                            <th>Discount</th>
                            <th>Remaining</th>
                            <th>Action(s)</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptClientDetails" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("RNo") %></td>
                                    <td><%# Convert.ToDateTime( Eval("Date")).ToString("dd-MM-yyyy") %></td>
                                    <td><%# String.IsNullOrEmpty(Eval("Description").ToString()) ? "-" : Eval("Description") %></td>
                                    <td><%# String.IsNullOrEmpty(Eval("Liters").ToString()) ? "-" : Eval("Liters") %></td>
                                    <td><%# String.IsNullOrEmpty(Eval("VehicleNo").ToString()) ? "-" : Eval("VehicleNo") %></td>
                                    <td><%# String.IsNullOrEmpty(Eval("ReciptNo").ToString()) ? "-" : Eval("ReciptNo") %></td>
                                    <td><%# String.IsNullOrEmpty(Eval("Rate").ToString()) ? "-" :  String.Format("{0:0.00}",Eval("Rate"))  %></td>
                                    <td><%# String.IsNullOrEmpty(Eval("Received").ToString()) ? "-" :String.Format("{0:0}",Eval("Received"))%></td>
                                    <td><%# String.IsNullOrEmpty(Eval("Amount").ToString()) ? "-" :String.Format("{0:0}",Eval("Amount")) %></td>
                                    <td><%# String.IsNullOrEmpty(Eval("DiscountAmount").ToString()) ? "-" :String.Format("{0:0}",Eval("DiscountAmount")) %></td>

                                    <td><%# String.IsNullOrEmpty(Eval("Remaining").ToString()) ? "-" :String.Format("{0:0}",Eval("Remaining"))%></td>

                                    <td>
                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("SerialNo") %>' OnClick="lnkEdit_Click" Style="font-size: 15px!important">
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
