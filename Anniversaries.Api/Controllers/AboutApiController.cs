using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Anniversaries.Api.Controllers
{
    [ApiController]
    [Route("about")]
    public class AboutApiController : ControllerBase
    {
        [HttpGet("version")]
        public IActionResult GetBasic()
        {
            string version = Assembly.GetEntryAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                .InformationalVersion ?? string.Empty;
            
            return this.Ok(version);
        }
    }
}