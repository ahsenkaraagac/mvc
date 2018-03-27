using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yms3313.DataLayer.Entity
{
    public class Urun : BaseEntity
    {
        public Urun()
        {
            Resimler = new List<Resim>();
        }
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public int Stok { get; set; }
        public decimal Fiyat { get; set; }
        public virtual List<Resim> Resimler { get; set; }

        public int KategoriID { get; set; }

        //[ForeignKey("KategoriID")]
        public virtual Kategori Kategori { get; set; }
    }
}
