using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Yms3313.WebUI.Areas.Admin.Models;
using Yms3313.WebUI.Tools;

namespace Yms3313.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class UrunlerController : Controller
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:44389/api/") };
        Data data;


        // GET: Admin/Urunler
        public ActionResult Index()
        {
            // Async metotlar geriye Task tipinde deger dondurur asenkron calisan metotlardir bu metotlar calismaya basladiginde islemin tamamlanmasini beklemeden kodlariniz calismaya devam eder eger dondurdugu dataya ihtiyaciniz varsa .Result diyerek sonucu bekleyebilirsiniz.

            //HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:44389/api/") };
            //client.DefaultRequestHeaders.Add("Auth", User.Identity.Name);
            //var response = client.GetAsync("Urunler").Result;

            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    var content = response.Content.ReadAsStringAsync().Result;
            //    var urunler = JsonConvert.DeserializeObject<List<Urun>>(content);
            //    return View(urunler);
            //}

            List<Urun> urunler = data.Get<List<Urun>>("Urunler");

            return View(urunler);
        }

        // GET: Admin/Urunler/Details/5
        public ActionResult Details(int id)
        {
            Urun urun = data.Get<Urun>("Urunler/" + id);
            return View(urun);
        }

        // GET: Admin/Urunler/Create
        public ActionResult Create()
        {
            var kategoriler = data.Get<List<Kategori>>("Kategoriler");
            ViewBag.Kategoriler = kategoriler;

            return View();
        }

        // POST: Admin/Urunler/Create
        [HttpPost]
        public ActionResult Create(Urun urun, HttpPostedFileBase resim)
        {
            try
            {
                if (resim != null)
                {
                    string resimAdi = Guid.NewGuid().ToString() + resim.FileName;
                    var yol = Server.MapPath("~/Content/resimler/" + resimAdi);
                    resim.SaveAs(yol);

                    urun.Resimler.Add(new Resim
                    {
                        Yol = resimAdi,
                        Aciklama = urun.UrunAdi
                    });
                }


                var result = data.Post<Urun>("Urunler", urun);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Urunler/Edit/5
        public ActionResult Edit(int id)
        {
            Urun urun = data.Get<Urun>("Urunler/" + id);
            ViewBag.Kategoriler = data.Get<List<Kategori>>("Kategoriler");

            return View(urun);
        }

        // POST: Admin/Urunler/Edit/5
        [HttpPost]
        public ActionResult Edit(Urun urun)
        {
            try
            {
                var result = data.Put<Urun>("Urunler", urun);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Urunler/Delete/5
        public ActionResult Delete(int id)
        {
            Urun urun = data.Get<Urun>("Urunler/" + id);

            return View(urun);
        }

        // POST: Admin/Urunler/Delete/5
        [HttpPost]
        public ActionResult Delete(Urun urun)
        {
            try
            {
                var response = data.Delete("Urunler/" + urun.ID);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ResimSil(  int ResimID,int UrunID)
        {
            var contentData = new { ResimID = ResimID, UrunID = UrunID };
            var response = data.Post<object>("Urunler/ResimSil?ResimID="+ResimID+"&UrunID="+UrunID, contentData);

            return RedirectToAction("Edit", new { id = UrunID });
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            client.DefaultRequestHeaders.Add("Auth", User.Identity.Name);
            data = new Data(User.Identity.Name);

        }
    }
}
