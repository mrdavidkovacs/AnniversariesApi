using System.Linq;
using Anniversaries.Core;
using Microsoft.AspNetCore.Mvc;

namespace Anniversaries.Api.Controllers
{
    [ApiController]
    [Route("anniversary-types")]
    public class AnniversaryTypesApiController : ControllerBase
    {
        private readonly IAnniversaryTypesRepository _typesRepository;

        public AnniversaryTypesApiController(IAnniversaryTypesRepository typesRepository)
        {
            _typesRepository = typesRepository;
        }

        [HttpGet]
        public IActionResult GetTypes()
        {
            return this.Ok(_typesRepository.GetTypes().ToArray());
        }
    }
}