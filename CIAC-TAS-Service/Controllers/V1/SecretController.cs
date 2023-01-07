using CIAC_TAS_Service.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CIAC_TAS_Service.Controllers.V1
{
    [ApiKeyAuth]
    public class SecretController : Controller
    {
        [HttpGet("secret")]
        public IActionResult GetSecret()
        {
            return Ok("Secret Endpoint");
        }
    }
}
