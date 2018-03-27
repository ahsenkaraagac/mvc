using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yms3313.ServiceLayer.Models
{
    public class SiparisUrunVM
    {
        public int ID { get; set; }
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public int Miktar { get; set; }
        public decimal Fiyat { get; set; }
    }
}
