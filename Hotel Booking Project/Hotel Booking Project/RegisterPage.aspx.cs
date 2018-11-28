using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;

namespace Hotel_Booking_Project
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
           try
            {
                pswdNot.Text = "";
                string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conStr;

                conn.Open();

                string update = "INSERT INTO Member (Email, Fname, Lname, Phone, pass) VALUES (@email, @fname,@lname, @phone, @pass)";

                SqlCommand cmd = new SqlCommand(update, conn);

                cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = emailBox.Text;
                cmd.Parameters.Add("@fname", System.Data.SqlDbType.NVarChar).Value = FnameBox.Text;
                cmd.Parameters.Add("@lname", System.Data.SqlDbType.NVarChar).Value = Lnamebox.Text;
                cmd.Parameters.Add("@phone", System.Data.SqlDbType.NVarChar).Value = numberBox.Text;
                cmd.Parameters.Add("@pass", System.Data.SqlDbType.NVarChar).Value = passwordBox.Text;

                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("SigninPage.aspx");

            }
            catch (Exception)
            {
                pswdNot.Text = "Failed to Register. Please try different email!";
            }
        }
    }
}