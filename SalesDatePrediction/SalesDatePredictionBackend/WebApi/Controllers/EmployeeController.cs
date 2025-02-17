using System.Net;
using BusinessLogic.Class;
using BusinessLogic.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.SalesPrediction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee IEmployeeBL;

        public EmployeeController(IEmployee iEmployeeBL)
        {
            IEmployeeBL = iEmployeeBL;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return Ok(IEmployeeBL.FindAll());
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
