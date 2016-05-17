<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     
    
    <script src="/Scripts/jquery-1.10.2.js"></script>
    <script src="/Scripts/jquery.unobtrusive-ajax.min.js"></script>
    <script src="/MyFiles/Scripts/JavaScript.js" type="text/javascript"></script>


    <br /><div class="marg-poloska" style="height: 583px; width: 991px">
       
        <div class="layer1" style="height: 538px;">

            <asp:Button class="btn btn-default" ID="EnterToChat" runat="server" Text=  "Напишите нам" OnClick="EnterToChat_Click" Width="125px" />
            <asp:Button class="btn btn-default" ID="GoToComments" runat="server" Text= "Коментарі" OnClick="GoToComments_Click" Width="125px" />
            <asp:Button class="btn btn-default" ID="Video" runat="server" Text="Відео" OnClick="Video_Click" Width="125px" />
            <asp:Button class="btn btn-default" ID="OrderTracking" runat="server" Text="Хід замовлення" OnClick="OrderTracking_Click" Width="125px" />

        </div>
            <div class="layer2" style="height: 538px;">
                <h2>"СТО на Дарнице - Автосервис &quot;ВВС&quot;">Автосервис "ВВС"        </h2>
                <div style="width: 538px; height: 402px;">
                    <p>Автосервис "ВВС" – завоевавшая доверие автолюбителей в Киеве <strong>СТО на Позняках</strong> постгарантийного обслуживания.</p>
                    <p>Отличное качество обслуживания и индивидуальный подходк каждому клиенту - визитная карточка нашего предприятия.</p>
                    С самого начала существования мы привлекаем заказчика гибкостью, динамичностью, желанием меняться вместе с непрерывно развивающимся рынком автоуслуг.
                <br>
                    <br>
                    Время показало, что выбранный курс оказался удачным и способствовует расширению деятельности фирмы.<iframe src="http://www.youtube.com/embed/eeX5CbbIahQ" frameborder="0" allowfullscreen="true" style="width: 66%; height: 188px;"></iframe>

                </div>
            </div>            
        </div>
    
</asp:Content>
  