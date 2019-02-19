using System.Threading.Tasks;
using AspNet.Security.OAuth.Introspection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Client.Controllers
{
    [Route("api")]
    [Authorize(AuthenticationSchemes = OAuthIntrospectionDefaults.AuthenticationScheme)]
    public class TestController : Controller
    {

        [HttpGet("message")]
        public async Task<IActionResult> GetMessage()
        {
            return Content($"has been successfully authenticated.");
        }
    }
}