using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yms3313.DataLayer.Entity;

namespace Yms3313.BusinessLayer.Repository
{
    interface IRepository<Entity>
    {
        List<Entity> ToList();
        Entity Find(int ID);
        int Add(Entity entity);
        bool Delete(int ID);
        bool Update(Entity entity);

    }
}
