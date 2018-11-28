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
    public partial class roomEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["RPath"] = "~/Images/" + roomPath.FileName;
            roomPath.SaveAs(Server.MapPath("~/Images/") + roomPath.FileName);
        }

        protected void UpDateBtn_Click(object sender, EventArgs e)
        {
            string conStr = ConfigurationManager.ConnectionStrings["connectionString"].ToString();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = conStr;

            conn.Open();

            string update = "INSERT INTO Room (Number, RmType, Hid, Price, RmPath, RmDesc) VALUES (@numb, @rmtype, @id, @price,@path ,@desc)";

            SqlCommand cmd = new SqlCommand(update, conn);
            // (@numb, @rmtype, @id, @price,@path ,@desc)";

            cmd.Parameters.Add("@numb", System.Data.SqlDbType.Int).Value = Convert.ToInt16(rnumberBox.Text);
            cmd.Parameters.Add("@rmtype", System.Data.SqlDbType.NVarChar).Value = RmType.Text;
            cmd.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = Convert.ToInt64(Session["Hotel_ID"]);
            cmd.Parameters.Add("@price", System.Data.SqlDbType.Float).Value = Convert.ToDouble(priceBox.Text);
            cmd.Parameters.Add("@path", System.Data.SqlDbType.NVarChar).Value = Session["RPath"];
            cmd.Parameters.Add("@desc", System.Data.SqlDbType.NVarChar).Value = RDescBox.Text;

            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}