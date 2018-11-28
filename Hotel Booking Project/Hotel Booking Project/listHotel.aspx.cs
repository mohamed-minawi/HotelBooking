using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Booking_Project
{
    public partial class listHotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void listButton_Click(object sender, EventArgs e)
        {


           Random rnd = new Random();
           int hotelId = rnd.Next(1000, 9999);

            try
            {
                string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conStr;

                conn.Open();

                string update = "INSERT INTO Hotel (Hid, Hname, Haddress, Hphone, Hemail, Hdescription, Hrating, Hcity, Hcountry, Himg) VALUES (@id, @name,@address, @phone,@mail ,@desc, @stars, @city, @country, @img)";

                SqlCommand cmd = new SqlCommand(update, conn);
                // @id, @name,@address, @phone, @desc, @stars, @city, @country, @img)";

                cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = hotelId;
                cmd.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = hnameBox.Text;
                cmd.Parameters.Add("@address", System.Data.SqlDbType.NVarChar).Value = addBox.Text;
                cmd.Parameters.Add("@mail", System.Data.SqlDbType.NVarChar).Value = emailBox.Text;
                cmd.Parameters.Add("@phone", System.Data.SqlDbType.NVarChar).Value = numberBox.Text;
                cmd.Parameters.Add("@desc", System.Data.SqlDbType.NVarChar).Value = descBox.Text;
                cmd.Parameters.Add("@stars", System.Data.SqlDbType.Float).Value = Convert.ToDouble(starsbox.Text);
                cmd.Parameters.Add("@city", System.Data.SqlDbType.NVarChar).Value = cityBox.Text;
                cmd.Parameters.Add("@country", System.Data.SqlDbType.NVarChar).Value = countrtyBox.Text;
                cmd.Parameters.Add("@img", System.Data.SqlDbType.NVarChar).Value = Session["Path"];

                cmd.ExecuteNonQuery();
                conn.Close();

                cmd.Dispose();
                conn.Open();

                update = "INSERT INTO HotelRating (Hid, Comfort, Value, Staff, Facilties, Location, Cleanliness) VALUES (@Hid, @comfort, @value, @staff,@fac ,@loc, @clean)";
                cmd = new SqlCommand(update, conn);

                cmd.Parameters.Add("@Hid", System.Data.SqlDbType.Int).Value = hotelId;
                cmd.Parameters.Add("@comfort", System.Data.SqlDbType.Float).Value = 0;
                cmd.Parameters.Add("@value", System.Data.SqlDbType.Float).Value = 0;
                cmd.Parameters.Add("@staff", System.Data.SqlDbType.Float).Value = 0;
                cmd.Parameters.Add("@fac", System.Data.SqlDbType.Float).Value = 0;
                cmd.Parameters.Add("@loc", System.Data.SqlDbType.Float).Value = 0;
                cmd.Parameters.Add("@clean", System.Data.SqlDbType.Float).Value = 0;

                cmd.ExecuteNonQuery();
                conn.Close();


                Session["Hotel_ID"] = hotelId;
                Response.Redirect("roomEdit.aspx");

            }
            catch (Exception)
            {

            }



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Path"] = "~/Images/"+imgHotel.FileName;
            imgHotel.SaveAs(Server.MapPath("~/Images/") + imgHotel.FileName);

        }
    }
}