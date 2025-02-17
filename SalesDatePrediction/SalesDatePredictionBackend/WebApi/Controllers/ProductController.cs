using BusinessLogic.Interface;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.SalesPrediction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct IProductBL;

        public ProductController(IProduct iProductBL)
        {
            IProductBL = iProductBL;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return Ok(IProductBL.FindAll());
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
