using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using Newton.CJU.Models;

namespace Newton.CJU.DAL
{
    public class CJUContext : IdentityDbContext<Usuario>
    {
        public CJUContext() : base("CJUContext", false)
        {
        }

        public DbSet<AreaConhecimento> AreasConhecimento { get; set; }
        public DbSet<AtividadeSemestral> AtividadesSemestrais { get; set; }
        public DbSet<FatoCotidiano> FatosCotidiano { get; set; }
        public DbSet<Historico> Historicos { get; set; }
        public DbSet<Situacao> Situacoes { get; set; }

        public DbSet<Solicitacao> Solicitacaos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public static CJUContext Create()
        {
            return new CJUContext();
        }
    }
}