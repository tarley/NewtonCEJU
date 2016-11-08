using System.Data.Entity;

namespace Newton.CJU.DAL
{
    public class CJUInitializer : DropCreateDatabaseIfModelChanges<CJUContext>
    {
        protected override void Seed(CJUContext context)
        {
        }
    }
}