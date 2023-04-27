using Microsoft.AspNetCore.Mvc;

namespace FolderHierarchy.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Hello()
        {
            return Ok("Hello World!");
        }
    }
}
