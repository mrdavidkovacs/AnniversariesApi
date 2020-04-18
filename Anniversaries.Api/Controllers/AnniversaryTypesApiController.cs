using System;
using System.Collections.Generic;
using System.Linq;
using Anniversaries.Core;
using Microsoft.AspNetCore.Mvc;

namespace Anniversaries.Api.Controllers
{
    [ApiController]
    [Route("anniversaries")]
    public class AnniversaryTypesApiController : ControllerBase
    {
        public AnniversaryTypesApiController()
        {
        }

        [HttpGet]
        public IActionResult GetTypes()
        {
            return this.Ok(this.GetTypesInternal().ToArray());
        }

        private IEnumerable<AnniversaryType> GetTypesInternal()
        {
            yield return new AnniversaryType("Hochzeit", "Hochzeitsdatum", "Standesamt", "wedding", "$wedding", new DateTime(2016, 07, 16));
        }
    }
}