using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Yms3313.WebUI.Areas.Admin.Models;
using Newtonsoft.Json;
using System.Text;

namespace Yms3313.WebUI.Areas.Admin.Controllers
{
    [Authorize]
    public class KategorilerController : Controller
    {
        HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:44389/api/") };

        // GET: Admin/Kategıler
        public ActionResult Index()
        {
         


            var response = client.GetAsync("Kategoriler").Result;
            var content = response.Content.ReadAsStringAsync().Result;

            List<Kategori> kategoriler = JsonConvert.DeserializeObject<List<Kategori>>(content);

            return View(kategoriler);
        }

        // GET: Admin/Kategıler/Details/5
        public ActionResult Details(int id)
        {
            var response = client.GetAsync("Kategoriler/" + id).Result;
            var content = response.Content.ReadAsStringAsync().Result;

            Kategori kategori = JsonConvert.DeserializeObject<Kategori>(content);

            return View(kategori);
        }

        // GET: Admin/Kategıler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Kategıler/Create
        [HttpPost]
        public ActionResult Create(Kategori kategori)
        {
            try
            {
                // TODO: Add insert logic here
                string json = JsonConvert.SerializeObject(kategori);
                var postContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync("Kategoriler", postContent).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    // ekleme islemi basarili

                }
                else
                {
                    // ekleme islemi hatali
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Kategıler/Edit/5
        public ActionResult Edit(int id)
        {
            var response = client.GetAsync("Kategoriler/" + id).Result;
            var content = response.Content.ReadAsStringAsync().Result;

            Kategori kategori = JsonConvert.DeserializeObject<Kategori>(content);

            return View(kategori);
        }

        // POST: Admin/Kategıler/Edit/5
        [HttpPost]
        public ActionResult Edit(Kategori kategori)
        {
            try
            {
                // TODO: Add update logic here

                string json = JsonConvert.SerializeObject(kategori);
                var postContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PutAsync("Kategoriler", postContent).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    // ekleme islemi basarili

                }
                else
                {
                    // ekleme islemi hatali
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Kategıler/Delete/5
        public ActionResult Delete(int id)
        {
            var response = client.GetAsync("Kategoriler/" + id).Result;
            var content = response.Content.ReadAsStringAsync().Result;

            Kategori kategori = JsonConvert.DeserializeObject<Kategori>(content);

            return View(kategori);
        }

        // POST: Admin/Kategıler/Delete/5
        [HttpPost]
        public ActionResult Delete(Kategori kategori)
        {
            try
            {
                // TODO: Add delete logic here

                var response = client.DeleteAsync("Kategoriler/" + kategori.ID).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // silindi
                }
                else
                {
                    // silme islemi basarisiz
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // FormsAuthentication.SetAuthCookie(token, false); metoduna parametre olarak verdigimiz string datayi verir
            string token = User.Identity.Name;
            // web apiye yapilan taleplerde kullanici kontrolu icin header icine token parametresini koyuyoruz.
            client.DefaultRequestHeaders.Add("Auth", token);
        }


    }
}
