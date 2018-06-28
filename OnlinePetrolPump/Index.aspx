<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="OnlinePetrolPump.Index" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <style>
        .dashboard-widget-content .sidebar-widget {
            width: 100% !important;
        }
    </style>
    <div class="col-md-12" role="main">
        <div class="row">
            <div class="col-lg-12">
                <a href="Report/rptProfit.aspx" class="btn btn-round btn-danger pull-right" target="_blank">Profit Report</a>

                <button type="button" class="btn btn-round btn-success pull-right" data-toggle="modal" data-target="#cashPopUp">Previous Cash</button>

                <button type="button" class="btn btn-round btn-info pull-right" data-toggle="modal" data-target="#formPopUp3">View Sale/Purchase Report</button>

                <button type="button" class="btn btn-round btn-success pull-right" data-toggle="modal" data-target="#formPopUp2">View Daily Statement Report</button>
                <!-- Pop up -->

                <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-hidden="true" id="cashPopUp">
                    <div class="modal-dialog modal-sm">
                        <div class="modal-content">

                            <div class="modal-header">
                                <button type="button" class="close" id="cls" data-dismiss="modal">
                                    <span aria-hidden="true">×</span>
                                </button>
                                <h4 class="modal-title">
                                    <asp:Label ID="Label3" runat="server">Previous Cash</asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <!-- Content  -->
                                <div class="x_content" style="float: none!important">

                                    <div class="clearfix"></div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <label>
                                                    Total Purchase :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="Valcash" ControlToValidate="txtTotalPurchase" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                </label>
                                            </div>
                                            <br />
                                            <div class="col-md-12">
                                               <asp:TextBox ID="txtTotalPurchase" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                         <div class="form-group">
                                            <div class="col-md-12">
                                                <label>
                                                    Total Sales:&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="Valcash" ControlToValidate="txtTotalSale" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                </label>
                                            </div>
                                            <br />
                                            <div class="col-md-12">
                                               <asp:TextBox ID="txtTotalSale" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>

                                          <div class="form-group">
                                            <div class="col-md-12">
                                                <label>
                                                    Total Expense :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="Valcash" ControlToValidate="txtTotalExpense" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                </label>
                                            </div>
                                            <br />
                                            <div class="col-md-12">
                                               <asp:TextBox ID="txtTotalExpense" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="clearfix"></div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal" id="cls11">Close</button>
                                <asp:Button ID="btnAddCashDetails" runat="server" Text="Submit" OnClick="btnAddCashDetails_Click" CssClass="btn btn-primary" ValidationGroup="Valcash" />
                            </div>
                            <asp:HiddenField ID="hfCashID" runat="server" />  
                        </div>
                    </div>
                </div>

                <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-hidden="true" id="formPopUp2">
                    <div class="modal-dialog modal-sm">
                        <div class="modal-content">

                            <div class="modal-header">
                                <button type="button" class="close" id="cls" data-dismiss="modal">
                                    <span aria-hidden="true">×</span>
                                </button>
                                <h4 class="modal-title" id="myModalLabel">
                                    <asp:Label ID="Label2" runat="server">Daily Statement Report</asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <!-- Content  -->
                                <div class="x_content" style="float: none!important">

                                    <div class="clearfix"></div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <label>
                                                    Date :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Val1" ControlToValidate="txtDate" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                </label>
                                            </div>
                                            <br />
                                            <div class="col-md-12">
                                                <telerik:RadDatePicker RenderMode="Lightweight" ID="txtDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
                                                    <DateInput runat="server" DateFormat="dd-MM-yyyy">
                                                    </DateInput>
                                                </telerik:RadDatePicker>
                                            </div>

                                            <%--   <div class="col-md-12">
                                                    <label>
                                                        To Date :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="Val1" ControlToValidate="toDate" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </label>
                                                </div>
                                                <br />
                                                <div class="col-md-12">
                                                    <telerik:raddatepicker rendermode="Lightweight" id="toDate" width="100%" runat="server" dateinput-cssclass="form-control clndr">
                                                                <DateInput runat="server" DateFormat="dd-MM-yyyy">
                                                                </DateInput>
                                                            </telerik:raddatepicker>
                                                </div>--%>
                                        </div>
                                    </div>


                                    <div class="clearfix"></div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal" id="cls1">Close</button>
                                <asp:Button ID="btnShowReport" runat="server" Text="Show" OnClick="btnShowReport_Click" CssClass="btn btn-primary" ValidationGroup="Val1" />
                            </div>

                        </div>
                    </div>
                </div>

                <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-hidden="true" id="formPopUp3">
                    <div class="modal-dialog modal-sm">
                        <div class="modal-content">

                            <div class="modal-header">
                                <button type="button" class="close" id="cls3" data-dismiss="modal">
                                    <span aria-hidden="true">×</span>
                                </button>
                                <h4 class="modal-title" id="myModalLabel1">
                                    <asp:Label ID="Label1" runat="server">Sale Report</asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <!-- Content  -->
                                <div class="x_content" style="float: none!important">

                                    <div class="clearfix"></div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <label>
                                                    Select Report&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="Val2" ControlToValidate="ddlReportType" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="has-error"></asp:RequiredFieldValidator>
                                                </label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <label>
                                                    Select Type&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="Val2" ControlToValidate="ddlReportType" Display="Dynamic" ErrorMessage="*" InitialValue="-1" CssClass="has-error"></asp:RequiredFieldValidator>
                                                </label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <label>
                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlReportOption">
                                                        <asp:ListItem Value="-1">
                                                          Select Type
                                                        </asp:ListItem>
                                                        <asp:ListItem Value="1">
                                                          Sale Report
                                                        </asp:ListItem>
                                                        <asp:ListItem Value="2">
                                                         Purchase Report
                                                        </asp:ListItem>

                                                    </asp:DropDownList>
                                                </label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <label>
                                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlReportType">
                                                        <asp:ListItem Value="-1">
                                                          Select Type
                                                        </asp:ListItem>
                                                        <asp:ListItem Value="1">
                                                          PMG Report
                                                        </asp:ListItem>
                                                        <asp:ListItem Value="2">
                                                         HSD Report
                                                        </asp:ListItem>
                                                        <asp:ListItem Value="3">
                                                          OIL Report
                                                        </asp:ListItem>
                                                        <asp:ListItem Value="4">
                                                          ALL 
                                                        </asp:ListItem>
                                                    </asp:DropDownList>
                                                </label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <label>
                                                    From Date :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Val2" ControlToValidate="RadDatePicker1" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                </label>
                                            </div>
                                        </div>
                                        <div class="form-group">

                                            <div class="col-md-12">
                                                <telerik:RadDatePicker RenderMode="Lightweight" ID="RadDatePicker1" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
                                                    <DateInput runat="server" DateFormat="dd-MM-yyyy">
                                                    </DateInput>
                                                </telerik:RadDatePicker>
                                            </div>

                                        </div>
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <label>
                                                    To Date :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Val2" ControlToValidate="RadDatePicker2" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                </label>
                                            </div>
                                        </div>
                                        <div class="form-group">

                                            <div class="col-md-12">
                                                <telerik:RadDatePicker RenderMode="Lightweight" ID="RadDatePicker2" Width="100%" runat="server" DateInput-CssClass="form-control clndr">
                                                    <DateInput runat="server" DateFormat="dd-MM-yyyy">
                                                    </DateInput>
                                                </telerik:RadDatePicker>
                                            </div>
                                        </div>


                                        <%--   <div class="col-md-12">
                                                    <label>
                                                        To Date :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="Val1" ControlToValidate="toDate" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </label>
                                                </div>
                                                <br />
                                                <div class="col-md-12">
                                                    <telerik:raddatepicker rendermode="Lightweight" id="toDate" width="100%" runat="server" dateinput-cssclass="form-control clndr">
                                                                <DateInput runat="server" DateFormat="dd-MM-yyyy">
                                                                </DateInput>
                                                            </telerik:raddatepicker>
                                                </div>--%>
                                    </div>


                                    <div class="clearfix"></div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal" id="cls2">Close</button>
                                <asp:Button ID="btnSalePurchaseReport" runat="server" Text="Show" OnClick="btnSalePurchaseReport_Click" CssClass="btn btn-primary" ValidationGroup="Val2" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>



        </div>

    </div>


    <asp:HiddenField ID="hfPMGTank" runat="server" />
    <asp:HiddenField ID="hfHSDTank" runat="server" />

    <div class="row">
        <div class="col-md-6 col-sm-8 col-xs-12">
            <div class="x_panel fixed_height_320">
                <div class="x_title">
                    <h2>Petrol Tank Details<small></small></h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div class="dashboard-widget-content">
                        <ul class="quick-list" style="display: none">
                            <li><i class="fa fa-bars"></i><a href="#">Consume Units</a>:&nbsp
                                        <asp:Label ID="lblConsumeUnts" runat="server"></asp:Label></li>
                            <li><i class="fa fa-bar-chart"></i><a href="#">Remaining</a> :&nbsp
                                        <asp:Label ID="lblRemaining" runat="server"></asp:Label></li>
                        </ul>
                        <div class="sidebar-widget">
                            <h4>PMG Tank</h4>
                            <canvas width="150" height="80" id="chart_gauge_02" class="" style="width: 160px; height: 100px;"></canvas>
                            <div class="goal-wrapper">
                                <!--<span class="gauge-value pull-left">$</span>-->
                                <span id="gauge-text2" class="gauge-value pull-left">0</span>
                                <span id="goal-text2" class="goal-value pull-right">15000</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6 col-sm-8 col-xs-12">
            <div class="x_panel tile fixed_height_320">
                <div class="x_title">
                    <h2>Diesal Tank Details</h2>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div class="dashboard-widget-content">

                        <div class="sidebar-widget">
                            <h4>HSD Tank</h4>
                            <canvas width="150" height="80" id="chart_gauge_01" class="" style="width: 160px; height: 100px;"></canvas>
                            <div class="goal-wrapper">
                                <span id="gauge-text" class="gauge-value pull-left">0</span>
                                <!--<span class="gauge-value pull-left">%</span>-->
                                <span id="goal-text" class="goal-value pull-right">25000</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">


        <div class="col-md-12 col-sm-8 col-xs-12">
            <div class="x_panel fixed_height_320">
                <div class="x_title">
                    <h2>Top Expenses <small>Today</small></h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="#">Settings 1</a>
                                </li>
                                <li><a href="#">Settings 2</a>
                                </li>
                            </ul>
                        </li>
                        <li><a class="close-link"><i class="fa fa-close"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <table class="" style="width: 100%">
                        <tr>

                            <th>
                                <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5">
                                    <p class=""></p>
                                </div>
                                <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5">
                                    <p class=""></p>
                                </div>
                            </th>
                        </tr>
                        <tr>

                            <td>
                                <table class="tile_info">
                                    <tr>
                                        <td class="col-lg-5 col-md-5 col-sm-5 col-xs-5">
                                            <b>Expense Head</b>
                                        </td>
                                        <td class="col-lg-5 col-md-5 col-sm-5 col-xs-5">
                                            <b>Amount</b>
                                        </td>
                                    </tr>
                                    <asp:Repeater runat="server" ID="rptExpense">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="col-lg-5 col-md-5 col-sm-5 col-xs-5">
                                                    <p><i class="fa fa-square blue"></i><%# Eval("Head") %> </p>
                                                </td>
                                                <td class="col-lg-5 col-md-5 col-sm-5 col-xs-5"><%# Eval("Amount") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>



                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>

    </div>
    <div class="row">
        <div class="col-lg-12">

            <iframe src="Report/rptDailyStatement.aspx?val=<%=getDateTime().ToString("yyyy-MM-dd")%>" frameborder="0" align="center" scrolling="auto" style="width: 100%!important; height: 800px!important"></iframe>

        </div>
    </div>
    </div>



</asp:Content>
