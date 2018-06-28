<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptExpense.aspx.cs" Inherits="OnlinePetrolPump.Report.rptExpense" %>

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

                <h3>Chashma Road, Fazal Abad D.I.Khan </h3>
                <h3>Prop: Muhammad Farooq & CO</h3>
                <h3>Expense Report <br /> <asp:Label runat="server" ID="lblDate"></asp:Label> </h3>
            </div>

            <div id="company" class="clearfix">
               &nbsp;

            </div>
            <div id="project">
                 &nbsp;
                


            </div>
        </header>
        <main>
      <table>
        <thead>
          <tr>
            <th class="service">#</th>
                
                           
                  
                                <th  class="desc">Head</th>
                                <th  class="desc">Description</th>
                                <th  class="desc">Amount</th>
                               
                                <th  class="desc">Expense Date</th>
            
              
          </tr>
        </thead>
        <tbody>
             <asp:Repeater ID="rptExpenses" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td  class="desc">
                                            <%# Eval("RNo") %>
                                        </td>

                                        <td  class="desc">
                                            <%# Eval("Head") %>
                                        </td>
                                          <td  class="desc"><%# Eval("Description") %></td>
                                       
                                        <td  class="desc"><%# Eval("Amount") %></td>
                                       <td  class="desc"><%# Eval("ExpenseDate","{0:dd/MM/yyyy}") %></td>
                                        
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
          <tr>
            <td colspan="4" class="grand total">Total :</td>
            <td class="grand total"><asp:Literal runat="server" ID="ltrTotal"></asp:Literal> </td>
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
