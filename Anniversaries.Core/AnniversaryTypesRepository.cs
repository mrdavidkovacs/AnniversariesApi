using System;
using System.Collections.Generic;
using System.Linq;

namespace Anniversaries.Core
{
    public class AnniversaryTypesRepository : IAnniversaryTypesRepository
    {
        private readonly Dictionary<AnniversaryTypes, (AnniversaryType, IAnniversaryRepository)> _definedRepositories = new Dictionary<AnniversaryTypes, (AnniversaryType, IAnniversaryRepository)>();

        public AnniversaryTypesRepository()
        {
            this.AddDefinedRepository(new WeddingAnniversaries());
            this.AddDefinedRepository(new BirthdayAnniversaries());
        }

        public IAnniversaryRepository GetByType(AnniversaryTypes type)
        {
            return _definedRepositories[type].Item2;
        }

        public IEnumerable<AnniversaryType> GetTypes()
        {
            return _definedRepositories.Select(r => r.Value.Item1);
        }

        private void AddDefinedRepository(IAnniversaryRepository repository)
        {
            AnniversaryType type = repository.GetAnniversaryType();

            _definedRepositories.Add(type.InternalName, (type, repository));
        }
    }
}