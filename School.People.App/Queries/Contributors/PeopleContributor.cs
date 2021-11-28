using System;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.Core.Repositories;
using School.People.App.Queries.Results;

namespace School.People.App.Queries.Contributors
{
    public class PeopleContributor : IHandle<ArchivedPeopleQueryResult>, IHandle<AllStudentsQueryResult>, 
        IHandle<AllPersonnelQueryResult>, IHandle<OtherPeopleQueryResult>
    {
        public async Task Handle(OtherPeopleQueryResult message)
        {
            try
            {
                var repository = (IOtherPeopleRepository)provider.GetService(typeof(IOtherPeopleRepository));
                var people = await repository.ReadAllAsync().ConfigureAwait(false);
                message.Data.People = people;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task Handle(AllPersonnelQueryResult message)
        {
            try
            {
                var repository = (IPersonnelRepository)provider.GetService(typeof(IPersonnelRepository));
                var people = await repository.ReadAllAsync().ConfigureAwait(false);
                message.Data.People = people;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task Handle(AllStudentsQueryResult message)
        {
            try
            {
                var repository = (IStudentsRepository)provider.GetService(typeof(IStudentsRepository));
                var people = await repository.ReadAllAsync().ConfigureAwait(false);
                message.Data.People = people;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task Handle(ArchivedPeopleQueryResult message)
        {
            try
            {
                var repository = (IArchivedPeopleRepository)provider.GetService(typeof(IArchivedPeopleRepository));
                var people = await repository.ReadAllAsync().ConfigureAwait(false);
                message.Data.People = people;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public PeopleContributor(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
