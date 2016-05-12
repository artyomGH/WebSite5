<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Myform.aspx.cs" Inherits="MyFiles_Myform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    
    <form id="form1" runat="server">
        <br /><asp:TextBox   ID="TextBox3" runat="server" TextMode="MultiLine" ></asp:TextBox>                   
        <p><textarea rows="10" cols="45" name="text"></textarea></p>
    </form>

    <script src="/Scripts/jquery-1.10.2.js"></script>
    <script src="/Scripts/jquery.unobtrusive-ajax.min.js"></script>
    <script src="/MyFiles/Scripts/JavaScript.js" type="text/javascript"></script>
</body>
</html>
