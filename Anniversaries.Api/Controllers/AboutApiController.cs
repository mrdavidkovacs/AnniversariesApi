using Anniversaries.Core;
using Microsoft.AspNetCore.Mvc;

namespace Anniversaries.Api.Controllers
{
    [ApiController]
    [Route("about")]
    public class AboutApiController : ControllerBase
    {
        private readonly BuildInformation _buildInformation;

        public AboutApiController(BuildInformation buildInformation)
        {
            _buildInformation = buildInformation;
        }

        [HttpGet("information")]
        public IActionResult GetInformation()
        {
            return this.Ok(_buildInformation);
        }
    }
}