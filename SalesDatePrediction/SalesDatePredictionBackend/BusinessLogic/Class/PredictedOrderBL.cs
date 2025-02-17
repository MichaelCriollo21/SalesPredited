using System;
using BusinessLogic.Interface;
using Context.Class;
using Context.Context;
using Context.Interface;
using Entities.DTO;

public class PredictedOrderBL : IPredictedOrder, IDisposable
{
    private readonly SalesPredictionContext _context;

    public PredictedOrderBL(SalesPredictionContext context)
    {
        _context = context;
    }

    public async Task<List<PredictedOrder>> GetNextPredictedOrders()
    {
        try
        {
            List<PredictedOrder> predictions = await _context.GetOrderPredictions();
            return predictions;
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener las predicciones de órdenes", ex);
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    
}
