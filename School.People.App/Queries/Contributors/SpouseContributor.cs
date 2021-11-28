using Apps.Communication.Core;
using School.People.App.Queries.Results;
using School.People.Core.Dtos;
using School.People.Core.Repositories;
using School.People.Core;
using System;
using System.Threading.Tasks;

namespace School.People.App.Queries.Contributors
{
    public class SpouseContributor : IHandle<FamilyMembersQueryResult>
    {
        public async Task Handle(FamilyMembersQueryResult message)
        {
            try
            {
                if (message.Data.SpouseId is Guid spouseId)
                {
                    var people = (IPersonRepository)provider.GetService(typeof(IPersonRepository));
                    var spouse = await people.ReadAsync(spouseId).ConfigureAwait(false);

                    message.Data.FamilyMembers.Add(new RelatedPerson()
                    {
                        Id = spouse.Id,
                        LastName = spouse.LastName,
                        FirstName = spouse.FirstName,
                        MiddleName = spouse.MiddleName,
                        NameExtension = spouse.NameExtension,
                        Title = spouse.Title,
                        Relationship = Relationship.Spouse
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public SpouseContributor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
