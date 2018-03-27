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
    public class ResimService
    {
        BLContext context = new BLContext();

        public List<ResimVM> ToList()
        {
            return context.Resimler.ToList().Select(x => new ResimVM
            {
                ID = x.ID,
                Aciklama = x.Aciklama,
                Yol = x.Yol
            }).ToList();
        }

        public ResimVM GetByID(int ID)
        {
            Resim resim = context.Resimler.Find(ID);

            ResimVM resimVM = new ResimVM
            {
                ID = resim.ID,
                Aciklama = resim.Aciklama,
                Yol = resim.Yol
            };

            return resimVM;
        }

        public int Add(ResimVM resimVM)
        {
            // object initializer
            Resim resim = new Resim
            {
                Aciklama = resimVM.Aciklama,
                Yol = resimVM.Yol
            };

            return context.Resimler.Add(resim);
        }

        public bool Update(ResimVM resimVM)
        {
            Resim resim = context.Resimler.Find(resimVM.ID);

            if (resim == null)
                return false;

            resim.Yol = resimVM.Yol;
            resim.Aciklama = resimVM.Aciklama;

            return context.Resimler.Update(resim);
        }

        public bool Delete(int ID)
        {
            return context.Resimler.Delete(ID);
        }

        public List<ResimVM> UrunResimleri(int urunID)
        {

            return context.Urunler.Find(urunID).Resimler.Where(x => x.SilindiMi == false).Select(x => new Models.ResimVM
            {
                ID = x.ID,
                Aciklama = x.Aciklama,
                Yol = x.Yol
            }).ToList();
        }



    }
}
