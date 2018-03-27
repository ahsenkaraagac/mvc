using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yms3313.DataLayer.Entity
{
    public class Yetki : BaseEntity
    {
        public Yetki()
        {
            Kullanicilar = new List<Kullanici>();
        }
        public string Adi { get; set; }
        public virtual List<Kullanici> Kullanicilar { get; set; }
    }
}
