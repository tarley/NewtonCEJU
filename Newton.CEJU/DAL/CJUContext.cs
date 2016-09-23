using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Newton.CJU.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Newton.CJU.DAL
{
    public class CJUContext : IdentityDbContext<Usuario>
    {
        public CJUContext() : base("CJUContext", throwIfV1Schema: false) 
        { 
        }

        public DbSet<AreaJuridica> AreasJuridicas { get; set; }
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<Assunto> Assuntos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static CJUContext Create()
        {
            return new CJUContext();
        }
    }
}