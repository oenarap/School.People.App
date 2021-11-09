using System;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using Apps.Communication.Core;
using School.People.App.Queries.Results;

namespace School.People.App.Queries.Contributors
{
    public class BirthdateContributor : IHandle<PersonalInformationQueryResult>
    {
        public async Task Handle(PersonalInformationQueryResult result)
        {
            var repository = (IDateOfBirthsRepository)provider.GetService(typeof(IDateOfBirthsRepository));
            var details = await repository.ReadAsync(result.Data.Id).ConfigureAwait(false);

            if (details != null)
            {
                result.Data.Birthdate = details.Birthdate;
            }
        }

        public BirthdateContributor(IQueryHub hub, IServiceProvider provider)
        {
            hub.RegisterContributor<BirthdateContributor, PersonalInformationQueryResult>(this);
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
