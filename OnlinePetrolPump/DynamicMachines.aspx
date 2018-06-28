<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DynamicMachines.aspx.cs" Inherits="OnlinePetrolPump.DynamicMachines" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function CalN1(index) {
            var Previous = parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_rptMachines_ctl0" + index + "_txtPreviousReadingN1").value);
            var Current = parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_rptMachines_ctl0" + index + "_txtCurrentReadingN1").value);
            var TestUnits = parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_rptMachines_ctl0" + index + "_txtTestUnitsN1").value);
            var result = Current - Previous;
            if (TestUnits != null || TestUnits != "") {
                result = Current - Previous - TestUnits;
            }
            document.getElementById("ctl00_ContentPlaceHolder1_rptMachines_ctl0" + index + "_txtConsumeUnitsN1").value = result.toFixed(2);
        }
        function CalN2(index) {
            var Previous = parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_rptMachines_ctl0" + index + "_txtPreviousReadingN2").value);
            var Current = parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_rptMachines_ctl0" + index + "_txtCurrentReadingN2").value);
            var TestUnits = parseFloat(document.getElementById("ctl00_ContentPlaceHolder1_rptMachines_ctl0" + index + "_txtTestUnitsN2").value);
            var result = Current - Previous;
            if (TestUnits != null || TestUnits != "") {
                result = Current - Previous - TestUnits;
            }
            document.getElementById("ctl00_ContentPlaceHolder1_rptMachines_ctl0" + index + "_txtConsumeUnitsN2").value = result.toFixed(2);
        }
    </script>
    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Machine Details
                   <center><table style="margin-left: 150px !important;margin-top: -19px !important;background-color: #ecedee!important;" border="0"><tr>
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
                            <asp:Repeater ID="rptMachines" runat="server">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hfMachineID" runat="server" Value='<%# Eval("MachineNo") %>' />
                                    <asp:HiddenField ID="hfNozleNo" runat="server" Value='<%# Eval("NozleNO") %>' />
                                    <asp:HiddenField ID="hfCategoryID" runat="server" Value='<%# Eval("CategoryID") %>' />
                                    <!-- Machine -->
                                    <div class="col-md-4 col-sm-6 col-xs-12">
                                        <div class="pricing">
                                            <div class="title">
                                                <h2>Machine No : <%# Eval("MachineNo") %></h2>
                                                <h1><%# Eval("Category") %></h1>
                                            </div>
                                            <div class="x_content">
                                                <div class="">
                                                    <div class="pricing_features">
                                                        <div>
                                                            <label class="btn btn-success btn-block">Nozle <span><%# Eval("NozleNO").ToString().Split(',')[0] %></span></label>
                                                            <asp:TextBox ID="txtPreviousReadingN1" runat="server" CssClass="form-control" Enabled="false" Text="0"></asp:TextBox>
                                                            <span class="required">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtPreviousReadingN1" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </span>
                                                            <asp:TextBox ID="txtCurrentReadingN1" runat="server" CssClass="form-control" onchange='<%# "CalN1(" + Container.ItemIndex + ")" %>' PlaceHolder="Current Reading">
                                                            </asp:TextBox>
                                                            <span class="required">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtCurrentReadingN1" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </span>
                                                            <asp:TextBox ID="txtTestUnitsN1" runat="server" CssClass="form-control" onchange='<%# "CalN1(" + Container.ItemIndex + ")" %>' PlaceHolder="Test Units" Text="0">
                                                            </asp:TextBox>
                                                            <span class="required">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtTestUnitsN1" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </span>
                                                            <asp:TextBox ID="txtConsumeUnitsN1" runat="server" CssClass="form-control" Enabled="false" PlaceHolder="Consumed Units">
                                                            </asp:TextBox>
                                                            <span class="required">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtConsumeUnitsN1" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </div>
                                                    </div>


                                                    <div class="pricing_features">
                                                        <div>
                                                            <label class="btn btn-success btn-block">Nozle <span><%# Eval("NozleNO").ToString().Split(',')[1] %></span></label>
                                                            <asp:TextBox ID="txtPreviousReadingN2" runat="server" CssClass="form-control" Enabled="false" Text="0"></asp:TextBox>
                                                            <span class="required">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtPreviousReadingN2" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </span>
                                                            <asp:TextBox ID="txtCurrentReadingN2" runat="server" CssClass="form-control" onchange='<%# "CalN2(" + Container.ItemIndex + ")" %>' PlaceHolder="Current Reading">
                                                            </asp:TextBox>
                                                            <span class="required">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtCurrentReadingN2" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </span>
                                                            <asp:TextBox ID="txtTestUnitsN2" runat="server" CssClass="form-control" onchange='<%# "CalN2(" + Container.ItemIndex + ")" %>' PlaceHolder="Test Units" Text="0">
                                                            </asp:TextBox>
                                                            <span class="required">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtTestUnitsN2" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </span>
                                                            <asp:TextBox ID="txtConsumeUnitsN2" runat="server" CssClass="form-control" Enabled="false" PlaceHolder="Consumed Units">
                                                            </asp:TextBox>
                                                            <span class="required">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtConsumeUnitsN2" SetFocusOnError="true" runat="server" ValidationGroup="Validation" Display="Dynamic" ErrorMessage="Required" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <div class="ln_solid"></div>
                <div class="row">
                    <div class="col-lg-12 col-lg-offset-4">
                        <asp:Button ID="btnSaveReading" runat="server" Text="Save reading" OnClientClick="if (!Page_ClientValidate('Validation')){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" ValidationGroup="Validation" CssClass="btn btn-round btn-danger" Style="width: 31%; height: 50px;" OnClick="btnSaveReading_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
