using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;

namespace EFCustomMigrationOperations.CheckConstraints.CustomMigrationOperation
{
    public static class DbMigrationExtensions
    {
        public static void CreateCheckConstraint(this DbMigration migration, string table, string column, string checkConstraint)
        {
            var createCheckConstraint = new CreateCheckConstraintOperation
            {
                Table = table,
                Column = column,
                CheckConstraint = checkConstraint
            };

            ((IDbMigration)migration).AddOperation(createCheckConstraint);
        }

        public static void DropCheckConstraint(this DbMigration migration, string table, string checkConstraintName)
        {
            var dropCheckConstraint = new DropCheckConstraintOperation
            {
                Table = table,
                CheckConstraintName = checkConstraintName
            };

            ((IDbMigration)migration).AddOperation(dropCheckConstraint);
        }
    }
}
