using System;
using School.People.Core;
using System.Collections.Generic;

namespace School.People.App.QueryResults
{
    public class ArchivedPeopleQueryResult : QueryResult<IEnumerable<IPerson>>
    {
        public ArchivedPeopleQueryResult(Guid id, IEnumerable<IPerson> data)
            : base(id, data) { }
    }

    public class OtherPeopleQueryResult : QueryResult<IEnumerable<IPerson>>
    {
        public OtherPeopleQueryResult(Guid id, IEnumerable<IPerson> data)
            : base(id, data) { }
    }

    public class OtherPersonQueryResult : QueryResult<IPerson>
    {
        public OtherPersonQueryResult(Guid id, IPerson data)
            : base(id, data) { }
    }

    public class AllPersonnelQueryResult : QueryResult<IEnumerable<IPerson>>
    {
        public AllPersonnelQueryResult(Guid id, IEnumerable<IPerson> data)
            : base(id, data) { }
    }

    public class PersonnelQueryResult : QueryResult<IPerson>
    {
        public PersonnelQueryResult(Guid id, IPerson data)
            : base(id, data) { }
    }

    public class AllStudentsQueryResult : QueryResult<IEnumerable<IPerson>>
    {
        public AllStudentsQueryResult(Guid id, IEnumerable<IPerson> data)
            : base(id, data) { }
    }

    public class StudentQueryResult : QueryResult<IPerson>
    {
        public StudentQueryResult(Guid id, IPerson data)
            : base(id, data) { }
    }
}
