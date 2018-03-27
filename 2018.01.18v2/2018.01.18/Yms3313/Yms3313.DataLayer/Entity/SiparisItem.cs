using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yms3313.DataLayer.Entity
{
    public class SiparisItem : BaseEntity
    {

        public string UrunAdi { get; set; }
        public int Miktar { get; set; }
        public decimal Fiyat { get; set; }



        public int UrunID { get; set; }
        public virtual Urun Urun { get; set; }
        public int SiparisID { get; set; }
        public virtual Siparis Siparis { get; set; }

    }
}
