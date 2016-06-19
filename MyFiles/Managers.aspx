<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="Managers.aspx.cs" Inherits="MyFiles_Managers" %>

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
                        
                        <%--<li><a runat="server" href="~/MyFiles/About">Про нас</a></li>--%>
                        <li><a runat="server" href="~/MyFiles/Contact">Контакти</a></li>                        
                    </ul>
                    <asp:LoginView runat="server" ViewStateMode="Disabled">
                        <AnonymousTemplate>
                            <ul class="nav navbar-nav navbar-right">
                                <li><a runat="server" href="~/Account/Register">Реєстрация</a></li>
                                <li><a runat="server" href="~/Account/Login">Увійти</a></li>
                            </ul>
                        </AnonymousTemplate>
                        <LoggedInTemplate>
                            <ul class="nav navbar-nav navbar-right">
                                <li><a runat="server" href="~/Account/Manage" title="Manage your account">Привіт, <%: Context.User.Identity.GetUserName()  %>!</a></li>
                                <li>
                                    <asp:LoginStatus runat="server" LogoutAction="Redirect" LogoutText="Вийти" LogoutPageUrl="~/" OnLoggingOut="Unnamed_LoggingOut" />
                                </li>
                            </ul>
                        </LoggedInTemplate>
                    </asp:LoginView>
                </div>
            </div>
        </div>
    <br />
        <div class="marg-left-default" style="height: 510px; width: 597px" >
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Виберіть користувачів яким слід надати права"></asp:Label>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            </asp:CheckBoxList>
            <br />
            <asp:Button class="btn btn-default" ID="btnConfirm" runat="server" Text="Надати права" OnClick="btnConfirm_Click" Width="125px" />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Виберіть користувачів у якид слід забрати права"></asp:Label>
            <asp:CheckBoxList ID="CheckBoxList2" runat="server">
            </asp:CheckBoxList>            
            <br />            
            <asp:Button class="btn btn-default" ID="btnDelete" runat="server" Text="Забрати права" OnClick="btnDelete_Click" Width="125px" />
    </div>     
	
	<script src="/Scripts/jquery-1.10.2.js"></script>
        <script src="/Scripts/jquery.unobtrusive-ajax.min.js"></script>
        <script src="/MyFiles/Scripts/JavaScript.js" type="text/javascript"></script>
    
       
            
        
    </form>
</body>
</html>