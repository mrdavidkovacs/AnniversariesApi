using System.Collections.Generic;

namespace Anniversaries.Core
{
    public interface IAnniversaryRepository
    {
        IEnumerable<Anniversary> Get();
    }
}