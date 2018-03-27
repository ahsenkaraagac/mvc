using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yms3313.DataLayer.Entity
{
    public class Kullanici:BaseEntity
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Token { get; set; }
        public DateTime? TokenDate { get; set; }


        public int YetkiID { get; set; }
        public virtual Yetki Yetki { get; set; }
    }
}
