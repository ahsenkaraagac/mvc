using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yms3313.WebUI.Areas.Admin.Models
{
    public class Kullanici
    {
        public int ID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public int YetkiID { get; set; }
    }
}