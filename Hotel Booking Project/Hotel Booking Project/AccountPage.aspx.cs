using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace Hotel_Booking_Project
{
    public partial class AccountPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conStr;

                string strSelect = "SELECT Fname, Lname, Phone FROM Member "
                    + " WHERE email = '" + Session["email"] + "'";

                SqlCommand cmdSelect = new SqlCommand(strSelect, conn);

                SqlDataReader reader;

                conn.Open();
                reader = cmdSelect.ExecuteReader();

                if (reader.Read())
                {
                    FnameBox.Text = (string)reader.GetValue(0);
                    Lnamebox.Text = (string)reader.GetValue(1);
                    numberBox.Text = (string)reader.GetValue(2);
                }
                conn.Close();
            }
        }

        protected void Cancel_Button(object sender, EventArgs e)
        {
            if(GridView1.SelectedIndex != -1 && GridView1.Rows.Count > 0)
            {
                string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conStr;

                string refno = Convert.ToString(GridView1.SelectedRow.Cells[1].Text);
                string Hname = Convert.ToString(GridView1.SelectedRow.Cells[2].Text);
                string Din = Convert.ToString(GridView1.SelectedRow.Cells[3].Text);
                string Dout = Convert.ToString(GridView1.SelectedRow.Cells[4].Text);

                conn.Open();

                string qry = "DELETE FROM Booking " + " WHERE BID = " + refno;

                SqlCommand cmd = new SqlCommand(qry, conn);

                cmd.ExecuteNonQuery();

                string emailSubject = "This is to confirm that you have cancelled your booking with reference no " + refno + " in " + Hname +" from " + Din + " to " + Dout ;

                sendEmail((string)Session["email"], emailSubject, "Booking Cancellation");

                GridView1.EditIndex = -1;
                GridView1.DataBind();
                cancelLbl.Text = "Booking Canceled";
            }
        }

        protected void Update_Button(object sender, EventArgs e)
        {
                string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conStr;

                conn.Open();

                string qry = "Update Member "
                    + " SET Fname = '" + FnameBox.Text + "', "
                    + " Lname = '" + Lnamebox.Text + "', "
                    + " Phone = '" + numberBox.Text + "' "
                    + " WHERE email = '" + Session["email"]+ "' ";

                SqlCommand cmd = new SqlCommand(qry, conn);

                cmd.ExecuteNonQuery();
            lblUpdate.Text = "Updated your Info";
            
        }

        protected void UodatePass_Button(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conStr;

            conn.Open();

            string qry = "Select * From Member"
                + " WHERE Pass = '" + passwordBox.Text + "' " +
                "AND email = '" + Session["email"] + "' ";

            SqlCommand cmd = new SqlCommand(qry, conn);

            SqlDataReader nw = cmd.ExecuteReader();

            if (nw.Read())
            {
                cmd.Dispose();
                qry = "Update Member "
                    + " SET Pass = '" + passwordConfirmBox.Text + "'"
                    + " WHERE email = '" + Session["email"] + "'";

                SqlCommand cmd2 = new SqlCommand(qry, conn);

                cmd2.ExecuteNonQuery();
                lblPass.Text = "Updated your Password";

            }
            else
            {
                lblPass.Text = "Wrong Password";

            }

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

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if (GridView2.SelectedIndex != -1 && GridView2.Rows.Count > 0)
            {

                string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = conStr;

                conn.Open();

                string selectCMD = "Select * From HotelRating Where Hid = @hid";
                SqlCommand cmd = new SqlCommand(selectCMD, conn);

                cmd.Parameters.Add("@hid", System.Data.SqlDbType.Int).Value = Convert.ToInt32(GridView2.SelectedRow.Cells[3].Text);

                SqlDataReader nw = cmd.ExecuteReader();

                double com = 0, val = 0, stf = 0, fac = 0, loc = 0, cln = 0;
                bool flag = false;
                if(nw.Read())
                {
                    com = Convert.ToDouble(nw.GetValue(1));
                    val = Convert.ToDouble(nw.GetValue(2));
                    stf = Convert.ToDouble(nw.GetValue(3));
                    fac = Convert.ToDouble(nw.GetValue(4));
                    loc = Convert.ToDouble(nw.GetValue(5));
                    cln = Convert.ToDouble(nw.GetValue(6));
                    flag = true;
                }
                nw.Close();
                cmd.Dispose();
                conn.Close();

                conn.Open();

                com = (com + ComfortRatings.CurrentRating) / 2;
                val = (val + ValRatings.CurrentRating) / 2;
                stf = (stf + staffRatings.CurrentRating) / 2;
                fac = (fac + facRatings.CurrentRating) / 2;
                loc = (loc + locRatings.CurrentRating) / 2;
                cln = (cln + cleanRatings.CurrentRating) / 2;
                string update = "";
                if (flag)
                {
                    update = "Update HotelRating Set Comfort = @comfort, Value = @value , Staff = @staff, Facilties = @fac, Location = @loc, Cleanliness = @clean Where Hid = @Hid" ;
                }
                else
                {
                   update = "INSERT INTO HotelRating (Hid, Comfort, Value, Staff, Facilties, Location, Cleanliness) VALUES (@Hid, @comfort, @value, @staff,@fac ,@loc, @clean)";
                }
                cmd = new SqlCommand(update, conn);
                // @Hid, @comfort, @value, @staff,@fac ,@loc, @clean)";

                cmd.Parameters.Add("@Hid", System.Data.SqlDbType.Int).Value = Convert.ToInt32(GridView2.SelectedRow.Cells[3].Text);
                cmd.Parameters.Add("@comfort", System.Data.SqlDbType.Float).Value = com;
                cmd.Parameters.Add("@value", System.Data.SqlDbType.Float).Value = val;
                cmd.Parameters.Add("@staff", System.Data.SqlDbType.Float).Value = stf;
                cmd.Parameters.Add("@fac", System.Data.SqlDbType.Float).Value = fac;
                cmd.Parameters.Add("@loc", System.Data.SqlDbType.Float).Value = loc;
                cmd.Parameters.Add("@clean", System.Data.SqlDbType.Float).Value = cln;

                cmd.ExecuteNonQuery();
                conn.Close();

                cmd.Dispose();

                update = "Insert into Reviews (Hid, Review, Rid) VALUES (@Hid, @Rev, @RID)";

                conn.Open();
                cmd = new SqlCommand(update, conn);
                
                Random r= new Random();
                int rand = r.Next(1000, 1000000);
                cmd.Parameters.Add("@Hid", System.Data.SqlDbType.Int).Value = Convert.ToInt32(GridView2.SelectedRow.Cells[3].Text);
                cmd.Parameters.Add("@Rev", System.Data.SqlDbType.NVarChar).Value = ReviewBox.Text;
                cmd.Parameters.Add("@RID", System.Data.SqlDbType.Int).Value = rand;

                cmd.ExecuteNonQuery();
                conn.Close();

                cleanRatings.CurrentRating = 0;
                ComfortRatings.CurrentRating = 0;
                facRatings.CurrentRating = 0;
                locRatings.CurrentRating = 0;
                staffRatings.CurrentRating = 0;
                ValRatings.CurrentRating = 0;
            }
        }
    }
}