using System;
using System.Collections.Generic;
using System.Linq;

namespace Anniversaries.Core
{
    public class BirthdayAnniversaries : IAnniversaryRepository
    {
        private const int Years = 150;

        public AnniversaryType GetAnniversaryType()
        {
            return new AnniversaryType("Geburtstag", "Geburtsdatum", "Caroline", AnniversaryTypes.Birthday, "fas fa-birthday-cake", new DateTime(2000, 01, 28));
        }

        public IEnumerable<Anniversary> GetAnniversaries()
        {
            yield return new Anniversary("Geburtstag", Duration.FromYears(0m), "Tag der Geburt");

            for (int years = 5; years <= Years; years++)
            {
                if (years % 5 == 0 || years.ToString().Distinct().Count() == 1)
                {
                     yield return new Anniversary($"{years}. Geburtstag", Duration.FromYears(years), string.Empty);
                }
            }

            for (int days = 1; days <= Years * 366; days++)
            {
                if (days % 1000 == 0 || days.ToString().Distinct().Count() == 1)
                {
                     yield return new Anniversary($"{days} Tage", Duration.FromDays(days), string.Empty);
                }
            }

            for (int weeks = 1; weeks <= Years * 52; weeks++)
            {
                if (weeks % 1000 == 0 || weeks.ToString().Distinct().Count() == 1)
                {
                     yield return new Anniversary($"{weeks} Wochen", Duration.FromDays(weeks * 7), string.Empty);
                }
            }

            for (int months = 1; months <= Years * 12; months++)
            {
                if (months % 100 == 0 || months.ToString().Distinct().Count() == 1)
                {
                     yield return new Anniversary($"{months} Monate", Duration.FromMonths(months), string.Empty);
                }
            }
        }
    }
}