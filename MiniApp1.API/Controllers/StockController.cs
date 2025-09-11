using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MiniApp1.API.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {

        [Authorize(Roles = "admin", Policy = "AnkaraPolicy")]
        [HttpGet]
        public IActionResult GetStock()
        {
            var userName = HttpContext.User.Identity.Name;

            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            // verireli çek

            return Ok($"Stock işlemleri  =>UserName: {userName}- UserId:{userIdClaim.Value}");
        }
    }
}
