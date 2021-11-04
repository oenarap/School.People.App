using System;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using Apps.Communication.Core;
using School.People.App.QueryResults;

namespace School.People.App.Queries.Results.Handlers
{
    public class FamilyMembersContributor : IHandle<FamilyMembersAggregateQueryResult>
    {
        public async Task Handle(FamilyMembersAggregateQueryResult result)
        {
            var ids = await FamilyIdsRepository.ReadAsync(result.Data.Id).ConfigureAwait(false);
            if (ids != null)
            {
                if (ids.MotherId is Guid motherId) { result.Data.Mother = await PersonRepository.ReadAsync(motherId).ConfigureAwait(false); }
                if (ids.FatherId is Guid fatherId) { result.Data.Father = await PersonRepository.ReadAsync(fatherId).ConfigureAwait(false); }
                if (ids.SpouseId is Guid spouseId) { result.Data.Spouse = await PersonRepository.ReadAsync(spouseId).ConfigureAwait(false); }
            }
        }

        public FamilyMembersContributor(IFamilyIdsRepository familyIdsRepository, IPersonRepository personRepository)
        {
            FamilyIdsRepository = familyIdsRepository ?? throw new ArgumentNullException(nameof(familyIdsRepository));
            PersonRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
        }

        private readonly IFamilyIdsRepository FamilyIdsRepository;
        private readonly IPersonRepository PersonRepository;
    }
}
