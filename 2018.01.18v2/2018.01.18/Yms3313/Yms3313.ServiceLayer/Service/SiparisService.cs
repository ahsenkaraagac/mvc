using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yms3313.BusinessLayer.BLL;
using Yms3313.DataLayer.Entity;
using Yms3313.ServiceLayer.Models;

namespace Yms3313.ServiceLayer.Service
{
    public class SiparisService
    {
        BLContext context = new BLContext();

        public List<SiparisVM> ToList()
        {
            return context.Siparisler.ToList().Select(x => new SiparisVM
            {
                ID = x.ID,
                Adres = x.Adres,
                SiparisDurum = x.SiparisDurum.Durum,
                SiparisNumarasi = x.SiparisNumarasi,
                SiparisTarihi = x.SiparisTarihi,
                SiparisUrunleri = x.SiparisUrunleri.Select(z => new SiparisUrunVM
                {
                    ID = z.ID,
                    Fiyat = z.Fiyat,
                    Miktar = z.Miktar,
                    UrunAdi = z.UrunAdi,
                    UrunID = z.UrunID
                }).ToList()
            }).ToList();
        }

        public SiparisVM GetByID(int ID)
        {
            Siparis siparis = context.Siparisler.Find(ID);
            if (siparis == null)
                return null;

            SiparisVM siparisVM = new SiparisVM
            {
                Adres = siparis.Adres,
                ID = siparis.ID,
                SiparisDurum = siparis.SiparisDurum.Durum,
                SiparisNumarasi = siparis.SiparisNumarasi,
                SiparisTarihi = siparis.SiparisTarihi,
                SiparisUrunleri = siparis.SiparisUrunleri.Select(ahsen => new SiparisUrunVM
                {
                    ID = ahsen.ID,
                    Fiyat = ahsen.Fiyat,
                    Miktar = ahsen.Miktar,
                    UrunAdi = ahsen.UrunAdi,
                    UrunID = ahsen.UrunID
                }).ToList()
            };

            return siparisVM;
        }

        public int Add(SiparisVM siparisVM)
        {
            Siparis item = new Siparis
            {
                Adres = siparisVM.Adres,
                KullaniciID = siparisVM.KullaniciID,
                SiparisDurumID = context.SiparisDurumlari.ToList().FirstOrDefault(x => x.Durum == "Hazirlaniyor").ID,
                SiparisNumarasi = siparisVM.SiparisNumarasi,
                SiparisTarihi = DateTime.Now,
                //SiparisUrunleri = siparis.SiparisUrunleri.Select(x => new SiparisItem
                //{
                //    Fiyat = x.Fiyat,
                //    Miktar = x.Miktar,
                //    UrunID = x.UrunID,
                //    UrunAdi = x.UrunAdi
                //}).ToList()
            };

            foreach (var siparisItem in siparisVM.SiparisUrunleri)
            {
                var urun = context.Urunler.Find(siparisItem.UrunID);
                item.SiparisUrunleri.Add(new SiparisItem
                {
                    Fiyat = urun.Fiyat,
                    UrunAdi = urun.UrunAdi,
                    UrunID = urun.ID,
                    Miktar = siparisItem.Miktar
                });
            }

            return context.Siparisler.Add(item);
        }

        public bool Iptal(int id)
        {
            Siparis siparis = context.Siparisler.Find(id);

            if (siparis.SiparisDurumID == context.SiparisDurumlari.ToList().FirstOrDefault(x => x.Durum == "Hazirlaniyor").ID) // siparis durumu hazirlaniyorsa 
            {
                siparis.SiparisDurumID = context.SiparisDurumlari.ToList().FirstOrDefault(x => x.Durum == "Iptal").ID;
                return context.Siparisler.Update(siparis);
            }
            return false;
        }

        public bool Update(SiparisVM siparisVM)
        {
            Siparis siparis = context.Siparisler.Find(siparisVM.ID);

            if (siparis.SiparisDurumID == context.SiparisDurumlari.ToList().FirstOrDefault(x => x.Durum == "Hazirlaniyor").ID)
            {
                siparis.Adres = siparisVM.Adres;
                siparis.SiparisUrunleri.RemoveRange(0, siparis.SiparisUrunleri.Count);

                foreach (var siparisItem in siparisVM.SiparisUrunleri)
                {
                    var urun = context.Urunler.Find(siparisItem.UrunID);
                    siparis.SiparisUrunleri.Add(new SiparisItem
                    {
                        ID = siparisItem.ID,
                        Fiyat = urun.Fiyat,
                        UrunAdi = urun.UrunAdi,
                        UrunID = urun.ID,
                        Miktar = siparisItem.Miktar
                    });
                }
                return context.Siparisler.Update(siparis);

            }

            return false;

        }

        public bool SiparisDurumKargoda(int siparisID)
        {
            Siparis siparis = context.Siparisler.Find(siparisID);
            siparis.SiparisDurumID = context.SiparisDurumlari.ToList().FirstOrDefault(x => x.Durum == "Kargoda").ID;
            return context.Siparisler.Update(siparis);
        }

        public bool SiparisDurumTeslimEdildi(int siparisID)
        {
            Siparis siparis = context.Siparisler.Find(siparisID);
            siparis.SiparisDurumID = context.SiparisDurumlari.ToList().FirstOrDefault(x => x.Durum == "Teslim Edildi").ID;
            return context.Siparisler.Update(siparis);
        }
    }
}
