using System;
using School.People.Core;
using System.Threading.Tasks;
using Apps.Communication.Core;
using System.Collections.Generic;
using School.People.App.QueryResults;
using School.People.Core.Repositories;

namespace School.People.App.Queries.Results.Handlers
{
    public class ChildrenContributor : IHandle<FamilyMembersAggregateQueryResult>
    {
        public async Task Handle(FamilyMembersAggregateQueryResult result)
        {
            var memberIds = await FamilyIdsRepository.ReadAllAsync(result.Data.Id).ConfigureAwait(false);
            if (memberIds != null)
            {
                var children = new List<IPerson>();
                foreach (var ids in memberIds)
                {
                    var child = await PersonRepository.ReadAsync(ids.Id).ConfigureAwait(false);
                    if (child != null) { children.Add(child); }
                }
                result.Data.Children = children; 
            }
        }

        public ChildrenContributor(IFamilyIdsRepository familyIdsRepository, IPersonRepository personRepository)
        {
            FamilyIdsRepository = familyIdsRepository ?? throw new ArgumentNullException(nameof(familyIdsRepository));
            PersonRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
        }

        private readonly IFamilyIdsRepository FamilyIdsRepository;
        private readonly IPersonRepository PersonRepository;
    }
}
