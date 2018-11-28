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
    public partial class SigninPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conStr;

            conn.Open();

            string qry = "Select * From Member where email = @email AND pass = @pass";

            SqlCommand cmd = new SqlCommand(qry, conn);

            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email.Text;
            cmd.Parameters.Add("@pass", System.Data.SqlDbType.NVarChar).Value = password.Text;

            SqlDataReader sdr = cmd.ExecuteReader();

            if (sdr.Read())
            {
                pswdNot.Text = "Login Sucess......!!";
                Session["email"] = email.Text;
                Response.Redirect("ListPage.aspx");
            }
            else
            {
                pswdNot.Text = "UserId & Password Is not correct Try again..!!";

            }

            conn.Close();
        }
    }
}