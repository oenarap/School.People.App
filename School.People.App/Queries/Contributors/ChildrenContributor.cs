using System;
using School.People.Core;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.Core.Repositories;
using School.People.App.Queries.Results;
using School.People.Core.Dtos;

namespace School.People.App.Queries.Contributors
{
    public class ChildrenContributor : IHandle<FamilyMembersQueryResult>
    {
        public async Task Handle(FamilyMembersQueryResult message)
        {
            try
            {
                var repository = (IChildrenIdsRepository)provider.GetService(typeof(IChildrenIdsRepository));
                var childrenIds = await repository.ReadAllAsync(message.Parameter).ConfigureAwait(false);

                if (childrenIds != null)
                {
                    var personsRepository = (IPersonRepository)provider.GetService(typeof(IPersonRepository));

                    foreach (var id in childrenIds)
                    {
                        var child = await personsRepository.ReadAsync(id).ConfigureAwait(false);
                        if (child != null)
                        {
                            message.Data.FamilyMembers.Add(new RelatedPerson()
                            {
                                Id = child.Id,
                                LastName = child.LastName,
                                FirstName = child.FirstName,
                                MiddleName = child.MiddleName,
                                NameExtension = child.NameExtension,
                                Title = child.Title,
                                Relationship = Relationship.Child
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public ChildrenContributor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
