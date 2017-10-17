<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Integration.aspx.cs" Inherits="Integration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="txtMessage" Text="Enter your message here" Width="400px" ></asp:TextBox>
        </div>
        <div>
            <asp:Button runat="server" ID="btnMessage" OnClick="btnMessage_Click" Text="Push Message"/>
        </div>
    </form>
</body>
</html>
