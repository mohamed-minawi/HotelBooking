<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="SigninPage.aspx.cs" Inherits="Hotel_Booking_Project.SigninPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="container">
        <div class="row d-flex justify-content-center" style="padding-top:100px;">
            <div class="col">
                <div class="card">
                    <div class="card-header" >
                        <h3 class="card-title"> Sign In with your email</h3>
                    </div>
                    <div class="card-body">
                                <div class="form-group">
                                    <asp:TextBox id="email" class="form-control" placeholder="E-mail" TextMode="email" runat="server" />
                                </div>
                                <div class="form-group">
                                    <asp:TextBox id="password" class="form-control" placeholder="Password" TextMode="password" runat="server" />
                                </div>
                                <div class="checkbox">
                                    <label>
                                        <asp:CheckBox ID="remeber" runat="server" Text="Remember Me"/>  
                                    </label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="pswdNot" runat="server" class ="badge badge-warning" Text= ""></asp:Label>
                                </div>
                                <!-- Change this to a button or input when using this as a form -->

                                 <asp:Button id="login" Text="Login" class="form-control btn btn-lg btn-success btn-block" runat="server" OnClick="login_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
