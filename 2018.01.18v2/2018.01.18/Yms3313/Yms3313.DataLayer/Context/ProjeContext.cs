using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yms3313.DataLayer.Entity;

namespace Yms3313.DataLayer.Context
{
    public class ProjeContext : DbContext
    {
        public ProjeContext() : base("ProjeContext")
        {
            
        }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Resim> Resimler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisDurum> SiparisDurumlari { get; set; }
        public DbSet<SiparisItem> SiparisItemlari { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Yetki> Yetkiler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<ProjeContext>(new Init());
        }




    }
}
