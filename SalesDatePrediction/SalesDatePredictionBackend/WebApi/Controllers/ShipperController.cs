﻿using BusinessLogic.Interface;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.SalesPrediction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipper IshipperBL;

        public ShipperController(IShipper ishipperBL)
        {
            IshipperBL = ishipperBL;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                return Ok(IshipperBL.FindAll());
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
