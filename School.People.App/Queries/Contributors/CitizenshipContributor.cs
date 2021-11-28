using System;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.Core.Repositories;
using School.People.App.Queries.Results;

namespace School.People.App.Queries.Contributors
{
    public class CitizenshipContributor : IHandle<PersonalInformationQueryResult>
    {
        public async Task Handle(PersonalInformationQueryResult message)
        {
            try
            {
                var repository = (ICitizenshipsRepository)provider.GetService(typeof(ICitizenshipsRepository));
                var citizenship = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);

                if (citizenship != null)
                {
                    message.Data.Country = citizenship.Country;
                    message.Data.DualCitizenship = citizenship.DualCitizenship;
                    message.Data.DualCitizenshipMode = citizenship.DualCitizenshipMode;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public CitizenshipContributor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
