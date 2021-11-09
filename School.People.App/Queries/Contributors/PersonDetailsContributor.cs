using System;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using Apps.Communication.Core;
using School.People.App.Queries.Results;

namespace School.People.App.Queries.Contributors
{
    public class PersonDetailsContributor : IHandle<PersonalInformationQueryResult>,
        IHandle<PersonDetailsQueryResult>
    {
        public async Task Handle(PersonalInformationQueryResult message)
        {
            var repository = (IPersonDetailsRepository)provider.GetService(typeof(IPersonDetailsRepository));
            var details = await repository.ReadAsync(message.Data.Id).ConfigureAwait(false);

            if (details != null)
            {
                message.Data.Sex = details.Sex;
                message.Data.CivilStatus = details.CivilStatus;
                message.Data.OtherCivilStatus = details.OtherCivilStatus;
                message.Data.HeightInCentimeters = details.HeightInCentimeters;
                message.Data.WeightInKilograms = details.WeightInKilograms;
                message.Data.BloodType = details.BloodType;
            }
        }

        public async Task Handle(PersonDetailsQueryResult message)
        {
            var repository = (IPersonDetailsRepository)provider.GetService(typeof(IPersonDetailsRepository));
            var details = await repository.ReadAsync(message.Data.Id).ConfigureAwait(false);

            if (details != null) { details.CopyTo(message.Data); }
        }

        public PersonDetailsContributor(IQueryHub hub, IServiceProvider provider)
        {
            hub.RegisterContributor<PersonDetailsContributor, PersonalInformationQueryResult>(this);
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
