using System;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.Core.Repositories;
using School.People.App.Queries.Results;

namespace School.People.App.Queries.Contributors
{
    public class CitizenshipContributor : IHandle<PersonalInformationQueryResult>
    {
        public async Task Handle(PersonalInformationQueryResult result)
        {
            var repository = (ICitizenshipsRepository)provider.GetService(typeof(ICitizenshipsRepository));
            var citizenship = await repository.ReadAsync(result.Data.Id).ConfigureAwait(false);

            if (citizenship != null)
            {
                result.Data.Country = citizenship.Country;
                result.Data.DualCitizenship = citizenship.DualCitizenship;
                result.Data.DualCitizenshipMode = citizenship.DualCitizenshipMode;
            }
        }

        public CitizenshipContributor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
