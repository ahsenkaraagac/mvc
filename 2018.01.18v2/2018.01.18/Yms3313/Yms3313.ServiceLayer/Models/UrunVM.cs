using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yms3313.ServiceLayer.Models
{
    public class UrunVM
    {
        public UrunVM()
        {
            Resimler = new List<ResimVM>();
        }

        public int ID { get; set; }
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public int Stok { get; set; }
        public decimal Fiyat { get; set; }

        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }

        public List<ResimVM> Resimler { get; set; }

    }
}
