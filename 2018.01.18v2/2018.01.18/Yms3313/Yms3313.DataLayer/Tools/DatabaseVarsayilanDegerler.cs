using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Yms3313.DataLayer.Context;

namespace Yms3313.DataLayer.Tools
{
    public class DatabaseVarsayilanDegerler
    {
        public DatabaseVarsayilanDegerler(ProjeContext context)
        {
            db = context;
            YetkiEkle();
            KullaniciEkle();
            SiparisDurumEkle();
            KategoriEkle();
        }

        ProjeContext db;

        public void KullaniciEkle()
        {
            if (db.Kullanicilar.FirstOrDefault() == null)
            {
                db.Kullanicilar.Add(new Entity.Kullanici
                {
                    Adi = "Can",
                    Soyadi = "KILIC",
                    Email = "can@can.com",
                    Sifre = MD5("123"),
                    YetkiID = 1,
                });
                db.SaveChanges();
            }

        }

        public void YetkiEkle()
        {
            if (db.Yetkiler.FirstOrDefault() == null)
            {
                db.Yetkiler.Add(new Entity.Yetki
                {
                    Adi = "Admin",
                });
                db.Yetkiler.Add(new Entity.Yetki
                {
                    Adi = "Personel",
                });
                db.Yetkiler.Add(new Entity.Yetki
                {
                    Adi = "Kullanici"
                });
                db.SaveChanges();
            }
        }

        public void SiparisDurumEkle()
        {
            if (db.SiparisDurumlari.FirstOrDefault() == null)
            {
                db.SiparisDurumlari.Add(new Entity.SiparisDurum
                {
                    Durum = "Hazirlaniyor"
                });
                db.SiparisDurumlari.Add(new Entity.SiparisDurum
                {
                    Durum = "Kargoda"
                });
                db.SiparisDurumlari.Add(new Entity.SiparisDurum
                {
                    Durum = "Teslim Edildi"
                });
                db.SiparisDurumlari.Add(new Entity.SiparisDurum
                {
                    Durum = "Iptal"
                });
                db.SaveChanges();
            }
        }

        public void KategoriEkle()
        {
            if (db.Kategoriler.FirstOrDefault() == null)
            {
                db.Kategoriler.Add(new Entity.Kategori
                {
                    Aciklama = "Telefon kategorisi",
                    KategoriAdi = "Telefon"
                });
                db.Kategoriler.Add(new Entity.Kategori
                {
                    Aciklama = "Bilgisayar kategorisi",
                    KategoriAdi = "Bilgisayar"
                });
                db.SaveChanges();
            }
        }


        public static string MD5(string metin)
        {
            // MD5CryptoServiceProvider nesnenin yeni bir instance'sını oluşturalım.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            //Girilen veriyi bir byte dizisine dönüştürelim ve hash hesaplamasını yapalım.
            byte[] btr = Encoding.UTF8.GetBytes(metin);
            btr = md5.ComputeHash(btr);

            //byte'ları biriktirmek için yeni bir StringBuilder ve string oluşturalım.
            StringBuilder sb = new StringBuilder();


            //hash yapılmış her bir byte'ı dizi içinden alalım ve her birini hexadecimal string olarak formatlayalım.
            foreach (byte ba in btr)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            //hexadecimal(onaltılık) stringi geri döndürelim.
            return sb.ToString();
        }
    }
}
