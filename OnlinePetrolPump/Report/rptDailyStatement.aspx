<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptDailyStatement.aspx.cs" Inherits="OnlinePetrolPump.Report.rptDailyStatement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Daily Statement</title>
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


            <header class="clearfix">
                <div id="logo" style="width: 109% !important;">
                    <h1>HASSAN PETROLIUM SERVICE</h1>

                    <%-- <h3>Chashma Road, Fazal Abad D.I.Khan 0966771253</h3>--%>
                    <h3>Daily Statement Report</h3>
                </div>
            </header>

            
            <div id="company" class="clearfix">
                <div>
                    <span>Date:</span>&nbsp;&nbsp;&nbsp;
                    <asp:Literal runat="server" ID="ltrDate"></asp:Literal>
                    &nbsp;&nbsp;&nbsp;
                </div>


            </div>

            <main>
      <table style="" id="tblReport" class="tblMediumReport">
        <thead>
          <tr>
                <th>
                    <table>
                        <tr>
                            <th rowspan="2">
                                1)
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="lblN1CurrentReading" runat="server"></asp:Label> <br /> <asp:Label ID="lblN1PrevReading" runat="server"></asp:Label> 
                                <br /> 
                                <hr /> <asp:Label ID="lblTotalN1" runat="server"></asp:Label>
                            </th>
                        </tr>
                    </table>
                </th> 
              <th>
                    <table>
                        <tr>
                            <th rowspan="2">
                                2)
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="lblN2CurrentReading" runat="server"></asp:Label> <br /> <asp:Label ID="lblN2PrevReading" runat="server"></asp:Label> 
                                <br /> 
                                <hr /> <asp:Label ID="lblTotalN2" runat="server"></asp:Label>
                            </th>
                        </tr>
                    </table>
                </th> 
              <th>
                     <table>
                        <tr>
                            <th rowspan="2">
                                3)
                            </th>
                        </tr>
                        <tr>
                            <th>
                                <asp:Label ID="lblN3CurrentReading" runat="server"></asp:Label> <br /> <asp:Label ID="lblN3PrevReading" runat="server"></asp:Label> 
                                <br /> 
                                <hr /> <asp:Label ID="lblTotalN3" runat="server"></asp:Label>
                            </th>
                        </tr>
                    </table>
                </th> 
              <th>
                    <table>
                        <tr>
                            <th rowspan="2">
                                4)
                            </th>
                        </tr>
                        <tr>
                            <th>
                                    <asp:Label ID="lblN4CurrentReading" runat="server"></asp:Label> <br /> <asp:Label ID="lblN4PrevReading" runat="server"></asp:Label> 
                                <br /> 
                                <hr /> <asp:Label ID="lblTotalN4" runat="server"></asp:Label>
                            </th>
                        </tr>
                    </table>
                </th> 
              <th>
                    <table>
                        <tr>
                            <th rowspan="2">
                                5)
                            </th>
                        </tr>
                        <tr>
                            <th>
                                 <asp:Label ID="lblN5CurrentReading" runat="server"></asp:Label> <br /> <asp:Label ID="lblN5PrevReading" runat="server"></asp:Label> 
                                <br /> 
                                <hr /> <asp:Label ID="lblTotalN5" runat="server"></asp:Label>
                            </th>
                        </tr>
                    </table>
                </th> 
              <th>
                    <table>
                        <tr>
                            <th rowspan="2">
                                6)
                            </th>
                        </tr>
                        <tr>
                            <th>
                                 <asp:Label ID="lblN6CurrentReading" runat="server"></asp:Label> <br /> <asp:Label ID="lblN6PrevReading" runat="server"></asp:Label> 
                                <br /> 
                                <hr /> <asp:Label ID="lblTotalN6" runat="server"></asp:Label>
                            </th>
                        </tr>
                    </table>
                </th>           
          </tr>
        </thead>
        <tbody>
            <tr>
              <td colspan="3" align="center" style="text-align:center">

               <table style="width: 100% !important;border:1px solid #C1CED9" id="tblOutReport" class="tblMediumReport" border="1">
                   <thead>
                     <tr>
                         <th colspan="3" style="text-align:center;">
                             <h2><i class="fa fa-arrow-up"></i>&nbspOutgoing</h2>
                         </th>
                     </tr>
                        
                   </thead>
                      
                        <tbody>

                            <tr>
                            <td colspan="3">
                                <center>
                                    <h3>Company</h3>
                                </center>
                            </td>
                        </tr>
                          <tr>
                             <th class="desc" colspan="2">
                                 Description
                             </th>
                               <th class="desc">
                                 Amount
                             </th>
                            
                         </tr>

                           <asp:Repeater ID="rptInvoicePaid" runat="server">
                                <ItemTemplate>
                                  <tr>
                                     <td class="desc" colspan="2">
                                       <%# Eval("ReciptNo") %> &nbsp <%# Eval("Company") %> &nbsp <%# String.IsNullOrEmpty(Eval("Description").ToString()) ? "-" : Eval("Description") %>
                                     </td>
                                      <td class="desc">
                                         <%# String.Format("{0:0}",Eval("Received")) %>
                                     </td>
                                 </tr>

                                </ItemTemplate>
                             
                            </asp:Repeater>
                           <tr style="background-color:darkgray !important">
                             
                                    <td>Total Invoice Paid:</td>
                                    <td class="desc" colspan="2"><asp:Literal runat="server" ID="ltrInvoicePaid"></asp:Literal> </td>
                            </tr>

                            
                             <tr>
                            <td colspan="3">
                                <center>
                                    <h3>Client Loans</h3>
                                </center>
                            </td>
                        </tr>
                          <tr>
                             <th class="desc" colspan="2">
                                 Description
                             </th>
                               <th class="desc">
                                 Amount
                             </th>
                            
                         </tr>

                           <asp:Repeater ID="RptLoans" runat="server">
                                <ItemTemplate>

                                  <tr>
                                     <td class="desc" colspan="2">
                                       <%# Eval("ReciptNo") %> &nbsp <%# Eval("ClientName") %> &nbsp <%# String.IsNullOrEmpty(Eval("Description").ToString()) ? "-" : Eval("Description") %>
                                     </td>
                                     <td class="desc">
                                         <%# String.Format("{0:0}",Eval("Amount")) %>
                                     </td>
                                    
                                 </tr>

                                </ItemTemplate>
                             
                            </asp:Repeater>
                            
                           <tr style="background-color:darkgray !important">
                             
                                    <td>Total Invoice Paid:</td>
                                    <td class="desc" colspan="2"><asp:Literal runat="server" ID="ltrLoans"></asp:Literal> </td>
                            </tr>



                        <tr>
                            <td colspan="3">
                                <center>
                                    <h3>Total Expenses</h3>
                                </center>
                            </td>
                        </tr>
                          <tr>
                            
                             <th class="desc" colspan="2">
                                 Description
                             </th>
                               <th class="desc" >
                                 Amount
                             </th>
                         </tr>
                           <asp:Repeater ID="rptExpenses" runat="server">
                                <ItemTemplate>
                                  <tr>
                                     
                                     <td class="desc" colspan="2">
                                         <%# String.IsNullOrEmpty(Eval("Description").ToString()) ? "-" : Eval("Description") %>
                                     </td>
                                      <td class="desc" >
                                         <%# String.Format("{0:0}",Eval("Amount")) %>
                                     </td>
                                 </tr>

                                </ItemTemplate>
                             
                            </asp:Repeater>
                            
                           <tr style="background-color:darkgray !important">
                             
                                    <td>Total Expense:</td>
                                    <td class="desc" colspan="2"><asp:Literal runat="server" ID="ltrTotalExpense"></asp:Literal> </td>
                            </tr>


                             <tr>
                            <td colspan="3">
                                <center>
                                    <h3>Total invioce Expenses</h3>
                                </center>
                            </td>
                        </tr>
                          <tr>
                             <th class="desc" colspan="2">
                                 Description
                             </th>
                                <th class="desc">
                                 Amount
                             </th>
                         </tr>
                            <asp:Repeater ID="rptInvoiceExpenses" runat="server">
                                <ItemTemplate>

                                  <tr>
                                    
                                     <td class="desc" colspan="2">
                                         <%# String.IsNullOrEmpty(Eval("Description").ToString()) ? "-" : Eval("Description") %>
                                     </td>
                                       <td class="desc">
                                         <%# String.Format("{0:0}",Eval("OtherExpense")) %>
                                     </td>
                                 </tr>

                                </ItemTemplate>
                             
                            </asp:Repeater>
                           <tr style="background-color:darkgray !important">
                             
                                    <td>Total Invoice Expenses:</td>
                                    <td class="desc" colspan="2"><asp:Literal runat="server" ID="ltrInvoiceExpenses"></asp:Literal> </td>
                            </tr>


                            




                 </tbody>
                 </table>

              </td>   
                
                <td colspan="3" align="center" style="text-align:center;vertical-align:top!important">
                 
                  <table style="width: 100% !important;border:1px solid #C1CED9" id="tblIncomeReport" class="tblMediumReport" border="1">
                   <thead>
                     <tr>
                         <th colspan="3" style="text-align:center;">
                             <h2><i class="fa fa-arrow-down"></i>&nbspIncome</h2>
                         </th>
                     </tr>
                        
                         
                   </thead>
                      
                        <tbody>
                            <tr>
                            <td colspan="3">
                                <center>
                                    <h3>Received amount </h3>
                                </center>
                            </td>
                        </tr>
                            <tr>
                             <th class="desc" colspan="2">
                                 Description
                             </th>
                             <th class="desc">
                                 Amount
                             </th>
                            
                         </tr>
                            <asp:Repeater ID="rptClientRecievedAmount" runat="server">
                                <ItemTemplate>
                                    <tr>
                             <td class="desc" colspan="2">
                                <%# Eval("ReciptNo") %> &nbsp <%# Eval("ClientName") %>  &nbsp <%# Eval("Description") %> 
                             </td>
                                        <td class="desc">
                                 <%# Eval("Received").ToString() %>
                             </td>
                             
                         </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                         <tr style="background-color:darkgray !important">
                             
                                    <td>Total amount recieved:</td>
                                    <td class="desc" colspan="2"><asp:Literal runat="server" ID="ltrClienRecievedAmount"></asp:Literal> </td>
                            </tr>

                             <tr>
                            <td colspan="3">
                                <center>
                                    <h3>Company Recieved Amount</h3>
                                </center>
                            </td>
                        </tr>
                            <tr>
                             <th class="desc" colspan="2">
                                 Description
                             </th>
                             <th class="desc">
                                 Amount
                             </th>
                            
                         </tr>
                            <asp:Repeater ID="rptCompanyPaidAmount" runat="server">
                                <ItemTemplate>
                                    <tr>
                             <td class="desc" colspan="2">
                                <%# Eval("ReciptNo") %> &nbsp <%# Eval("Company") %>  &nbsp <%# Eval("Description") %> 
                             </td>
                                        <td class="desc">
                                 <%# Eval("Amount").ToString() %>
                             </td>
                             
                         </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                         <tr style="background-color:darkgray !important">
                             
                                    <td>Total amount:</td>
                                    <td class="desc" colspan="2"><asp:Literal runat="server" ID="ltrTotalPaidCompany"></asp:Literal> </td>
                            </tr>


                        <tr>
                            <td colspan="3">
                                <center>
                                    <h3>Machine Reading </h3>
                                </center>
                            </td>
                        </tr>
                            <tr>
                                    <th class="desc">
                                        Type
                                    </th>
                                    <th class="desc">
                                        Total Units
                                    </th>
                                    <th class="desc">
                                        Amount
                                    </th>
                                </tr>

                                <tr>
                                    <td class="desc">
                                        PMG
                                    </td>
                                    <td class="desc">
                                        <asp:Label ID="lblPMGUnits" runat="server"></asp:Label>
                                    </td>
                                    <td class="desc">
                                        <asp:Label ID="lblPMGAmount" runat="server"></asp:Label>
                                    </td>
                                </tr>

                                 <tr>
                                    <td class="desc">
                                        HSD 
                                    </td>
                                    <td class="desc">
                                        <asp:Label ID="lblHSDUnits" runat="server"></asp:Label>
                                    </td>
                                    <td class="desc">
                                        <asp:Label ID="lblHSDAmount" runat="server"></asp:Label>
                                    </td>

                                </tr>

                             <tr>
                                    <td class="desc">
                                        Oil 
                                    </td>
                                    <td class="desc">
                                        <asp:Label ID="lblOilLIters" runat="server"></asp:Label>
                                    </td>
                                    <td class="desc">
                                        <asp:Label ID="lblOilAmount" runat="server"></asp:Label>
                                    </td>

                                </tr>

                                 <tr>
                                    <td class="desc" colspan="2" style="text-align:right">
                                       Total Amount:
                                    </td>
                                    <td class="desc">
                                        <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                                    </td>

                                </tr>
                            <tr>
                                <td colspan="3">
                                    
                                </td>
                            </tr>
                            <tr>
            <td colspan="2" class="grand total">Total Income :</td>
            <td class="grand total" style="text-align:left !important"><asp:Literal runat="server" ID="ltrTotalIncome"></asp:Literal> </td>
          </tr>

                                       
                            <tr>
            <td colspan="2" class="grand total">Total outgoing :</td>
            <td class="grand total" style="text-align:left !important"><asp:Literal runat="server" ID="LtrTotalOutGoing"></asp:Literal> </td>
          </tr>

                                     <tr>
            <td colspan="2" class="grand total">Cash in hand:</td>
            <td class="grand total" style="text-align:left !important"><asp:Literal runat="server" ID="ltrSubMinus"></asp:Literal> </td>
          </tr>
                 </tbody>
                 </table>


              </td>                 
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
