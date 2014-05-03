using System.Data.Entity;

namespace EFCustomMigrationOperations.CheckConstraints.Model
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("DefaultConnection")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
