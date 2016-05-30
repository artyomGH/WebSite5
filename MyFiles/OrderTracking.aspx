<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderTracking.aspx.cs" Inherits="MyFiles_OrderTracking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <%--<meta name="viewport" content="width=device-width, initial-scale=1.0" />--%>
    <title><%: Page.Title %> - My ASP.NET Application</title>   
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/OrderTracking.css" rel="stylesheet" />
    
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

                       <%-- <li><a runat="server" href="~/MyFiles/About">О нас</a></li>--%>
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
        
        <br />
        <br />
        <br />
        <br />
        <br />
        <div class="marg" style="height: 510px; width: 597px">
            
            <label id="Label1"> Виберіть авто</label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
            </asp:DropDownList>
            
            <br /><label id="Label2" > Виберіть дату замовлення></label>
            <br />
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Table   ID="Table1" runat="server" Height="132px" Width="318px"   >
            </asp:Table>
            <br /><br />
        </div>

        

    </form>
</body>
</html>
