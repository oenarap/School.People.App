using System;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using Apps.Communication.Core;
using School.People.App.QueryResults;

namespace School.People.App.Queries.Results.Handlers
{
    public class DateOfBirthContributor : IHandle<PersonalInformationAggregateQueryResult>
    {
        public async Task Handle(PersonalInformationAggregateQueryResult result)
        {
            var dob = await DateOfBirthsRepository.ReadAsync(result.Data.Id).ConfigureAwait(false);
            if (dob != null) { result.Data.Birthdate = dob.Birthdate; }
        }

        public DateOfBirthContributor(IDateOfBirthsRepository dateOfBirthsRepository)
        {
            DateOfBirthsRepository = dateOfBirthsRepository ?? throw new ArgumentNullException(nameof(dateOfBirthsRepository));
        }

        private readonly IDateOfBirthsRepository DateOfBirthsRepository;
    }
}
