using System.Net;
using BusinessLogic.Interface;
using Context.Context;
using Entities.Entities.Sales.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.SalesPrediction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictedOrderController : ControllerBase
    {
        private readonly IPredictedOrder IOrderPredictionBL;

        public PredictedOrderController(IPredictedOrder orderPrediction)
        {
            IOrderPredictionBL = orderPrediction;
        }

        [HttpGet]
        [Route("PredictedOrders")]
        public async Task<IActionResult> PredictedOrders()
        {
            try
            {
                return Ok(await IOrderPredictionBL.GetNextPredictedOrders());
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
       
        private ObjectResult HandleException(Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
