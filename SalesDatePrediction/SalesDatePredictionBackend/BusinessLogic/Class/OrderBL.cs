using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface;
using Context.Class;
using Context.Interface;
using Entities.Entities.Sales;
using Entities.Entities.Sales.Sales;
using Microsoft.EntityFrameworkCore.Storage;

namespace BusinessLogic.Class
{
    public class OrderBL : IOrder, IDisposable
    {
        private readonly IUnitOfWork UnitOfWork;
        private Repository<Order> OrderRepository;

        public OrderBL(IUnitOfWork UoW)
        {
            this.UnitOfWork = UoW;
            OrderRepository = UnitOfWork.Repository<Order>();
        }

        public IEnumerable<Order> FindOrdersByCustomer(int customerId)
        {
            return OrderRepository.Find(o => o.CustId == customerId)
                    .Select(o => new Order
                    {
                        OrderId = o.OrderId,
                        RequiredDate = o.RequiredDate,
                        ShippedDate = o.ShippedDate,
                        ShipName = o.ShipName,
                        ShipAddress = o.ShipAddress,
                        ShipCity = o.ShipCity
                    }).ToList();
        }

        public async Task<Order> Create(Order order, OrderDetail orderDetail)
        {
            using (IDbContextTransaction transaction = UnitOfWork.GetContext().Database.BeginTransaction())
            {
                try
                {
                    // Guardar la orden
                    OrderRepository.Create(order);
                    UnitOfWork.SaveChanges();
                    orderDetail.OrderId = order.OrderId;

                    // Guardar el detalle de la orden
                    var orderDetailRepo = UnitOfWork.Repository<OrderDetail>();
                    orderDetailRepo.Create(orderDetail);
                    UnitOfWork.SaveChanges();
                    transaction.Commit();
                    return order;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}