using School.People.App.Queries.Models;
using System;

namespace School.People.App.Queries.Results
{
    public class VerificationDetailsQueryResult : QueryResult<VerificationDetailsQueryData>
    {
        public VerificationDetailsQueryResult(Guid id, VerificationDetailsQueryData data)
            : base(id, data) { }
    }

    public class FamilyMembersQueryResult : QueryResult<FamilyMembersQueryData>
    {
        public FamilyMembersQueryResult(Guid id, FamilyMembersQueryData data)
            : base(id, data) { }
    }

    public class PersonalInformationQueryResult : QueryResult<PersonalInformationQueryData>
    {
        public PersonalInformationQueryResult(Guid id, PersonalInformationQueryData data)
            : base(id, data) { }
    }
}
