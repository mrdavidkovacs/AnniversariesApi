using System.Collections.Generic;

namespace Anniversaries.Core
{
    public interface IAnniversaryTypesRepository
    {
        IEnumerable<AnniversaryType> GetTypes();
    }
}