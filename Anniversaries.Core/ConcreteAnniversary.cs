using System;

namespace Anniversaries.Core
{
    public class Appointment
    {
        public Appointment(string name, string description, DateTime dateTime)
        {
            this.Name = name;
            this.Description = description;
            this.DateTime = dateTime;
        }

        public string Name { get; }

        public string Description { get; }

        public DateTime DateTime { get; }
    }
}