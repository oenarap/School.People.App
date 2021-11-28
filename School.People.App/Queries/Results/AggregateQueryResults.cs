using School.People.App.Queries.Data;
using System;

namespace School.People.App.Queries.Results
{
    public class VerificationDetailsQueryResult : QueryResult<VerificationDetailsQueryData, Guid>
    {
        public VerificationDetailsQueryResult(Guid id, VerificationDetailsQueryData data, Guid parameter)
            : base(id, data, parameter) { }
    }

    public class FamilyMembersQueryResult : QueryResult<FamilyMembersQueryData, Guid>
    {
        public FamilyMembersQueryResult(Guid id, FamilyMembersQueryData data, Guid parameter)
            : base(id, data, parameter) { }
    }

    public class PersonalInformationQueryResult : QueryResult<PersonalInformationQueryData, Guid>
    {
        public PersonalInformationQueryResult(Guid id, PersonalInformationQueryData data, Guid parameter)
            : base(id, data, parameter) { }
    }
}
