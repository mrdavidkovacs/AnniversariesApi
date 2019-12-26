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
        [HttpGet]
        public IActionResult GetBasic()
        {
            WeddingAnniversaries weddingAnniversaries = new WeddingAnniversaries();
            
            return this.Ok(weddingAnniversaries.Get());
        }

        [FormatFilter]
        [HttpGet("{weddingDate}"), HttpGet("{weddingDate}.{format}")]
        public IActionResult Get([DataType(DataType.Date)] DateTime weddingDate, string name)
        {
            WeddingAnniversaries weddingAnniversaries = new WeddingAnniversaries();

            Appointment[] appointments = weddingAnniversaries.Get()
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