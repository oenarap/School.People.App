using System;

namespace School.People.App.Queries
{
    public class FamilyMembersQuery : Query<Guid>
    {
        public FamilyMembersQuery(Guid id, Guid param)
            : base(id, param) { }
    }

    public class VerificationDetailsQuery : Query<Guid>
    {
        public VerificationDetailsQuery(Guid id, Guid param)
           : base(id, param) { }
    }

    public class PersonalInformationQuery : Query<Guid>
    {
        public PersonalInformationQuery(Guid id, Guid param)
            : base(id, param) { }
    }
}
