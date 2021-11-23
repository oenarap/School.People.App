using System;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.Core.DTOs;
using School.People.Core.Repositories;
using School.People.App.Queries.Results;

namespace School.People.App.Queries.Contributors
{
    public class PeopleContributor : IHandle<ArchivedPeopleQueryResult>, IHandle<AllStudentsQueryResult>, 
        IHandle<AllPersonnelQueryResult>, IHandle<OtherPeopleQueryResult>
    {
        public async Task Handle(OtherPeopleQueryResult message)
        {
            var repository = (IOtherPeopleRepository)provider.GetService(typeof(IOtherPeopleRepository));
            var people = await repository.ReadAllAsync().ConfigureAwait(false);

            foreach (var person in people)
            {
                message.Data.Add(new Person(person.Id, person.LastName, person.FirstName,
                    person.MiddleName, person.NameExtension, person.Title));
            }
        }

        public async Task Handle(AllPersonnelQueryResult message)
        {
            var repository = (IPersonnelRepository)provider.GetService(typeof(IPersonnelRepository));
            var people = await repository.ReadAllAsync().ConfigureAwait(false);

            foreach (var person in people)
            {
                message.Data.Add(new Person(person.Id, person.LastName, person.FirstName,
                    person.MiddleName, person.NameExtension, person.Title));
            }
        }

        public async Task Handle(AllStudentsQueryResult message)
        {
            var repository = (IStudentsRepository)provider.GetService(typeof(IStudentsRepository));
            var people = await repository.ReadAllAsync().ConfigureAwait(false);

            foreach (var person in people)
            {
                message.Data.Add(new Person(person.Id, person.LastName, person.FirstName,
                    person.MiddleName, person.NameExtension, person.Title));
            }
        }

        public async Task Handle(ArchivedPeopleQueryResult message)
        {
            var repository = (IArchivedPeopleRepository)provider.GetService(typeof(IArchivedPeopleRepository));
            var people = await repository.ReadAllAsync().ConfigureAwait(false);
            
            foreach (var person in people) 
            {
                message.Data.Add(new Person(person.Id, person.LastName, person.FirstName, 
                    person.MiddleName, person.NameExtension, person.Title)); 
            }
        }

        public PeopleContributor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
