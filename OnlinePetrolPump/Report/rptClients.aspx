<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptClients.aspx.cs" Inherits="OnlinePetrolPump.Report.rptClients" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="style.css" media="all" />
  
</head>
<body>
    <form id="form1" runat="server">
    <header class="clearfix">
      <div id="logo">
        <h1>HASSAN PETROLIUM SERVICE</h1>
      
      <h3>Chashma Road, Fazal Abad D.I.Khan 0966771253 </h3>
           
           <h3>Clients Report</h3>
      </div>
     
      
    </header>
    <main>
      <table>
        <thead>
          <tr>
            <th class="service">#</th>
            <th class="desc">Name</th>
            <th class="desc">Contact No</th>
            <th class="desc">CNIC</th>
            <th class="desc">Amount</th>
          </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rptClientsinfo" >
                <ItemTemplate>
          <tr>
            <td class="service"><%# Eval("Rno") %></td>
            <td class="desc"><%# Eval("ClientName") %></td>
            <td class="desc"><%# Eval("Contact") %></td>
            <td class="desc"><%# Eval("CNIC") %></td>
            <td class="desc"><%#String.Format("{0:0}",Eval("Remaining"))   %></td>
                
          </tr>
                    </ItemTemplate>
          
          </asp:Repeater>
          <tr>
            <td colspan="4" class="grand total">TOTAL CREDIT :</td>
            <td class="grand total"><asp:Literal runat="server" ID="ltrTotal"></asp:Literal> </td>
          </tr>
        </tbody>
      </table>
      <div id="notices">
        
        <div class="notice"> Software Developed By Spartan Technologies (03349977332)</div>
      </div>
    </main>
    
    </form>
</body>
</html>