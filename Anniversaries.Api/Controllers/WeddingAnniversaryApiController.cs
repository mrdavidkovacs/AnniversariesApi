using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Anniversaries.Core;
using Microsoft.AspNetCore.Mvc;

namespace Anniversaries.Api.Controllers
{
    [ApiController]
    [Route("anniversaries/wedding")]
    public class WeddingAnniversaryApiController : ControllerBase
    {
        private readonly IAnniversaryRepository _repository;

        public WeddingAnniversaryApiController(IAnniversaryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetBasic()
        {
            return this.Ok(_repository.Get());
        }

        [FormatFilter]
        [HttpGet("{weddingDate}")]
        [HttpGet("{weddingDate}.{format}")]
        public IActionResult Get([DataType(DataType.Date)] DateTime weddingDate, string name)
        {
            Appointment[] appointments = _repository.Get()
                .Select(a => new Appointment(GenerateName(a.Name, name), a.Description, a.CalculateConcreteDate(weddingDate)))
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