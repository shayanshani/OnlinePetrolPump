<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptCompanyInvoice.aspx.cs" Inherits="OnlinePetrolPump.Report.rptCompanyInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" />
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
    <div>
     <header class="clearfix">
            <div id="logo" style="width: 115% !important;">
                <h1>HASSAN PETROLIUM SERVICE</h1>

                <h3>Chashma Road, Fazal Abad D.I.Khan 0966771253</h3>

                <h3>Company Invoice Report</h3>
            </div>
            <div id="company" class="clearfix">
                <div>
                    <span><b>Contact No</b></span>&nbsp;&nbsp;&nbsp;
                    <asp:Literal runat="server" ID="ltrContact"></asp:Literal>
                    &nbsp;&nbsp;&nbsp;
                </div>


            </div>
            <div id="project">

                <div>
                    <span><b>Company Name</b></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Literal runat="server" ID="ltrName"></asp:Literal>
                </div>



            </div>

        </header>
        <main>
      <table style="width: 115% !important;" id="tblReport" class="tblMediumReport">
        <thead>
          <tr>
             
                          
                            <th>#</th>
                             <th class="desc">Date</th>
                            <th class="desc">Description</th>
                             <th class="desc">Qty(Liters)</th>
                            
                            <th class="desc">VehicleNo</th>
                            <th class="desc">RecieptNo</th>
                            <th class="desc">Rate</th>
                            <th class="desc">Paid Amount</th>
                            <th class="desc">Amount</th>
                           
                            <th class="desc">Remaining</th>
          </tr>
        </thead>
        <tbody>
            <%--<asp:Repeater runat="server" ID="rptClientsinfo" >
                <ItemTemplate>
          <tr>
                                    <td><%# Eval("RNo") %></td>
                                    <td class="desc"><%# Convert.ToDateTime( Eval("Date")).ToString("dd-MM-yyyy") %></td>
                                    <td class="desc"><%# String.IsNullOrEmpty(Eval("Description").ToString()) ? "-" : Eval("Description") %></td>
                                    <td class="desc"><%# String.IsNullOrEmpty(Eval("ReciptNo").ToString()) ? "-" : Eval("ReciptNo") %></td>                      
                                     <td class="desc"><%# String.IsNullOrEmpty(Eval("Liters").ToString()) ? "-" : Eval("Liters") %></td>
                                    <td class="desc"><%# String.Format("{0:0.00}",Eval("Rate"))  %></td>
                                    <td class="desc"><%# String.Format("{0:0}",Eval("Amount")) %></td>
                                    <td class="desc"><%# String.Format("{0:0}",Eval("DiscountAmount")) %></td>
                                    <td class="desc"><%# String.Format("{0:0}", Eval("Received")) %></td>
                                    <td class="desc"><%# String.Format("{0:0}",Eval("Remaining"))%></td>
                                     
                
          </tr>
                    </ItemTemplate>
          
          </asp:Repeater>--%>
             <tr>
            <td colspan="9" class="grand total">Previous CREDIT :</td>
            <td class="grand total" style="text-align:left !important"><asp:Literal runat="server" ID="lblPrv"></asp:Literal> </td>
          <td class="grand total"></td>
             </tr>
          <tr>
            <td colspan="9" class="grand total">Current Month CREDIT :</td>
            <td class="grand total" style="text-align:left !important"><asp:Literal runat="server" ID="ltrTotal"></asp:Literal> </td>
           <td class="grand total"></td>
          </tr>
             <tr>
            <td colspan="9" class="grand total">Balance :</td>
            <td class="grand total" style="text-align:left !important"><asp:Literal runat="server" ID="lblbalance"></asp:Literal> </td>
           <td class="grand total"></td>
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
