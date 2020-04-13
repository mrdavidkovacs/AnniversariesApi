using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Anniversaries.Api.Controllers
{
    [ApiController]
    [Route("about")]
    public class AboutApiController : ControllerBase
    {
        [HttpGet("version")]
        public IActionResult GetVersion()
        {
            string version = Assembly.GetExecutingAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                .InformationalVersion;
            
            return this.Ok(version);
        }
    }
}