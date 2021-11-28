using System;
using Apps.Communication.Core;
using School.People.App.Queries.Results;
using School.People.Core.Repositories;
using System.Threading.Tasks;
using School.People.Core.Dtos;
using School.People.Core;

namespace School.People.App.Queries.Contributors
{
    public class FatherContributor : IHandle<FamilyMembersQueryResult>
    {
        public async Task Handle(FamilyMembersQueryResult message)
        {
            try
            {
                if (message.Data.FatherId is Guid fatherId)
                {
                    var people = (IPersonRepository)provider.GetService(typeof(IPersonRepository));
                    var father = await people.ReadAsync(fatherId).ConfigureAwait(false);

                    message.Data.FamilyMembers.Add(new RelatedPerson()
                    {
                        Id = father.Id,
                        LastName = father.LastName,
                        FirstName = father.FirstName,
                        MiddleName = father.MiddleName,
                        NameExtension = father.NameExtension,
                        Title = father.Title,
                        Relationship = Relationship.Father
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public FatherContributor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
