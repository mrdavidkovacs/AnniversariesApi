using System.Collections.Generic;

namespace Anniversaries.Core
{
    public class BirthdayAnniversaries : IAnniversaryRepository
    {
        public IEnumerable<Anniversary> Get()
        {
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