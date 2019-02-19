using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Client.Controllers
{
    [Route("api")]
    public class TestController : Controller
    {

        [Authorize, HttpGet("message")]
        public async Task<IActionResult> GetMessage()
        {
            return Content($"has been successfully authenticated.");
        }
    }
}