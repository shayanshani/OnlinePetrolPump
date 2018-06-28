<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptSalePurchase.aspx.cs" Inherits="OnlinePetrolPump.Report.rptSalePurchase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <script type="text/javascript">
        function setSmallFont() {
            document.getElementById('tblReport').className = "tblSmallReport";
        }
        function setLargeFont() {
            document.getElementById('tblReport').className = "tblLargeReport";
        }
    </script>
    <style>
        #tblIncomeReport tr:nth-child(odd) td {
            background: white !important;
        }

        #tblOutReport tr:nth-child(odd) td {
            background: white !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>


            <header class="clearfix" style="margin-bottom: -25px!important">
                <div id="logo" style="width: 109% !important;">
                    <h1><asp:Literal runat="server" ID="lblHeading"></asp:Literal></h1>


                </div>
            </header>

            <main>
                <table style="width:109%!important" id="tblReport" class="tblMediumReport">
               <thead>
          <tr>
                <th>
                    
                </th> 
                       
          </tr>
        </thead>
                <tbody>
                    <tr>
                                             


                        <td colspan="3" align="center" style="text-align: center">
                            <div>

                            </div>
                            <table style="width: 100% !important; border: 1px solid #C1CED9" id="tblOutReport" class="tblMediumReport" border="1">
                                <thead>
                                    <tr>
                                        <th colspan="4" style="text-align: center;">
                                            <h2><i class="fa fa-arrow-up"></i> From 
                    <asp:Literal runat="server" ID="ltrFromDate"></asp:Literal> To 
                    <asp:Literal runat="server" ID="ltrToDate"></asp:Literal> </h2>
                                        </th>
                                    </tr>

                                </thead>

                                <tbody>

                                    <div runat="server" ID="PMG" visible="false">
                                    <tr>
                                        <td colspan="4">
                                            <center>
                                    <h3>PMG Sale Details</h3>
                                </center>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="desc">
                                            Type
                                        </th>
                                         <th class="desc">Date
                                        </th>
                                        <th class="desc"  >Quantity
                                        </th>
                                        <th class="desc">Amount
                                        </th>

                                    </tr>

                                    <asp:Repeater ID="rptPMGSale" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="desc">PMG</td>
                                                 <td class="desc"><%# Convert.ToDateTime( Eval("Date")).ToString("dd-MM-yyyy") %></td>
                 
                                                <td class="desc" >
                                                    <%# Eval("QTY") %> X <%# Eval("Rate") %> 
                                                </td>
                                                <td class="desc">
                                                    <%# String.Format("{0:0}",Eval("Price")) %>
                                                </td>
                                            </tr>

                                        </ItemTemplate>

                                    </asp:Repeater>
                                    <tr style="background-color: darkgray !important">
                                        <td></td>
                                         <td>PMG Total Sale QTY : </td>
                                        <td><asp:Literal runat="server" ID="ltrPMGSaleQTy"></asp:Literal></td>
                                        <td class="desc" >
                                            RS :
                                            <asp:Literal runat="server" ID="ltrPMGSalePrice"></asp:Literal>
                                        </td>
                                    </tr>

 </div>
                                       <div runat="server" ID="HSD" visible="false">
                                    <tr>
                                        <td colspan="4">
                                            <center>
                                    <h3>HSD Sale Report</h3>
                                </center>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="desc"  >
                                            Type
                                        </th>
                                         <th class="desc"  >Date
                                        </th>
                                        <th class="desc"  >Description
                                        </th>
                                        <th class="desc">Amount
                                        </th>

                                    </tr>
                                   
                                  
                                    <asp:Repeater ID="rptHSDSale" runat="server">
                                        <ItemTemplate>

                                             <tr>
                                                 <td class="desc">HSD</td>
                 
                                                 <td class="desc"><%# Convert.ToDateTime( Eval("Date")).ToString("dd-MM-yyyy") %></td>
                 
                                                <td class="desc" >
                                                    <%# Eval("QTY") %> X <%# Eval("Rate") %> 
                                                </td>
                                                <td class="desc">
                                                    <%# String.Format("{0:0}",Eval("Price")) %>
                                                </td>
                                            </tr>


                                        </ItemTemplate>

                                    </asp:Repeater>

                                    <tr style="background-color: darkgray !important">
                                         <td></td>
                                         <td>PMG Total Sale QTY : </td>
                                        <td><asp:Literal runat="server" ID="ltrHSDSaleQTy"></asp:Literal></td>
                                        <td class="desc" >
                                            RS :
                                            <asp:Literal runat="server" ID="ltrHSDSalePrice"></asp:Literal>
                                        </td>
                                    </tr>
                                     </div>

                                     <div runat="server" ID="Oil" visible="false">
                                    <tr>
                                        <td colspan="4">
                                            <center>
                                    <h3>Oil</h3>
                                </center>
                                        </td>
                                    </tr>
                                    <tr>
                                         <th class="desc"  >Type
                                        </th>
                                         <th class="desc"  >Date
                                        </th>
                                        <th class="desc"  >Description
                                        </th>
                                        <th class="desc">Amount
                                        </th>

                                    </tr>

                                    <asp:Repeater ID="rptMoboilSale" runat="server">
                                        <ItemTemplate>

                                             <tr>

                                                 <td class="desc">Oil</td>
                 
                                                 <td class="desc"><%# Convert.ToDateTime( Eval("Date")).ToString("dd-MM-yyyy") %></td>
                 
                                                <td class="desc" >
                                                    <%# Eval("Liters") %> X <%# Eval("PerPrice") %> 
                                                </td>
                                                <td class="desc">
                                                    <%# String.Format("{0:0}",Eval("Total")) %>
                                                </td>
                                            </tr>


                                        </ItemTemplate>

                                    </asp:Repeater>

                                    <tr style="background-color: darkgray !important">
                                                                                          <td></td>
                                         <td>Moboile Total Sale QTY : </td>
                                        <td><asp:Literal runat="server" ID="ltrMoboiltotalQTY"></asp:Literal></td>
                                        <td class="desc" >
                                            RS :
                                            <asp:Literal runat="server" ID="ltrMoboilPrice"></asp:Literal>
                                        </td>
                                    </tr>
                                         </div>


                                      <div runat="server" ID="PMGPurchase" visible="false">
                                    <tr>
                                        <td colspan="4">
                                            <center>
                                    <h3>PMG Purchase Details</h3>
                                </center>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="desc">
                                            Type
                                        </th>
                                         <th class="desc">Date
                                        </th>
                                        <th class="desc"  >Quantity
                                        </th>
                                        <th class="desc">Amount
                                        </th>

                                    </tr>

                                    <asp:Repeater ID="rptPMGPurchase" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="desc">PMG</td>
                                                 <td class="desc"><%# Convert.ToDateTime( Eval("Date")).ToString("dd-MM-yyyy") %></td>
                 
                                                <td class="desc" >
                                                    <%# Eval("Liters") %> X <%# Eval("Rate") %> 
                                                </td>
                                                <td class="desc">
                                                    <%# String.Format("{0:0}",Eval("Amount")) %>
                                                </td>
                                            </tr>

                                        </ItemTemplate>

                                    </asp:Repeater>
                                    <tr style="background-color: darkgray !important">
                                        <td></td>
                                         <td>PMG Purchase QTY : </td>
                                        <td><asp:Literal runat="server" ID="ltrPMGPurchaseQTY"></asp:Literal></td>
                                        <td class="desc" >
                                            RS :
                                            <asp:Literal runat="server" ID="ltrPMGPurchasePrices"></asp:Literal>
                                        </td>
                                    </tr>

 </div>
                                       <div runat="server" ID="HSDpurchase" visible="false">
                                    <tr>
                                        <td colspan="4">
                                            <center>
                                    <h3>HSD Purchase Report</h3>
                                </center>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th class="desc"  >
                                            Type
                                        </th>
                                         <th class="desc"  >Date
                                        </th>
                                        <th class="desc"  >Description
                                        </th>
                                        <th class="desc">Amount
                                        </th>

                                    </tr>
                                   
                                  
                                    <asp:Repeater ID="rptHSDPurchase" runat="server">
                                        <ItemTemplate>

                                             <tr>
                                                 <td class="desc">HSD</td>
                 
                                                 <td class="desc"><%# Convert.ToDateTime( Eval("Date")).ToString("dd-MM-yyyy") %></td>
                 
                                                <td class="desc" >
                                                    <%# Eval("Liters") %> X <%# Eval("Rate") %> 
                                                </td>
                                                <td class="desc">
                                                    <%# String.Format("{0:0}",Eval("Amount")) %>
                                                </td>
                                            </tr>


                                        </ItemTemplate>

                                    </asp:Repeater>

                                    <tr style="background-color: darkgray !important">
                                         <td></td>
                                         <td>PMG Total Sale QTY : </td>
                                        <td><asp:Literal runat="server" ID="ltrHSDPurchaseQTY"></asp:Literal></td>
                                        <td class="desc" >
                                            RS :
                                            <asp:Literal runat="server" ID="ltrHSDPurchasePrice"></asp:Literal>
                                        </td>
                                    </tr>
                                     </div>

                                     <div runat="server" ID="OilPurchase" visible="false">
                                    <tr>
                                        <td colspan="4">
                                            <center>
                                    <h3>Oil Purchase</h3>
                                </center>
                                        </td>
                                    </tr>
                                    <tr>
                                         <th class="desc"  >Type
                                        </th>
                                         <th class="desc"  >Date
                                        </th>
                                        <th class="desc"  >Description
                                        </th>
                                        <th class="desc">Amount
                                        </th>

                                    </tr>

                                    <asp:Repeater ID="rptOilPurchase" runat="server">
                                        <ItemTemplate>

                                             <tr>

                                                 <td class="desc">Oil</td>
                 
                                                 <td class="desc"><%# Convert.ToDateTime( Eval("Date")).ToString("dd-MM-yyyy") %></td>
                 
                                                <td class="desc" >
                                                    <%# Eval("Liters") %> X <%# Eval("Rate") %> 
                                                </td>
                                                <td class="desc">
                                                    <%# String.Format("{0:0}",Eval("Amount")) %>
                                                </td>
                                            </tr>


                                        </ItemTemplate>

                                    </asp:Repeater>

                                    <tr style="background-color: darkgray !important">
                                                                                          <td></td>
                                         <td>Moboile Purchase QTY : </td>
                                        <td><asp:Literal runat="server" ID="ltrOilPurchaseQTY"></asp:Literal></td>
                                        <td class="desc" >
                                            RS :
                                            <asp:Literal runat="server" ID="ltrOilPurchasePrice"></asp:Literal>
                                        </td>
                                    </tr>
                                         </div>


                                    
                                     
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            </main>



            <div id="notices">

                <div class="notice">Software Developed By Spartan Technologies (03349977332)</div>
            </div>



        </div>
    </form>
</body>
</html>
