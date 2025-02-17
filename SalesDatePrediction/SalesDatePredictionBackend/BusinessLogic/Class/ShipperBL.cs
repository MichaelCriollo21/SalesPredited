using BusinessLogic.Interface;
using Context.Class;
using Context.Interface;
using Entities.Entities.Sales.Sales;

namespace BusinessLogic.Class
{
    public class ShipperBL : IShipper, IDisposable
    {
        private readonly IUnitOfWork UnitOfWork;
        private Repository<Shipper> ShipperRepository;

        public ShipperBL(IUnitOfWork UoW)
        {
            this.UnitOfWork = UoW;
            ShipperRepository = UnitOfWork.Repository<Shipper>();
        }

        public IEnumerable<Shipper> FindAll()
        {
            return ShipperRepository.FindAll();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
