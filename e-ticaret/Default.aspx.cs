using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
namespace E_Ticaret
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public SqlConnection baglan()
        {
            try
            {
                SqlConnection conn;//bağlantı oluşturuyor.
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Library"].ToString());
                return conn;
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
                try
                {
                    SqlConnection con = baglan();
                    con.Open();
                    //Label1.Text = "Bağlantı Kuruldu";

                    SqlCommand cmd = new SqlCommand("SELECT P.ProductID,P.ProductName,C.CategoryName,P.ProductCost,P.ProductAdress FROM Products AS P " +
                                                    "INNER JOIN Categories AS C ON P.CategoryID=C.CategoryID ORDER BY ProductName", con);//ürünlerin bilgileri veritabanından alınıyor.

                    SqlDataReader rd = cmd.ExecuteReader();

                    DataList1.DataSource = rd;//bilgiler dataliste aktarılıyor.
                    DataList1.DataBind();
                    con.Close();        
                }
                catch(Exception)
                { throw; }
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    SqlConnection con = baglan();
                    con.Open();
                    /*-----------------DropDownList--------------------------Dropdownliste ürün kategorileri yazdırılıyor.*/
                    SqlCommand drp = new SqlCommand("SELECT C.CategoryName FROM Categories AS C ORDER BY CategoryName", con);//kategori adıyla listeleniyor.
                    SqlDataAdapter adptr = new SqlDataAdapter(drp);
                    DataTable tbl = new DataTable();
                    adptr.Fill(tbl);
                    Categories.DataSource = tbl;
                    Categories.DataValueField = "CategoryName";
                    Categories.DataBind();
                    Categories.Items.Add("Hepsi");
                    con.Close();
                }
                catch (Exception) { throw; }
                /*-------------------------------------------------------*/
            }
        }

        protected void Button2_Click(object sender, EventArgs e)//Filtreyi uygulama Butonu
        {
            try
            {
                SqlConnection con = baglan();
                con.Open();
                //Label1.Text = "Bağlantı Kuruldu";
                SqlCommand cmdAll = new SqlCommand("SELECT P.ProductID,P.ProductName,C.CategoryName,P.ProductCost,P.ProductAdress FROM Products AS P " +
                                                "INNER JOIN Categories AS C ON P.CategoryID=C.CategoryID ORDER BY ProductName", con);//hepsi seçilirse tüm ürünler listeleniyor
                SqlCommand cmdFilter = new SqlCommand("SELECT P.ProductID,P.ProductName,C.CategoryName,P.ProductCost,P.ProductAdress FROM Products AS P " +
                                                "INNER JOIN Categories AS C ON P.CategoryID=C.CategoryID WHERE C.CategoryName = @cName ORDER BY ProductName", con);//seçilen kategorideki ürünler listeleniyor.
                cmdFilter.Parameters.AddWithValue("@cName", Categories.SelectedItem.ToString());
                SqlDataReader rd;
                if (Categories.SelectedItem.ToString().Equals("Hepsi"))
                    rd = cmdAll.ExecuteReader();
                else
                    rd = cmdFilter.ExecuteReader();

                DataList1.DataSource = rd;//dataliste ekleniyor.
                DataList1.DataBind();
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            try
            {
                Response.Redirect("asd.aspx");
            }
            catch (Exception)
            {
                throw;
            }

            
        }
    }
}