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
    public class UrunService
    {
        BLContext context = new BLContext();
        ResimService resimService = new ResimService();

        public List<UrunVM> ToList()
        {

            return context.Urunler.ToList().Select(x => new Models.UrunVM
            {
                ID = x.ID,
                Aciklama = x.Aciklama,
                Fiyat = x.Fiyat,
                KategoriAdi = x.Kategori.KategoriAdi,
                KategoriID = x.KategoriID,
                Stok = x.Stok,
                UrunAdi = x.UrunAdi,
                Resimler = resimService.UrunResimleri(x.ID)
            }).ToList();


        }

        public UrunVM GetByID(int ID)
        {
            Urun urun = context.Urunler.Find(ID);

            if (urun == null)
                return null;

            UrunVM urunVM = new UrunVM
            {
                ID = urun.ID,
                Aciklama = urun.Aciklama,
                Fiyat = urun.Fiyat,
                KategoriAdi = urun.Kategori.KategoriAdi,
                KategoriID = urun.KategoriID,
                Stok = urun.Stok,
                UrunAdi = urun.UrunAdi,
                Resimler = resimService.UrunResimleri(urun.ID)
            };

            return urunVM;
        }

        public int Add(UrunVM urunVM)
        {
            Urun urun = new Urun
            {
                Aciklama = urunVM.Aciklama,
                Fiyat = urunVM.Fiyat,
                KategoriID = urunVM.KategoriID,
                Stok = urunVM.Stok,
                UrunAdi = urunVM.UrunAdi
            };

            //if (urunVM.Resimler.Count > 0)
            //{

            // foreach dongusu urunVM.Resimler de resim var ise calisir
            foreach (var item in urunVM.Resimler)
            {
                urun.Resimler.Add(new Resim
                {
                    Yol = item.Yol,
                    Aciklama = item.Aciklama
                });
            }
            //}

            return context.Urunler.Add(urun);

        }

        public bool Update(UrunVM urunVM)
        {
            Urun urun = context.Urunler.Find(urunVM.ID);

            if (urun == null)
                return false;

            urun.Aciklama = urunVM.Aciklama;
            urun.Fiyat = urunVM.Fiyat;
            urun.KategoriID = urunVM.KategoriID;
            urun.Stok = urunVM.Stok;
            urun.UrunAdi = urunVM.UrunAdi;

            return context.Urunler.Update(urun);
        }

        public bool Delete(int ID)
        {
            return context.Urunler.Delete(ID);
        }


        public bool UrunResimSil(int urunID, int resimID)
        {
            Urun urun = context.Urunler.Find(urunID);

            Resim resim = urun.Resimler.FirstOrDefault(x => x.ID == resimID);

            if (resim == null)
                return false;

            return context.Resimler.Delete(resimID);
        }


        public int UrunResimEkle(int urunID, ResimVM resimVM)
        {
            Urun urun = context.Urunler.Find(urunID);

            if (urun == null)
                return -1;

            Resim resim = new Resim
            {
                Aciklama = resimVM.Aciklama,
                Yol = resimVM.Yol
            };

            urun.Resimler.Add(resim);
            context.Urunler.Update(urun);

            return resim.ID;
        }


    }
}
