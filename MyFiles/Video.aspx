<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Video.aspx.cs" Inherits="MyFiles_Video" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %> - My ASP.NET Application</title>

    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    
    <style>
       body {
        /*background: url(http://www.arc21.org.uk/download/1/Sheffield%20daytime%20web%20jk.jpg);  Цвет фона и путь к файлу */
        background: #c7b39b url(/images/video_back.jpg);
        color: #fff; /* Цвет текста */
       }
    </style>
</head>
<body>
    
    <form id="form1" runat="server" >

        <div class="navbar navbar-inverse navbar-fixed-top">            
            <ul class="nav navbar-nav navbar-left">
                <li><a href="/Default.aspx"> На главную &raquo;</a></li>
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
                        <li><asp:LoginStatus runat="server" LogoutAction="Redirect" LogoutText="Log off" LogoutPageUrl="~/" OnLoggingOut="Unnamed_LoggingOut" /></li>
                    </ul>
                </LoggedInTemplate>
            </asp:LoginView>
        </div>

        <div class="col-md-4">          
            
    <div class="iv-embed" style="margin:0 auto;padding:0;border:0;width:642px;"><div class="iv-v" style="display:block;margin:0;padding:1px;border:0;background:#000;"><iframe class="iv-i" style="display:block;margin:0;padding:0;border:0;" src="https://open.ivideon.com/embed/v2/?server=100-676275bf544e8faf4d8614390e4719e1&amp;camera=0&amp;width=&amp;height=&amp;lang=ru" width="640" height="480" frameborder="0" allowfullscreen></iframe></div><div class="iv-b" style="display:block;margin:0;padding:0;border:0;"><div style="float:right;text-align:right;padding:0 0 10px;line-height:10px;"><a class="iv-a" style="font:10px Verdana,sans-serif;color:inherit;opacity:.6;" href="https://www.ivideon.com/" target="_blank">powered by Ivideon</a></div><div style="clear:both;height:0;overflow:hidden;">&nbsp;
     </div>
        <script src="https://open.ivideon.com/embed/v2/embedded.js"></script></div></div>
    </div>
    </form>
</body>
</html>
