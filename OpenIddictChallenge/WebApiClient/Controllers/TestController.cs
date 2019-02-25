using System.Threading.Tasks;
using AspNet.Security.OAuth.Introspection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Validation;

namespace Mvc.Client.Controllers
{
    [Route("api")]
    [Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
    public class TestController : Controller
    {

        [HttpGet("message"), Authorize]
        public async Task<IActionResult> GetMessage()
        {
            return Content($"has been successfully authenticated.");
        }
    }
}