using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Sales
{
    [Table("OrderDetails", Schema = "Sales")]
    public class OrderDetail
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("productid")]
        public int ProductId { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public short Qty { get; set; }

        [Required]
        public decimal Discount { get; set; }
    }
}
