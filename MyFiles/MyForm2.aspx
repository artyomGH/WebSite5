<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyForm2.aspx.cs" Inherits="MyFiles_MyForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    </form>
    <body>
    <form id="form2" runat="server">
        <asp:ScriptManager ID="MainScriptManager" runat="server" />
        <asp:UpdatePanel ID="pnlHelloWorld" runat="server">
            <ContentTemplate>
                <asp:Label runat="server" ID="lblHelloWorld" Text="Click the button!" />
                <br /><br />
                <asp:Button runat="server" ID="btnHelloWorld" OnClick="btnHelloWorld_Click" Text="Update label!" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
    <script src="/Scripts/jquery-1.10.2.js"></script>
    <script src="/Scripts/jquery.unobtrusive-ajax.min.js"></script>
    <script src="/MyFiles/Scripts/JavaScript.js" type="text/javascript"></script>
</body>
</html>
