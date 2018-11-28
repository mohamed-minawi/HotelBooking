<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AccountPage.aspx.cs" Inherits="Hotel_Booking_Project.AccountPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="padding-top: 50px; padding-bottom: 50px;">
        <div class="row">
           <div class="col d-flex justify-content-center">
                 <button class="btn btn-primary" style="margin-right:5px; margin-left:5px;" type="button" data-toggle="collapse" data-target="#Password" ">
                    Change Password
                  </button>
                   <button class="btn btn-primary" style="margin-right:5px; margin-left:5px;" type="button" data-toggle="collapse" data-target="#Profile" ">
                    Edit Profile
                  </button>
                  <button class="btn btn-primary" style="margin-right:5px; margin-left:5px;" type="button" data-toggle="collapse" data-target="#Bookings" ">
                    View Bookings
                  </button>
                   <button class="btn btn-primary" style="margin-right:5px; margin-left:5px;" type="button" data-toggle="collapse" data-target=".multi-collapse"; ">
                    Rate and Review
                  </button>


           </div>

        </div>
    </div>

    <div style="padding-top: 50px; padding-bottom: 50px;">

        <div class="row">
           <div class="col" >
               <div class="collapse" id="Password">
                         <div class="card card-body">
                              <div class="form-group">
                                <label for="password" class="col-sm-3 control-label">Password*</label>
                                <div class="col-sm-9">
                                    <asp:TextBox id="passwordBox" class="form-control" placeholder="Password" TextMode="password" runat="server" />
                                </div>
                            </div>
<%--                            <asp:RequiredFieldValidator ID="pswdV" 
                               runat="server" ControlToValidate ="passwordBox"
                               ErrorMessage="Please enter Password" 
                               InitialValue="" Font-Size="11px" ForeColor="Red">
                            </asp:RequiredFieldValidator >--%>

                            <div class="form-group">
                                <label for="password" class="col-sm-3 control-label">Confirm Password*</label>
                                <div class="col-sm-9">
                                    <asp:TextBox id="passwordConfirmBox" class="form-control" placeholder="Password" TextMode="password" runat="server" />
                                </div>
<%--                            </div>
                            <asp:RequiredFieldValidator ID="pwdCV" 
                               runat="server" ControlToValidate ="passwordConfirmBox"
                               ErrorMessage="Please enter Password" 
                               InitialValue="" Font-Size="11px" ForeColor="Red">
                            </asp:RequiredFieldValidator>--%>
                            <br />
                               <asp:Button runat="server" class="btn btn-warning" ID="PassUpdate" Text="Update Password" OnClick="UodatePass_Button"/>

                              <asp:Label ID="lblPass" runat="server" class ="badge badge-warning" Text= ""></asp:Label>

                        </div>

               </div>
           </div>
</div>
           <div class="col">
                <div class="collapse" id="Profile">
                          <div class="card card-body">
                              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                  <ContentTemplate>
                                <div class="form-group">
                                    <label for="firstName" class="col-sm-3 control-label">First Name*</label>
                                    <div class="auto-style1">
                                        <asp:TextBox id="FnameBox" class="form-control" type="text" placeholder="First Name" runat="server" />
                                    </div>
                                </div>   
<%--                                <asp:RequiredFieldValidator ID="fnameV" 
                                   runat="server" ControlToValidate ="FnameBox"
                                   ErrorMessage="Please enter First Name" 
                                   InitialValue="" Font-Size="11px" ForeColor="Red">

                                </asp:RequiredFieldValidator>--%>
                              
                                <div class="form-group">
                                    <label for="lastName" class="col-sm-3 control-label">Last Name*</label>
                                    <div class="col-sm-9">
                                        <asp:TextBox id="Lnamebox" class="form-control" type="text" placeholder="Last Name" runat="server" />
                                    </div>
                                </div>
<%--                                <asp:RequiredFieldValidator ID="lnameV" 
                                   runat="server" ControlToValidate ="Lnamebox"
                                   ErrorMessage="Please enter Last Name" 
                                   InitialValue="" Font-Size="11px" ForeColor="Red">
                                </asp:RequiredFieldValidator>--%>

                                <div class="form-group">
                                    <label for="phoneNumber" class="col-sm-3 control-label">Phone number* </label>
                                    <div class="col-sm-9">
                                        <asp:TextBox id="numberBox" class="form-control" type="text"  placeholder="Phone Number" runat="server" />
                                    </div>
                                </div>
