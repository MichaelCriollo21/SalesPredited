using BusinessLogic.Interface;
using Context.Class;
using Context.Interface;
using Entities.Entities.Production;

namespace BusinessLogic.Class
{
    public class ProductBL : IProduct, IDisposable
    {
        private readonly IUnitOfWork UnitOfWork;
        private Repository<Product> ProductRepository;

        public ProductBL(IUnitOfWork UoW)
        {
            this.UnitOfWork = UoW;
            ProductRepository = UnitOfWork.Repository<Product>();
        }

        public IEnumerable<Product> FindAll()
        {
            return ProductRepository.FindAll();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
