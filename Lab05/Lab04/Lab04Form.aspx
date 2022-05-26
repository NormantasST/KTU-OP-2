<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lab04Form.aspx.cs" Inherits="Lab04.Lab04Form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" runat="server" media="screen" href="~/css/stylesheet.css" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label0" runat="server" Text="Intiail Data (Directory):"></asp:Label>
            <asp:Table ID="Table0" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Initial Data (Territory prices)"></asp:Label>
            <asp:Table ID="Table1" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Queried Data"></asp:Label>
            <asp:Table ID="Table4" runat="server">
            </asp:Table>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Below Average Per Person Price"></asp:Label>
            <br />
            <br />
            <asp:Table ID="Table2" runat="server">
            </asp:Table>
            Enter Price to search:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Height="20px" OnClick="Button1_Click" Text="Submit" Width="53px" />
            <br />
            Pravalyti Query: <asp:Button ID="Button2" runat="server" Height="20px" OnClick="Button2_Click" Text="Clean Query" Width="128px" />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Above X Price Households"></asp:Label>
            <br />
            <asp:Table ID="Table3" runat="server">
            </asp:Table>
        </div>
    </form>
</body>
</html>
