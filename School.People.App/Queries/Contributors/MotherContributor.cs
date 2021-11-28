using School.People.App.Queries.Results;
using School.People.Core.Dtos;
using School.People.Core.Repositories;
using School.People.Core;
using System;
using System.Threading.Tasks;
using Apps.Communication.Core;

namespace School.People.App.Queries.Contributors
{
    public class MotherContributor : IHandle<FamilyMembersQueryResult>
    {
        public async Task Handle(FamilyMembersQueryResult message)
        {
            try
            {
                if (message.Data.MotherId is Guid motherId)
                {
                    var people = (IPersonRepository)provider.GetService(typeof(IPersonRepository));
                    var mother = await people.ReadAsync(motherId).ConfigureAwait(false);

                    message.Data.FamilyMembers.Add(new RelatedPerson()
                    {
                        Id = mother.Id,
                        LastName = mother.LastName,
                        FirstName = mother.FirstName,
                        MiddleName = mother.MiddleName,
                        NameExtension = mother.NameExtension,
                        Title = mother.Title,
                        Relationship = Relationship.Mother
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public MotherContributor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
