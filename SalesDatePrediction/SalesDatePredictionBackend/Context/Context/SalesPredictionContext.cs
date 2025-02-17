using Entities.DTO;
using Entities.Entities.HR;
using Entities.Entities.Production;
using Entities.Entities.Sales;
using Entities.Entities.Sales.Sales;
using Microsoft.EntityFrameworkCore;

namespace Context.Context
{
    public class SalesPredictionContext : DbContext
    {
        public SalesPredictionContext(DbContextOptions<SalesPredictionContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        // DTO
        public DbSet<PredictedOrder> PredictedOrders { get; set; }

        // Se usa para realizar la consulta de predicciones
        public async Task<List<PredictedOrder>> GetOrderPredictions()
        {
            return await this.Set<PredictedOrder>()
                .FromSqlRaw("EXEC GetNextPredictedOrders")
                .AsNoTracking()
                .ToListAsync();  
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PredictedOrder>().HasNoKey();
        }
    }
}
