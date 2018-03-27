using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yms3313.DataLayer.Entity
{
    public class Kategori : BaseEntity
    {
        public Kategori()
        {
            // list olarak tanimladigimiz propertilere veritabaninda deger gelmedi zaman null referans hatasi almamak icin yapici metot icinde instance alma islemi yapmamiz gerekir.
            Urunler = new List<Urun>();
        }

        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }


        // virtual Lazy loading ( tembel yukleme ) veri tabanindan ihtiyacimiz olmadiginda kategorinin urunlerini getirmeyerek performans kazanmamizi saglar
        public virtual List<Urun> Urunler { get; set; }
    }
}
