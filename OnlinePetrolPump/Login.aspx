<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlinePetrolPump.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Meta, title, CSS, favicons, etc. -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Login</title>

    <!-- Bootstrap -->
    <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- iCheck -->
    <link href="vendors/iCheck/skins/flat/green.css" rel="stylesheet">

    <!-- Animate.css -->
    <link href="vendors/animate.css/animate.min.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="build/css/custom.min.css" rel="stylesheet">
    <style>
        .login_content form input[type=text], .login_content form input[type=email], .login_content form input[type=password] {
            margin: 0px !important;
        }

        #chkremember {
            display: none !important;
        }
    </style>
</head>
<body class="login">
         <div>
            <div class="login_wrapper">
                <div class="animate form login_form">
                    <section class="login_content">
                        <form id="form2" runat="server">
                            <asp:ScriptManager ID="mainScriptmg" runat="server"></asp:ScriptManager>

                            <p>
                                <asp:Label ID="lblHeading" runat="server">Please sign in to your account</asp:Label>
                            </p>
                            <h1 id="h1" runat="server">Login Form</h1>

                            <p>
                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </p>

                            <div id="divLogin" runat="server">

                                <div style="text-align: left!important">
                                    <asp:TextBox ID="txtUserName" runat="server" class="form-control" placeholder="Username"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtUserName" ErrorMessage="Enter Username" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ErrorMessage="$ symbol is not allowed" ControlToValidate="txtUserName" ValidationExpression="[^$]+" Display="Dynamic" BorderColor="#FF66FF" ForeColor="Red" SetFocusOnError="true" ValidationGroup="validation"></asp:RegularExpressionValidator>
                                </div>
                                <div style="text-align: left!important">
                                    <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password" TextMode="Password" Style="margin-top: 20px!important;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtPassword" ErrorMessage="Enter Password" ForeColor="Red" ValidationGroup="validation"></asp:RequiredFieldValidator>

                                </div>
                                <div>
                                    <div class="pull-right">
                                        <asp:LinkButton ID="btnLogin" runat="server" class="btn btn-default submit" OnClientClick="if (!Page_ClientValidate('validation')){ return false; } this.disabled = true; this.value = 'Please wait...';" UseSubmitBehavior="false" OnClick="btnLogin_Click" ValidationGroup="validation">Log in</asp:LinkButton>
                                    </div>
                                    <div class="pull-left">
                                        <asp:UpdatePanel ID="pnlcheck" runat="server">
                                            <ContentTemplate>
                                                <div class="checkbox">
                                                    <label>
                                                        <asp:CheckBox ID="chkremember" class="icheckbox_flat-green" OnCheckedChanged="chkremember_CheckedChanged" AutoPostBack="true" runat="server" />
                                                        &nbsp Remeber Me
                                                    </label>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </div>
                                </div>

                                <div class="clearfix"></div>

                                <div class="separator">
                                    <asp:LinkButton ID="btnForGotPass" runat="server" OnClick="btnForGotPass_Click" class="to_register">Lost your password?</asp:LinkButton>
                                    <div class="clearfix"></div>
                                    <br />

                                      <div>
                                        <h1><i class="fa fa-paw"></i>&nbsp Hassan Petrolium services</h1>
                                    </div>
                                </div>


                            </div>



                            <div id="divReset" visible="false" runat="server">

                                <div style="text-align: left!important">
                                    <asp:TextBox ID="txtContact" runat="server" class="form-control" placeholder="Enter your Contact"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtContact" ErrorMessage="Enter your contact" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="$ symbol is not allowed" ControlToValidate="txtContact" ValidationExpression="[^$]+" Display="Dynamic" BorderColor="#FF66FF" ForeColor="Red" SetFocusOnError="true" ValidationGroup="validation1"></asp:RegularExpressionValidator>

                                </div>
                                <div style="text-align: left!important">
                                    <asp:TextBox ID="txtPinCode" runat="server" class="form-control" placeholder="Pic Code" TextMode="Password" Style="margin-top: 20px!important;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtPinCode" ErrorMessage="Enter Pincode" ForeColor="Red" ValidationGroup="validation1"></asp:RequiredFieldValidator>

                                </div>
                                <div>
                                    <div class="pull-right">
                                        <asp:LinkButton ID="btnSend" runat="server" class="btn btn-default submit" OnClick="btnSend_Click" ValidationGroup="validation1">Send</asp:LinkButton>
                                    </div>
                                </div>

                                <div class="clearfix"></div>

                                <div class="separator">
                                    <a href="#" class="to_register">Lost your password?</a>
                                    <div class="clearfix"></div>
                                    <br />

                                    <div>
                                        <h1><i class="fa fa-paw"></i>&nbsp Hassan Petrolium services!</h1>
                                    </div>
                                </div>
                            </div>


                            <div id="divPasswordUpdate" visible="false" runat="server">

                                <div style="text-align: left!important">
                                    <asp:TextBox ID="txtCode" runat="server" class="form-control" placeholder="Enter Code"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtCode" ErrorMessage="Enter your contact" ForeColor="Red" ValidationGroup="validation2"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="$ symbol is not allowed" ControlToValidate="txtCode" ValidationExpression="[^$]+" Display="Dynamic" BorderColor="#FF66FF" ForeColor="Red" SetFocusOnError="true" ValidationGroup="validation2"></asp:RegularExpressionValidator>

                                </div>
                                <div style="text-align: left!important">
                                    <asp:TextBox ID="txtNewPassword" runat="server" class="form-control" placeholder="New Password" TextMode="Password" Style="margin-top: 20px!important;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtNewPassword" ErrorMessage="Enter New Password" ForeColor="Red" ValidationGroup="validation2"></asp:RequiredFieldValidator>

                                </div>

                                <div style="text-align: left!important">
                                    <asp:TextBox ID="txtRetypePaswword" runat="server" class="form-control" placeholder="Confirm Password" TextMode="Password" Style="margin-top: 20px!important;"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic" BorderColor="#FF66FF" SetFocusOnError="true" ControlToValidate="txtRetypePaswword" ErrorMessage="Retype Password" ForeColor="Red" ValidationGroup="validation2"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="cmpPass" runat="server" ControlToValidate="txtNewPassword" ControlToCompare="txtRetypePaswword" Operator="Equal" ErrorMessage="Passwords mismatched" ValidationGroup="validation2" ForeColor="Red" SetFocusOnError="true"></asp:CompareValidator>
                                </div>

                                <div>
                                    <div class="pull-right">
                                        <asp:LinkButton ID="btnChange" runat="server" class="btn btn-default submit" OnClick="btnChange_Click" ValidationGroup="validation2">Update</asp:LinkButton>
                                    </div>
                                </div>

                                <div class="clearfix"></div>
                            </div>

                        </form>
                    </section>
                </div>
            </div>
        </div>
</body>

<!-- jQuery -->
<script src='<%= ResolveUrl("vendors/jquery/dist/jquery.min.js") %>'></script>
<!-- Bootstrap -->
<script src='<%= ResolveUrl("vendors/bootstrap/dist/js/bootstrap.min.js") %>'></script>

<!-- iCheck -->
<script src='<%= ResolveUrl("vendors/iCheck/icheck.min.js") %>'></script>
</html>
