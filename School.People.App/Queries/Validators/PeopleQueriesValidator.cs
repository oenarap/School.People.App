using System;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.App.Queries.Results;
using School.People.App.Queries.Data;

namespace School.People.App.Queries.Validators
{
    public class PeopleQueriesValidator : IHandle<AllStudentsQuery, AllStudentsQueryResult>, 
        IHandle<AllPersonnelQuery, AllPersonnelQueryResult>, IHandle<OtherPeopleQuery, OtherPeopleQueryResult>, 
        IHandle<ArchivedPeopleQuery, ArchivedPeopleQueryResult>
    {
        public Task<ArchivedPeopleQueryResult> Handle(ArchivedPeopleQuery query)
        {
            return Task.FromResult(new ArchivedPeopleQueryResult(query.Id, new PeopleQueryData()));
        }

        public Task<OtherPeopleQueryResult> Handle(OtherPeopleQuery query)
        {
            return Task.FromResult(new OtherPeopleQueryResult(query.Id, new PeopleQueryData()));
        }

        public Task<AllPersonnelQueryResult> Handle(AllPersonnelQuery query)
        {
            return Task.FromResult(new AllPersonnelQueryResult(query.Id, new PeopleQueryData()));
        }

        public Task<AllStudentsQueryResult> Handle(AllStudentsQuery query)
        {
            return Task.FromResult(new AllStudentsQueryResult(query.Id, new PeopleQueryData()));
        }
    }
}
