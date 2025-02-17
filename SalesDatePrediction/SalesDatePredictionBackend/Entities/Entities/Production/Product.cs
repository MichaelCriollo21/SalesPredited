using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities.Production
{
    [Table("Products", Schema = "Production")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(40)]
        public string ProductName { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public bool Discontinued { get; set; }
    }
}
