<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewClients.aspx.cs" Inherits="OnlinePetrolPump.ViewClients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        function open(url)
        {
            window.open(url, '_blank');
        }
    </script>

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>View All Clients</h2>
                    <div class="clearfix"></div>
                </div>

                <div class="x_content">

                    <div class="row">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12"></label>

                        <div class="col-lg-6">

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Timer runat="server" ID="timer1" Interval="10000" OnTick="MsgTime_Tick"></asp:Timer>
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

                            <button type="button" class="btn btn-success" data-toggle="modal" data-target=".bs-example-modal-sm">Add New Client</button>
                            <asp:LinkButton ID="btnViewReport" runat="server" OnClick="btnViewReport_Click" CssClass="btn btn-primary">View Report</asp:LinkButton> 
                            
                            <!-- Pop up -->
                            <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-hidden="true" id="formPopUp">
                                <div class="modal-dialog modal-sm">
                                    <div class="modal-content">

                                        <div class="modal-header">
                                            <button type="button" class="close" id="cls" data-dismiss="modal">
                                                <span aria-hidden="true">×</span>
                                            </button>
                                            <h4 class="modal-title" id="myModalLabel">
                                                <asp:Label ID="lblPopUpHeading" runat="server">Add Client</asp:Label></h4>
                                        </div>
                                        <div class="modal-body">
                                            <!-- Content  -->
                                            <div class="x_content" style="float: none!important">
                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-md-12">
                                                            <label>
                                                                Name :&nbsp;
                                                <asp:RequiredFieldValidator ID="req" runat="server" ValidationGroup="Validation" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </label>

                                                        </div>
                                                        <br />
                                                        <div class="col-md-12">
                                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control has-feedback-left"></asp:TextBox>
                                                            <span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
                                                            <asp:RegularExpressionValidator ID="reg" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Invaid Input." CssClass="has-error" ValidationExpression="^[a-zA-Z ]+$"></asp:RegularExpressionValidator>
                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-md-12">
                                                            <label>
                                                                Contact # :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="Validation" ControlToValidate="txtContact" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </label>
                                                        </div>
                                                        <br />
                                                        <div class="col-md-12">
                                                            <asp:TextBox ID="txtContact" runat="server" CssClass="form-control has-feedback-left" data-inputmask="'mask': '9999-9999999'"></asp:TextBox>
                                                            <span class="fa fa-phone form-control-feedback left" aria-hidden="true"></span>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="clearfix"></div>
                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-md-12">
                                                            <label>
                                                                CNIC :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="Validation" ControlToValidate="txtCNIC" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </label>
                                                        </div>
                                                        <br />
                                                        <div class="col-md-12">
                                                            <asp:TextBox ID="txtCNIC" runat="server" CssClass="form-control has-feedback-left" data-inputmask="'mask': '99999-9999999-9'"></asp:TextBox>
                                                            <span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
                                                        </div>

                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-md-12">
                                                            <label>
                                                                Limit :&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="Validation" ControlToValidate="txtLimit" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                            </label>
                                                        </div>
                                                        <br />
                                                        <div class="col-md-12">
                                                            <asp:TextBox ID="txtLimit" runat="server" CssClass="form-control has-feedback-left"></asp:TextBox>
                                                            <span class="fa fa-sort-amount-asc form-control-feedback left" aria-hidden="true"></span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                        <div class="modal-footer">
                                            <button type="button" class="btn btn-default" data-dismiss="modal" id="cls1">Close</button>
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="if (!Page_ClientValidate('Validation')){ return false; } this.disabled = true; this.value = 'Saving...';" UseSubmitBehavior="false" CssClass="btn btn-primary" ValidationGroup="Validation" />
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
                                <th>Name</th>
                                <th>Contact</th>
                                <th>CNIC</th>
                                <th>Amount</th>
                                <th>Posted Date</th>
                                <th>Action(s)</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptClients" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <a href='ViewClientDetails.aspx?ClientID=<%# Eval("ClientID") %>' style="color:#0094ff!important"><%# Eval("ClientName") %></a>
                                        </td>
                                        <td><%# Eval("Contact") %></td>
                                        <td><%# Eval("CNIC") %></td>
                                        <td><%#String.Format("{0:0}",Eval("Remaining"))   %></td>
                                        <td><%# Eval("Date") %></td>
                                        <td>
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandArgument='<%# Eval("Clientid") %>' OnClick="lnkEdit_Click" Style="font-size: 15px!important">
                                                <i class="fa fa-edit"></i>
                                            </asp:LinkButton>
                                            &nbsp; | &nbsp;
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandArgument='<%# Eval("Clientid") %>' OnClick="lnkDelete_Click" Style="font-size: 15px!important" OnClientClick="return confirm('Are you sure you want to delete this client?')">
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
