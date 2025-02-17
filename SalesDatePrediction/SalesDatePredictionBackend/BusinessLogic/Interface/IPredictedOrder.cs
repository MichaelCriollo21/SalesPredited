using Entities.DTO;
using Entities.Entities.Sales.Sales;

namespace BusinessLogic.Interface
{
    public interface IPredictedOrder 
    {
        Task<List<PredictedOrder>> GetNextPredictedOrders();
    }
}
