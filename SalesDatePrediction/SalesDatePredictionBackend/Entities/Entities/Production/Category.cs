using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities.Production
{
    [Table("Categories", Schema = "Production")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(15)]
        public string CategoryName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
