using System;
using System.Collections.Generic;

namespace Anniversaries.Core
{
    public class AnniversaryTypesRepository : IAnniversaryTypesRepository
    {
        public IEnumerable<AnniversaryType> GetTypes()
        {
            yield return new AnniversaryType("Hochzeit", "Hochzeitsdatum", "Standesamt", AnniversaryTypes.Wedding, "$wedding", new DateTime(2016, 07, 16));
            yield return new AnniversaryType("Geburtstag", "Geburtsdatum", "Caroline", AnniversaryTypes.Birthday, "fas fa-birthday-cake", new DateTime(2000, 01, 28));
        }
    }
}