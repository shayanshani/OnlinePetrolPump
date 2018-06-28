<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptClientAccount.aspx.cs" Inherits="OnlinePetrolPump.Report.rptClientAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="style.css" media="all" />

    <script type="text/javascript">
     function setSmallFont() {
         document.getElementById('tblReport').className = "tblSmallReport";
     }
     function setLargeFont() {
         document.getElementById('tblReport').className = "tblLargeReport";
     }

 </script>
</head>
<body>
    <form id="form1" runat="server">
        <header class="clearfix">
            <div id="logo">
                <h1>HASSAN PETROLIUM SERVICE</h1>

                <h3>Chashma Road, Fazal Abad D.I.Khan </h3>
                <h3>Prop: Muhammad Farooq & CO 0966771253</h3>
                <h3>BILLING DETAILS</h3>
            </div>

            <div id="company" class="clearfix">
                <div>
                    <span>Contact No</span>&nbsp;&nbsp;&nbsp;
                    <asp:Literal runat="server" ID="ltrContact"></asp:Literal>
                    &nbsp;&nbsp;&nbsp;
                </div>


            </div>
            <div id="project">

                <div>
                    <span>Client Name</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Literal runat="server" ID="ltrName"></asp:Literal>
                </div>
                <div>
                    <span>Date</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Literal runat="server" ID="ltrDate"></asp:Literal>
                </div>


            </div>
        </header>
        <main>
      <table id="tblReport" class="tblMediumReport">
        <thead>
          <tr>
            <th class="service">#</th>
               <th class="desc">Date</th>
               <th class="desc">Description</th>
               <th class="desc">VehicleNo</th>
               <th class="desc">RecieptNo</th>
               <th class="desc">Liters</th>
               <th class="desc">Rate</th>
               <th class="desc">Amount</th>
              <%-- <th class="desc">Discount</th>--%>
          <%--     <th class="desc">Amount-Payable</th>--%>

          </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rptInvoiceDetails">
                <ItemTemplate>
          <tr>
            <td class="service"><%# Eval("Rno") %></td>
                  <td><%# Convert.ToDateTime( Eval("Date")).ToString("dd-MM-yyyy") %></td>
                          
            <td class="desc"><%# Eval("Description") %></td>
              <td class="desc"><%# String.IsNullOrEmpty(Eval("VehicleNo").ToString()) ? "-" : Eval("VehicleNo") %></td>
                <td class="desc"><%# String.IsNullOrEmpty(Eval("ReciptNo").ToString()) ? "-" : Eval("ReciptNo") %></td>
         
            <td class="desc"><%# Eval("Liters") %></td>
            <td class="desc"><%# String.IsNullOrEmpty(Eval("Rate").ToString()) ? "-" :String.Format("{0:0.00}",Eval("Rate")) %> </td>
            <td class="desc"><%#String.Format("{0:0}",Eval("Amount"))   %></td>
               <%-- <td class="desc"><%# String.Format("{0:0}",Eval("DiscountAmount")) %></td>--%>
             <%-- <td class="desc"><%#String.Format("{0:0}",Eval("Total"))   %></td>
           --%>   
                                                             
          </tr>
                    </ItemTemplate>
          
          </asp:Repeater>
          <tr>
            <td colspan="7" class="grand total">Total :</td>
            <td class="grand total" style="text-align:left !important"><asp:Literal runat="server" ID="ltrTotal"></asp:Literal> </td>
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
