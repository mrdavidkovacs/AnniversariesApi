using System;

namespace Anniversaries.Core
{
    public class AnniversaryRepositoryFactory : IAnniversaryRepositoryFactory
    {
        public IAnniversaryRepository GetRepository(AnniversaryTypes type)
        {
            switch (type)
            {
                case AnniversaryTypes.Wedding:
                    return new WeddingAnniversaries();

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}