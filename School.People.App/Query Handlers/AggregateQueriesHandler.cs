using System;
using System.Threading.Tasks;
using School.People.App.Models;
using School.People.App.Queries;
using School.People.Core.Repositories;
using System.Collections.Generic;
using Apps.Communication.Core;
using School.People.App.QueryResults;

namespace School.People.App.Queries.Handlers
{
    public class AggregateQueriesHandler : IHandle<PersonalInformationAggregateQuery, PersonalInformationAggregateQueryResult>,
        IHandle<VerificationDetailAggregateQuery, VerificationDetailsAggregateQueryResult>,
        IHandle<FamilyMembersAggregateQuery, FamilyMembersAggregateQueryResult>
    {
        
        public Task<PersonalInformationAggregateQueryResult> Handle(PersonalInformationAggregateQuery query)
        {
            return Task.FromResult(new PersonalInformationAggregateQueryResult(query.Id, new PersonalInformationAggregate(query.Parameter))); 
        }

        public Task<VerificationDetailsAggregateQueryResult> Handle(VerificationDetailAggregateQuery query)
        {
            return Task.FromResult(new VerificationDetailsAggregateQueryResult(query.Id, new VerificationDetailsAggregate(query.Parameter)));
        }

        public Task<FamilyMembersAggregateQueryResult> Handle(FamilyMembersAggregateQuery query)
        {
            return Task.FromResult(new FamilyMembersAggregateQueryResult(query.Id, new FamilyMembersAggregate(query.Parameter)));
        }
    }
}
