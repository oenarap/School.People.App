using System;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.App.Queries.Results;
using School.People.App.Queries.Models;
using School.People.Core.Repositories;

namespace School.People.App.Queries.Validators
{
    public class AggregateQueriesValidator : IHandle<PersonalInformationQuery, PersonalInformationQueryResult>,
        IHandle<VerificationDetailsQuery, VerificationDetailsQueryResult>,
        IHandle<FamilyMembersQuery, FamilyMembersQueryResult>
    {
        public async Task<PersonalInformationQueryResult> Handle(PersonalInformationQuery query)
        {
            if (query.Parameter != Guid.Empty)
            {
                var repository = (IPersonRepository)provider.GetService(typeof(IPersonRepository));
                var person = await repository.ReadAsync(query.Parameter).ConfigureAwait(false);

                if (person != null)
                {
                    var data = new PersonalInformationQueryData(person.Id);
                    return new PersonalInformationQueryResult(query.Id, data);
                }
            }

            return null;
        }

        public async Task<VerificationDetailsQueryResult> Handle(VerificationDetailsQuery query)
        {
            if (query.Parameter != Guid.Empty)
            {
                var repository = (IPersonRepository)provider.GetService(typeof(IPersonRepository));
                var person = await repository.ReadAsync(query.Parameter).ConfigureAwait(false);

                if (person != null)
                {
                    var data = new VerificationDetailsQueryData(person.Id);
                    return new VerificationDetailsQueryResult(query.Id, data);
                }
            }
                
            return null;
        }

        public async Task<FamilyMembersQueryResult> Handle(FamilyMembersQuery query)
        {
            if (query.Parameter != Guid.Empty)
            {
                var repository = (IPersonRepository)provider.GetService(typeof(IPersonRepository));
                var person = await repository.ReadAsync(query.Parameter).ConfigureAwait(false);

                if (person != null)
                {
                    var data = new FamilyMembersQueryData(person.Id);
                    return new FamilyMembersQueryResult(query.Id, data);
                }
            }

            return null;
        }

        public AggregateQueriesValidator(IQueryHub hub, IServiceProvider provider)
        {
            hub.RegisterValidator<AggregateQueriesValidator, 
                PersonalInformationQuery, PersonalInformationQueryResult>(this);
            hub.RegisterValidator<AggregateQueriesValidator,
                VerificationDetailsQuery, VerificationDetailsQueryResult>(this);
            hub.RegisterValidator<AggregateQueriesValidator,
                FamilyMembersQuery, FamilyMembersQueryResult>(this);

            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
