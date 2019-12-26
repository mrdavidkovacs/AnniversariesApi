using System;

namespace Anniversaries.Core
{
    public class Anniversary
    {
        public Anniversary(string name, decimal years, string description)
        {
            this.Years = years;
            this.Description = description;
            this.Name = name;
        }

        public decimal Years { get; }

        public string Name { get; }

        public string Description { get; }

        public DateTime CalculateConcreteDate(DateTime relevantDate)
        {
            return relevantDate.AddMonths((int) (this.Years * 12));
        }
    }
}