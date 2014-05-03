using System.ComponentModel.DataAnnotations;

namespace EFCustomMigrationOperations.CheckConstraints.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(16)]
        public string SKU { get; set; }

        public decimal Price { get; set; }
    }
}
