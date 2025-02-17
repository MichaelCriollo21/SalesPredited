using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities.Production;
using Entities.Entities.Sales;
using Entities.Entities.Sales.Sales;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLogic.Interface
{
    public interface IOrder
    {
        Task<Order> Create(Order order, OrderDetail orderDetail);
        IEnumerable<Order> FindOrdersByCustomer(int customerId);
    }
}
