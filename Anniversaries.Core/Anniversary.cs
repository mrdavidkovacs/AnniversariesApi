using System;

namespace Anniversaries.Core
{
    public class Anniversary
    {
        public Anniversary(string name, decimal years, string description)
            : this(name, Duration.FromYears(years), description)
        {
        }

        public Anniversary(string name, Duration duration, string description)
        {
            this.Duration = duration;
            this.Description = description;
            this.Name = name;
        }

        public string Name { get; }

        public string Description { get; }

        public Duration Duration { get; }

        public DateTime CalculateConcreteDate(DateTime relevantDate)
        {
            return this.Duration.CalculateConcreteDate(relevantDate);
        }
    }
}