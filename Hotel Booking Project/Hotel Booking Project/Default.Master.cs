using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Booking_Project
{
    public partial class Default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["email"] == null) {
                b6.Text = "Sign In";
                b5.Text = "Register";
                b4.Text = "Register your Property on MITCH";
            }
            else { 
                b6.Text = "Log Out";
                b5.Text = "My Account";
                b4.Text = "Search for Hotel";

            }
        }

        protected void b4_Click(object sender, EventArgs e)
        {
            if (Session["email"] == null)
                Response.Redirect("listHotel.aspx");
            else
                Response.Redirect("ListPage.aspx");

        }

        protected void b5_Click(object sender, EventArgs e)
        {
            if (Session["email"] == null)
                Response.Redirect("RegisterPage.aspx");
            else
                Response.Redirect("AccountPage.aspx");
            

        }

        protected void b6_Click(object sender, EventArgs e)
        {
            if (Session["email"] == null)
                Response.Redirect("SigninPage.aspx");
            else
            {
                Session["email"] = null;
                Response.Redirect("SigninPage.aspx");
            }


        }
    }
}