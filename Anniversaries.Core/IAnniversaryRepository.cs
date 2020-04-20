using System.Collections.Generic;

namespace Anniversaries.Core
{
    public interface IAnniversaryRepository
    {
        AnniversaryType GetAnniversaryType();

        IEnumerable<Anniversary> GetAnniversaries();
    }
}