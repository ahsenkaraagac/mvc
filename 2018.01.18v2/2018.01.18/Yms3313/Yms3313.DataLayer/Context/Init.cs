using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yms3313.DataLayer.Tools;

namespace Yms3313.DataLayer.Context
{
    //CreateDatabaseIfNotExists
    //class Init : DropCreateDatabaseAlways<ProjeContext> // her açılışta databaseı tekrar oluşturur
    class Init : CreateDatabaseIfNotExists<ProjeContext> // database yok ise oluştur ve doldur
    {
        protected override void Seed(ProjeContext context)
        {
            DatabaseVarsayilanDegerler db = new DatabaseVarsayilanDegerler(context);
        }
    }
}
