namespace Anniversaries.Core
{
    public interface IAnniversaryRepositoryFactory
    {
        IAnniversaryRepository GetRepository(AnniversaryTypes type);
    }
}