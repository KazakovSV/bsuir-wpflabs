using System.Data.Entity;

using Lab08.Model;

namespace Lab08.DAL
{
    /// <summary>
    ///     Контекст приложения
    /// </summary>
    public class PharmacyContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public PharmacyContext()
            : base()
        {
            Database.SetInitializer(new PharmacyDbInitializer());
        }
    }
}
