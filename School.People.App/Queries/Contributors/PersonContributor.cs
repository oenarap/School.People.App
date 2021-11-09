using System;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.App.Queries.Results;
using School.People.Core.Repositories;

namespace School.People.App.Queries.Contributors
{
    public class PersonContributor : IHandle<StudentQueryResult>, 
        IHandle<PersonnelQueryResult>, IHandle<OtherPersonQueryResult>
    {
        public async Task Handle(OtherPersonQueryResult message)
        {
            var repository = (IOtherPeopleRepository)provider.GetService(typeof(IOtherPeopleRepository));
            var person = await repository.ReadAsync(message.Data.Id).ConfigureAwait(false);
            person?.CopyTo(message.Data);
        }

        public async Task Handle(PersonnelQueryResult message)
        {
            var repository = (IPersonnelRepository)provider.GetService(typeof(IPersonnelRepository));
            var person = await repository.ReadAsync(message.Data.Id).ConfigureAwait(false);
            person?.CopyTo(message.Data);
        }

        public async Task Handle(StudentQueryResult message)
        {
            var repository = (IStudentsRepository)provider.GetService(typeof(IStudentsRepository));
            var person = await repository.ReadAsync(message.Data.Id).ConfigureAwait(false);
            person?.CopyTo(message.Data);
        }

        public PersonContributor(IQueryHub hub, IServiceProvider provider)
        {
            hub.RegisterContributor<PersonContributor, StudentQueryResult>(this);
            hub.RegisterContributor<PersonContributor, PersonnelQueryResult>(this);
            hub.RegisterContributor<PersonContributor, OtherPersonQueryResult>(this);

            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
