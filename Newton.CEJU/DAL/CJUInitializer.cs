using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Newton.CJU.Models;

namespace Newton.CJU.DAL
{
    public class CJUInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CJUContext>
    {
        protected override void Seed(CJUContext context)
        {
            /*
            var areas = new List<AreaJuridica>
            {
                new AreaJuridica{ Area = "Cível" },
                new AreaJuridica{ Area = "Criminal" },
                new AreaJuridica{ Area = "Trabalhista" }
            };
            areas.ForEach(s => context.AreasJuridicas.Add(s));
            
            context.SaveChanges();*/
            
        }
    }
}