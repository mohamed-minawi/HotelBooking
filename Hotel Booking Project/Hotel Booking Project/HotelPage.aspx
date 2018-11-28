<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="HotelPage.aspx.cs" Inherits="Hotel_Booking_Project.HotelPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" PopupControlID="Panl1" TargetControlID="ddl"  

    CancelControlID="btnCancel" BehaviorID="mpe" runat="server"></ajaxToolkit:ModalPopupExtender> 

<asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none; background-color:gray;">

    <div style=" width: 300px; height: 300px; border-color:black;" id="irm1" >
         <asp:Label runat="server" Text="" ForeColor="Yellow" BorderColor ="White" ID ="lblRoomType"></asp:Label>
               <br/>

         <asp:Label runat="server" Text="" ForeColor="Yellow" BorderColor ="White"  ID ="lblRoomDesc"></asp:Label>
               <br/>

         <asp:Label runat="server" Text="" ForeColor="Yellow" BorderColor ="White" ID ="lblRoomPrice"></asp:Label>
        <br />
        <asp:Image ID="roomImg" runat="server" />
    </div>

   <br/>     
    <asp:DropDownList ID="ddl" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                <asp:Label runat="server" Text="" ID ="lblPrice"></asp:Label>
                <asp:Button runat="server" class="btn btn-warning" ID="CalcPrice" Text="Calculate" OnClick="Calc_Button"/>
        </ContentTemplate>
    </asp:UpdatePanel>
       <br/>
     
    <asp:Button runat="server" class="btn btn-warning" ID="btnCancel" Text="Cancel"/>

    <asp:Button ID="btnBook" class="btn btn-warning" runat="server" Text="Book" OnClick="Book_Button" />

</asp:Panel>



        <div style="margin-top:10px;">
               <div class="container-fluid">
                  <div class="row">
                    <div class="col-3">
                        <div class="row">
                            <div class="col d-flex justify-content-center">
                                 <asp:image id="Hotel_logo" runat="server"  class="img-fluid" alt="Responsive image" />
                            </div>
                        </div>      
                        <div class="row" style="margin-top:30px; ">
                            <div class="col d-flex justify-content-center">
                                <asp:Label ID ="Hotel_Name" runat ="server" Text = "" Font-Size= "XX-Large" ForeColor ="Red"/>
                                 
                            </div>
                        </div>      
                        <div class="row" style="margin-top:30px; ">
                            <div class="col d-flex justify-content-center">
                                <asp:Label ID ="Hotel_Address" runat ="server" Text = "" Font-Size= "Large" ForeColor ="Black"/>
                            </div>
                        </div> 
                        <div class="row" style="margin-top:30px; ">
                            <div class="col d-flex justify-content-center">
                                 <asp:image id="Hotel_Location" runat="server" class="img-fluid" alt="Responsive image" />
                            </div>
                        </div> 
                        
                    </div>
                    <div class="col">
                        <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
                          <div class="carousel-inner">
                            <div class="carousel-item active">
                              <asp:image id="img4" runat="server" imageurl="Images/Sh1.jpg" class="d-block w-100"  style="width:20rem; height:40rem;" />
                            </div>
                            <div class="carousel-item">
                              <asp:image id="img5" runat="server" imageurl="Images/Sh2.jpg" class="d-block w-100"  style="width:20rem; height:40rem;" />
                            </div>
                            <div class="carousel-item">
                              <asp:image id="img6" runat="server" imageurl="Images/Sh3.jpg" class="d-block w-100"  style="width:20rem; height:40rem;" />
                            </div>
                            <div class="carousel-item">
                              <asp:image id="img7" runat="server" imageurl="Images/Sh4.jpg" class="d-block w-100"  style="width:20rem; height:40rem;" />
                            </div>
                            <div class="carousel-item">
                              <asp:image id="img8" runat="server" imageurl="Images/Sh5.jpg" class="d-block w-100"  style="width:20rem; height:40rem;" />
                            </div>
                          </div>
                          <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
                            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                            <span class="sr-only">Previous</span>
                          </a>
                          <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
                            <span class="carousel-control-next-icon" aria-hidden="true"></span>
                            <span class="sr-only">Next</span>
                          </a>
                        </div>
                       </div>
                   </div>
                </div>
        </div>

        <div style="margin-top:10px;">
                <div class="container-fluid">
                     <div class="row">
                            <div class="col-3 ">
                                <div class="jumbotron jumbotron-fluid">
                                  <div class="container">
                                    <h1 class="display-4 d-flex justify-content-center">Reviews</h1>
                                        <asp:BulletedList ID="Reviews_List" runat="server">

                                        </asp:BulletedList>
                                  </div>
                                </div>                            
                            </div>
                            <div class="col">
                                    <h3 class ="d-flex justify-content-center" style="color: Green;"> General Information </h3>
                                    <asp:Label ID="Hotel_Desc" Text="" runat="server" Font-Size="Large"/>
                            </div>
                            <div class="col-3">
                                 <div class="jumbotron jumbotron-fluid" style="background-color:#7FDFFF;">
                                  <div class="container">
                                    <h1 class="display-4 d-flex justify-content-center">Ratings</h1>
                                   <asp:BulletedList ID="Rating_List" runat="server"></asp:BulletedList>
                                  </div>
                                </div>                            
                            </div>
                        
                    </div>
                </div>
        </div>
        
        <div style="margin-top:10px;">
            <div class="container-fluid">
                <div class="row">
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server">

                        </asp:PlaceHolder>
                 </div>
            </div>
        </div>
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MitchDB.mdf;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT DISTINCT [AccType] FROM [Accommodation]"></asp:SqlDataSource>
        
</asp:Content>
