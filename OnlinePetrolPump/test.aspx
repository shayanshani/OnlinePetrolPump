<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="OnlinePetrolPump.test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Button ID="btn" runat="server" Text="Anonymous method" OnClick="btn_Click" />
    <script src="TimePicker/bootstrap-datetimepicker.js"></script>
    <link href="TimePicker/TimePicker.css" rel="stylesheet" />
    <div class="input-group date timepicker col-md-5">
        <asp:TextBox ID="txtStartTime" runat="server" CssClass="form-control col-sm-5"></asp:TextBox>
        <span class="input-group-addon">
            <span class="fa fa-clock-o"></span>
        </span>
    </div>
    <div class="container">
        <div class="row">
            <div class='col-sm-6'>
                <div class="form-group">
                    <div class='input-group date' id='datetimepicker1'>
                        <input type='text' class="form-control" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-calendar"></span>
                        </span>
                    </div>
                </div>
            </div>
            <script type="text/javascript">
                $(function () {
                    $('#datetimepicker1').datetimepicker(
                        {
                            format: 'L'
                        });
                });
            </script>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class='col-sm-6'>
                <div class="form-group">
                    <div class='input-group date' id='datetimepicker3'>
                        <input type='text' class="form-control" />
                        <span class="input-group-addon">
                            <span class="glyphicon glyphicon-time"></span>
                        </span>
                    </div>
                </div>
            </div>
            <script type="text/javascript">
                $(function () {
                    $('#datetimepicker3').datetimepicker({
                        format: 'LT'
                    });
                });
            </script>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class='col-sm-6'>
                <input type='text' class="form-control" id='datetimepicker4' />
            </div>
            <script type="text/javascript">
                $(function () {
                    $('#datetimepicker4').datetimepicker();
                });
            </script>
        </div>
    </div>

    <script type="text/javascript">
        $('.timepicker').datetimepicker({
            format: 'LT'
        });
    </script>

</asp:Content>
