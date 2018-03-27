using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yms3313.BusinessLayer.BLL;
using Yms3313.ServiceLayer.Models;
using Yms3313.DataLayer.Entity;
using Yms3313.BusinessLayer.Repository;

namespace Yms3313.ServiceLayer.Service
{
    public class KategoriService
    {
        BLContext context = new BLContext();

        public List<KategoriVM> ToList()
        {
            return context.Kategoriler.ToList().Select(x => new KategoriVM
            {
                ID = x.ID,
                Aciklama = x.Aciklama,
                Adi = x.KategoriAdi
            }).ToList();
        }

        public KategoriVM GetByID(int ID)
        {
            var kategori = context.Kategoriler.Find(ID);

            KategoriVM kategoriVM = new KategoriVM
            {
                ID = kategori.ID,
                Adi = kategori.KategoriAdi,
                Aciklama = kategori.Aciklama
            };

            return kategoriVM;
        }

        public int Add(KategoriVM kategori)
        {
            Kategori item = new Kategori
            {
                KategoriAdi = kategori.Adi,
                Aciklama = kategori.Aciklama
            };

            return context.Kategoriler.Add(item);
        }

        public bool Update(KategoriVM kategori)
        {
            Kategori item = context.Kategoriler.Find(kategori.ID);

            if (item == null)
                return false;

            item.KategoriAdi = kategori.Adi;
            item.Aciklama = kategori.Aciklama;

            return context.Kategoriler.Update(item);
        }

        public bool Delete(int ID)
        {
            return context.Kategoriler.Delete(ID);
        }

    }
}
