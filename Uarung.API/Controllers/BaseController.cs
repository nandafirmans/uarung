using System;
using Microsoft.AspNetCore.Mvc;

namespace Uarung.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        protected static string GenerateId()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}