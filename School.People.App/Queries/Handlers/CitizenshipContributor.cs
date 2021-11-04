using System;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using Apps.Communication.Core;
using School.People.App.QueryResults;

namespace School.People.App.Queries.Results.Handlers
{
    public class CitizenshipContributor : IHandle<PersonalInformationAggregateQueryResult>
    {
        public async Task Handle(PersonalInformationAggregateQueryResult result)
        {
            var citizenship = await CitizenshipsRepository.ReadAsync(result.Data.Id).ConfigureAwait(false);
            if (citizenship != null)
            {
                result.Data.Country = citizenship.Country;
                result.Data.DualCitizenship = citizenship.DualCitizenship;
                result.Data.DualCitizenshipMode = citizenship.DualCitizenshipMode;
            }
        }

        public CitizenshipContributor(ICitizenshipsRepository citizenshipsRepository)
        {
            CitizenshipsRepository = citizenshipsRepository ?? throw new ArgumentNullException(nameof(citizenshipsRepository));
        }

        private readonly ICitizenshipsRepository CitizenshipsRepository;
    }
}
