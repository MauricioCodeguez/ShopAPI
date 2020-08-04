using Microsoft.AspNetCore.Mvc;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public object Get()
        {
            return new { version = "Version 0.0.1" };
        }
    }
}