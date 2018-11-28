<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="listHotel.aspx.cs" Inherits="Hotel_Booking_Project.listHotel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class ="row" style =" padding-top:20px; padding-bottom:20px;">
            <div class ="col ">

               <div class="card">
                    <div class="card-header" >
                        <h3 class="card-title"> List Your Hotel</h3>
                    </div>
                    <div class="card-body ">

                        <div class="form-group">
                            <label for="hotelName" class="col-sm-3 control-label">Hotel Name*</label>
                            <div class="auto-style1">
                                <asp:TextBox id="hnameBox" class="form-control" type="text" placeholder="Hotel Name" runat="server" />
                            </div>
                        </div>   

                        <div class="form-group">
                            <label for="adress" class="col-sm-3 control-label">Address*</label>
                            <div class="col-sm-9">
                                <asp:TextBox id="addBox" class="form-control" type="text" placeholder="Address" runat="server" />
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <label for="desc" class="col-sm-3 control-label">Hotel Description* </label>
                            <div class="col-sm-9">
                                <asp:TextBox id="descBox" class="form-control" type="text"  placeholder="Description" runat="server" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="email" class="col-sm-3 control-label">Hotel Email* </label>
                            <div class="col-sm-9">
                                <asp:TextBox id="emailBox" class="form-control" type="email" TextMode="email" placeholder="Email" runat="server" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="phoneNumber" class="col-sm-3 control-label">Phone number* </label>
                            <div class="col-sm-9">
                                <asp:TextBox id="numberBox" class="form-control" type="text"  placeholder="Phone Number" runat="server" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="srating" class="col-sm-3 control-label">Star Rating*</label>
                            <div class="col-sm-9">
                                <asp:TextBox id="starsbox" class="form-control" placeholder="i.e 5 Stars" TextMode="number" runat="server" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="city" class="col-sm-3 control-label">City*</label>
                            <div class="col-sm-9">
                                <asp:TextBox id="cityBox" class="form-control" placeholder="City" type="text" runat="server" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="country" class="col-sm-3 control-label">Country*</label>
                            <div class="col-sm-9">
                                <asp:TextBox id="countrtyBox" class="form-control" placeholder="City" type="text" runat="server" />
                            </div>
                        </div>

                        <asp:Label ID="uiLabel" runat="server" Text="Upload Image"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:FileUpload ID="imgHotel" runat="server" />
                        <asp:Button id="Button1" Text="Upload" class="btn btn-success" runat="server" OnClick="Button1_Click"/>
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <div class="col-md-2" style="padding-top:10px;">
                              <asp:Button id="listButton" Text="Register" class="btn btn-lg btn-success btn-block" runat="server" OnClick="listButton_Click"/>

                        </div>

                    </div>
                </div>
             </div>
        </div>
    </div>
    

</asp:Content>
