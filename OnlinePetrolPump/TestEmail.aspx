<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestEmail.aspx.cs" Inherits="OnlinePetrolPump.TestEmail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:50%">
            <tr>
                <th>ToEmail</th>
                <td>
                    <asp:TextBox ID="txtToEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>Message</th>
                <td>
                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btn" runat="server" Text="Send" OnClick="btn_Click" />
                </td>
            </tr>
        </table>


    
    </div>
    </form>
</body>
</html>
