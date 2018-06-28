<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStock.aspx.cs" Inherits="OnlinePetrolPump.AddCompany" MasterPageFile="~/Admin.Master" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>View Stock Details</h2>
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

                            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#formPopUp2">View Report</button>
                            <!-- Pop up -->

                            <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-hidden="true" id="formPopUp2">
                                <div class="modal-dialog modal-sm">
                                    <div class="modal-content">

                                        <div class="modal-header">
                                            <button type="button" class="close" id="cls" data-dismiss="modal">
                                                <span aria-hidden="true">×</span>
                                            </button>
                                            <h4 class="modal-title" id="myModalLabel">
                                                <asp:Label ID="Label2" runat="server">Stock Report</asp:Label></h4>
                                        </div>
                                        <div class="modal-body">
                                            <!-- Content  -->
                                            <div class="x_content" style="float: none!important">




                                                <div class="clearfix"></div>
                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-md-12">
                                                            <label>
                                                                From Date :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Val1" ControlToValidate="frmDate" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </label>
                                                        </div>
                                                        <br />
                                                        <div class="col-md-12">
                                                            <telerik:RadDatePicker RenderMode="Lightweight" ID="frmDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
                                                                <DateInput runat="server" DateFormat="dd-MM-yyyy">
                                                                </DateInput>
                                                            </telerik:RadDatePicker>
                                                        </div>

                                                        <div class="col-md-12">
                                                            <label>
                                                                To Date :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="Val1" ControlToValidate="toDate" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </label>
                                                        </div>
                                                        <br />
                                                        <div class="col-md-12">
                                                            <telerik:RadDatePicker RenderMode="Lightweight" ID="toDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
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
                                            <asp:Button ID="btnShowReport" runat="server" Text="Show" OnClientClick="if (!Page_ClientValidate('Val1')){ return false; } this.disabled = true; this.value = 'Please wait...';" UseSubmitBehavior="false" OnClick="btnShowReport_Click" CssClass="btn btn-primary" ValidationGroup="Val1" />
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
                                <th>#</th>

                                <th>Company</th>
                                <th>Category</th>
                                <th>Description</th>
                                <th>Qty(Liters)</th>
                                <th>VehicleNo</th>

                                <th>Rate</th>

                                <th>Total Amount</th>
                                <th>Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptStock" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("SerialNo") %></td>
                                        <td><%#Eval("Company")%></td>
                                        <td><%# Convert.ToInt32(Eval("CategoryID"))==1?"PMG":"HSD" %></td>

                                        <td><%# String.IsNullOrEmpty(Eval("Description").ToString()) ? "-" : Eval("Description") %></td>
                                        <td><%# String.IsNullOrEmpty(Eval("Liters").ToString()) ? "-" : Eval("Liters") %></td>
                                        <td><%# String.IsNullOrEmpty(Eval("VehcleNo").ToString()) ? "-" : Eval("VehcleNo") %></td>
                                        <td><%# String.IsNullOrEmpty(Eval("Rate").ToString()) ? "-" :  String.Format("{0:0.00}",Eval("Rate"))  %></td>
                                        <td><%# String.IsNullOrEmpty(Eval("Amount").ToString()) ? "-" :String.Format("{0:0}",Eval("Amount")) %></td>
                                        <td><%# Convert.ToDateTime( Eval("Date")).ToString("dd-MM-yyyy") %></td>

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
