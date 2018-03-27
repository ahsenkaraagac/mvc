using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yms3313.DataLayer.Entity
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            SilindiMi = false;
            EklemeTarihi = DateTime.Now;
            GuncellemeTarihi = DateTime.Now;
        }
        public int ID { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public bool SilindiMi { get; set; }
    }
}
