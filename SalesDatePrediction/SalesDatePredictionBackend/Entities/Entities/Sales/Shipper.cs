using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Sales.Sales
{
    [Table("Shippers", Schema = "Sales")]
    public class Shipper
    {
        [Key]
        public int ShipperId { get; set; }

        [Required]
        [MaxLength(40)]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(24)]
        public string Phone { get; set; }
    }
}
