using System;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.App.Queries.Results;
using School.People.Core.Repositories;

namespace School.People.App.Queries.Contributors
{
    public class BirthAddressContributor : IHandle<PersonalInformationQueryResult>
    {
        public Task Handle(PersonalInformationQueryResult result)
        {
            throw new NotImplementedException();
        }

        public BirthAddressContributor() //IServiceProvider provider)
        {
            //this.provider = provider;
        }

        //private readonly IServiceProvider provider;
    }
}
