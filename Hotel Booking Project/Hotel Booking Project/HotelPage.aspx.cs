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
using System.Net.Mail;
using System.Net;

namespace Hotel_Booking_Project
{
    public partial class HotelPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conStr;

                conn.Open();

                string qry = "Select * From Hotel where Hname = @search";

                SqlCommand cmd = new SqlCommand(qry, conn);

                cmd.Parameters.Add("@search", System.Data.SqlDbType.NVarChar).Value = Session["hotelName"];

                SqlDataReader nw = cmd.ExecuteReader();

                if (nw.Read())
                {
                    Hotel_Name.Text = Convert.ToString(nw.GetValue(1));
                    Hotel_Address.Text = Convert.ToString(nw.GetValue(2));
                    Hotel_logo.ImageUrl = "~/Images/"+ Session["hotelName"] + "_Logo.jpg";
                    Hotel_Location.ImageUrl = "~/Images/" + Session["hotelName"] + "_Map.jpg";
                    Hotel_Desc.Text = (string)nw.GetValue(5);
                }
                cmd.Dispose();
                conn.Close();

                conn.Open();

                qry = "Select Review From Reviews where Hid = " + Session["HID"];

                SqlDataAdapter da = new SqlDataAdapter(qry, conn);

                DataSet dt = new DataSet();

                da.Fill(dt, "table");

                Reviews_List.DataTextField = "Review";
                Reviews_List.DataSource = dt.Tables["table"].DefaultView;
                Reviews_List.DataBind();

                conn.Close();
                conn.Open();

                qry = "Select * From HotelRating where Hid = @search";

                cmd = new SqlCommand(qry, conn);

                cmd.Parameters.Add("@search", System.Data.SqlDbType.Int).Value = Convert.ToInt32(Session["HID"]);

                nw = cmd.ExecuteReader();

                if (nw.Read())
                {
                    List<string> str = new List<string>();
                    str.Add("Comfort");
                    str.Add("Value");
                    str.Add("Staff");
                    str.Add("Facilities");
                    str.Add("Location");
                    str.Add("Cleanliness");
                    for (int i = 0; i < 6; i++)
                    {   
                        Rating_List.Items.Add(new ListItem(str[i] + ": "+ Convert.ToString((double)nw.GetValue(i + 1))));
                    }
                }
                cmd.Dispose();
                conn.Close();


                conn.Open();
                qry = "Select Room.RmType, Room.Price,Room.RmPath, Room.RmDesc" +
                "   from Room " +
                "   left join Booking " +
                "   on      Booking.HID = Room.Hid " +
                "     and   Booking.RID = Room.Number " +
                "     and   Booking.DateOut >= @SDate " +
                "     and   Booking.DateIn <= @EDate " +
                "   Where Booking.BID IS NULL " +
                "   AND Room.Hid = @HID" +
                "   Group By Room.RmType, Room.Price,Room.RmPath, Room.RmDesc ";

                cmd = new SqlCommand(qry, conn);

                cmd.Parameters.Add("@HID", System.Data.SqlDbType.Int).Value = Convert.ToInt32(Session["HID"]);
                DateTime date = DateTime.ParseExact((string)Session["DateIn"], "dd/MM/yyyy", null);

                cmd.Parameters.Add("@SDate", System.Data.SqlDbType.DateTime).Value = Convert.ToDateTime(date);
                date = DateTime.ParseExact((string)Session["Dateout"], "dd/MM/yyyy", null);

                cmd.Parameters.Add("@EDate", System.Data.SqlDbType.DateTime).Value = Convert.ToDateTime(date);

                nw = cmd.ExecuteReader();
                int cnt = 0;

                PlaceHolder1.Controls.Clear();

