﻿using System;
using School.People.App.Models;

namespace School.People.App.QueryResults
{
    public class VerificationDetailsAggregateQueryResult : QueryResult<VerificationDetailsAggregate>
    {
        public VerificationDetailsAggregateQueryResult(Guid id, VerificationDetailsAggregate data)
            : base(id, data) { }
    }

    public class FamilyMembersAggregateQueryResult : QueryResult<FamilyMembersAggregate>
    {
        public FamilyMembersAggregateQueryResult(Guid id, FamilyMembersAggregate data)
            : base(id, data) { }
    }

    public class PersonalInformationAggregateQueryResult : QueryResult<PersonalInformationAggregate>
    {
        public PersonalInformationAggregateQueryResult(Guid id, PersonalInformationAggregate data)
            : base(id, data) { }
    }
}
