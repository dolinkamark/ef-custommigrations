using System;
using System.Data.Entity.Migrations.Model;

namespace EFCustomMigrationOperations.CheckConstraints.CustomMigrationOperation
{
    public class CreateCheckConstraintOperation : MigrationOperation
    {
        private string _table;
        private string _column;
        private string _checkConstraint;
        private string _checkConstraintName;

        public CreateCheckConstraintOperation()
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
                    throw new ArgumentException(
                        "Argument is null or contains only white spaces.",
                        "value");
                }

                _table = value;
            }
        }

        public string Column
        {
            get { return _column; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "Argument is null or contains only white spaces.", 
                        "value");
                }

                _column = value;
            }
        }

        public string CheckConstraint
        {
            get { return _checkConstraint; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "Argument is null or contains only white spaces.", 
                        "value");
                }

                _checkConstraint = value;
            }
        }

        public string CheckConstraintName
        {
            get { return _checkConstraintName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "Argument is null or contains only white spaces.", 
                        "value");
                }

                _checkConstraintName = value;
            }
        }

        public override bool IsDestructiveChange
        {
            get { return false; }
        }

        public string BuildDefaultName()
        {
            return string.Format("CK_{0}_{1}", Table, Column);
        }
    }
}
