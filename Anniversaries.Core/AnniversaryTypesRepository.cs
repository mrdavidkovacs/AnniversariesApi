using System;
using System.Collections.Generic;

namespace Anniversaries.Core
{
    public class AnniversaryTypesRepository : IAnniversaryTypesRepository
    {
        public IEnumerable<AnniversaryType> GetTypes()
        {
            yield return new AnniversaryType("Hochzeit", "Hochzeitsdatum", "Standesamt", "wedding", "$wedding", new DateTime(2016, 07, 16));
        }
    }
}