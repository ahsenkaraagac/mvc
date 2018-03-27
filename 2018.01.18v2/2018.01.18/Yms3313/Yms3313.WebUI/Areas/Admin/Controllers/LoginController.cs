using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Yms3313.WebUI.Areas.Admin.Models;
using System.Web.Security;

namespace Yms3313.WebUI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]// Gelen taleplerin Login/index sayfasi uzeinden geldigini kontrol eder talebe izin vermesi icin fom icinde  @Html.AntiForgeryToken() tanimlamasi yapilmis olmali
        public ActionResult Index(Kullanici kullanici)
        {
            HttpClient client = new HttpClient();

            // Kullanici objesini string json formatina ceviriyoruz.
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(kullanici);

            // json datayi post edebilmek icin icindeki karakterleri ve datanin tipini ekleyerek StringContent olusturuyoruz
            var postContent = new StringContent(json, Encoding.UTF8, "application/json");

            // olusturdugumuz dontent dosyasini post metodu ile apimize gonderiyoruz
            var response = client.PostAsync("http://localhost:44389/api/Login", postContent).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                string token = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(content);

                // proje genelinde login isleminin yapildigini bildirmek icin asagidaki kodu yaziyoruz bu yontemi kullanabilmek icin web.config icerisinde formsaurhentication metodunu kullanicagimizi bildirmemiz gerekir.
                FormsAuthentication.SetAuthCookie(token, false);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        public ActionResult Cikis()
        {
            // kullanicinin login islemini bitirir.
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index");
        }

    }
}