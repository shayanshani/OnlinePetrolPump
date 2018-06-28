<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptMachineReading.aspx.cs" Inherits="OnlinePetrolPump.Report.rptMachineReading" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Machine Reading</title>
    <link href="style.css" rel="stylesheet" />
    <script type="text/javascript">
        function setSmallFont() {
            document.getElementById('tblReport').className = "tblSmallReport";
        }
        function setLargeFont() {
            document.getElementById('tblReport').className = "tblLargeReport";
        }

    </script>

    <style>
        #tblTotals tr:nth-child(odd) td {
            background: white !important;
        }
    </style>
</head>
<body style="left: -60px !important;">
    <form id="form1" runat="server">

        <header class="clearfix">
            <div id="logo" style="width: 115% !important;">
                <h1>HASSAN PETROLIUM SERVICE</h1>

                <h3>Chashma Road, Fazal Abad D.I.Khan 0966771253</h3>

                <h3>Machine Reading Report</h3>
            </div>
            <%--<div id="company" class="clearfix">
                <div>
                    <span><b>Contact No</b></span>&nbsp;&nbsp;&nbsp;
                    <asp:Literal runat="server" ID="ltrContact"></asp:Literal>
                    &nbsp;&nbsp;&nbsp;
                </div>


            </div>--%>
            <%--<div id="project">

                <div>
                    <span><b>Client Name</b></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Literal runat="server" ID="ltrName"></asp:Literal>
                </div>



            </div>--%>
        </header>
        <main>
      <table style="width: 115% !important;" id="tblReport" class="tblMediumReport">
        <thead>
          <tr>
             
                            <th>#</th>
                             <th class="desc">Date</th>
              <th class="desc" style="text-align:center"> Machine </th>
                            <th class="desc">Previous Reading</th>
                            <th class="desc">Current Reading</th>
              <th class="desc">Consume Units</th>
              <th class="desc">Test Liters</th>
              <th class="desc">Rate</th>
                           <th class="desc">Amount</th>
          </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rptMachineReadings" >
                <ItemTemplate>
          <tr>
                                    <td><%# Eval("RNo") %></td>
                                    <td class="desc"><%# Convert.ToDateTime( Eval("Date")).ToString("dd-MM-yyyy") %></td>
              
              
                                    <td class="desc" style="text-align:center">Machine&nbsp<%# Eval("MachineID") %> Nozle&nbsp<%# Eval("NozleID") %> <br /> 
                                        <%# Convert.ToInt32(Eval("CategoryID"))==1 ? "(P)" : "(D)" %></td>


                                    <td class="desc"><%# String.IsNullOrEmpty(Eval("PreviousReading").ToString()) ? "-" : Eval("PreviousReading") %></td>
                                    <td class="desc"><%# String.IsNullOrEmpty(Eval("CurrentReading").ToString()) ? "-" : Eval("CurrentReading") %></td>  
                                    <td class="desc"><%# String.IsNullOrEmpty(Eval("ConsumeUnit").ToString()) ? "-" : Eval("ConsumeUnit") %></td>  
                                    <td class="desc"><%# String.IsNullOrEmpty(Eval("TestLiter").ToString()) ? "-" : Eval("TestLiter") %></td>
                                    <td class="desc"><%# String.Format("{0:0.00}",Eval("Rate"))  %></td>
                                    <td class="desc"><%# String.Format("{0:0.00}",Eval("Amount"))  %></td>
                
          </tr>
                    </ItemTemplate>
          
          </asp:Repeater>
             <%--<tr style="background-color:darkgray !important">
                  <td class="desc"></td>
                                    <td> Cash Total:</td>
                                    <td class="desc"><asp:Literal runat="server" ID="ltrCash"></asp:Literal> </td>
                                    <td class="desc">Total QTY:</td>
                                    <td class="desc"><asp:Literal runat="server" ID="ltrQTY"></asp:Literal> </td>                      
                                    
                                    <td class="desc"></td>
                                    <td class="desc"></td>
                                    <td class="desc"></td>
                                    <td class="desc"></td>
                                    <td class="desc"></td>
                                     
                
          </tr>--%>
          
               <tr>
        
                        <td colspan="9">

                            <table border="1" id="tblTotals" style="width:45%!important;float: right;border:1px solid #C1CED9">

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
                                    <td class="desc" colspan="2" style="text-align:right">
                                       Total Amount:
                                    </td>
                                    <td class="desc">
                                        <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                                    </td>

                                </tr>

                            </table>

                        </td>
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
