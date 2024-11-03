<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TP05_Douglas.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Validador de XML</h2>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:FileUpload ID="XSDUpload" runat="server" />
            <br />
            <asp:Button ID="ValidateButton" runat="server" Text="Validar XML" OnClick="ValidateButton_Click"  />
            <br /><br />
            <asp:Label ID="ResultLabel" runat="server" Text="" />
        </div>
    </form>
</body>
</html>
