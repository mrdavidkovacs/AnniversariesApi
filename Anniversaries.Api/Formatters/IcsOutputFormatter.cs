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
            List<string> contents = new List<string>
            {
                "BEGIN:VCALENDAR",
                "PRODID:https://github.com/mrdavidkovacs/AnniversariesApi",
                "VERSION:2.0",
                "CALSCALE:GREGORIAN",
                "METHOD:PUBLISH",
                "X-WR-CALNAME:Anniversaries",
            };

            if (context.Object is IEnumerable<Appointment> appointments)
            {
                foreach (Appointment appointment in appointments)
                {
                    contents.AddRange(this.FormatIcs(appointment));
                }
            }
            else
            {
                Appointment appointment = context.Object as Appointment;
                contents.AddRange(this.FormatIcs(appointment));
            }

            contents.Add("END:VCALENDAR");

            HttpResponse response = context.HttpContext.Response;
            return response.WriteAsync(string.Join(Separator, contents));
        }

        private IEnumerable<string> FormatIcs(Appointment appointment)
        {
            yield return "BEGIN:VEVENT";
            yield return $"UID:{Guid.NewGuid():D}";
            yield return "LOCATION:";
            yield return $"SUMMARY:{appointment.Name}";
            yield return $"DESCRIPTION:{appointment.Description}";
            yield return "CLASS:PUBLIC";
            yield return $"DTSTART;VALUE=DATE:{appointment.DateTime:yyyyMMdd}";
            yield return $"DTEND;VALUE=DATE:{appointment.DateTime.AddDays(1):yyyyMMdd}";
            yield return $"DTSTAMP:{DateTime.Now:yyyyMMddTHHmmzzzZ}";
            yield return "END:VEVENT";
        }
    }
}