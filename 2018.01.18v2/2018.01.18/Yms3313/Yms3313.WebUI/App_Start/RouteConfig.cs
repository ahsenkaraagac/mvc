using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Yms3313.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // area alani ekledi[iniz projelerde routerda belirttiginiz controllerlarin namesapaceslerini tanimlamaniz gerekir/

            // route tanimlamarinda {KategoriAdi}-{UrunAdi}-{id} seklinde yaptiginiz tanimlarda routeParametresine {}icinde yazan properti isimlerindeki degerleri koyar action parametresinde bu isimleri vererek almanizi saglar

            routes.MapRoute(
              name: "UrunDetay",
              url: "detay/{KategoriAdi}-{UrunAdi}-{id}",
              defaults: new
              {
                  controller = "Home",
                  action = "Detay",
                  id = UrlParameter.Optional,
              },
              namespaces: new string[] { "Yms3313.WebUI.Controllers" }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional,
                }, 
                namespaces: new string[] { "Yms3313.WebUI.Controllers" }
            );
        }
    }
}
