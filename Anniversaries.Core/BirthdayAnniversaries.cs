using System;
using System.Collections.Generic;

namespace Anniversaries.Core
{
    public class BirthdayAnniversaries : IAnniversaryRepository
    {
        public AnniversaryType GetAnniversaryType()
        {
            return new AnniversaryType("Geburtstag", "Geburtsdatum", "Caroline", AnniversaryTypes.Birthday, "fas fa-birthday-cake", new DateTime(2000, 01, 28));
        }

        public IEnumerable<Anniversary> GetAnniversaries()
        {
            yield return new Anniversary("Geburtstag", 0, "Tag der Geburt");

            for (int years = 10; years <= 1000; years += 5)
            {
                if ((years < 100 && years % 10 == 0) || years % 25 == 0)
                {
                    yield return new Anniversary($"{years}. Geburtstag", years, string.Empty);
                }
            }            
        }
    }
}