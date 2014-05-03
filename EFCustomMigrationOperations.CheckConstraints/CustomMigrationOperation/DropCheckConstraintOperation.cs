using System;
using System.Data.Entity.Migrations.Model;

namespace EFCustomMigrationOperations.CheckConstraints.CustomMigrationOperation
{
    public class DropCheckConstraintOperation : MigrationOperation
    {
        private string _table;
        private string _checkConstraintName;

        public DropCheckConstraintOperation()
            : base(null)
        {
        }

        public string Table
        {
            get { return _table; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Argument is null or contains only white spaces.", "value");
                }

                _table = value;
            }
        }
        
        public string CheckConstraintName
        {
            get { return _checkConstraintName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Argument is null or contains only white spaces.", "value");
                }

                _checkConstraintName = value;
            }
        }

        public override bool IsDestructiveChange
        {
            get { return false; }
        }
    }
}
