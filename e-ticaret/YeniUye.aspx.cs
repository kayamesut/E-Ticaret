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
    public partial class WebForm4 : System.Web.UI.Page
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

        protected void Button1_Click(object sender, EventArgs e)//Yeni üye ekle
        {
            try
            {
                SqlConnection con = baglan();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Customers Values (@ad,@soyad,@sifre,@mail,@gsm,@adres,getdate())", con);//Customer tablosuna üye ekleniyor

                cmd.Parameters.AddWithValue("@ad", TextBox1.Text.ToString());//parametreler yerine giriliyor.
                cmd.Parameters.AddWithValue("@soyad", TextBox2.Text.ToString());
                cmd.Parameters.AddWithValue("@sifre", TextBox4.Text.ToString());
                cmd.Parameters.AddWithValue("@mail", TextBox3.Text.ToString());//parametreler yerine giriliyor.
                cmd.Parameters.AddWithValue("@gsm", TextBox5.Text.ToString());
                cmd.Parameters.AddWithValue("@adres", TextBox6.Text.ToString());
                cmd.ExecuteNonQuery();
                Response.Redirect("Default.aspx");
                con.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}