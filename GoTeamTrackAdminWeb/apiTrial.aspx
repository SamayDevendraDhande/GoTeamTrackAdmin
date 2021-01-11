<%@ Page Language="C#" AutoEventWireup="true" CodeFile="apiTrial.aspx.cs" Inherits="apiTrial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            inout: <asp:TextBox runat="server" id="inout" TextMode="MultiLine" rows="4" cols="50"></asp:TextBox></br>
        gps: <asp:TextBox runat="server" TextMode="MultiLine" id="gps" rows="4" cols="50"></asp:TextBox></br>
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit"/>
        </div>
    </form>
</body>
</html>
