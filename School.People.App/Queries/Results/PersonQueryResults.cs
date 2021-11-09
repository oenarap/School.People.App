using System;
using School.People.Core.DTOs;

namespace School.People.App.Queries.Results
{
    public class StudentQueryResult : QueryResult<Person>
    {
        public StudentQueryResult(Guid id, Person data)
            : base(id, data) { }
    }

    public class PersonnelQueryResult : QueryResult<Person>
    {
        public PersonnelQueryResult(Guid id, Person data)
            : base(id, data) { }
    }

    public class OtherPersonQueryResult : QueryResult<Person>
    {
        public OtherPersonQueryResult(Guid id, Person data)
            : base(id, data) { }
    }

    public class ArchivedPersonQueryResult : QueryResult<Person>
    {
        public ArchivedPersonQueryResult(Guid id, Person data)
            : base(id, data) { }
    }
}
