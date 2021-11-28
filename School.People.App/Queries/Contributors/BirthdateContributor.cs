using System;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using Apps.Communication.Core;
using School.People.App.Queries.Results;

namespace School.People.App.Queries.Contributors
{
    public class BirthdateContributor : IHandle<PersonalInformationQueryResult>
    {
        public async Task Handle(PersonalInformationQueryResult message)
        {
            try
            {
                var repository = (IDateOfBirthsRepository)provider.GetService(typeof(IDateOfBirthsRepository));
                var details = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);

                if (details != null)
                {
                    message.Data.Birthdate = details.Birthdate;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public BirthdateContributor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
