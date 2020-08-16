using System;
using System.Collections.Generic;
using System.Linq;

namespace Anniversaries.Core
{
    public class BirthdayAnniversaries : IAnniversaryRepository
    {
        private const int Years = 150;
        private readonly int[] _binaryNumbers;

        public BirthdayAnniversaries()
        {
            _binaryNumbers = Enumerable.Range(1, 100)
                .Select(nr => (int) Math.Pow(2, nr))
                .ToArray();
        }

        public AnniversaryType GetAnniversaryType()
        {
            return new AnniversaryType("Geburtstag", "Geburtsdatum", "Caroline", AnniversaryTypes.Birthday, "fas fa-birthday-cake", new DateTime(2000, 01, 28));
        }

        public IEnumerable<Anniversary> GetAnniversaries()
        {
            yield return new Anniversary("Geburtstag", Duration.FromYears(0m), "Tag der Geburt");

            for (int years = 1; years <= Years; years++)
            {
                var (relevant, reason) = this.GetAnniversaryReasons(years, 10);

                if (!relevant)
                {
                    continue;
                }

                yield return new Anniversary($"{years}. Geburtstag", Duration.FromYears(years), reason);
            }

            for (int days = 1; days <= Years * 366; days++)
            {
                var (relevant, reason) = this.GetAnniversaryReasons(days, 1000);

                if (!relevant)
                {
                    continue;
                }

                yield return new Anniversary($"{days} Tage", Duration.FromDays(days), reason);
            }

            for (int weeks = 1; weeks <= Years * 52; weeks++)
            {
                var (relevant, reason) = this.GetAnniversaryReasons(weeks, 1000);

                if (!relevant)
                {
                    continue;
                }
                
                yield return new Anniversary($"{weeks} Wochen", Duration.FromDays(weeks * 7), reason);
            }

            for (int months = 1; months <= Years * 12; months++)
            {
                var (relevant, reason) = this.GetAnniversaryReasons(months, 100);

                if (!relevant)
                {
                    continue;
                }
                
                yield return new Anniversary($"{months} Monate", Duration.FromMonths(months), reason);
            }
        }

        private (bool, string) GetAnniversaryReasons(int number, int roundEveryX)
        {
            List<string> reasons = new List<string>();

            if (number % roundEveryX == 0)
            {
                reasons.Add($"Durch {roundEveryX} teilbar.");
            }

            if (number.ToString().Distinct().Count() == 1)
            {
                reasons.Add("Nur eine Zahl in Verwendung.");
            }

            if (_binaryNumbers.Contains(number))
            {
                reasons.Add($"{number} ist eine Zweierpotenz.");
            }

            if (reasons.Any())
            {
                return (true, string.Join(" ", reasons));
            }

            return (false, string.Empty);
        }
    }
}
