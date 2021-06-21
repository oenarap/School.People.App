using System;

namespace School.People.App.Queries
{
    public class ArchivedPeopleQuery : Query
    {
        public ArchivedPeopleQuery(Guid id)
            : base(id) { }
    }

    public class OtherPersonQuery : Query<Guid>
    {
        public OtherPersonQuery(Guid id, Guid param)
           : base(id, param) { }
    }

    public class OtherPeopleQuery : Query
    {
        public OtherPeopleQuery(Guid id)
            : base(id) { }
    }

    public class PersonnelQuery : Query<Guid>
    {
        public PersonnelQuery(Guid id, Guid param)
           : base(id, param) { }
    }

    public class AllPersonnelQuery : Query
    {
        public AllPersonnelQuery(Guid id)
            : base(id) { }
    }

    public class StudentQuery : Query<Guid>
    {
        public StudentQuery(Guid id, Guid param)
            : base(id, param) { }
    }

    public class AllStudentsQuery : Query
    {
        public AllStudentsQuery(Guid id)
            : base(id) { }
    }
}
