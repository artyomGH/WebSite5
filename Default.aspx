<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     
    
    <script src="/Scripts/jquery-1.10.2.js"></script>
    <script src="/Scripts/jquery.unobtrusive-ajax.min.js"></script>
    <script src="/MyFiles/Scripts/JavaScript.js" type="text/javascript"></script>


    <br /><div class="marg-poloska" style="height: 583px; width: 991px">
       
        <div class="layer1" style="height: 538px;">

            <asp:Button class="btn btn-default" ID="EnterToChat" runat="server" Text=  "Напишіть нам" OnClick="EnterToChat_Click" Width="125px" />
            <asp:Button class="btn btn-default" ID="GoToComments" runat="server" Text= "Коментарі" OnClick="GoToComments_Click" Width="125px" />
            <asp:Button class="btn btn-default" ID="Video" runat="server" Text="Відео" OnClick="Video_Click" Width="125px" />
            <asp:Button class="btn btn-default" ID="OrderTracking" runat="server" Text="Хід замовлення" OnClick="OrderTracking_Click" Width="125px" />
            <asp:Button class="btn btn-default" ID="ForManager" runat="server" Text="Призначити" OnClick="ForManager_Click" Width="125px" Visible="False" />

        </div>
            <div class="layer2" style="height: 538px;">
                <h2>Lorem ipsum </h2>
                <div style="width: 557px; height: 144px;">
                    <p>Nullam et sodales nunc, vel pharetra est. Fusce non nisl velit.
                    Integer scelerisque tortor quis dolor condimentum, ac accumsan dui commodo.
                    Aenean et diam mi. Nunc vestibulum sem felis. 
                    Praesent ac libero elementum, varius enim ut, facilisis dolor. 
                    Fusce sit amet tellus at justo faucibus maximus commodo vel libero. 
                    Vestibulum malesuada eget erat et efficitur. Praesent scelerisque 
                    velit ac libero vulputate, id mattis dui tincidunt. Pellentesque 
                    habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.</p> 
                    
                </div>
                <div style="height: 308px; width: 559px">
                    <iframe src="//www.youtube.com/embed/FkX88N4pCow?rel=0" frameborder="0" allowfullscreen style="height: 285px; width: 540px"></iframe>

                </div>
                
                 <br />
            </div>            
        </div>
    
</asp:Content>
  