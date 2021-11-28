using System;
using School.People.App.Queries.Data;

namespace School.People.App.Queries.Results
{
    public class ArchivedPeopleQueryResult : QueryResult<PeopleQueryData>
    {
        public ArchivedPeopleQueryResult(Guid id, PeopleQueryData data)
            : base(id, data) { }
    }

    public class OtherPeopleQueryResult : QueryResult<PeopleQueryData>
    {
        public OtherPeopleQueryResult(Guid id, PeopleQueryData data)
            : base(id, data) { }
    }

    public class AllPersonnelQueryResult : QueryResult<PeopleQueryData>
    {
        public AllPersonnelQueryResult(Guid id, PeopleQueryData data)
            : base(id, data) { }
    }

    public class AllStudentsQueryResult : QueryResult<PeopleQueryData>
    {
        public AllStudentsQueryResult(Guid id, PeopleQueryData data)
            : base(id, data) { }
    }
}
