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
            var situacoes = new List<Situacao>
            {
                new Situacao {Id = 1, Nome = "Criada" },
                new Situacao {Id = 1, Nome = "Em Analise" },
                new Situacao {Id = 1, Nome = "Respondida" }
            };

            context.Situacoes.AddRange(situacoes);
            context.SaveChanges();
            */
        }
    }
}