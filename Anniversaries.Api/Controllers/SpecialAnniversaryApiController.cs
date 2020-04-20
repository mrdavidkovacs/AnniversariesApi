using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Anniversaries.Core;
using Microsoft.AspNetCore.Mvc;

namespace Anniversaries.Api.Controllers
{
    [ApiController]
    [Route("anniversaries")]
    public class SpecialAnniversaryApiController : ControllerBase
    {
        private readonly IAnniversaryRepositoryFactory _factory;

        public SpecialAnniversaryApiController(IAnniversaryRepositoryFactory factory)
        {
            _factory = factory;
        }

        [HttpGet("{type}")]
        public IActionResult GetAvailableAnniversaries(AnniversaryTypes type)
        {
            IAnniversaryRepository repository = _factory.GetRepository(type);
            return this.Ok(repository.Get());
        }

        [FormatFilter]
        [HttpGet("{type}/{date}")]
        [HttpGet("{type}/{date}.{format}")]
        public IActionResult Get(AnniversaryTypes type, [DataType(DataType.Date)] DateTime date, string name)
        {
            IAnniversaryRepository repository = _factory.GetRepository(type);

            Appointment[] appointments = repository.Get()
                .Select(a => new Appointment(GenerateName(a.Name, name), a.Description, a.CalculateConcreteDate(date)))
                .OrderBy(a => a.DateTime)
                .ToArray();

            return this.Ok(appointments);

            string GenerateName(string anniversaryName, string optionalName)
            {
                StringBuilder sb = new StringBuilder();

                if (!string.IsNullOrWhiteSpace(optionalName))
                {
                    sb.Append(optionalName).Append(" ");
                }

                sb.Append(anniversaryName);

                return sb.ToString();
            }
        }
    }
}