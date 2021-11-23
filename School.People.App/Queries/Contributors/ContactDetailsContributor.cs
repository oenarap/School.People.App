using System;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using Apps.Communication.Core;
using School.People.App.Queries.Results;

namespace School.People.App.Queries.Contributors
{
    public class ContactDetailsContributor : IHandle<PersonalInformationQueryResult>
    {
        public async Task Handle(PersonalInformationQueryResult result)
        {
            var repository = (IContactDetailsRepository)provider.GetService(typeof(IContactDetailsRepository));
            var details = await repository.ReadAsync(result.Data.Id).ConfigureAwait(false);

            if (details != null)
            {
                result.Data.EmailAddress = details.EmailAddress;
                result.Data.TelephoneNumber = details.TelephoneNumber;
                result.Data.MobileNumber = details.MobileNumber;
            }
        }

        public ContactDetailsContributor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
