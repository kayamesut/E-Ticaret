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
    public partial class WebForm2 : System.Web.UI.Page
    {
        public SqlConnection baglan()//bağlantı oluşturma
        {
            try
            {
                SqlConnection con;
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
            if (!IsPostBack)//yeniden yüklemeyi engelleme
            {
                try
                {
                    SqlConnection con = baglan();
                    int productCount = 0;

                    SqlCommand cmd = new SqlCommand("SELECT P.ProductName,P.ProductCost,C.CategoryName,P.ProductDetails,P.ProductAdress,P.ProductCount FROM Products AS P " +
                                                    "INNER JOIN Categories AS C ON P.CategoryID=C.CategoryID WHERE ProductID = @pid", con);//ürünle ilgili bilgiler alınıyor


                    cmd.Parameters.AddWithValue("@pid", Convert.ToInt32(Request.QueryString["uid"]));//parametre değerleri giriliyor Session da kullanıcı ID'si var
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())//ürün bilgileri yazdırılıyor
                    {
                        Label5.Text = rd[0].ToString();
                        Label6.Text = rd[1].ToString() + " TL";
                        Label7.Text = rd[2].ToString();
                        Label8.Text = rd[3].ToString();
                        
                        UrunResim.ImageUrl = rd[4].ToString();
                        productCount = Convert.ToInt32(rd[5].ToString());
                    }
                    for (int i = 1; i < productCount + 1; i++)//Ürün Stok miktarı dropdownliste ekleniyor.
                        DropDownListProductCount.Items.Add(i.ToString());

                    con.Close();
                    
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void SepeteEkle_Click(object sender, EventArgs e)
        {
            int found = 0;//aynı üründen sepette var mı diye kontrol ediliyor
            if (Session["UyeId"] != null)//üye oturum açtıysa devam ediliyor, oturum açılmadıysa login sayfasına yönlendiriliyor.
            {

                try
                {
                    SqlConnection con = baglan();

                    SqlCommand cmdControl = new SqlCommand("select CustomerID from Box where CustomerID = @cid and ProductID = @pid", con);//Aynı üründen sepette var mı ?

                    cmdControl.Parameters.AddWithValue("@cid", Convert.ToInt32(Session["UyeId"]));//parametre değerleri giriliyor
                    cmdControl.Parameters.AddWithValue("@pid", Convert.ToInt32(Request.QueryString["uid"]));

                    con.Open();

                    SqlDataReader rdContol = cmdControl.ExecuteReader();

                    while (rdContol.Read())//aynı üründen varsa found=1 olacak
                    {
                        found = 1;
                    }
                    if (found == 1)//Sepette varsa uyarı verilsin
                    {
                        sepetteVar.Text = "Ürün sepetinizde mevcut !!!";
                        found = 0;//Eski haline geri dön
                    }
                    else//üründen sepette yoksa sepete eklensin
                    {
                        con.Close();
                        con.Open();
                        string miktar = DropDownListProductCount.SelectedValue.ToString();
                        SqlCommand cmd = new SqlCommand("insert into Box Values (@cid,@pid,@count)", con);//Sepete Ekleme İşlemi

                        cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(Session["UyeId"]));//parametreler yerine giriliyor.
                        cmd.Parameters.AddWithValue("@pid", Convert.ToInt32(Request.QueryString["uid"]));
                        cmd.Parameters.AddWithValue("@count", miktar);
                        cmd.ExecuteNonQuery();
                        sepetteVar.Text = "Ürün Sepetinize Eklendi...";//sepete eklenince bilgilendirme mesajı verildi
                        con.Close();
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
                
            }

            else
            {

                Response.Redirect("Login.aspx");

            }
        }
    }
}