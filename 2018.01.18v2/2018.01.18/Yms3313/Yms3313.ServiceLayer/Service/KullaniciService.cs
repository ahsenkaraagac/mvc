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
    public class KullaniciService
    {
        BLContext context = new BLContext();
        public List<KullaniciVM> ToList()
        {
            return context.Kullanicilar.ToList().Select(x =>
            new KullaniciVM
            {
                ID = x.ID,
                Adi = x.Adi,
                Email = x.Email,
                Soyadi = x.Soyadi,
                YetkiID = x.YetkiID
            }).ToList();
        }

        public KullaniciVM GetByID(int ID)
        {
            var kullanici = context.Kullanicilar.Find(ID);

            return new KullaniciVM
            {
                ID = kullanici.ID,
                Adi = kullanici.Adi,
                Email = kullanici.Email,
                Soyadi = kullanici.Soyadi,
                YetkiID = kullanici.YetkiID
            };
        }

        public int Add(KullaniciVM kullanici)
        {



            Kullanici item = new Kullanici
            {
                Adi = kullanici.Adi,
                Soyadi = kullanici.Soyadi,
                Email = kullanici.Email,
                Sifre = Tools.Sifrele.MD5(kullanici.Sifre),
                YetkiID = 1

            };

            return context.Kullanicilar.Add(item);
        }

        public bool Update(KullaniciVM kullanici)
        {
            Kullanici item = context.Kullanicilar.Find(kullanici.ID);

            if (item == null)
                return false;

            item.Adi = kullanici.Adi;
            item.Soyadi = kullanici.Soyadi;
            item.Email = kullanici.Email;
            item.YetkiID = kullanici.YetkiID;

            return context.Kullanicilar.Update(item);
        }

        public bool Delete(int ID)
        {
            return context.Kullanicilar.Delete(ID);
        }

        public bool SifreDegistir(KullaniciSifreDegistirVM kullaniciSifreDegistirVM)
        {
            Kullanici kullanici = context.Kullanicilar.Find(kullaniciSifreDegistirVM.KullaniciID);

            // kullanici yoksa metotdan cik
            if (kullanici == null)
                return false;

            // eski sifre ayni degilse metotdan cik
            if (kullanici.Sifre != Tools.Sifrele.MD5(kullaniciSifreDegistirVM.EskiSifre))
                return false;

            // kullanicinin sifresini degistir
            kullanici.Sifre = Tools.Sifrele.MD5(kullaniciSifreDegistirVM.Sifre);
            return context.Kullanicilar.Update(kullanici);
        }

        public string Giris(KullaniciGirisVM kullaniciGirisVM)
        {
            Kullanici kullanici = context.Kullanicilar.ToList().FirstOrDefault(x => x.Email == kullaniciGirisVM.Email && x.Sifre == Tools.Sifrele.MD5(kullaniciGirisVM.Sifre));

            if (kullanici == null)
                return null;

            kullanici.Token = Guid.NewGuid().ToString();
            kullanici.TokenDate = DateTime.Now.AddHours(1);

            context.Kullanicilar.Update(kullanici);
            return kullanici.Token;
        }

        public KullaniciVM TokenKontrol(string token)
        {
            Kullanici kullanici = context.Kullanicilar.ToList().FirstOrDefault(x => x.Token == token);

            //if (kullanici == null)
            //    return null;

            if (kullanici == null ||  kullanici.TokenDate < DateTime.Now)
                return null;

            return GetByID(kullanici.ID);
        }

    }
}
