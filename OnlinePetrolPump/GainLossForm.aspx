<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GainLossForm.aspx.cs" Inherits="OnlinePetrolPump.GainLossForm" MasterPageFile="~/Admin.Master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function open(url) {
            window.open(url, '_blank');
        }
    </script>

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Gain/Lose</h2>
                    <div class="clearfix"></div>
                </div>

                <div class="x_content">

                    <div class="row">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12"></label>

                        <div class="col-lg-6">

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Timer runat="server" ID="timer1" Interval="10000" OnTick="timer1_Tick"></asp:Timer>
                                    <div aria-live="assertive" id="msgDiv" runat="server" visible="false" style="width: 300px; right: 36px; top: 36px; cursor: auto; text-align: left">
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

                            <button type="button" class="btn btn-success" data-toggle="modal" data-target=".bs-example-modal-sm">Add Gain/Lose</button>
                            <%--   <asp:LinkButton ID="btnViewReport" runat="server" OnClick="btnViewReport_Click" CssClass="btn btn-primary">View Report</asp:LinkButton> 
                            --%>
                            <!-- Pop up -->
                            <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-hidden="true" id="formPopUp">
                                <div class="modal-dialog modal-sm">
                                    <div class="modal-content">

                                        <div class="modal-header">
                                            <button type="button" class="close" id="cls" data-dismiss="modal">
                                                <span aria-hidden="true">×</span>
                                            </button>
                                            <h4 class="modal-title" id="myModalLabel">
                                                <asp:Label ID="lblPopUpHeading" runat="server">Add Gain/Lose</asp:Label></h4>
                                        </div>
                                        <div class="modal-body">
                                            <!-- Content  -->
                                            <div class="x_content" style="float: none!important">
                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-md-12">
                                                            <label>
                                                                Select Catagory :&nbsp;
                                                <asp:RequiredFieldValidator ID="req" runat="server" ValidationGroup="Validation" ControlToValidate="ddlCatagory" InitialValue="-1" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </label>

                                                        </div>
                                                        <br />
                                                        <div class="col-md-12">
                                                            <asp:DropDownList runat="server" ID="ddlCatagory" CssClass="form-control">
                                                                <asp:ListItem Value="-1">Select Catagory </asp:ListItem>
                                                                <asp:ListItem Value="1">PMG</asp:ListItem>
                                                                <asp:ListItem Value="2">HSD</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-md-12">
                                                            <label>
                                                                Gain / Loss:&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="Validation" InitialValue="-1" ControlToValidate="ddlType" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </label>

                                                        </div>
                                                        <br />
                                                        <div class="col-md-12">
                                                            <asp:DropDownList runat="server" ID="ddlType" CssClass="form-control">
                                                                <asp:ListItem Value="-1">Select Option </asp:ListItem>
                                                                <asp:ListItem Value="1">Gain</asp:ListItem>
                                                                <asp:ListItem Value="0">Loss</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-md-12">
                                                            <label>
                                                                Total QTY:&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Validation" ControlToValidate="txtQTY" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </label>
                                                        </div>
                                                        <br />
                                                        <div class="col-md-12">
                                                            <asp:TextBox ID="txtQTY" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-md-12">
                                                            <label>
                                                                Date:&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ValidationGroup="Validation" ControlToValidate="txtDate" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </label>
                                                        </div>
                                                        <br />
                                                        <div class="col-md-12">
                                                            <telerik:RadDatePicker RenderMode="Lightweight" ID="txtDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr" TabIndex="5">
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
                                            <button type="button" class="btn btn-default" data-dismiss="modal" id="cls1">Close</button>
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClientClick="if (!Page_ClientValidate('Validation')){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" OnClick="btnSave_Click" CssClass="btn btn-primary" ValidationGroup="Validation" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:HiddenField ID="hfClientID" runat="server" />
                    <table id="datatable-responsive" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
                        <thead>
                            <tr>
                                <th>Catagory</th>
                                <th>QTY</th>
                                <th>Type</th>
                                <th>Date</th>
                                <th>Action(s)</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptGainLoss" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Convert.ToInt32(Eval("CategoryID"))==1 ? "PMG" : "HSD" %></td>
                                        <td><%# Eval("QTY") %></td>
                                        <td><%# Convert.ToInt32(Eval("Type"))==1 ? "Gain" : "Loss" %></td>
                                        <td><%# Eval("Date","{0:MM-dd-yyy}") %></td>
                                        <td>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("SerialNo")+","+Eval("Type")+","+Eval("CategoryID")+","+Eval("QTY") %>' OnClick="lnkDelete_Click" Style="font-size: 15px!important" OnClientClick="return confirm('Are you sure you want to delete this record?')">
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


    <script type="text/javascript">
        function openModal(id) {
            $(id).modal('show');
        }
    </script>


</asp:Content>

