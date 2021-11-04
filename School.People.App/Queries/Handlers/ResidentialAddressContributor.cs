using System;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.App.QueryResults;

namespace School.People.App.Queries.Results.Handlers
{
    public class ResidentialAddressContributor : IHandle<PersonalInformationAggregateQueryResult>
    {
        public Task Handle(PersonalInformationAggregateQueryResult result)
        {
            throw new NotImplementedException();
        }
    }
}
