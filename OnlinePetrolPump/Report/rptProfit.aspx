<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptProfit.aspx.cs" Inherits="OnlinePetrolPump.Report.rptProfit" %>

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
    <style>
        .TextBox {
            display: block;
            width: 96%;
            height: 22px;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            color: #555;
            background-color: #fff;
            background-image: none;
            border: 1px solid #ccc;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            box-shadow: inset 0 1px 1px rgba(0,0,0,.075);
            -webkit-transition: border-color ease-in-out .15s,-webkit-box-shadow ease-in-out .15s;
            -o-transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
            transition: border-color ease-in-out .15s,box-shadow ease-in-out .15s;
        }

        .Disabled {
            background: rgba(0,0,0,.075);
            cursor: not-allowed;
        }

        #Totals td {
            text-align: center !important;
        }

        #PMGHSD td {
            text-align: center !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header class="clearfix">
            <div id="logo">
                <h1>HASSAN PETROLIUM SERVICE</h1>

                <h3>Chashma Road, Fazal Abad D.I.Khan </h3>
                <h3>Prop: Muhammad Farooq & CO 0966771253</h3>
                <h3>Profit report</h3>
            </div>
        </header>

        <main>

      <table style="font-size:16px!important">
        <tbody>
          <tr>
            <th colspan="12" class="grand total" style="text-align:left!important">Total Purchases</th>
          </tr>
            <tr>
                <td colspan="3">
                    Total PMG:
                </td>
                <td>
                    <asp:TextBox ID="txtTotalPurchasedPMG" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>

                <td colspan="3">
                    Price:
                </td>
                <td>
                    <asp:TextBox ID="txtPurchasedPMGPrice" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>
                <td colspan="3">
                    Expense:
                </td>
                <td>
                    <asp:TextBox ID="txtPurchasesPMGExpense" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td colspan="3" style="text-align:left!important">
                    Total forwarded:
                </td>
                <td>
                    <asp:TextBox ID="txtforwardedPMG" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>

                <td colspan="3">
                    Price:
                </td>
                <td>
                    <asp:TextBox ID="txtforwardedPMGRate" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>

                 <td colspan="3">
                    Expense:
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" Enabled="false" Text="Nill" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>

            </tr>

             <tr>
                <td colspan="3">
                    Total HSD:
                </td>
                <td>
                    <asp:TextBox ID="txtTotalPurchasedHSD" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>

                <td colspan="3">
                    Price:
                </td>
                <td>
                    <asp:TextBox ID="txtPurchasedHSDPrice" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>
                 <td colspan="3">
                    Expense:
                </td>
                <td>
                    <asp:TextBox ID="txtPurchasesHSDExpense" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td colspan="3" style="text-align:left!important">
                    Total forwarded:
                </td>
                <td>
                    <asp:TextBox ID="txtforwardedHSD" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>

                <td colspan="3">
                    Price:
                </td>
                <td>
                    <asp:TextBox ID="txtforwardedHSDRate" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>

                 <td colspan="3">
                    Expense:
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" Enabled="false" Text="Nill" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td colspan="3" style="white-space:nowrap!important">
                    Total Mobil Oil:
                </td>
                <td>
                    <asp:TextBox ID="txtPurchaseMobilOil" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>

                <td colspan="3">
                    Price:
                </td>
                <td>
                    <asp:TextBox ID="txtPurchaseMobileOilPrice" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>
                  <td colspan="3">
                    Expense:
                </td>
                <td>
                    <asp:TextBox ID="txtPurchasesMbOExpense" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>
            </tr>
             <tr>
            <td colspan="10" class="grand total">Total Purchase:</td>
            <td colspan="2" class="grand total" style="text-align:left !important"><asp:Literal runat="server" ID="ltrTotalPurchase"></asp:Literal> </td>
          </tr>
        </tbody>
      </table>

      <table style="font-size:16px!important">
        <tbody>
          <tr>
            <th colspan="12" class="grand total" style="text-align:left!important">Total Sales</th>
          </tr>
            <tr>
                <td colspan="5">
                    Total PMG:
                </td>
                <td>
                    <asp:TextBox ID="txtSoldPMG" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>

                <td colspan="5">
                    Price:
                </td>
                
                <td>
                    <asp:TextBox ID="txtSoldPMGPrice" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>
                
            </tr>

             <tr>
                <td colspan="5">
                    Total HSD:
                </td>
                <td>
                    <asp:TextBox ID="txtSoldHSD" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>

                <td colspan="5">
                    Price:
                </td>
                <td>
                    <asp:TextBox ID="txtSoldHSDPrice" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>
                 
            </tr>

             <tr>
                <td colspan="5" style="white-space:nowrap!important" >
                    Total Mobil Oil:
                </td>
                <td>
                    <asp:TextBox ID="txtSoldMobileOil" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>

                <td colspan="5">
                    Price:
                </td>
                <td>
                    <asp:TextBox ID="txtSoldMobilOilPrice" Enabled="false" CssClass="TextBox Disabled" runat="server" style="float:left"></asp:TextBox>
                </td>
                 
            </tr>
             <tr>
            <td colspan="10" class="grand total">Total Sales:</td>
            <td colspan="2" class="grand total" style="text-align:left !important"><asp:Literal runat="server" ID="LtrTotalSales"></asp:Literal> </td>
          </tr>
        </tbody>
      </table>

   <table style="font-size:16px!important">
        <tbody>
          <tr>
            <th colspan="12" class="grand total" style="text-align:center!important">Expenses</th>
          </tr>
         
             <asp:Repeater runat="server" ID="rptExpense">
                 <HeaderTemplate>
                      <tr>
                        <th colspan="6" style="text-align:left!important">Expense Head</th>
                        <th colspan="6" style="text-align:right!important">Amount</th>
                      </tr>
                 </HeaderTemplate>
                   <ItemTemplate>
                              <tr>
                                    <td colspan="6" style="text-align:left!important">
                                        <%# Eval("Head") %> 
                                    </td>
                                    <td colspan="6" style="text-align:right!important">
                                        <%# Eval("Amount") %>
                                    </td>
                                </tr>
                    </ItemTemplate>
                 </asp:Repeater>
             <tr>
            <td colspan="10" class="grand total">Total Expense:</td>
            <td colspan="2" class="grand total" style="text-align:right !important"><asp:Literal runat="server" ID="ltrTotalExpense"></asp:Literal> </td>
          </tr>
        </tbody>
      </table>

            <table style="font-size:16px!important">
        <tbody>
          <tr>
            <th colspan="12" class="grand total" style="text-align:left!important">Stock Detail</th>
          </tr>
        </tbody>
      </table>

             <table id="PMGHSD" style="text-align:center!important">
                <tr>
                    <th>
                        Category
                    </th>
                     <th>
                       Qty
                    </th>
                   
                    <th>
                        Amount
                    </th>
                </tr>
                <tr>
                    <td>
                        PMG
                    </td>
                    <td>
                        <asp:Label ID="lblAvailablePMG" runat="server"></asp:Label> x <asp:Label ID="lblPMGRate" runat="server"></asp:Label>
                    </td>
                    
                    <td>
                         <asp:Label ID="lblPMGAmount" runat="server"></asp:Label>
                    </td>
                </tr>

                  <tr>
                    <td style="text-align:center!important">
                        HSD
                    </td>
                    <td>
                        <asp:Label ID="lblAvailableHSD" runat="server"></asp:Label> x <asp:Label ID="lblHSDRate" runat="server"></asp:Label>
                    </td>
                    
                    <td>
                         <asp:Label ID="lblHSDAmount" runat="server"></asp:Label>
                    </td>
                </tr>

                 <tr>
                    <td style="text-align:center!important">
                        Mobil Oil
                    </td>
                    <td>
                        <asp:Label ID="lblAvailableMBO" runat="server"></asp:Label> x <asp:Label ID="lblMBORate" runat="server"></asp:Label>
                    </td>
                    
                    <td>
                         <asp:Label ID="lblMBOAmount" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>


            <table id="Totals" style="text-align:center!important">
                <tr>
                    <th>
                        Total Sales
                    </th>
                     <th>
                        Total Purchases
                    </th>
                   
                    <th>
                        Total Expense
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTotalSales" runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblTotalPurchases" runat="server"></asp:Label>
                    </td>
                    
                    <td>
                         <asp:Label ID="lblTotalExpense" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td><b>Net Profit :</b> &nbsp;&nbsp;&nbsp; <asp:Label ID="lblProfit" runat="server"></asp:Label></td>
                    <td colspan="2"><b>Cash in hand :</b> &nbsp;&nbsp;&nbsp; <asp:Label ID="lblCashInHand" runat="server"></asp:Label></td>
                </tr>
            </table>

      <div id="notices">
        <div class="notice"> Software Developed By Spartan Technologies (03349977332)</div>
      </div>
    </main>
    </form>
</body>
</html>
