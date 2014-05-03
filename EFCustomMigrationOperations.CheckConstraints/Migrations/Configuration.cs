using EFCustomMigrationOperations.CheckConstraints.CustomMigrationOperation;
using EFCustomMigrationOperations.CheckConstraints.Model;

namespace EFCustomMigrationOperations.CheckConstraints.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator(
                "System.Data.SqlClient", 
                new CheckConstraintMigrationSqlGenerator()
            );
        }

        protected override void Seed(ProductContext context)
        {
            context.Products.AddOrUpdate(
                p => p.Id,
                new Product { Id = 1, SKU = "DA-12", Price = 120.0M },
                new Product { Id = 2, SKU = "JB-02", Price = 80.0M },
                new Product { Id = 3, SKU = "FA-12", Price = 136.0M }
            );
        }
    }
}
