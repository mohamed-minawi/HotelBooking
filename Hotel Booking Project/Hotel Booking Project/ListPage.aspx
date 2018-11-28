<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ListPage.aspx.cs" Inherits="Hotel_Booking_Project.ListPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            width: 100%;
            min-height: 1px;
            -ms-flex-preferred-size: 0;
            flex-basis: 0;
            -ms-flex-positive: 1;
            flex-grow: 1;
            max-width: 100%;
            left: -3px;
            top: 13px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                           <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div style="padding-top: 50px; padding-bottom: 50px; background: rgba(0, 0, 0, 0.05)">
            <div class="container-fluid" style="padding-left:100px;">
                <div class="row">
                    <div class="col d-flex justify-content-center" style="padding-bottom: 10px;">
                        <h4>Filter the Hotels using the following</h4>
                    </div>
                </div>
                <div class="row d-flex justify-content-center" style=" margin-top: 10px">
                  <div class="col">
                    <div class="row d-flex justify-content-center">
                       <asp:Label ID="label1" href="#" class = "badge badge-primary" runat="server" data-toggle="collapse" data-target="#Budget" style="margin-left: 10px; margin-right: 10px;" Text="Budget per night" />
                     </div>

                    <div class="row d-flex justify-content-center" style="padding-top:10px;">
                        <div class="collapse multi-collapse" id="Budget">
                             <div class="btn-group" role="group">
                                   <asp:Button id="budget1" Text="All" class="btn btn-primary" runat="server" OnClick="budget1_Click" />
                                   <asp:Button id="budget2" Text="200+" class="btn btn-primary" runat="server" OnClick="budget2_Click" />
                                   <asp:Button id="budget3" Text="400+" class="btn btn-primary" runat="server" OnClick="budget3_Click" />
                                   <asp:Button id="budget4" Text="600+" class="btn btn-primary" runat="server" OnClick="budget4_Click" />
                                   <asp:Button id="budget5" Text="800+" class="btn btn-primary" runat="server" OnClick="budget5_Click" />
                            </div>
                        </div>
                    </div>
                  </div>
                  <div class="col">
                     <div class="row d-flex justify-content-center">
                        <asp:Label ID="label2" href="#" class = "badge badge-secondary" runat="server" data-toggle="collapse" data-target="#Star" style="margin-left: 10px; margin-right: 10px;" Text="Star Rating" />

                     </div>   
                     <div class="row d-flex justify-content-center" style="padding-top:10px;">   
                        <div class="collapse multi-collapse" id="Star">
                             <div class="btn-group" role="group">
                                   <asp:Button id="Star1" Text="*" class="btn btn-secondary" runat="server" OnClick="Star1_Click" />
                                   <asp:Button id="Star2" Text="**" class="btn btn-secondary" runat="server" OnClick="Star2_Click" />
                                   <asp:Button id="Star3" Text="***" class="btn btn-secondary" runat="server" OnClick="Star3_Click" style="width: 36px" />
                                   <asp:Button id="Star4" Text="****" class="btn btn-secondary" runat="server" OnClick="Star4_Click" />
                                   <asp:Button id="Star5" Text="*****" class="btn btn-secondary" runat="server" OnClick="Star5_Click" />
                            </div>
                        </div>
                     </div>
                  </div>
                  <div class="col">
                    <div class="row d-flex justify-content-center">
                        <asp:Label ID="label3" href="#" class = "badge badge-success" runat="server" data-toggle="collapse" data-target="#Customer" style="margin-left: 10px; margin-right: 10px;" Text="Customer Ratings" />

                     </div>
                    <div class="row d-flex justify-content-center" style="padding-top:10px;">
                        <div class="collapse multi-collapse" id="Customer">
                         <div class="btn-group" role="group">
                               <asp:Button id="Customer1" Text="All" class="btn btn-success" runat="server" OnClick="Customer1_Click" />
                               <asp:Button id="Customer2" Text="2+" class="btn btn-success" runat="server" OnClick="Customer2_Click" />
                               <asp:Button id="Customer3" Text="4+" class="btn btn-success" runat="server" OnClick="Customer3_Click" />
                               <asp:Button id="Customer4" Text="6+" class="btn btn-success" runat="server" OnClick="Customer4_Click" />
                               <asp:Button id="Customer5" Text="8+" class="btn btn-success" runat="server" OnClick="Customer5_Click" />
                        </div>
                        </div>   
                     </div>                

                  </div> 
              </div>
                <div class ="row d-flex justify-content-center" style= "padding-top:20px;">
                    <asp:Button id="filter" Text="Filter" class="btn btn-warning" runat="server" OnClick="filter_Click" />
                </div>
            </div>
        </div>
    
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
       <div>
           <div class="container">
                <div class="row" >

                            <div class="input-group" style="padding-bottom: 20px; padding-top: 20px; ">
                            <!-- Every one of these inputs would need to be changed to a proper ASP TextBox -->
                            <asp:TextBox id="tb1" placeholder="Where are you going?" runat="server" />
                            <asp:TextBox id="chk_in"  placeholder="DD/MM/YEAR" runat="server" TextMode="DateTime" type="date"  />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="chk_in" Format="dd/MM/yyyy" runat="server" />
                            <asp:TextBox id="chk_out"   placeholder="DD/MM/YEAR" runat="server" TextMode="DateTime" type="date"/>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="chk_out" Format="dd/MM/yyyy" runat="server" />

                            <asp:Button id="b7"  class="form-control btn btn-danger" runat="server" Text="Submit" OnClick="b7_Click"/>
                         </div>
                </div>
           </div>
                
           <div class="container-fluid">
              <div class="row">
                    <div class="col-2">
                        <div class="row" style="margin-top:10px;">
                            <div class="col d-flex justify-content-center">
                                 <h3>Sort Hotel</h3>
                             </div>
                        </div>
                            
                        <div class="row" >
                            <div class="col d-flex justify-content-center">
                                <asp:Button id="SortStar"  class=" btn btn-primary" style="margin-top:10px; margin-bottom:10px;" runat="server" Text="Star Rating" OnClick="SortStar_Click"/>
                             </div>
                        </div>
                            
                         <div class="row" >
                            <div class="col d-flex justify-content-center">
                               <asp:Button id="SortPrice"  class=" btn btn-success" style="margin-top:10px; margin-bottom:10px;" runat="server" Text="Total Price" OnClick="SortPrice_Click"/>
                             </div>
                        </div>
                            
                         <div class="row" >
                            <div class="col d-flex justify-content-center">
                                <asp:Button id="SortRating"  class=" btn btn-danger" style="margin-top:10px; margin-bottom:10px;" runat="server" Text="Customer Rating" OnClick="SortRating_Click"/>
                             </div>
                        </div>
                    </div>
                    <div class ="auto-style1">
                        <div class="row d-flex justify-content-center">
                        
                                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">

                                    </asp:PlaceHolder>
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </div>
                    </div>
                    <br />
                    <br />
     
              </div>
            </div>
       </div>
              </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
