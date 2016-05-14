<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="Mail.aspx.cs" Inherits="MyFiles_Mail" %>

<!DOCTYPE html>
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <%--<meta name="viewport" content="width=device-width, initial-scale=1.0" />--%>
    <title><%: Page.Title %> - My ASP.NET Application</title>   
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    
    <style>
       body {
        /*background: url(http://www.arc21.org.uk/download/1/Sheffield%20daytime%20web%20jk.jpg);  ���� ���� � ���� � ����� */
        background: #c7b39b url(/images/video_back.jpg);
        color: #fff; /* ���� ������ */
       }
    </style>
</head>
<body>
    <form id="form1" runat="server"> 
        
    <div class="navbar navbar-inverse navbar-fixed-top">            
            <ul class="nav navbar-nav navbar-left">
                <li><a href="/Default.aspx"> �� ������� &raquo;</a></li>
            </ul>            
            <asp:LoginView runat="server" ViewStateMode="Disabled">
                <AnonymousTemplate>
                    <ul class="nav navbar-nav navbar-right">
                        <li><a runat="server" href="~/Account/Register">�����������</a></li>
                        <li><a runat="server" href="~/Account/Login">�����</a></li>
                    </ul>
                </AnonymousTemplate>
                <LoggedInTemplate>
                    <ul class="nav navbar-nav navbar-right">
                        <li><a runat="server" href="~/Account/Manage" title="Manage your account">������, <%: Context.User.Identity.GetUserName()  %>!</a></li>
                        <li><asp:LoginStatus runat="server" LogoutAction="Redirect" LogoutText="Log off" LogoutPageUrl="~/" OnLoggingOut="Unnamed_LoggingOut" /></li>
                    </ul>
                </LoggedInTemplate>
            </asp:LoginView>
        </div>
    <div >
        <p>
            <br /><asp:Label   ID="nickname" runat="server" Text="nickname"></asp:Label>
            <br /><asp:TextBox  class="wrapper form-control" ID="TextBox3" runat="server" TextMode="MultiLine" Height="95px" Width="548px" ></asp:TextBox>                   
            <br /><asp:Label   ID="Label3" runat="server" Text="�������� ���� ��������� "></asp:Label> 
            <asp:DropDownList  ID="DropDownList1" runat="server" AutoPostBack="True" Height="29px" Width="173px" >
                </asp:DropDownList>   
            <asp:Button class="btn btn-danger" ID="Send" runat="server" OnClick="btnSend" Text="���������" Width="114px" Height="35px" />
        
            <br /><asp:Label ID="Label2" runat="server" Text="���������"></asp:Label>
            <asp:TextBox  ID="TextBox1" runat="server" Height="249px" TextMode="MultiLine" Width="548px" ReadOnly="true"></asp:TextBox >
            
        </p>
    </div>     
        
            
        <script src="/Scripts/jquery-1.10.2.js"></script>
        <script src="/Scripts/jquery.unobtrusive-ajax.min.js"></script>
        <script src="/MyFiles/Scripts/JavaScript.js" type="text/javascript"></script>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="~/MyFiles/WebService.asmx" />
        </Services>
        </asp:ScriptManager>   
    </form>
</body>
</html>