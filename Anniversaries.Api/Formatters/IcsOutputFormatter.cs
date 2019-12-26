using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Anniversaries.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace Anniversaries.Api.Formatters
{
    public class IcsOutputFormatter : TextOutputFormatter
    {
        private const string Separator = "\r\n";

        public IcsOutputFormatter()
        {
            this.SupportedEncodings.Add(Encoding.UTF8);
            this.SupportedEncodings.Add(Encoding.Unicode);
            
            this.SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/x-ical"));
            this.SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/ical"));
        }

        protected override bool CanWriteType(Type type)
        {
            // this should only be available for appointments
            if (typeof(Appointment).IsAssignableFrom(type) || typeof(IEnumerable<Appointment>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }

            return false;
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            List<string> contents = new List<string>();

            contents.Add("BEGIN:VCALENDAR");
            contents.Add("PRODID:https://github.com/mrdavidkovacs/AnniversariesApi ");
            contents.Add("VERSION:2.0");
            contents.Add("CALSCALE:GREGORIAN");
            contents.Add("METHOD:PUBLISH");
            contents.Add("X-WR-CALNAME:Anniversaries");

            if (context.Object is IEnumerable<Appointment> appointments)
            {
                foreach (Appointment appointment in appointments)
                {
                    this.FormatIcs(contents, appointment);
                }
            }
            else
            {
                Appointment appointment = context.Object as Appointment;
                this.FormatIcs(contents, appointment);
            }

            contents.Add("END:VCALENDAR");

            HttpResponse response = context.HttpContext.Response;
            return response.WriteAsync(string.Join(Separator, contents));
        }

        private void FormatIcs(List<string> contents, Appointment appointment)
        {
            contents.Add("BEGIN:VEVENT");
            contents.Add($"UID:{Guid.NewGuid():D}");
            contents.Add("LOCATION:");
            contents.Add($"SUMMARY:{appointment.Name}");
            contents.Add($"DESCRIPTION:{appointment.Description}");
            contents.Add("CLASS:PUBLIC");
            contents.Add($"DTSTART;VALUE=DATE:{appointment.DateTime:yyyyMMdd}");
            contents.Add($"DTEND;VALUE=DATE:{appointment.DateTime.AddDays(1):yyyyMMdd}");
            contents.Add($"DTSTAMP:{DateTime.Now:yyyyMMddTHHmmzzzZ}");
            contents.Add("END:VEVENT");
        }
    }
}