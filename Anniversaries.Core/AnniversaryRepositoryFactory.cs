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

                case AnniversaryTypes.Birthday:
                    return new BirthdayAnniversaries();

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}