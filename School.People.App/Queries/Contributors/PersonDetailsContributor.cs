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
            try
            {
                var repository = (IPersonDetailsRepository)provider.GetService(typeof(IPersonDetailsRepository));
                var details = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);

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
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task Handle(PersonDetailsQueryResult message)
        {
            try
            {
                var repository = (IPersonDetailsRepository)provider.GetService(typeof(IPersonDetailsRepository));
                var details = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);
                message.Data.PersonDetails = details;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public PersonDetailsContributor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
