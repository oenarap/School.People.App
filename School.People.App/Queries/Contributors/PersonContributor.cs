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
            try
            {
                var repository = (IOtherPeopleRepository)provider.GetService(typeof(IOtherPeopleRepository));
                var person = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);
                message.Data.Person = person.Copy();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task Handle(PersonnelQueryResult message)
        {
            try
            {
                var repository = (IPersonnelRepository)provider.GetService(typeof(IPersonnelRepository));
                var person = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);
                message.Data.Person = person.Copy();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task Handle(StudentQueryResult message)
        {
            try
            {
                var repository = (IStudentsRepository)provider.GetService(typeof(IStudentsRepository));
                var person = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);
                message.Data.Person = person.Copy();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public PersonContributor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
