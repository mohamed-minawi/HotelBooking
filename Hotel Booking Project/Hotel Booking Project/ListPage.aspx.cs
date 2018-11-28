using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;
using System.Web.UI.HtmlControls;
using System.Data;

namespace Hotel_Booking_Project
{
    public partial class ListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CalendarExtender1.StartDate = DateTime.Now;
            CalendarExtender2.StartDate = DateTime.Now;

            if (IsPostBack)
            {
                int x = Convert.ToInt16(Session["count"]);
                PlaceHolder1.Controls.Clear();
                for (int i = 0; i < x; i++)
                {
                    string name = (string)Session["c" + Convert.ToString(i) + "name"];
                    string add = (string)Session["c" + Convert.ToString(i) + "add"];
                    string Desc = (string)Session["c" + Convert.ToString(i) + "desc"]; ;

                    Panel nw = generateCard(i, name, add, Desc);
                    PlaceHolder1.Controls.Add(nw);
                }
            }
            else
            {
                Session["budget"] = "0";
                Session["star"] = "0";
                Session["rating"] = "0";
            }
        }

        protected void budget1_Click(object sender, EventArgs e)
        {
            Session["budget"] = "0";
        }

        protected void budget2_Click(object sender, EventArgs e)
        {
            Session["budget"] = "200";
        }

        protected void budget3_Click(object sender, EventArgs e)
        {
            Session["budget"] = "400";
        }

        protected void budget4_Click(object sender, EventArgs e)
        {
            Session["budget"] = "600";
        }

        protected void budget5_Click(object sender, EventArgs e)
        {
            Session["budget"] = "600";
        }

        protected void Star1_Click(object sender, EventArgs e)
        {
            Session["star"] = Convert.ToString(1);
        }

        protected void Star2_Click(object sender, EventArgs e)
        {
            Session["star"] = Convert.ToString(2);
        }

        protected void Star3_Click(object sender, EventArgs e)
        {
            Session["star"] = Convert.ToString(3);
        }

        protected void Star4_Click(object sender, EventArgs e)
        {
            Session["star"] = Convert.ToString(4);
        }

        protected void Star5_Click(object sender, EventArgs e)
        {
            Session["star"] = Convert.ToString(5);
        }

        protected void Customer1_Click(object sender, EventArgs e)
        {
            Session["rating"] = Convert.ToString(0);
        }

        protected void Customer2_Click(object sender, EventArgs e)
        {
            Session["rating"] = Convert.ToString(2);
        }

        protected void Customer3_Click(object sender, EventArgs e)
        {
            Session["rating"] = Convert.ToString(4);
        }

        protected void Customer4_Click(object sender, EventArgs e)
        {
            Session["rating"] = Convert.ToString(6);
        }

        protected void Customer5_Click(object sender, EventArgs e)
        {
            Session["rating"] = Convert.ToString(8);
        }

        protected void dynamic_btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string ID = btn.ID;
            Session["HID"] = Session["c" + ID + "ID"];
            Session["hotelName"] = Session["c" + ID + "name"];
            Session["DateIn"] = chk_in.Text;
            Session["Dateout"] = chk_out.Text;
            Response.Redirect("HotelPage.aspx");
        }

        protected void b7_Click(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conStr;

            conn.Open();

            string qry = "Select H.Hid , H.Hname , H.Haddress , H.Hcity , H.Hcountry, H.Hrating, H.Himg" +
                " From Hotel H " +
                " Where H.Hid IN  " +
                "( Select Room.Hid " +
                "   from Room " +
                "   left join Booking " +
                "   on      Booking.HID = Room.Hid " +
                "     and   Booking.RID = Room.Number " +
                "     and   Booking.DateOut >= @SDate " +
                "     and   Booking.DateIn <= @EDate " +
                "   Where Booking.BID IS NULL) " +
                "and ( H.Hname like @search or H.Haddress like @search or H.Hcountry like @search or H.Hcity like @search)";

            SqlCommand cmd = new SqlCommand(qry, conn);

            cmd.Parameters.Add("@search", System.Data.SqlDbType.NVarChar).Value = "%" + tb1.Text + "%";

            DateTime date = DateTime.ParseExact(chk_in.Text, "dd/MM/yyyy", null);

            cmd.Parameters.Add("@SDate", System.Data.SqlDbType.DateTime).Value = Convert.ToDateTime(date);
            date = DateTime.ParseExact(chk_out.Text, "dd/MM/yyyy", null);

            cmd.Parameters.Add("@EDate", System.Data.SqlDbType.DateTime).Value = Convert.ToDateTime(date);

            int cnt = 0;

            SqlDataReader nw = cmd.ExecuteReader();
            PlaceHolder1.Controls.Clear();

            while (nw.Read())
            {
                string Desc = nw.GetString(3) + ", " + nw.GetString(4) + "         " + Convert.ToString(nw.GetValue(5)) + "*";
                Panel outer = generateCard(cnt, (string)nw.GetValue(1), (string)nw.GetValue(6), Desc);

                PlaceHolder1.Controls.Add(outer);
                Session["c" + Convert.ToString(cnt) + "name"] = (string)nw.GetValue(1);
                Session["c" + Convert.ToString(cnt) + "ID"] = Convert.ToString(nw.GetValue(0));
                Session["c" + Convert.ToString(cnt) + "add"] = (string)nw.GetValue(6);
                Session["c" + Convert.ToString(cnt) + "desc"] = Desc;

                cnt++;
            }

            Session["count"] = Convert.ToString(cnt);

            conn.Close();
        }

        public Panel generateCard(int cnt, string name, string path, string dec)
        {
            Panel outer = new Panel();
            outer.Attributes["class"] = "col";
            outer.Attributes["style"] = "padding-top: 10px;";

            Panel card = new Panel();
            card.Attributes["class"] = "card";
            card.Attributes["style"] = "width: 18rem; ";

            Panel crdb = new Panel();
            crdb.Attributes["class"] = "card-body";

            Image img = new Image();
            img.Attributes["class"] = "card-img-top";
            img.Attributes["runat"] = "server";
            img.ImageUrl = path;

            HtmlGenericControl hd = new HtmlGenericControl("h5");
            hd.Attributes["class"] = "card-title";
            hd.InnerHtml = name;

            HtmlGenericControl crdtext = new HtmlGenericControl("p");
            crdtext.Attributes["class"] = "card-text";
            crdtext.InnerHtml = dec;

            Button but = new Button();
            but.Text = "Choose Hotel";
            but.ID = Convert.ToString(cnt);
            but.Click += new System.EventHandler(this.dynamic_btn_Click);

            crdb.Controls.Add(hd);
            crdb.Controls.Add(crdtext);
            crdb.Controls.Add(but);

            card.Controls.Add(img);
            card.Controls.Add(crdb);

            outer.Controls.Add(card);
            return outer;
        }

        protected void filter_Click(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conStr;

            conn.Open();

            string qry = "Select H.Hid , H.Hname , H.Haddress , H.Hcity , H.Hcountry, H.Hrating, H.Himg" +
                    " From Hotel H " +
                    " Where H.Hid IN  " +
                    " ( Select Room.Hid " +
                    "   from Room " +
                    "   left join Booking " +
                    "   on      Booking.HID = Room.Hid " +
                    "     and   Booking.RID = Room.Number " +
                    "     and   Booking.DateOut >= @SDate " +
                    "     and   Booking.DateIn <= @EDate " +
                    "   Where Booking.BID IS NULL) " +
                    "   AND ( H.Hname like @search or H.Haddress like @search or H.Hcountry like @search or H.Hcity like @search) " +
                    "   AND H.Hid IN ( Select Room.HID From Room Where Room.Price >= @budget Group By Room.HID)  " +
                    "   AND H.Hrating >= @star " +
                    "   AND (Select a = (Comfort + Value + Staff + Facilties + Location + Cleanliness)/6.0  From HotelRating Where H.Hid = HotelRating.Hid) >= @rating ";

            SqlCommand cmd = new SqlCommand(qry, conn);

            cmd.Parameters.Add("@search", System.Data.SqlDbType.NVarChar).Value = "%" + tb1.Text + "%";

            DateTime date = DateTime.ParseExact(chk_in.Text, "dd/MM/yyyy", null);

            cmd.Parameters.Add("@SDate", System.Data.SqlDbType.DateTime).Value = Convert.ToDateTime(date);
            date = DateTime.ParseExact(chk_out.Text, "dd/MM/yyyy", null);

            cmd.Parameters.Add("@EDate", System.Data.SqlDbType.DateTime).Value = Convert.ToDateTime(date);
            cmd.Parameters.Add("@budget", System.Data.SqlDbType.Float).Value = Convert.ToDouble(Session["budget"]);
            cmd.Parameters.Add("@star", System.Data.SqlDbType.Float).Value = Convert.ToDouble(Session["star"]);
            cmd.Parameters.Add("@rating", System.Data.SqlDbType.Float).Value = Convert.ToDouble(Session["rating"]);


            int cnt = 0;

            SqlDataReader nw = cmd.ExecuteReader();

            PlaceHolder1.Controls.Clear();

            while (nw.Read())
            {
                string Desc = nw.GetString(3) + " , " + nw.GetString(4) + "     " + Convert.ToString(nw.GetValue(5)) + "*";
                Panel outer = generateCard(cnt, (string)nw.GetValue(1), (string)nw.GetValue(6), Desc);

                PlaceHolder1.Controls.Add(outer);
                Session["c" + Convert.ToString(cnt) + "name"] = (string)nw.GetValue(1);
                Session["c" + Convert.ToString(cnt) + "ID"] = Convert.ToString(nw.GetValue(0));
                Session["c" + Convert.ToString(cnt) + "add"] = (string)nw.GetValue(6);
                Session["c" + Convert.ToString(cnt) + "desc"] = Desc;

                cnt++;
            }

            Session["count"] = Convert.ToString(cnt);

            conn.Close();

        }

        protected void SortStar_Click(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conStr;

            conn.Open();

            string qry = "Select H.Hid , H.Hname , H.Haddress , H.Hcity , H.Hcountry, H.Hrating, H.Himg" +
                    " From Hotel H " +
                    " Where H.Hid IN  " +
                    " ( Select Room.Hid " +
                    "   from Room " +
                    "   left join Booking " +
                    "   on      Booking.HID = Room.Hid " +
                    "     and   Booking.RID = Room.Number " +
                    "     and   Booking.DateOut >= @SDate " +
                    "     and   Booking.DateIn <= @EDate " +
                    "   Where Booking.BID IS NULL) " +
                    "   AND ( H.Hname like @search or H.Haddress like @search or H.Hcountry like @search or H.Hcity like @search) " +
                    "   AND H.Hid IN ( Select Room.HID From Room Where Room.Price >= @budget Group By Room.HID)  " +
                    "   AND H.Hrating >= @star " +
                    "   AND (Select a = (Comfort + Value + Staff + Facilties + Location + Cleanliness)/6.0  From HotelRating Where H.Hid = HotelRating.Hid) >= @rating" +
                    "   Order By H.Hrating ";

            SqlCommand cmd = new SqlCommand(qry, conn);

            cmd.Parameters.Add("@search", System.Data.SqlDbType.NVarChar).Value = "%" + tb1.Text + "%";

            DateTime date = DateTime.ParseExact(chk_in.Text, "dd/MM/yyyy", null);

            cmd.Parameters.Add("@SDate", System.Data.SqlDbType.DateTime).Value = Convert.ToDateTime(date);
            date = DateTime.ParseExact(chk_out.Text, "dd/MM/yyyy", null);

            cmd.Parameters.Add("@EDate", System.Data.SqlDbType.DateTime).Value = Convert.ToDateTime(date);
            cmd.Parameters.Add("@budget", System.Data.SqlDbType.Float).Value = Convert.ToDouble(Session["budget"]);
            cmd.Parameters.Add("@star", System.Data.SqlDbType.Float).Value = Convert.ToDouble(Session["star"]);
            cmd.Parameters.Add("@rating", System.Data.SqlDbType.Float).Value = Convert.ToDouble(Session["rating"]);


            int cnt = 0;

            SqlDataReader nw = cmd.ExecuteReader();

            PlaceHolder1.Controls.Clear();

            while (nw.Read())
            {
                string Desc = nw.GetString(3) + " , " + nw.GetString(4) + "     " + Convert.ToString(nw.GetValue(5)) + "*";
                Panel outer = generateCard(cnt, (string)nw.GetValue(1), (string)nw.GetValue(6), Desc);

                PlaceHolder1.Controls.Add(outer);
                Session["c" + Convert.ToString(cnt) + "name"] = (string)nw.GetValue(1);
                Session["c" + Convert.ToString(cnt) + "ID"] = Convert.ToString(nw.GetValue(0));
                Session["c" + Convert.ToString(cnt) + "add"] = (string)nw.GetValue(6);
                Session["c" + Convert.ToString(cnt) + "desc"] = Desc;

                cnt++;
            }

            Session["count"] = Convert.ToString(cnt);

            conn.Close();
        }

        protected void SortPrice_Click(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conStr;

            conn.Open();

            string qry = "Select H.Hid , H.Hname , H.Haddress , H.Hcity , H.Hcountry, H.Hrating, H.Himg" +
                    " From Hotel H " +
                    " Where H.Hid IN  " +
                    " ( Select Room.Hid " +
                    "   from Room " +
                    "   left join Booking " +
                    "   on      Booking.HID = Room.Hid " +
                    "     and   Booking.RID = Room.Number " +
                    "     and   Booking.DateOut >= @SDate " +
                    "     and   Booking.DateIn <= @EDate " +
                    "   Where Booking.BID IS NULL) " +
                    "   AND ( H.Hname like @search or H.Haddress like @search or H.Hcountry like @search or H.Hcity like @search) " +
                    "   AND H.Hid IN ( Select Room.HID From Room Where Room.Price >= @budget Group By Room.HID)  " +
                    "   AND H.Hrating >= @star " +
                    "   Order By (Select Min(R.Price) From Room R Where H.Hid = R.Hid)";

            SqlCommand cmd = new SqlCommand(qry, conn);

            cmd.Parameters.Add("@search", System.Data.SqlDbType.NVarChar).Value = "%" + tb1.Text + "%";

            DateTime date = DateTime.ParseExact(chk_in.Text, "dd/MM/yyyy", null);

            cmd.Parameters.Add("@SDate", System.Data.SqlDbType.DateTime).Value = Convert.ToDateTime(date);
            date = DateTime.ParseExact(chk_out.Text, "dd/MM/yyyy", null);

            cmd.Parameters.Add("@EDate", System.Data.SqlDbType.DateTime).Value = Convert.ToDateTime(date);
            cmd.Parameters.Add("@budget", System.Data.SqlDbType.Float).Value = Convert.ToDouble(Session["budget"]);
            cmd.Parameters.Add("@star", System.Data.SqlDbType.Float).Value = Convert.ToDouble(Session["star"]);
            cmd.Parameters.Add("@rating", System.Data.SqlDbType.Float).Value = Convert.ToDouble(Session["rating"]);


            int cnt = 0;

            SqlDataReader nw = cmd.ExecuteReader();

            PlaceHolder1.Controls.Clear();

            while (nw.Read())
            {
                string Desc = nw.GetString(3) + " , " + nw.GetString(4) + "     " + Convert.ToString(nw.GetValue(5)) + "*";
                Panel outer = generateCard(cnt, (string)nw.GetValue(1), (string)nw.GetValue(6), Desc);

                PlaceHolder1.Controls.Add(outer);
                Session["c" + Convert.ToString(cnt) + "name"] = (string)nw.GetValue(1);
                Session["c" + Convert.ToString(cnt) + "ID"] = Convert.ToString(nw.GetValue(0));
                Session["c" + Convert.ToString(cnt) + "add"] = (string)nw.GetValue(6);
                Session["c" + Convert.ToString(cnt) + "desc"] = Desc;

                cnt++;
            }

            Session["count"] = Convert.ToString(cnt);

            conn.Close();
        }

        protected void SortRating_Click(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conStr;

            conn.Open();

            string qry = "Select H.Hid , H.Hname , H.Haddress , H.Hcity , H.Hcountry, H.Hrating, H.Himg, a = (R.Comfort + R.Value + R.Staff + R.Facilties + R.Location + R.Cleanliness)/6.0 " +
                    " From Hotel H  JOIN HotelRating R" +
                    " ON R.Hid = H.Hid" +
                    " Where H.Hid IN  " +
                    " ( Select Room.Hid " +
                    "   from Room " +
                    "   left join Booking " +
                    "   on      Booking.HID = Room.Hid " +
                    "     and   Booking.RID = Room.Number " +
                    "     and   Booking.DateOut >= @SDate " +
                    "     and   Booking.DateIn <= @EDate " +
                    "   Where Booking.BID IS NULL) " +
                    "   AND ( H.Hname like @search or H.Haddress like @search or H.Hcountry like @search or H.Hcity like @search) " +
                    "   AND H.Hid IN ( Select Room.HID From Room Where Room.Price >= @budget Group By Room.HID)  " +
                    "   AND H.Hrating >= @star " +
                    "   AND (Select a = (Comfort + Value + Staff + Facilties + Location + Cleanliness)/6.0  From HotelRating Where H.Hid = HotelRating.Hid) >= @rating" +
                    "   Order by a ";


            SqlCommand cmd = new SqlCommand(qry, conn);

            cmd.Parameters.Add("@search", System.Data.SqlDbType.NVarChar).Value = "%" + tb1.Text + "%";

            DateTime date = DateTime.ParseExact(chk_in.Text, "dd/MM/yyyy", null);

            cmd.Parameters.Add("@SDate", System.Data.SqlDbType.DateTime).Value = Convert.ToDateTime(date);
            date = DateTime.ParseExact(chk_out.Text, "dd/MM/yyyy", null);

            cmd.Parameters.Add("@EDate", System.Data.SqlDbType.DateTime).Value = Convert.ToDateTime(date);
            cmd.Parameters.Add("@budget", System.Data.SqlDbType.Float).Value = Convert.ToDouble(Session["budget"]);
            cmd.Parameters.Add("@star", System.Data.SqlDbType.Float).Value = Convert.ToDouble(Session["star"]);
            cmd.Parameters.Add("@rating", System.Data.SqlDbType.Float).Value = Convert.ToDouble(Session["rating"]);


            int cnt = 0;

            SqlDataReader nw = cmd.ExecuteReader();

            PlaceHolder1.Controls.Clear();

            while (nw.Read())
            {
                string Desc = nw.GetString(3) + " , " + nw.GetString(4) + "     " + Convert.ToString(nw.GetValue(5)) + "*";
                Panel outer = generateCard(cnt, (string)nw.GetValue(1), (string)nw.GetValue(6), Desc);

                PlaceHolder1.Controls.Add(outer);
                Session["c" + Convert.ToString(cnt) + "name"] = (string)nw.GetValue(1);
                Session["c" + Convert.ToString(cnt) + "ID"] = Convert.ToString(nw.GetValue(0));
                Session["c" + Convert.ToString(cnt) + "add"] = (string)nw.GetValue(6);
                Session["c" + Convert.ToString(cnt) + "desc"] = Desc;

                cnt++;
            }

            Session["count"] = Convert.ToString(cnt);

            conn.Close();
        }
    }
}