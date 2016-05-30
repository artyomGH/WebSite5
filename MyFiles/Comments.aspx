<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Comments.aspx.cs" Inherits="MyFiles_Comments" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - My ASP.NET Application</title>

    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Mail.css" rel="stylesheet" />    
</head>
<body>
    
    <form id="form1" runat="server" >
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
                        
                        <%--<li><a runat="server" href="~/MyFiles/About">О нас</a></li>--%>
                        <li><a runat="server" href="~/MyFiles/Contact">Контакти</a></li>                        
                    </ul>
                    <asp:LoginView runat="server" ViewStateMode="Disabled">
                        <AnonymousTemplate>
                            <ul class="nav navbar-nav navbar-right">
                                <li><a runat="server" href="~/Account/Register">Реєстрація</a></li>
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

        <div class="marg-left-default" style="height: 510px; width: 597px" >
            <br /><br /><asp:Label ID="Label1" runat="server" Text="Введіть ім'я або залиште пустим"></asp:Label>
            <br />
            <asp:TextBox class="artem" ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Button class=" comment_otpravit_left" ID="SendComment" runat="server" OnClick="Button1_Click" Text="Відправити" />
            
            <br /><br /><asp:TextBox class="artem" ID="TextBox3" runat="server" Height="47px" Width="429px" TextMode="MultiLine"></asp:TextBox>
            
            <br /><br /><asp:TextBox class="artem" ID="TextBox1" runat="server" Height="269px" Width="429px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
        
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
