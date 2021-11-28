using System;
using Apps.Communication.Core;
using System.Threading.Tasks;
using School.People.App.Queries.Results;
using School.People.App.Queries.Data;

namespace School.People.App.Queries.Validators
{
    public class PersonQueriesValidator : IHandle<StudentQuery, StudentQueryResult>, 
        IHandle<PersonnelQuery, PersonnelQueryResult>, IHandle<OtherPersonQuery, OtherPersonQueryResult>
    {
        public Task<OtherPersonQueryResult> Handle(OtherPersonQuery query)
        {
            return Task.FromResult(new OtherPersonQueryResult(query.Id, new PersonQueryData(), query.Parameter));
        }

        public Task<PersonnelQueryResult> Handle(PersonnelQuery query)
        {
            return Task.FromResult(new PersonnelQueryResult(query.Id, new PersonQueryData(), query.Parameter));
        }

        public Task<StudentQueryResult> Handle(StudentQuery query)
        {
            return Task.FromResult(new StudentQueryResult(query.Id, new PersonQueryData(), query.Parameter));
        }
    }
}
