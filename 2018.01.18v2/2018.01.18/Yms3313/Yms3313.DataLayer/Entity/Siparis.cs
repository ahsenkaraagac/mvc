using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yms3313.DataLayer.Entity
{
    public class Siparis : BaseEntity
    {
        public Siparis()
        {
            SiparisUrunleri = new List<SiparisItem>();
        }
        public string SiparisNumarasi { get; set; }
        public DateTime SiparisTarihi { get; set; }


        public string Adres { get; set; }

        public int SiparisDurumID { get; set; }
        public virtual SiparisDurum SiparisDurum { get; set; }

        public int KullaniciID { get; set; }
        public virtual Kullanici Kullanici { get; set; }

        public virtual List<SiparisItem> SiparisUrunleri { get; set; }
    }
}
