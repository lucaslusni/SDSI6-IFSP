<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="JsonIntroduction.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             Código: <asp:DropDownList ID="ddlVoos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlVoos_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:GridView ID="gvVoos" runat="server" AutoGenerateColumns="True">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
