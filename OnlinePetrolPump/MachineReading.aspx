<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MachineReading.aspx.cs" MasterPageFile="~/Admin.Master" Inherits="OnlinePetrolPump.MachineReading" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">

        function M1N1() {
            var Previous = parseFloat(document.getElementById("<%=txtPreviousM1N1.ClientID%>").value);
            var Current = parseFloat(document.getElementById("<%=txtCurrentM1N1.ClientID%>").value);
            var TestUnits = parseFloat(document.getElementById("<%=txtTestM1N1.ClientID%>").value);
            var result;
            result = Current - Previous;
            if (TestUnits != null || TestUnits != "") {
                result = Current - Previous - TestUnits;
            }

            document.getElementById("<%=txtConsumeM1N1.ClientID%>").value = result.toFixed(2);
        }

        function M1N2() {
            var Previous = parseFloat(document.getElementById("<%=txtPreviousM1N2.ClientID%>").value);
            var Current = parseFloat(document.getElementById("<%=txtCurrentM1N2.ClientID%>").value);
            var TestUnits = parseFloat(document.getElementById("<%=txtTestM1N2.ClientID%>").value);
            var result;
            result = Current - Previous;
            if (TestUnits != null || TestUnits != "") {
                result = Current - Previous - TestUnits;
            }

            document.getElementById("<%=txtConsumeM1N2.ClientID%>").value = result.toFixed(2);
        }

        function M2N1() {
            var Previous = parseFloat(document.getElementById("<%=txtPreviousM2N1.ClientID%>").value);
            var Current = parseFloat(document.getElementById("<%=txtCurrentM2N1.ClientID%>").value);
            var TestUnits = parseFloat(document.getElementById("<%=txtTestM2N1.ClientID%>").value);
            var result;
            result = Current - Previous;
            if (TestUnits != null || TestUnits != "") {
                result = Current - Previous - TestUnits;
            }

            document.getElementById("<%=txtConsumedM2N1.ClientID%>").value = result.toFixed(2);
        }

        function M2N2() {
            var Previous = parseFloat(document.getElementById("<%=txtPreviousM2N2.ClientID%>").value);
            var Current = parseFloat(document.getElementById("<%=txtCurrentM2N2.ClientID%>").value);
            var TestUnits = parseFloat(document.getElementById("<%=txtTestM2N2.ClientID%>").value);
            var result;
            result = Current - Previous;
            if (TestUnits != null || TestUnits != "") {
                result = Current - Previous - TestUnits;
            }

            document.getElementById("<%=txtConsumedM2N2.ClientID%>").value = result.toFixed(2);
        }

        function M3N1() {
            var Previous = parseFloat(document.getElementById("<%=txtPreviousM3N1.ClientID%>").value);
            var Current = parseFloat(document.getElementById("<%=txtCurrentM3N1.ClientID%>").value);
            var TestUnits = parseFloat(document.getElementById("<%=txtTestM3N1.ClientID%>").value);
            var result;
            result = Current - Previous;
            if (TestUnits != null || TestUnits != "") {
                result = Current - Previous - TestUnits;
            }

            document.getElementById("<%=txtConsumedM3N1.ClientID%>").value = result.toFixed(2);
        }

        function M3N2() {
            var Previous = parseFloat(document.getElementById("<%=txtPreviousM3N2.ClientID%>").value);
            var Current = parseFloat(document.getElementById("<%=txtCurrentM3N2.ClientID%>").value);
            var TestUnits = parseFloat(document.getElementById("<%=txtTestM3N2.ClientID%>").value);
            var result;
            result = Current - Previous;
            if (TestUnits != null || TestUnits != "") {
                result = Current - Previous - TestUnits;
            }
            document.getElementById("<%=txtConsumedM3N2.ClientID%>").value = result.toFixed(2);
        }

    </script>

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Machine Details
                   <center>
                       
                       <table style="margin-left: 150px !important;margin-top: -19px !important;background-color: #ecedee!important;" border="0"><tr>
                        <td><h2>&nbsp;&nbsp;PMG Rate:&nbsp;&nbsp;</h2></td>
                       <td><asp:TextBox runat="server" Width="100px"  ID="txtPetrolRate" CssClass="form-control"></asp:TextBox></td>
                        <td>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="true" ValidationGroup="Validation" ControlToValidate="txtPetrolRate" style="font-size:small" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                       </td>
                         <td><h2>&nbsp;&nbsp;HSD Rate:&nbsp;&nbsp;</h2></td>
                       <td><asp:TextBox runat="server" Width="100px" ID="txtDesialRate" CssClass="form-control"></asp:TextBox></td>
                         <td>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" SetFocusOnError="true" ValidationGroup="Validation" ControlToValidate="txtDesialRate" style="font-size:small" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                       </td>
                         <td><h2>&nbsp;&nbsp;Reading Date:&nbsp;&nbsp;</h2></td><td>
                         
                             <telerik:RadDatePicker RenderMode="Lightweight" ID="txtPetrolDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr" TabIndex="5">
                                                <DateInput runat="server" DateFormat="dd-MM-yyyy">
                                                </DateInput>
                                            </telerik:RadDatePicker>
                             
                             </td>
                       <td>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" SetFocusOnError="true" ValidationGroup="Validation" ControlToValidate="txtPetrolDate" style="font-size:small" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                       </td>
                                                                              </tr>
                       <tr>
                           <td>
                                    <!-- Report PopUp -->
                            <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-hidden="true" id="GenerateReport">
                                <div class="modal-dialog modal-sm">
                                    <div class="modal-content">

                                        <div class="modal-header">
                                            <button type="button" class="close" data-dismiss="modal">
                                                <span aria-hidden="true">×</span>
                                            </button>
                                            <h4 class="modal-title">
                                                <asp:Label ID="Label2" runat="server">Machine Reading Report</asp:Label></h4>
                                        </div>
                                        <div class="modal-body">
                                            <!-- Content  -->
                                            <div class="x_content" style="float: none!important">

                                                <div class="row">
                                                    <div class="form-group">

                                                        <div class="col-md-12">
                                                            <label>
                                                                Select Report size:
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


                                                    </div>


                                                </div>

                                                  <div class="row">
                                                    <div class="form-group">

                                                        <div class="col-md-12">
                                                            <label>
                                                                Select Date:
                                                            </label>

                                                            <br />
                                                            <div class="col-md-12">

                                                                  <telerik:RadDatePicker RenderMode="Lightweight" ID="txtReportDate" Width="100%" runat="server" DateInput-CssClass="form-control clndr" TabIndex="5">
                                                <DateInput runat="server" DateFormat="dd-MM-yyyy">
                                                </DateInput>
                                            </telerik:RadDatePicker>

                                                                </div>
                                                            </div>
                                                        </div>
                                                      </div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                            <asp:Button ID="btnShowReport" runat="server" Text="Show Report" OnClick="btnShowReport_Click" CssClass="btn btn-primary" ValidationGroup="rpt1" />
                                        </div>

                                    </div>
                                </div>
                            </div>

                            <button type="button" class="btn btn-round btn-success" data-toggle="modal" data-target="#GenerateReport">Generate report</button>
                           </td>
                       </tr>

                           </table></center>
                    </h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false"><i class="fa fa-wrench"></i></a>

                        </li>
                        <li><a class="close-link"><i class="fa fa-close"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>

                <div class="x_content">
                    <div class="row">

                        <div class="col-md-12">

                            <!-- price element -->
                            <div class="col-md-4 col-sm-6 col-xs-12">
                                <div class="pricing">
                                    <div class="title">
                                        <h2>Machine No : 1</h2>
                                        <h1>Petrol</h1>

                                    </div>
                                    <div class="x_content">
                                        <div class="">
                                            <div class="pricing_features">
                                                <div>
                                                    <label class="btn btn-success btn-block">Nozle <span>1</span> </label>
                                                    <asp:TextBox ID="txtPreviousM1N1" runat="server" CssClass="form-control" Enabled="false" Text="0"></asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" SetFocusOnError="true" runat="server" ValidationGroup="Validation" ControlToValidate="txtPreviousM1N1" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>

                                                    <asp:TextBox ID="txtCurrentM1N1" runat="server" CssClass="form-control" onchange="M1N1();" PlaceHolder="Current Reading">
                                                    </asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="true" runat="server" ValidationGroup="Validation" ControlToValidate="txtCurrentM1N1" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <asp:TextBox ID="txtTestM1N1" runat="server" CssClass="form-control" onchange="M1N1();" PlaceHolder="Test Units" Text="0">
                                                    </asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtTestM1N1" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <asp:TextBox ID="txtConsumeM1N1" runat="server" CssClass="form-control" Enabled="false" PlaceHolder="Consumed Units">
                                                    </asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtConsumeM1N1" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                </div>
                                            </div>


                                            <div class="pricing_features">
                                                <div>
                                                    <label class="btn btn-success btn-block">Nozle <span>2</span></label>
                                                    <asp:TextBox ID="txtPreviousM1N2" runat="server" CssClass="form-control" Enabled="false" Text="0"></asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtPreviousM1N2" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <asp:TextBox ID="txtCurrentM1N2" runat="server" CssClass="form-control" onchange="M1N2();" PlaceHolder="Current Reading">
                                                    </asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtCurrentM1N2" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <asp:TextBox ID="txtTestM1N2" runat="server" CssClass="form-control" onchange="M1N2();" PlaceHolder="Test Units" Text="0">
                                                    </asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtTestM1N2" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <asp:TextBox ID="txtConsumeM1N2" runat="server" CssClass="form-control" Enabled="false" PlaceHolder="Consumed Units">
                                                    </asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtConsumeM1N2" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                </div>
                                            </div>

                                        </div>


                                    </div>


                                </div>
                            </div>
                            <!-- price element -->
                            <div class="col-md-4 col-sm-6 col-xs-12">
                                <div class="pricing">
                                    <div class="title">
                                        <h2>Machine No : 2</h2>
                                        <h1>Diesel</h1>

                                    </div>
                                    <div class="x_content">
                                        <div class="">
                                            <div class="pricing_features">
                                                <div>
                                                    <label class="btn btn-success btn-block">Nozle <span>3</span></label>
                                                    <asp:TextBox ID="txtPreviousM2N1" runat="server" CssClass="form-control" Enabled="false" Text="0"></asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtPreviousM2N1" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <asp:TextBox ID="txtCurrentM2N1" runat="server" CssClass="form-control" onchange="M2N1();" PlaceHolder="Current Reading">
                                                    </asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtCurrentM2N1" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <asp:TextBox ID="txtTestM2N1" runat="server" CssClass="form-control" onchange="M2N1();" PlaceHolder="Test Units" Text="0">
                                                    </asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="txtTestM2N1" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <asp:TextBox ID="txtConsumedM2N1" runat="server" CssClass="form-control" Enabled="false" PlaceHolder="Consumed Units">
                                                    </asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToValidate="txtConsumedM2N1" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                </div>
                                            </div>


                                            <div class="pricing_features">
                                                <div>
                                                    <label class="btn btn-success btn-block">Nozle <span>4</span></label>
                                                    <asp:TextBox ID="txtPreviousM2N2" runat="server" CssClass="form-control" Enabled="false" Text="0"></asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="txtPreviousM2N2" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <asp:TextBox ID="txtCurrentM2N2" runat="server" CssClass="form-control" onchange="M2N2();" PlaceHolder="Current Reading">
                                                    </asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="txtCurrentM2N2" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <asp:TextBox ID="txtTestM2N2" runat="server" CssClass="form-control" onchange="M2N2();" PlaceHolder="Test Units" Text="0">
                                                    </asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="txtTestM2N2" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <asp:TextBox ID="txtConsumedM2N2" runat="server" CssClass="form-control" Enabled="false" PlaceHolder="Consumed Units">
                                                    </asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ControlToValidate="txtConsumedM2N2" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                </div>
                                            </div>

                                        </div>


                                    </div>


                                </div>
                            </div>
                            <!-- price element -->


                            <!-- price element -->

                            <!-- price element -->

                            <div class="col-md-4 col-sm-6 col-xs-12">
                                <div class="pricing">
                                    <div class="title">
                                        <h2>Machine No : 3</h2>
                                        <h1>Diesel</h1>

                                    </div>
                                    <div class="x_content">
                                        <div class="">
                                            <div class="pricing_features">
                                                <div>
                                                    <label class="btn btn-success btn-block">Nozle <span>5</span></label>
                                                    <asp:TextBox ID="txtPreviousM3N1" runat="server" CssClass="form-control" Enabled="false" Text="0"></asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ControlToValidate="txtPreviousM3N1" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <asp:TextBox ID="txtCurrentM3N1" runat="server" CssClass="form-control" onchange="M3N1();" PlaceHolder="Current Reading">
                                                    </asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ControlToValidate="txtCurrentM3N1" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <asp:TextBox ID="txtTestM3N1" runat="server" CssClass="form-control" onchange="M3N1();" PlaceHolder="Test Units" Text="0">
                                                    </asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ControlToValidate="txtTestM3N1" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <asp:TextBox ID="txtConsumedM3N1" runat="server" CssClass="form-control" Enabled="false" PlaceHolder="Consumed Units">
                                                    </asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" ControlToValidate="txtConsumedM3N1" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                </div>
                                            </div>


                                            <div class="pricing_features">
                                                <div>
                                                    <label class="btn btn-success btn-block">Nozle <span>6</span></label>
                                                    <asp:TextBox ID="txtPreviousM3N2" runat="server" CssClass="form-control" Enabled="false" Text="0"></asp:TextBox>
                                                     <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" ControlToValidate="txtPreviousM3N2" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <asp:TextBox ID="txtCurrentM3N2" runat="server" CssClass="form-control" onchange="M3N2();" PlaceHolder="Current Reading">
                                                    </asp:TextBox>
                                                     <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ControlToValidate="txtCurrentM3N2" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <asp:TextBox ID="txtTestM3N2" runat="server" CssClass="form-control" onchange="M3N2();" PlaceHolder="Test Units" Text="0">
                                                    </asp:TextBox>
                                                    <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" ControlToValidate="txtTestM3N2" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                    <asp:TextBox ID="txtConsumedM3N2" runat="server" CssClass="form-control" Enabled="false" PlaceHolder="Consumed Units">
                                                    </asp:TextBox>
                                                     <span class="required">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" ControlToValidate="txtConsumedM3N2" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                    </span>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- price element -->

                            <!-- price element -->

                        </div>
                    </div>
                    <div class="ln_solid"></div>
                    <div class="row">
                        <div class="col-lg-12 col-lg-offset-4">
                            <asp:Button ID="btnSaveReading" runat="server" Text="Save reading" CssClass="btn btn-round btn-danger" OnClientClick="if (!Page_ClientValidate('Validation')){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" ValidationGroup="Validation" Style="width: 31%; height: 50px;" OnClick="btnSaveReading_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
