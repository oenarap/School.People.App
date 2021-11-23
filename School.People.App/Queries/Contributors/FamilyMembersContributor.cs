using System;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.Core.Repositories;
using School.People.App.Queries.Results;

namespace School.People.App.Queries.Contributors
{
    public class FamilyMembersContributor : IHandle<FamilyMembersQueryResult>
    {
        public async Task Handle(FamilyMembersQueryResult result)
        {
            var repository = (IFamilyIdsRepository)provider.GetService(typeof(IFamilyIdsRepository));
            var ids = await repository.ReadAsync(result.Data.Id).ConfigureAwait(false);

            if (ids != null)
            {
                var persons = (IPersonRepository)provider.GetService(typeof(IPersonRepository));

                if (ids.MotherId is Guid motherId) 
                { 
                    result.Data.Mother = await persons.ReadAsync(motherId).ConfigureAwait(false);
                }
                if (ids.FatherId is Guid fatherId) 
                { 
                    result.Data.Father = await persons.ReadAsync(fatherId).ConfigureAwait(false); 
                }
                if (ids.SpouseId is Guid spouseId) 
                { 
                    result.Data.Spouse = await persons.ReadAsync(spouseId).ConfigureAwait(false); 
                }
            }
        }

        public FamilyMembersContributor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
