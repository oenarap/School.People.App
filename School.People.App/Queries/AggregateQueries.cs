using System;

namespace School.People.App.Queries
{
    public class FamilyMembersAggregateQuery : Query<Guid>
    {
        public FamilyMembersAggregateQuery(Guid id, Guid param)
            : base(id, param) { }
    }

    public class VerificationDetailAggregateQuery : Query<Guid>
    {
        public VerificationDetailAggregateQuery(Guid id, Guid param)
            : base(id, param) { }
    }

    public class PersonalInformationAggregateQuery : Query<Guid>
    {
        public PersonalInformationAggregateQuery(Guid id, Guid param)
            : base(id, param) { }
    }
}
