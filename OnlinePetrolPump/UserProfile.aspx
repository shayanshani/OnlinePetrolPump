<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="OnlinePetrolPump.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Profile Setting</h2>
                    <div class="clearfix"></div>
                </div>


                <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-hidden="true" id="formPopUp">
                    <div class="modal-dialog modal-sm">
                        <div class="modal-content">

                            <div class="modal-header">
                                <button type="button" class="close" id="cls" data-dismiss="modal">
                                    <span aria-hidden="true">×</span>
                                </button>
                                <h4 class="modal-title" id="myModalLabel">
                                    <asp:Label ID="lblPopUpHeading" runat="server">Change Password </asp:Label></h4>
                            </div>
                            <div class="modal-body">
                                <!-- Content  -->
                                <div class="x_content" style="float: none!important">

                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <label>
                                                    Current Password:&nbsp;
                                                <asp:RequiredFieldValidator ID="req" runat="server" ValidationGroup="ValidationPass" ControlToValidate="txtCurrentPassword" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                </label>

                                            </div>
                                            <br />
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="form-control has-feedback-left" TextMode="Password"></asp:TextBox>
                                                <span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
                                                <asp:CompareValidator ID="cmpPass" runat="server" ControlToValidate="txtCurrentPassword" ValidationGroup="ValidationPass" Display="Dynamic" ErrorMessage="Invalid Current Password" CssClass="has-error"></asp:CompareValidator>
                                            </div>

                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <label>
                                                    New Password:&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="ValidationPass" ControlToValidate="txtNewPassword" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                </label>

                                            </div>
                                            <br />
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control has-feedback-left" TextMode="Password"></asp:TextBox>
                                                <span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
                                            </div>

                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-md-12">
                                                <label>
                                                    Retype Password:&nbsp;
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="ValidationPass" ControlToValidate="txtRetypePass" Display="Dynamic" ErrorMessage="*" CssClass="has-error"></asp:RequiredFieldValidator>
                                                </label>

                                            </div>
                                            <br />
                                            <div class="col-md-12">
                                                <asp:TextBox ID="txtRetypePass" runat="server" CssClass="form-control has-feedback-left" TextMode="Password"></asp:TextBox>
                                                <span class="fa fa-user form-control-feedback left" aria-hidden="true"></span>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtNewPassword" ControlToCompare="txtRetypePass" ValidationGroup="ValidationPass" Display="Dynamic" ErrorMessage="Passwords mis-matched" CssClass="has-error"></asp:CompareValidator>
                                            </div>

                                        </div>
                                    </div>

                                    <div class="clearfix"></div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal" id="cls1">Close</button>
                                <asp:Button ID="btnSavePassword" runat="server" Text="Change" OnClick="btnSavePassword_Click" CssClass="btn btn-primary" ValidationGroup="ValidationPass" />
                            </div>

                        </div>
                    </div>
                </div>
                <asp:HiddenField ID="hfCurrentPassword" runat="server" />
                <div class="x_content">

                    <div class="row">
                        <label class="control-label col-md-3 col-sm-3 col-xs-12"></label>

                        <div class="col-lg-6">

                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

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

                    <div id="demo-form2" data-parsley-validate="" class="form-horizontal form-label-left" novalidate="">

                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="first-name">
                                Admin Name <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtAdminName" runat="server" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12" for="last-name">
                                UserName <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtUserName" runat="server" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="middle-name" class="control-label col-md-3 col-sm-3 col-xs-12"></label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <a  style="color: #0094ff;cursor:pointer" data-toggle="modal" data-target=".bs-example-modal-sm">Change Password</a>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-12">
                                Contact <span class="required">*</span>
                            </label>
                            <div class="col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtContact" runat="server" class="form-control col-md-7 col-xs-12"></asp:TextBox>
                            </div>
                        </div>
                        <div class="ln_solid"></div>
                        <div class="form-group">
                            <div class="col-md-6 col-sm-6 col-xs-12 col-md-offset-3">
                                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" class="btn btn-success" Text="Submit"></asp:Button>
                            </div>
                        </div>

                    </div>
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
