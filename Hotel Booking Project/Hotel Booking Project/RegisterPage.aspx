<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Hotel_Booking_Project.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            width: 100%;
            min-height: 1px;
            -ms-flex: 0 0 75%;
            flex: 0 0 75%;
            max-width: 75%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div class="container">
        <div class ="row" style =" padding-top:20px; padding-bottom:20px;">
            <div class ="col ">

               <div class="card">
                    <div class="card-header" >
                        <h3 class="card-title"> Register</h3>
                    </div>
                    <div class="card-body ">
                        <div class="form-group">
                            <label for="firstName" class="col-sm-3 control-label">First Name*</label>
                            <div class="auto-style1">
                                <asp:TextBox id="FnameBox" class="form-control" type="text" placeholder="First Name" runat="server" />
                            </div>
                        </div>   
                        <asp:RequiredFieldValidator ID="fnameV" 
                           runat="server" ControlToValidate ="FnameBox"
                           ErrorMessage="Please enter First Name" 
                           InitialValue="" Font-Size="11px" ForeColor="Red">

                        </asp:RequiredFieldValidator>

                        <div class="form-group">
                            <label for="lastName" class="col-sm-3 control-label">Last Name*</label>
                            <div class="col-sm-9">
                                <asp:TextBox id="Lnamebox" class="form-control" type="text" placeholder="Last Name" runat="server" />
                            </div>
                        </div>
                        <asp:RequiredFieldValidator ID="lnameV" 
                           runat="server" ControlToValidate ="Lnamebox"
                           ErrorMessage="Please enter Last Name" 
                           InitialValue="" Font-Size="11px" ForeColor="Red">
                        </asp:RequiredFieldValidator>

                        <div class="form-group">
                            <label for="email" class="col-sm-3 control-label">Email* </label>
                            <div class="col-sm-9">
                                <asp:TextBox id="emailBox" class="form-control" type="email" TextMode="email" placeholder="Email" runat="server" />
                            </div>
                        </div>
                        <asp:RequiredFieldValidator ID="emailV" 
                           runat="server" ControlToValidate ="emailBox"
                           ErrorMessage="Please enter Email" 
                           InitialValue="" Font-Size="11px" ForeColor="Red">
                        </asp:RequiredFieldValidator>

                        <div class="form-group">
                            <label for="phoneNumber" class="col-sm-3 control-label">Phone number* </label>
                            <div class="col-sm-9">
                                <asp:TextBox id="numberBox" class="form-control" type="text"  placeholder="Phone Number" runat="server" />
                            </div>
                        </div>
                        <asp:RequiredFieldValidator ID="PhoneV" 
                           runat="server" ControlToValidate ="numberBox"
                           ErrorMessage="Please enter phone Number" 
                           InitialValue="" Font-Size="11px" ForeColor="Red">
                        </asp:RequiredFieldValidator>

                        <div class="form-group">
                            <label for="password" class="col-sm-3 control-label">Password*</label>
                            <div class="col-sm-9">
                                <asp:TextBox id="passwordBox" class="form-control" placeholder="Password" TextMode="password" runat="server" />
                            </div>
                        </div>
                        <asp:RequiredFieldValidator ID="pswdV" 
                           runat="server" ControlToValidate ="passwordBox"
                           ErrorMessage="Please enter Password" 
                           InitialValue="" Font-Size="11px" ForeColor="Red">
                        </asp:RequiredFieldValidator >

                        <div class="form-group">
                            <label for="password" class="col-sm-3 control-label">Confirm Password*</label>
                            <div class="col-sm-9">
                                <asp:TextBox id="passwordConfirmBox" class="form-control" placeholder="Password" TextMode="password" runat="server" />
                            </div>
                        </div>
                        <asp:RequiredFieldValidator ID="pwdCV" 
                           runat="server" ControlToValidate ="passwordConfirmBox"
                           ErrorMessage="Please enter Password" 
                           InitialValue="" Font-Size="11px" ForeColor="Red">
                        </asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />
                        <asp:CompareValidator runat="server" ID="PWDCompareV" ControlToValidate="passwordBox" 
                         ControlToCompare="passwordConfirmBox" Text="Password mismatch" Font-Size="11px" ForeColor="Red" >
                        </asp:CompareValidator >
                        
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        
                        <asp:Label ID="pswdNot" runat="server" class ="badge badge-warning" Text= ""></asp:Label>

                         <asp:Button id="loginButton" Text="Register" class="form-control btn btn-lg btn-success btn-block" runat="server" OnClick="loginButton_Click" />
                    </div>
                </div>
             </div>
        </div>
    </div>
            

</asp:Content>
