<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server"  ID="lblOne" TextMode="MultiLine" Height="400px" Width="700px" Text="hello mr periera"/>
        </div>
        <div>
            <asp:Button runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" Text="Send Email"/>
        </div>
    </form>
</body>
</html>
