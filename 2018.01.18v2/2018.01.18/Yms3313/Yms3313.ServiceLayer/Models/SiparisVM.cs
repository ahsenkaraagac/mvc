using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yms3313.ServiceLayer.Models
{
    public class SiparisVM
    {
        public int ID { get; set; }
        public string SiparisNumarasi { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public string Adres { get; set; }
        public string SiparisDurum { get; set; }


        public int KullaniciID { get; set; }
        public List<SiparisUrunVM> SiparisUrunleri { get; set; }


    }
}
