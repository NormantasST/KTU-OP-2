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
            Intiail Data:<br />
            <asp:Table ID="Table0" runat="server">
            </asp:Table>
            <br />
            Older than 2 years:<br />
            <asp:Table ID="Table1" runat="server">
            </asp:Table>
            <br />
            &quot;Mokslinis&quot; type publication<br />
            <asp:Table ID="Table2" runat="server">
            </asp:Table>
            <br />
            Old releases<br />
            <asp:Table ID="Table3" runat="server">
            </asp:Table>
            <br />
            <br />
            Very large releases (10 000+)<br />
            <asp:Table ID="Table4" runat="server">
            </asp:Table>
        </div>
    </form>
</body>
</html>
