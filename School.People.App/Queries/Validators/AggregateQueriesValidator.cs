using System;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.App.Queries.Results;
using School.People.Core.Repositories;
using School.People.App.Queries.Data;

namespace School.People.App.Queries.Validators
{
    public class AggregateQueriesValidator : IHandle<PersonalInformationQuery, PersonalInformationQueryResult>,
        IHandle<VerificationDetailsQuery, VerificationDetailsQueryResult>,
        IHandle<FamilyMembersQuery, FamilyMembersQueryResult>
    {
        public async Task<PersonalInformationQueryResult> Handle(PersonalInformationQuery message)
        {
            try
            {
                if (message.Parameter != Guid.Empty)
                {
                    var repository = (IPersonRepository)provider.GetService(typeof(IPersonRepository));
                    var person = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);

                    if (person != null)
                    {
                        return new PersonalInformationQueryResult(message.Id,
                            new PersonalInformationQueryData(), person.Id);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<VerificationDetailsQueryResult> Handle(VerificationDetailsQuery message)
        {
            try
            {
                if (message.Parameter != Guid.Empty)
                {
                    var repository = (IPersonRepository)provider.GetService(typeof(IPersonRepository));
                    var person = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);

                    if (person != null)
                    {
                        return new VerificationDetailsQueryResult(message.Id,
                            new VerificationDetailsQueryData(), person.Id);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<FamilyMembersQueryResult> Handle(FamilyMembersQuery message)
        {
            try
            {
                if (message.Parameter == Guid.Empty) { return null; }

                var repository = (IFamilyIdsRepository)provider.GetService(typeof(IFamilyIdsRepository));
                var familyIds = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);

                if (familyIds != null)
                {
                    var data = new FamilyMembersQueryData()
                    {
                        MotherId = familyIds.MotherId,
                        FatherId = familyIds.FatherId,
                        SpouseId = familyIds.SpouseId
                    };
                    return new FamilyMembersQueryResult(message.Id, data, message.Parameter);
                }
                return new FamilyMembersQueryResult(message.Id,
                    new FamilyMembersQueryData(), message.Parameter);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public AggregateQueriesValidator(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
