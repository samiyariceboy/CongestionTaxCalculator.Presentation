﻿using CongestionTaxCalculator.Application.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CongestionTaxCalculator.Application.Models
{
    [ApiController]
    [ApiResultFilter]
    [Route("/v{version:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {
        public bool UserIsAutheticated => HttpContext.User.Identity.IsAuthenticated;
    }

    [ApiController]
    [ApiResultFilter]
    [Route("/v{version:apiVersion}/[controller]")]
    public class BaseMvcController : Controller
    {
        public bool UserIsAutheticated => HttpContext.User.Identity.IsAuthenticated;
    }
}
