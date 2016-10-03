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

        public DbSet<AreaConhecimento> AreasConhecimento { get; set; }
        public DbSet<AtividadeSemestral> AtividadesSemestrais { get; set; }
        public DbSet<FatoCotidiano> FatosCotidiano { get; set; }
        public DbSet<Historico> Historicos { get; set; }
        public DbSet<Situacao> Situacoes { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public static CJUContext Create()
        {
            return new CJUContext();
        }

        public System.Data.Entity.DbSet<Newton.CJU.Models.Solicitacao> Solicitacaos { get; set; }
    }
}