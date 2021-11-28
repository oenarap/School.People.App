using System;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.App.Queries.Results;
using School.People.Core.Repositories;

namespace School.People.App.Queries.Contributors
{
    public class AgencyMemberDetailsContributor : IHandle<PersonalInformationQueryResult>
    {
        public async Task Handle(PersonalInformationQueryResult message)
        {
            try
            {
                var repository = (IAgencyMemberDetailsRepository)provider.GetService(typeof(IAgencyMemberDetailsRepository));
                var details = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);

                if (details != null)
                {
                    message.Data.AgencyId = details.AgencyId;
                    message.Data.GsisIdNumber = details.GsisIdNumber;
                    message.Data.PagIbigIdNumber = details.PagIbigIdNumber;
                    message.Data.PhilhealthNumber = details.PhilhealthNumber;
                    message.Data.SssNumber = details.SssNumber;
                    message.Data.Tin = details.Tin;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public AgencyMemberDetailsContributor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
