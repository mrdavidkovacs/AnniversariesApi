using System;
using System.Diagnostics.CodeAnalysis;

namespace Anniversaries.Core
{
    public class Duration : IComparable<Duration>
    {
        private readonly decimal? _years;
        private readonly int? _months;
        private readonly int? _days;

        private Duration(decimal? years, int? months, int? days)
        {
            if (!(years.HasValue ^ months.HasValue ^ days.HasValue))
            {
                throw new ArgumentException("You can only set one parameter.");
            }

            _years = years;
            _months = months;
            _days = days;
        }

        public DateTime CalculateConcreteDate(DateTime relevantDate)
        {
            if (_years.HasValue)
            {
                return relevantDate.AddMonths((int) (_years.Value * 12));
            }

            if (_months.HasValue)
            {
                return relevantDate.AddMonths(_months.Value);
            }
        
            if (_days.HasValue)
            {
                return relevantDate.AddDays(_days.Value);
            }

            throw new InvalidOperationException("One of the values must be set!");
        }

        public int CompareTo([AllowNull] Duration other)
        {
            if (other == null)
            {
                return -1;
            }

            return this.GetDaysForComparision().CompareTo(other.GetDaysForComparision());            
        }

        public static Duration FromYears(decimal years)
        {
            return new Duration(years, null, null);
        }

        public static Duration FromMonths(int months)
        {
            return new Duration(null, months, null);
        }

        public static Duration FromDays(int days)
        {
            return new Duration(null, null, days);
        }

        private double GetDaysForComparision()
        {
            if (_years.HasValue)
            {
                return (int) (_years.Value * 365.2425m);
            }

            if (_months.HasValue)
            {
                return _months.Value * 30.43687d;
            }
        
            if (_days.HasValue)
            {
                return _days.Value;
            }

            throw new InvalidOperationException("One of the values must be set!");
        }
    }
}