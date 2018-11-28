<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="roomEdit.aspx.cs" Inherits="Hotel_Booking_Project.roomEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                       <div class="form-group">
                            <label for="rnumber" class="col-sm-3 control-label">Room Number*</label>
                            <div class="col-sm-9">
                                <asp:TextBox id="rnumberBox" class="form-control" placeholder="Room Number" TextMode="number" runat="server" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="RmType" class="col-sm-3 control-label">Room Type*</label>
                            <div class="col-sm-9">
                                <asp:TextBox id="RmType" class="form-control" placeholder="Room Type" type="text" runat="server" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="Price" class="col-sm-3 control-label">Price*</label>
                            <div class="col-sm-9">
                                <asp:TextBox id="priceBox" class="form-control" placeholder="Price" type="text" runat="server" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="RDesc" class="col-sm-3 control-label">Room Description*</label>
                            <div class="col-sm-9">
                                <asp:TextBox id="RDescBox" class="form-control" placeholder="Room Description" type="text" runat="server" />
                            </div>
                        </div>
                        
                        <asp:Label ID="uiLabel" runat="server" Text="Upload Image"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:FileUpload ID="roomPath" runat="server" />
                        <asp:Button id="Button1" Text="Upload" class="btn btn-success" runat="server" OnClick="Button1_Click"/>

                        <div class="col-md-2" style="padding-top:10px;">
                              <asp:Button id="UpDateBtn" Text="Add Room" class="btn btn-lg btn-success btn-block" runat="server" OnClick="UpDateBtn_Click"/>

                        </div>


</asp:Content>
