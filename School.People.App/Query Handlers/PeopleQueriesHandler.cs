using System;
using School.People.Core;
using System.Threading.Tasks;
using School.People.Core.DTOs;
using Apps.Communication.Core;
using School.People.App.Queries;
using System.Collections.Generic;
using School.People.App.QueryResults;
using School.People.Core.Repositories;

namespace School.People.App.QueryHandlers
{
    public class PeopleQueriesHandler : IHandle<StudentQuery, StudentQueryResult>, IHandle<AllStudentsQuery, AllStudentsQueryResult>,
        IHandle<PersonnelQuery, PersonnelQueryResult>, IHandle<AllPersonnelQuery, AllPersonnelQueryResult>,
        IHandle<OtherPersonQuery, OtherPersonQueryResult>, IHandle<OtherPeopleQuery, OtherPeopleQueryResult>,
        IHandle<ArchivedPeopleQuery, ArchivedPeopleQueryResult>
    {
        public async Task<ArchivedPeopleQueryResult> Handle(ArchivedPeopleQuery query)
        {
            IEnumerable<IPerson> people = await ArchivedPeopleRepository.ReadAllAsync().ConfigureAwait(false);
            var list = new List<Person>();
            foreach (var p in people) { list.Add(new Person(p.Id, p.LastName, p.FirstName, p.MiddleName, p.NameExtension, p.Title)); }
            if (people != null) { return new ArchivedPeopleQueryResult(query.Id, list); }
            return null;
        }

        public async Task<OtherPeopleQueryResult> Handle(OtherPeopleQuery query)
        {
            IEnumerable<IPerson> people = await OtherPeopleRepository.ReadAllAsync().ConfigureAwait(false);
            var list = new List<Person>();
            foreach (var p in people) { list.Add(new Person(p.Id, p.LastName, p.FirstName, p.MiddleName, p.NameExtension, p.Title)); }
            if (people != null) { return new OtherPeopleQueryResult(query.Id, list); }
            return null;
        }

        public async Task<OtherPersonQueryResult> Handle(OtherPersonQuery query)
        {
            IPerson p = await OtherPeopleRepository.ReadAsync(query.Parameter).ConfigureAwait(false);
            if (p != null) { return new OtherPersonQueryResult(query.Id, p); }
            return null;
        }

        public async Task<AllPersonnelQueryResult> Handle(AllPersonnelQuery query)
        {
            IEnumerable<IPerson> people = await PersonnelRepository.ReadAllAsync().ConfigureAwait(false);
            var list = new List<Person>();
            foreach (var p in people) { list.Add(new Person(p.Id, p.LastName, p.FirstName, p.MiddleName, p.NameExtension, p.Title)); }
            if (people != null) { return new AllPersonnelQueryResult(query.Id, list); }
            return null;
        }

        public async Task<PersonnelQueryResult> Handle(PersonnelQuery query)
        {
            IPerson p = await PersonnelRepository.ReadAsync(query.Parameter).ConfigureAwait(false);
            if (p != null) { return new PersonnelQueryResult(query.Id, new Person(p.Id, p.LastName, p.FirstName, p.MiddleName, p.NameExtension, p.Title)); }
            return null;
        }

        public async Task<StudentQueryResult> Handle(StudentQuery query)
        {
            IPerson p = await StudentsRepository.ReadAsync(query.Parameter).ConfigureAwait(false);
            if (p != null) { return new StudentQueryResult(query.Id, new Person(p.Id, p.LastName, p.FirstName, p.MiddleName, p.NameExtension, p.Title)); }
            return null;
        }

        public async Task<AllStudentsQueryResult> Handle(AllStudentsQuery query)
        {
            IEnumerable<IPerson> people = await StudentsRepository.ReadAllAsync().ConfigureAwait(false);
            if (people != null) 
            {
                var list = new List<Person>();
                foreach (var p in people) { list.Add(new Person(p.Id, p.LastName, p.FirstName, p.MiddleName, p.NameExtension, p.Title)); }
                return new AllStudentsQueryResult(query.Id, list); 
            }
            return null;
        }

        public PeopleQueriesHandler(IStudentsRepository studentsRepository, IPersonnelRepository personnelRepository, 
            IOtherPeopleRepository otherPeopleRepository, IArchivedPeopleRepository archivedPeopleRepository)
        {
            ArchivedPeopleRepository = archivedPeopleRepository ?? throw new ArgumentNullException(nameof(archivedPeopleRepository));
            OtherPeopleRepository = otherPeopleRepository ?? throw new ArgumentNullException(nameof(otherPeopleRepository));
            PersonnelRepository = personnelRepository ?? throw new ArgumentNullException(nameof(personnelRepository));
            StudentsRepository = studentsRepository ?? throw new ArgumentNullException(nameof(studentsRepository));
        }

        private readonly IArchivedPeopleRepository ArchivedPeopleRepository;
        private readonly IOtherPeopleRepository OtherPeopleRepository;
        private readonly IPersonnelRepository PersonnelRepository;
        private readonly IStudentsRepository StudentsRepository;
    }
}
