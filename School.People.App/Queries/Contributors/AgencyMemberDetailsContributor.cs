using System;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.App.Queries.Results;
using School.People.Core.Repositories;

namespace School.People.App.Queries.Contributors
{
    public class AgencyMemberDetailsContributor : IHandle<PersonalInformationQueryResult>
    {
        public async Task Handle(PersonalInformationQueryResult result)
        {
            var repository = (IAgencyMemberDetailsRepository)provider.GetService(typeof(IAgencyMemberDetailsRepository));
            var details = await repository.ReadAsync(result.Data.Id).ConfigureAwait(false);

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

        public AgencyMemberDetailsContributor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
