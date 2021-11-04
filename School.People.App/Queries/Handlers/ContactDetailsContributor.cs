using System;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using Apps.Communication.Core;
using School.People.App.QueryResults;

namespace School.People.App.Queries.Results.Handlers
{
    public class ContactDetailsContributor : IHandle<PersonalInformationAggregateQueryResult>
    {
        public async Task Handle(PersonalInformationAggregateQueryResult result)
        {
            var details = await ContactDetailsRepository.ReadAsync(result.Data.Id).ConfigureAwait(false);
            if (details != null)
            {
                result.Data.EmailAddress = details.EmailAddress;
                result.Data.TelephoneNumber = details.TelephoneNumber;
                result.Data.MobileNumber = details.MobileNumber;
            }
        }

        public ContactDetailsContributor(IContactDetailsRepository contactDetailsRepository)
        {
            ContactDetailsRepository = contactDetailsRepository ?? throw new ArgumentNullException(nameof(contactDetailsRepository));
        }

        private readonly IContactDetailsRepository ContactDetailsRepository;
    }
}
