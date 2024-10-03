using CongestionTaxCalculator.Application.Models;
using Microsoft.AspNetCore.Components;

namespace ProjectManager.WebFramework.Api
{

    public class InternalApiController : BaseController
    {
    }


    [Route("api/v{version:apiVersion}/[controller]")]
    public class OpenApiController : BaseController
    {
    }   
}
