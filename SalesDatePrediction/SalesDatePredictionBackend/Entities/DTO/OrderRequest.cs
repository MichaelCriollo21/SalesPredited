using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities.Sales.Sales;
using Entities.Entities.Sales;

namespace Entities.DTO
{
    public class OrderRequest
    {
        public Order Order { get; set; }
        public OrderDetail OrderDetail { get; set; }
    }
}
