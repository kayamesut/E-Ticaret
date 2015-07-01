using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;

namespace E_Ticaret
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        public SqlConnection baglan()
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
            if (!IsPostBack)
            {
                VeriGetir();//sayfa ilk açıldığında verigetir methodu çağırılıyor
            }

        }

        private void VeriGetir()
        {

            try
            {
                SqlConnection con = baglan();
                con.Close();
                con.Open();
                SqlCommand cmd = new SqlCommand("Select B.BoxID,P.ProductName,P.ProductCost,B.Count FROM Box B " +
                                                "inner join Products P ON P.ProductID = B.ProductID " +
                                                "Where B.CustomerID = @cid", con);//müşterinin sepetindeki ürünler getiriliyor.
                cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(Session["uyeId"]));
                SqlDataAdapter da = new SqlDataAdapter(cmd);//adapter e atılıyor
                DataTable dt = new DataTable("tbl");//datatable örneği oluşturuluyor
                da.Fill(dt);// veriler tablo ya dolduruluyor
                DataList1.DataSource = dt.DefaultView;//datalist e dolduruluyor
                DataList1.DataBind();
                con.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        protected void Button1_Click(object sender, EventArgs e)//SİLME İŞLEMİ
        {
            try
            {
                ArrayList dizi = new ArrayList();//bir arraylis dizi alınıyor

                foreach (DataListItem item in DataList1.Items)//datalistin kayıt sayı kadar bir döngü oluşturuluyor
                {
                    CheckBox c = (CheckBox)item.FindControl("c");//her satırdaki checkbox ın değeri bir checkbox örneği oluturulup atanıyor
                    if (c.Checked)//alınan checkbox seçili ise
                    {
                        Label lbl = (Label)item.FindControl("silinecekUrun");// o satırdaki Labeldeki id değeri aynı mantıkla alınıyor
                        dizi.Add(lbl.Text);//bu alınan değer diziye ekleniyor
                    }
                }

                for (int i = 0; i < dizi.Count; i++)//dizinin eleman sayısı kadar bir döngü oluşturuluyor
                {
                    KayitSil(dizi[i].ToString());//her id değeri kayıt sil methoduna parametre oalrak gönderiliyor
                }
                VeriGetir();//sayfadaki mailler yeniden listleniyor
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void KayitSil(string p)//gelen id değeri alınıyor
        {
            try
            {
                int id = Int32.Parse(p);//integer e dönüştülüyor
                SqlConnection con = baglan();
                con.Open();//bağlantı açılıyor
                SqlCommand cmd = new SqlCommand("delete FROM Box Where BoxID=" + id + " ", con);//veritabanından gelen id ye ayit kayıt siliniyor
                cmd.ExecuteNonQuery();//bitti ....
                con.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        private void SatinAl(string p)//gelen id değeri alınıyor
        {
            try
            {
                int id = Int32.Parse(p);//integer e dönüştülüyor
                string pid = "", cid = "", count = "";
                SqlConnection con = baglan();
                con.Open();//bağlantı açılıyor

                SqlCommand cmdUrunBilgiGetir = new SqlCommand("select B.ProductID,B.CustomerID,B.Count from Box AS B Where BoxID=" + id + " ", con);//Satın alınacak ürün bilgisi
                SqlDataReader rd = cmdUrunBilgiGetir.ExecuteReader();
                while (rd.Read())
                {
                    pid = rd[0].ToString();
                    cid = rd[1].ToString();
                    count = rd[2].ToString();
                }
                con.Close();

                SqlCommand cmdSatinAl = new SqlCommand("insert into Sales Values(@pid,@cid,@count,getdate())", con);//satılan ürün tablosuna ekleniyor
                cmdSatinAl.Parameters.AddWithValue("@pid", pid);
                cmdSatinAl.Parameters.AddWithValue("@cid", cid);
                cmdSatinAl.Parameters.AddWithValue("@count", count);

                SqlCommand cmd = new SqlCommand("delete FROM Box Where BoxID=" + id + " ", con);//satın alınan ürün sepetten siliniyor

                /*SqlCommand cmdStockUpdate = new SqlCommand("update Products set ProductCount = ProductCount - @stok where ProductID = @pid", con);//satın alınan ürün stok güncelleme işlemi
                cmdStockUpdate.Parameters.AddWithValue("@stok",Convert.ToInt32(count));
                cmdStockUpdate.Parameters.AddWithValue("@pid", pid);
                */
                con.Open();
                cmdSatinAl.ExecuteNonQuery();//satın alındı ....
                cmd.ExecuteNonQuery();//satın alınan silindi ...
                //cmdStockUpdate.ExecuteNonQuery();
                con.Close();
                bilgilendirme.Text = "Satın Alma İşlemi Başarılı";
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        protected void Button2_Click(object sender, EventArgs e)//anasayfa
        {
            Response.Redirect("Default.aspx");
        }
        protected void SatinAL_Click(object sender, EventArgs e)//SATIN ALMA İŞLEMİ
        {
            try
            {
                ArrayList dizi = new ArrayList();//bir arraylis dizi alınıyor

                foreach (DataListItem item in DataList1.Items)//datalistin kayıt sayı kadar bir döngü oluşturuluyor
                {
                    CheckBox c = (CheckBox)item.FindControl("c");//her satırdaki checkbox ın değeri bir checkbox örneği oluturulup atanıyor
                    if (c.Checked)//alınan checkbox seçili ise
                    {
                        Label lbl = (Label)item.FindControl("silinecekUrun");// o satırdaki Labeldeki id değeri aynı mantıkla alınıyor
                        dizi.Add(lbl.Text);//bu alınan değer diziye ekleniyor
                    }
                }

                for (int i = 0; i < dizi.Count; i++)//dizinin eleman sayısı kadar bir döngü oluşturuluyor
                {
                    SatinAl(dizi[i].ToString());//her id değeri kayıt sil methoduna parametre oalrak gönderiliyor
                }
                VeriGetir();//sayfadaki mailler yeniden listleniyor
            }
            catch(Exception)
            {

            }
        }
    }
}