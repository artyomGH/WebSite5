﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderTracking.aspx.cs" Inherits="MyFiles_OrderTracking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <%--<meta name="viewport" content="width=device-width, initial-scale=1.0" />--%>
    <title><%: Page.Title %> - My ASP.NET Application</title>   
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    
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
        <br />
        <br />
        <br />
        <br />
        <div style="height: 510px; width: 597px">
            
            <label id="Label1"> Виберіть авто</label>
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
            </asp:DropDownList>
            
            <br /><asp:Label ID="Label2" runat="server" Text="Виберіть дату замовлення"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Table ID="Table1" runat="server" BackColor="#FF0066" BorderColor="#660066" BorderStyle="Groove" ForeColor="#99CCFF" GridLines="Both" Height="212px" Width="390px">
            </asp:Table>
            
            <asp:TextBox ID="TextBox1" runat="server" Height="153px" TextMode="MultiLine" Width="291px"></asp:TextBox>
            
        </div>

        

    </form>
</body>
</html>
