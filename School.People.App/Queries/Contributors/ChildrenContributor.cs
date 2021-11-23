using System;
using School.People.Core;
using System.Threading.Tasks;
using Apps.Communication.Core;
using System.Collections.Generic;
using School.People.Core.Repositories;
using School.People.App.Queries.Results;

namespace School.People.App.Queries.Contributors
{
    public class ChildrenContributor : IHandle<FamilyMembersQueryResult>
    {
        public async Task Handle(FamilyMembersQueryResult message)
        {
            var repository = (IChildrenIdsRepository)provider.GetService(typeof(IChildrenIdsRepository));
            var childrenIds = await repository.ReadAllAsync(message.Data.Id).ConfigureAwait(false);

            if (childrenIds != null)
            {
                var personsRepository = (IPersonRepository)provider.GetService(typeof(IPersonRepository));
                var children = new List<IPerson>();

                foreach (var id in childrenIds)
                {
                    var child = await personsRepository.ReadAsync(id).ConfigureAwait(false);
                    if (child != null) { children.Add(child); }
                }

                message.Data.Children = children;
            }
        }

        public ChildrenContributor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
