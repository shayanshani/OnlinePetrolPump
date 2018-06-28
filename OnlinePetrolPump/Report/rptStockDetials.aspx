<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptStockDetials.aspx.cs" Inherits="OnlinePetrolPump.Report.rptStockInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="style.css" media="all" />
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <header class="clearfix">
      <div id="logo">
        <h1>HASSAN PETROLIUM SERVICE</h1>
      
      <h3>Chashma Road, Fazal Abad D.I.Khan 0966771253</h3>
           
           <h3>Stock Report</h3>
           <div id="company" class="clearfix">
                <div><span>Contact No</span>&nbsp;&nbsp;&nbsp;
                    <asp:Literal runat="server" ID="ltrContact"></asp:Literal>
                    &nbsp;&nbsp;&nbsp;</div>


            </div>
            <div id="project">

                <div><span>Client Name</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Literal runat="server" ID="ltrName"></asp:Literal></div>
                <div><span>Date</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Literal runat="server" ID="ltrDate"></asp:Literal>
                </div>


            </div>
      </div>
     
      
    </header>
    <main>
      <table>
        <thead>
          <tr>
            <th class="service">#</th>
            <th class="desc">Date</th>
            <th class="desc">Description</th>
            <th class="desc">Rate</th>
            <th class="desc">Liter</th>
          </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rptStock" >
                <ItemTemplate>
          <tr>
            <td class="service"><%# Eval("SerialNo") %></td>
            <td class="desc"><%# Convert.ToDateTime(Eval("Date")).ToShortDateString()%></td>
            <td class="desc"><%# Eval("Description") %></td>
            <td class="desc"><%# Eval("Rate") %></td>
            <td class="desc"><%#Eval("Liters")   %></td>
                
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
    </div>
    </form>
</body>
</html>
