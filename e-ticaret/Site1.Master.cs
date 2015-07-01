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
    public partial class Site1 : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UyeId"] == null)
            {
                sepetGoster.Visible = false;
                girisCikis.Text = "Giriş";
            }
            else
                girisCikis.Text = "Çıkış";
        }

        protected void girisCikis_Click(object sender, EventArgs e)
        {
            if (girisCikis.Text.ToString() == "Giriş")
                Response.Redirect("Login.aspx");
            else
            {
                Session["uyeId"] = null;
                girisCikis.Text = "Giriş";
                Response.Redirect("Default.aspx");
            }
        }

        protected void sepetGoster_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sepet.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}