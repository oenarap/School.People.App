using System;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using Apps.Communication.Core;
using School.People.App.QueryResults;

namespace School.People.App.Queries.Results.Handlers
{
    public class AgencyMemberDetailsContributor : IHandle<PersonalInformationAggregateQueryResult>
    {
        public async Task Handle(PersonalInformationAggregateQueryResult result)
        {
            var details = await AgencyMemberDetailsRepository.ReadAsync(result.Data.Id).ConfigureAwait(false);
            if (details != null)
            {
                result.Data.AgencyId = details.AgencyId;
                result.Data.GsisIdNumber = details.GsisIdNumber;
                result.Data.PagIbigIdNumber = details.PagIbigIdNumber;
                result.Data.PhilhealthNumber = details.PhilhealthNumber;
                result.Data.SssNumber = details.SssNumber;
                result.Data.Tin = details.Tin;
            }
        }

        public AgencyMemberDetailsContributor(IAgencyMemberDetailsRepository agencyMemberDetailsRepository)
        {
            AgencyMemberDetailsRepository = agencyMemberDetailsRepository ?? throw new ArgumentNullException(nameof(agencyMemberDetailsRepository));
        }

        private readonly IAgencyMemberDetailsRepository AgencyMemberDetailsRepository;
    }
}
