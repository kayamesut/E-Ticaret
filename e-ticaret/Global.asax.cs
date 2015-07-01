using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;

namespace E_Ticaret
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup

        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            Response.Redirect("HataSayfasi.aspx");
            Exception ex = Server.GetLastError();//son oluşan hata 
            string HataOlusanSayfa = Request.CurrentExecutionFilePath;//hatanın olduğu sayfa
            StreamWriter str = new StreamWriter(Server.MapPath("Logs/errorLog.txt"), true);//errorlog dosyasına hatayı yazdırmak

            str.WriteLine("---- Hata Olusma Zamani------");
            str.WriteLine(DateTime.Now.ToString()); /* Hata oluşma tarihini kaydetmek için kullandık */
            str.WriteLine("---- Hata Mesaji ------------");
            str.WriteLine(ex.Message); /* Burada ise oluşan hatamızı yazıyoruz */
            str.WriteLine("---- Mesaj Icerigi ----------");
            str.WriteLine(ex.StackTrace); /* Ve son olarak burada ise hatamızın içeriği yazılıyor */
            str.Flush();/* Bu komut ise önbellekte tutulan yazılmış olan verilerin silinmesini sağlar */
            str.Close(); /*ve nesnesimiz kapatılıp yok edilir */

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
