using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yms3313.WebUI.Areas.Admin.Models
{
    public class Urun
    {
        public Urun()
        {
            Resimler = new List<Resim>();
        }

        public int ID { get; set; }
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public int Stok { get; set; }
        public decimal Fiyat { get; set; }

        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }

        public List<Resim> Resimler { get; set; }

        public Resim AnaResim
        {
            get
            {
                if (Resimler.Count == 0)
                {
                    return new Resim
                    {
                        Aciklama = "Yms3313",
                        Yol = "img/shop/products/1.jpg"
                    };
                }

                return Resimler[0];

            }
        }

        public object Seo
        {
            get
            {
                return new { id = this.ID, KategoriAdi = this.KategoriAdi, UrunAdi = this.UrunAdi };
            }
        }
    }
}