using System;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using Apps.Communication.Core;
using School.People.App.Queries.Results;

namespace School.People.App.Queries.Contributors
{
    public class ContactDetailsContributor : IHandle<PersonalInformationQueryResult>
    {
        public async Task Handle(PersonalInformationQueryResult message)
        {
            try
            {
                var repository = (IContactDetailsRepository)provider.GetService(typeof(IContactDetailsRepository));
                var details = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);

                if (details != null)
                {
                    message.Data.EmailAddress = details.EmailAddress;
                    message.Data.TelephoneNumber = details.TelephoneNumber;
                    message.Data.MobileNumber = details.MobileNumber;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public ContactDetailsContributor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
