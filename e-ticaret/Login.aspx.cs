using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace E_Ticaret
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        public SqlConnection baglan()
        {
            try
            {
                SqlConnection con;//bağlantı oluşturuluyor.
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["Library"].ToString());
                return con;
            }
            catch (Exception)
            {
                
                throw;
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = baglan();
                SqlCommand cmd = new SqlCommand("select CustomerID from Customers where CustomerEmail = @cEmail and Password = @pwd", con);//email ve şifre değerlerine uygun kullanıcı varsa müşteri ID'si veritabanından çekiliyor.
                cmd.Parameters.AddWithValue("@cEmail", TextBox1.Text.ToString());
                cmd.Parameters.AddWithValue("@pwd", TextBox2.Text.ToString());

                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())// kullanıcı veritabanında varsa Session'a uyeID giriliyor ve sitede dinamik bir oturum açtırılıyor. Session ile Sayfalarda kontrol ediliyor.
                {
                    Session["uyeId"] = rd[0].ToString();
                }
                con.Close();
                //Button1.Text = "Giriş Başarılı";
                Response.Redirect("Default.aspx");//giriş başarılı olursa anasayfaya yönlendiriliyor.
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("YeniUye.aspx");
        }
    }
}