                while (nw.Read())
                {
                    Panel outer = generateCard(cnt, (string)nw.GetValue(0), "$"+Convert.ToString(nw.GetValue(1)) +"\n" + (string)nw.GetValue(3)
                        , (string)nw.GetValue(2));

                    PlaceHolder1.Controls.Add(outer);
                    Session["h" + Convert.ToString(cnt) + "type"] = (string)nw.GetValue(0);
                    Session["h" + Convert.ToString(cnt) + "Price"] = Convert.ToString(nw.GetValue(1));
                    Session["h" + Convert.ToString(cnt) + "path"] = (string)nw.GetValue(2);
                    Session["h" + Convert.ToString(cnt) + "desc"] = (string)nw.GetValue(3);

                    cnt++;
                }
                Session["hcount"] = Convert.ToString(cnt);

                cmd.Dispose();
                conn.Close();

                ddl.DataTextField = "AccType";
                ddl.DataValueField = "AccType";
                ddl.DataSource = SqlDataSource1;
                ddl.DataBind();
                ddl.Attributes["style"] = "margin-bottom:10px;";

            }
            else
            {
                int x = Convert.ToInt16(Session["hcount"]);
                PlaceHolder1.Controls.Clear();
                for (int i = 0; i < x; i++)
                {
                    string type = (string)Session["h" + Convert.ToString(i) + "type"];
                    string price = (string)Session["h" + Convert.ToString(i) + "Price"];
                    string path = (string)Session["h" + Convert.ToString(i) + "path"];
                    string desc = (string)Session["h" + Convert.ToString(i) + "desc"];

                    Panel nw = generateCard(i, type, "$" + price  + desc,path);
                    PlaceHolder1.Controls.Add(nw);
                }
            }

        }

        public void dynamic_btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string ID = btn.ID;
            string Type = (string)Session["h" + ID + "type"];
            string Price = (string)Session["h" + ID + "Price"] ;
            string Desc = (string)Session["h" + ID + "desc"];

            Session["price"] = Price;

            lblRoomDesc.Text = Desc;
            lblRoomPrice.Text = "$" + Price + " per night";
            lblRoomType.Text = Type;
            roomImg.ImageUrl = (string)Session["h" + ID + "path"];
            roomImg.Attributes["style"] = "height:200px;width:250px;";

            lblPrice.Text = Price;
            ModalPopupExtender1.Show();
            //Response.Redirect("ListPage.aspx");

        }

        public void Calc_Button(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conStr;

            conn.Open();

            string qry = "Select Price From Accommodation where AccType = @search AND H_id = @Hid";

            SqlCommand cmd = new SqlCommand(qry, conn);

            cmd = new SqlCommand(qry, conn);

            cmd.Parameters.Add("@search", System.Data.SqlDbType.NVarChar).Value = ddl.SelectedValue;
            cmd.Parameters.Add("@HID", System.Data.SqlDbType.Int).Value = Convert.ToInt32(Session["HID"]);

            SqlDataReader nw = cmd.ExecuteReader();
            double Price = 0;
            if (nw.Read())
            {
                Price = Convert.ToDouble(nw.GetValue(0));
            }
            cmd.Dispose();
            conn.Close();
            lblPrice.Visible = true;
            lblPrice.ForeColor = System.Drawing.Color.Yellow;
            lblPrice.Text = Convert.ToString(Convert.ToDouble(Session["price"]) + Price);
        }

        public void Book_Button(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conStr;

            conn.Open();

            Random r = new Random();
            int n = r.Next();

            int BID = n;
            int RID = 0;
            int HID = Convert.ToInt32(Session["HID"]);
            DateTime datein = DateTime.ParseExact((string)Session["DateIn"], "dd/MM/yyyy", null);
            DateTime dateout = DateTime.ParseExact((string)Session["Dateout"], "dd/MM/yyyy", null);
            string email = (string)Session["email"];
            double price = Convert.ToDouble(lblPrice.Text);

            string qry = "Select Room.Number" +
                "   from Room " +
                "   left join Booking " +
                "   on      Booking.HID = Room.Hid " +
                "     and   Booking.RID = Room.Number " +
                "     and   Booking.DateOut >= @SDate " +
                "     and   Booking.DateIn <= @EDate " +
                "   Where Booking.BID IS NULL " +
                "   AND Room.Hid = @HID" +
                "   And Room.RmType = @type" +
                "   Group By Room.Number";

            SqlCommand cmd = new SqlCommand(qry, conn);

            cmd.Parameters.Add("@HID", System.Data.SqlDbType.Int).Value = Convert.ToInt32(Session["HID"]);

            cmd.Parameters.Add("@SDate", System.Data.SqlDbType.DateTime).Value = datein;

            cmd.Parameters.Add("@EDate", System.Data.SqlDbType.DateTime).Value = dateout;

            cmd.Parameters.Add("@type", System.Data.SqlDbType.NVarChar).Value = lblRoomType.Text;

            SqlDataReader nw = cmd.ExecuteReader();

            if(nw.Read())
            {
                RID = (int)nw.GetValue(0);
            }
            cmd.Dispose();
            conn.Close();

            conn.Open();

            qry = "INSERT INTO Booking(BID, HID, RID, email, DateIn, DateOut, Price) VALUES(@BID, @HID, @RID, @email, @Din, @Dout, @price)";
            cmd = new SqlCommand(qry, conn);

            cmd.Parameters.Add("@HID", System.Data.SqlDbType.Int).Value = HID;
            cmd.Parameters.Add("@RID", System.Data.SqlDbType.Int).Value = RID;
            cmd.Parameters.Add("@BID", System.Data.SqlDbType.Int).Value = BID;
            cmd.Parameters.Add("@Din", System.Data.SqlDbType.DateTime).Value = datein;
            cmd.Parameters.Add("@Dout", System.Data.SqlDbType.DateTime).Value = dateout;
            cmd.Parameters.Add("@email", System.Data.SqlDbType.NVarChar).Value = email;
            cmd.Parameters.Add("@price", System.Data.SqlDbType.Float).Value = price;

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();

            string emailSubject = "This is to confirm your booking in the " + Session["hotelName"] + " from " + Session["DateIn"] + " to " + Session["Dateout"]
                + " for a fee of " + Convert.ToString(price) + " for a " + lblRoomType.Text + " room. Your reference number is: " + Convert.ToString(BID) +"."; 

            sendEmail(email,emailSubject,"Booking Confirmation");

            Response.Redirect("AccountPage.aspx");

        }

        public Panel generateCard(int cnt, string name, string count, string imgpath)
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
            img.ImageUrl = imgpath;

            HtmlGenericControl hd = new HtmlGenericControl("h5");
            hd.Attributes["class"] = "card-title";
            hd.InnerHtml = name;

            HtmlGenericControl crdtext = new HtmlGenericControl("p");
            crdtext.Attributes["class"] = "card-text";
            crdtext.InnerHtml = count;

            Button but = new Button();
            but.Text = "Choose Room";
            but.ID = Convert.ToString(cnt);
            but.Click += new System.EventHandler(this.dynamic_btn_Click);
            but.OnClientClick = "$find('mpe').show();";
            
            crdb.Controls.Add(hd);
            crdb.Controls.Add(crdtext);
            crdb.Controls.Add(but);

            card.Controls.Add(img);
            card.Controls.Add(crdb);

            outer.Controls.Add(card);
            return outer;
        }

        protected void sendEmail(string strEmail, string strMsg, string Subject)
        {

            MailMessage msg = new MailMessage("CSCE4502@gmail.com", strEmail);
            msg.Subject = Subject;
            msg.Body = strMsg;

            SmtpClient Sclient = new SmtpClient("smtp.gmail.com", 587);
            NetworkCredential auth = new NetworkCredential("CSCE4502@gmail.com", "csce4502f16");

            Sclient.UseDefaultCredentials = false;
            Sclient.Credentials = auth;
            Sclient.EnableSsl = true;
            Sclient.Send(msg);

        }

    }
}