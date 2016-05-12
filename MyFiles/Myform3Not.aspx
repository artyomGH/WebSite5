<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Myform3Not.aspx.cs" Inherits="MyFiles_Myform3Not" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Страница с использованием Аякса, но без UpdatePanel</title>
</head>
<body>
  <form id="form1" runat="server">
  <div>

  <script>
    function GetResult() {
      WebService.HelloWorld(function (result) {
        $get('Label1').innerHTML = result;
      });
    }
  </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    <Services>
    <asp:ServiceReference Path="~/MyFiles/WebService.asmx" />
    </Services>
    </asp:ScriptManager>

   
    <asp:Label ID="Label1" runat="server" Text="Label" ></asp:Label>
    <br />
    <br />
    <input type="button" onclick="GetResult()" value="Button" />
    
   
    
  </div>
  </form>
</body>
</html>