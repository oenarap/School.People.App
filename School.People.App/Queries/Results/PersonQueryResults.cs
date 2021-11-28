using System;
using School.People.App.Queries.Data;

namespace School.People.App.Queries.Results
{
    public class StudentQueryResult : QueryResult<PersonQueryData, Guid>
    {
        public StudentQueryResult(Guid id, PersonQueryData data, Guid parameter)
            : base(id, data, parameter) { }
    }

    public class PersonnelQueryResult : QueryResult<PersonQueryData, Guid>
    {
        public PersonnelQueryResult(Guid id, PersonQueryData data, Guid parameter)
            : base(id, data, parameter) { }
    }

    public class OtherPersonQueryResult : QueryResult<PersonQueryData, Guid>
    {
        public OtherPersonQueryResult(Guid id, PersonQueryData data, Guid parameter)
            : base(id, data, parameter) { }
    }

    public class ArchivedPersonQueryResult : QueryResult<PersonQueryData, Guid>
    {
        public ArchivedPersonQueryResult(Guid id, PersonQueryData data, Guid parameter)
            : base(id, data, parameter) { }
    }
}
