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
                .InformationalVersion;

            if (string.IsNullOrEmpty(version))
            {
                throw new InvalidOperationException($"The version should not be null.");
            }
            
            return this.Ok(version);
        }
    }
}