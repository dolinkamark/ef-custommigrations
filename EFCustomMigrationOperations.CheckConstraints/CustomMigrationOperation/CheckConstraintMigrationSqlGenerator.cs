using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;

namespace EFCustomMigrationOperations.CheckConstraints.CustomMigrationOperation
{
    public class CheckConstraintMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(MigrationOperation migrationOperation)
        {
            if (migrationOperation is CreateCheckConstraintOperation)
            {
                Generate(migrationOperation as CreateCheckConstraintOperation);
            }
            else if (migrationOperation is DropCheckConstraintOperation)
            {
                Generate(migrationOperation as DropCheckConstraintOperation);
            }
        }

        protected virtual void Generate(CreateCheckConstraintOperation migrationOperation)
        {
            if (migrationOperation.CheckConstraintName == null)
            {
                migrationOperation.CheckConstraintName = migrationOperation.BuildDefaultName();
            }

            using (var writer = Writer())
            {
                writer.WriteLine(
                    "ALTER TABLE {0} ADD CONSTRAINT {1} CHECK ({2})",
                    Name(migrationOperation.Table),
                    Quote(migrationOperation.CheckConstraintName),
                    migrationOperation.CheckConstraint
                );
                Statement(writer);
            }
        }

        protected virtual void Generate(DropCheckConstraintOperation migrationOperation)
        {
            using (var writer = Writer())
            {
                writer.WriteLine(
                    "IF EXISTS (SELECT name FROM sys.check_constraints WHERE name = N'{0}' " +
                    "AND parent_object_id = object_id(N'{1}', N'U'))",
                    migrationOperation.CheckConstraintName.Replace("'", "''"),
                    Name(migrationOperation.Table).Replace("'", "''")
                );

                writer.Write(
                    "ALTER TABLE {0} DROP CONSTRAINT {1}",
                    Name(migrationOperation.Table),
                    Quote(migrationOperation.CheckConstraintName)
                );

                Statement(writer);
            }
        }
    }
}
