<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptClientVehicleBill.aspx.cs" Inherits="OnlinePetrolPump.Report.rptClientVehicleBill" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="style.css" media="all" />
    <style type="text/css">
        #notices .notice {
    color: #5D6975;
    font-size: 0.8em;
    text-align: center !important;
    margin: 22px !important;
}
    </style>

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
                <h3>Vehicle(s) Billing Details</h3>
            </div>

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
        </header>
        <main>

      <table id="tblReport" class="tblMediumReport">
        <thead>
          <tr>
            <th class="service">#</th>
                
                           
               
            
              <th class="desc">Vehicle No</th>
               
              <th class="desc">Total Liters</th>
              
              <th class="desc">Amount</th>
          </tr>
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="rptClientVehicle">
                <ItemTemplate>
          <tr>
            <td class="service"><%# Eval("Rno") %></td>
                           
               <td class="desc"><%# String.IsNullOrEmpty(Eval("VehicleNo").ToString()) ? "-" : Eval("VehicleNo") %></td>
                
            <td class="desc"><%# Eval("TotalLtr") %></td>
           
           
            <td class="desc"><%#String.Format("{0:0}",Eval("TotalAmount"))   %></td>
                                                             
          </tr>
                    </ItemTemplate>
          
          </asp:Repeater>
          <tr>
            <td colspan="3" class="grand total">Total :</td>
            <td class="grand total" style="text-align:left !important"><asp:Literal runat="server" ID="ltrTotal"></asp:Literal> </td>
            
          </tr>
        </tbody>
      </table>
      <div id="notices">
        <br />
        <div class="notice"> Software Developed By Spartan Technologies (03349977332)</div>
      </div>
    </main>

    </form>
</body>
</html>
