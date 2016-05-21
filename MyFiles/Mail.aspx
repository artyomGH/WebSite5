<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="Mail.aspx.cs" Inherits="MyFiles_Mail" %>

<!DOCTYPE html>
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <%--<meta name="viewport" content="width=device-width, initial-scale=1.0" />--%>
    <title><%: Page.Title %> - My ASP.NET Application</title>   
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Mail.css" rel="stylesheet" />    
</head>
<body>
    <form id="form1" runat="server"> 
    <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" runat="server" href="~/">СТО</a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        
                        <li><a runat="server" href="~/MyFiles/About">О нас</a></li>
                        <li><a runat="server" href="~/MyFiles/Contact">Контакты</a></li>                        
                    </ul>
                    <asp:LoginView runat="server" ViewStateMode="Disabled">
                        <AnonymousTemplate>
                            <ul class="nav navbar-nav navbar-right">
                                <li><a runat="server" href="~/Account/Register">Регистрация</a></li>
                                <li><a runat="server" href="~/Account/Login">Войти</a></li>
                            </ul>
                        </AnonymousTemplate>
                        <LoggedInTemplate>
                            <ul class="nav navbar-nav navbar-right">
                                <li><a runat="server" href="~/Account/Manage" title="Manage your account">Привет, <%: Context.User.Identity.GetUserName()  %>!</a></li>
                                <li>
                                    <asp:LoginStatus runat="server" LogoutAction="Redirect" LogoutText="Log off" LogoutPageUrl="~/" OnLoggingOut="Unnamed_LoggingOut" />
                                </li>
                            </ul>
                        </LoggedInTemplate>
                    </asp:LoginView>
                </div>
            </div>
        </div>
    <br />
        <div class="marg-left-default" style="height: 510px; width: 597px" >
    
        
            <br /><h4><asp:Label   ID="nickname" runat="server" Text="Ваше імя"></asp:Label></h4>
            <asp:TextBox  class="wrapper form-control" ID="TextBox3" runat="server" TextMode="MultiLine" Height="95px" Width="548px" ></asp:TextBox>                   
            <br /><asp:Label   class="h4" ID="Label3" runat="server" Text="Виберіть кому відправити "></asp:Label> 
            <asp:DropDownList class="artem" ID="DropDownList1" runat="server" AutoPostBack="True"  >
                </asp:DropDownList>   
            
            
            <button class="btn btn-default artem_left" id="btnSend" type="button" >Відправити</button>
            <br />
            <br /><asp:Label class="h4" ID="Label2" runat="server" Text="Повідомлення"></asp:Label>
            <br /><asp:TextBox  class="wrapper form-control" ID="TextBox1" runat="server" Height="249px" TextMode="MultiLine" Width="548px" ReadOnly="true"></asp:TextBox >
            
        
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