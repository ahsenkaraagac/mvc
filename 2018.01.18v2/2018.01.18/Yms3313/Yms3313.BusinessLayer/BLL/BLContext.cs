using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yms3313.BusinessLayer.Repository;

namespace Yms3313.BusinessLayer.BLL
{
    public class BLContext
    {
        public BLContext()
        {
            Kategoriler = new KategoriRepository();
            Kullanicilar = new KullaniciRepository();
            Resimler = new ResimRepository();
            SiparisDurumlari = new SiparisDurumRepository();
            SiparisUrunleri = new SiparisItemRepository();
            Siparisler = new SiparisRepository();
            Urunler = new UrunRepository();
            Yetkiler = new YetkiRepository();
        }

        public KategoriRepository Kategoriler { get; set; }
        public KullaniciRepository Kullanicilar { get; set; }
        public ResimRepository Resimler { get; set; }
        public SiparisDurumRepository SiparisDurumlari { get; set; }
        public SiparisItemRepository SiparisUrunleri { get; set; }
        public SiparisRepository Siparisler { get; set; }
        public UrunRepository Urunler { get; set; }
        public YetkiRepository Yetkiler { get; set; }
    }
}
