using System;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.App.Queries.Results;
using School.People.App.Queries.Models;

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

        public PeopleQueriesValidator(IQueryHub hub)
        {
            
            hub.RegisterValidator<PeopleQueriesValidator,
                AllStudentsQuery, AllStudentsQueryResult>(this);
            hub.RegisterValidator<PeopleQueriesValidator,
                AllPersonnelQuery, AllPersonnelQueryResult>(this);
            hub.RegisterValidator<PeopleQueriesValidator,
                OtherPeopleQuery, OtherPeopleQueryResult>(this);
            hub.RegisterValidator<PeopleQueriesValidator,
                ArchivedPeopleQuery, ArchivedPeopleQueryResult>(this);
        }
    }
}
