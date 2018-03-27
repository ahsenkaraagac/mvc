using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yms3313.DataLayer.Context;
using Yms3313.DataLayer.Entity;

namespace Yms3313.BusinessLayer.Repository
{
    public abstract class BaseRepository<Entity> : IRepository<Entity> where Entity : BaseEntity
        // Base repository icine sadece class verilebilmesi icin "where Entity:class" kosulunu ekledik
    {

        //ProjeContext db = new ProjeContext();
        static ProjeContext _db;
        ProjeContext db
        {
            get
            {
                if (_db == null)
                {
                    _db = new ProjeContext();
                }
                return _db;
            }
        }




        public virtual int Add(Entity entity)
        {
            try
            {

                // Set<Entity> entity ye verilen classin butun ozelliklerini kullanmamizi saglar

                entity.EklemeTarihi = DateTime.Now;
                entity.GuncellemeTarihi = DateTime.Now;
                entity.SilindiMi = false;


                db.Set<Entity>().Add(entity);
                db.SaveChanges();
                _db = new ProjeContext();
                return entity.ID;

            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public virtual bool Delete(int ID)
        {
            try
            {

                Entity entity = db.Set<Entity>().Find(ID);

                entity.GuncellemeTarihi = DateTime.Now;
                entity.SilindiMi = true;
                db.SaveChanges();
                _db = new ProjeContext();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public virtual Entity Find(int ID)
        {

            return db.Set<Entity>().FirstOrDefault(x => x.SilindiMi == false && x.ID == ID);

        }

        public virtual List<Entity> ToList()
        {

            return db.Set<Entity>().Where(x => x.SilindiMi == false).ToList();

        }

        public virtual bool Update(Entity entity)
        {
            try
            {

                entity.GuncellemeTarihi = DateTime.Now;
                db.Entry<Entity>(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                _db = new ProjeContext();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
