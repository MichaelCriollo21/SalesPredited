using System.Net;
using BusinessLogic.Interface;
using Entities.DTO;
using Entities.Entities.Sales;
using Entities.Entities.Sales.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.SalesPrediction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder IOrderBL;

        public OrderController(IOrder iOrderBL)
        {
            IOrderBL = iOrderBL;
        }

        [HttpPost]
        [Route("GetOrderByClient/{customerId}")]
        public async Task<IActionResult> GetOrderByClient(int customerId)
        {
            try
            {
                return Ok(IOrderBL.FindOrdersByCustomer(customerId));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] OrderRequest request)
        {
            try
            {
                var newOrder = IOrderBL.Create(request.Order, request.OrderDetail);
                return Ok(newOrder);
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