<%--                                <asp:RequiredFieldValidator ID="PhoneV" 
                                   runat="server" ControlToValidate ="numberBox"
                                   ErrorMessage="Please enter phone Number" 
                                   InitialValue="" Font-Size="11px" ForeColor="Red">
                                </asp:RequiredFieldValidator>--%>
                                 <asp:Button runat="server" class="btn btn-primary" ID="Button1" Text="Update" OnClick="Update_Button"/>
                                 <asp:Label ID="lblUpdate" runat="server" class ="badge badge-warning" Text= ""></asp:Label>

                                      </ContentTemplate>
                                </asp:UpdatePanel>

                          </div>

               </div>
               
           </div>
           <div class="col" >
                <div class="collapse" id="Bookings">
                          <div class="card card-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                               <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="BID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="BID" HeaderText="BID" ReadOnly="True" SortExpression="BID" />
                                    <asp:BoundField DataField="Hname" HeaderText="Hname" SortExpression="Hname" />
                                    <asp:BoundField DataField="Column1" HeaderText="Check In" ReadOnly="True" SortExpression="Column1" />
                                    <asp:BoundField DataField="Column2" HeaderText="Chceck Out" ReadOnly="True" SortExpression="Column2" />
                                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
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
                             </ContentTemplate>     
                         </asp:UpdatePanel>
                               <asp:Button runat="server" class="btn btn-warning" ID="btnCancel" Text="Cancel" OnClick="Cancel_Button"/>
                                <asp:Label ID="cancelLbl" runat="server" class ="badge badge-warning" Text= ""></asp:Label>

                          </div>
               </div>

           </div>

                 <br />
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MitchDB.mdf;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT B.BID, H.Hname, Convert(VARCHAR(10),B.DateIn,101), Convert(VARCHAR(10),B.DateOut,101), B.Price FROM Booking AS B INNER JOIN Hotel AS H ON B.HID = H.Hid WHERE (B.email = @email)">
                     <SelectParameters>
                         <asp:SessionParameter Name="email" SessionField="email" Type="String" />
                     </SelectParameters>
                 </asp:SqlDataSource>
    </div>
            

        <div class ="row d-flex justify-content-center" style="margin-top: 20px">
                <div class ="col d-flex justify-content-center">
                   <div class="collapse multi-collapse">

                        <div class="card card-body container-fluid">
                               <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="BID,Hid" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    <asp:CommandField ShowSelectButton="True" />
                                                    <asp:BoundField DataField="BID" HeaderText="BID" ReadOnly="True" SortExpression="BID" />
                                                    <asp:BoundField DataField="Hname" HeaderText="Hname" SortExpression="Hname" />
                                                    <asp:BoundField DataField="Hid" HeaderText="Hid" ReadOnly="True" SortExpression="Hid" />
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
                                            <br></br>
                                            <div class="row">
                                                <h5 style="margin-right:10px;">Comfort Ratings</h5>
                                                <ajaxToolkit:Rating ID="ComfortRatings" runat="server" CurrentRating="0" EmptyStarCssClass="emptyRatingStar" FilledStarCssClass="filledRatingStar" MaxRating="10" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar" />
                                            </div>
                                            <br></br>
                                            <div class="row">
                                                <h5 style="margin-right:10px;">Staff Ratings</h5>
                                                <ajaxToolkit:Rating ID="staffRatings" runat="server" CurrentRating="0" EmptyStarCssClass="emptyRatingStar" FilledStarCssClass="filledRatingStar" MaxRating="10" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar" />
                                            </div>
                                            <br></br>
                                            <div class="row">
                                                <h5 style="margin-right:10px;">Facilities Ratings</h5>
                                                <ajaxToolkit:Rating ID="facRatings" runat="server" CurrentRating="0" EmptyStarCssClass="emptyRatingStar" FilledStarCssClass="filledRatingStar" MaxRating="10" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar" />
                                            </div>
                                            <br></br>
                                            <div class="row">
                                                <h5 style="margin-right:10px;">Location Ratings</h5>
                                                <ajaxToolkit:Rating ID="locRatings" runat="server" CurrentRating="0" EmptyStarCssClass="emptyRatingStar" FilledStarCssClass="filledRatingStar" MaxRating="10" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar" />
                                            </div>
                                            <br></br>
                                            <div class="row">
                                                <h5 style="margin-right:10px;">Value Ratings</h5>
                                                <ajaxToolkit:Rating ID="ValRatings" runat="server" CurrentRating="0" EmptyStarCssClass="emptyRatingStar" FilledStarCssClass="filledRatingStar" MaxRating="10" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar" />
                                            </div>
                                            <br></br>
                                            <div class="row">
                                                <h5 style="margin-right:10px;">Cleanliness Ratings</h5>
                                                <ajaxToolkit:Rating ID="cleanRatings" runat="server" CurrentRating="0" EmptyStarCssClass="emptyRatingStar" FilledStarCssClass="filledRatingStar" MaxRating="10" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar" />
                                            </div>
                                            <br></br>
                                            <div class="row" style="margin-top:15px;">
                                                <h5 style="margin-right:10px;">Review </h5>
                                                <asp:TextBox ID="ReviewBox" runat="server"></asp:TextBox>
                                            </div>
                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MitchDB.mdf;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT B.BID, H.Hname,H.Hid FROM Booking AS B INNER JOIN Hotel AS H ON B.HID = H.Hid WHERE (B.email = @email)">
                                                <SelectParameters>
                                                    <asp:SessionParameter Name="email" SessionField="email" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
                                            <br></br>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                     <div class="row" style="margin-top:15px;">
                                         <asp:Button ID="SubmitButton" CssClass ="btn btn-primary" runat="server" Text="Submit Rating and Review" OnClick="SubmitButton_Click" />
                                    </div>

                        </div>

                   </div>
             </div>
<%--                <div class ="col">
                   <div class="collapse multi-collapse">

                        <div class="card card-body container-fluid">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <h5> Comfort Ratings</h5>
                                                <ajaxToolkit:Rating ID="ComfortRating"  runat="server" CurrentRating="0" MaxRating="10"
                                        StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar" FilledStarCssClass="filledRatingStar"
                                        EmptyStarCssClass="emptyRatingStar"  />
                                        </div>
                                    </br>
                                    <div class="row">
                                            <h5> Staff Ratings</h5>

                                                <ajaxToolkit:Rating ID="staffRating"  runat="server" CurrentRating="0" MaxRating="10"
                                        StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar" FilledStarCssClass="filledRatingStar"
                                        EmptyStarCssClass="emptyRatingStar"  />    

                                   </div>
                              </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                   </div>

             </div>--%>

       </div>

    </div>

</asp:Content>
