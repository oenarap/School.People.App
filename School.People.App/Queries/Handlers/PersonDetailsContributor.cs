using System;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using Apps.Communication.Core;
using School.People.App.QueryResults;

namespace School.People.App.Queries.Results.Handlers
{
    public class PersonDetailsContributor : IHandle<PersonalInformationAggregateQueryResult>
    {
        public async Task Handle(PersonalInformationAggregateQueryResult result)
        {
            var details = await PersonDetailsRepository.ReadAsync(result.Data.Id).ConfigureAwait(false);
            if (details != null)
            {
                result.Data.Sex = details.Sex;
                result.Data.CivilStatus = details.CivilStatus;
                result.Data.OtherCivilStatus = details.OtherCivilStatus;
                result.Data.HeightInCentimeters = details.HeightInCentimeters;
                result.Data.WeightInKilograms = details.WeightInKilograms;
                result.Data.BloodType = details.BloodType;
            }
        }

        public PersonDetailsContributor(IPersonDetailsRepository personDetailsRepository)
        {
            PersonDetailsRepository = personDetailsRepository ?? throw new ArgumentNullException(nameof(personDetailsRepository));
        }

        private readonly IPersonDetailsRepository PersonDetailsRepository;
    }
}
