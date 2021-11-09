using System;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.App.Queries.Results;

namespace School.People.App.Queries.Contributors
{
    public class ResidentialAddressContributor : IHandle<PersonalInformationQueryResult>
    {
        public Task Handle(PersonalInformationQueryResult result)
        {
            throw new NotImplementedException();
        }
    }
}
