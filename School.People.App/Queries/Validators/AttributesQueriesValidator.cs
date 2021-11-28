using System;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using Apps.Communication.Core;
using School.People.App.Queries.Results;
using System.Collections.Generic;
using School.People.Core.Attributes;
using School.People.App.Queries.Data;

namespace School.People.App.Queries.Validators
{
    public class AttributesQueriesValidator : IHandle<PersonDetailsQuery, PersonDetailsQueryResult>, 
        IHandle<EducationsQuery, EducationsQueryResult>, IHandle<EligibilitiesQuery, EligibilitiesQueryResult>, 
        IHandle<WorksQuery, WorksQueryResult>, IHandle<CivicWorksQuery, CivicWorksQueryResult>
    {
        public async Task<CivicWorksQueryResult> Handle(CivicWorksQuery message)
        {
            try
            {
                if (message.Parameter != Guid.Empty)
                {
                    var repository = (IPersonRepository)provider.GetService(typeof(IPersonRepository));
                    var person = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);

                    if (person != null)
                    {
                        return new CivicWorksQueryResult(message.Id, new List<ICivicWork>(), person.Id);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<WorksQueryResult> Handle(WorksQuery message)
        {
            try
            {
                if (message.Parameter != Guid.Empty)
                {
                    var repository = (IPersonRepository)provider.GetService(typeof(IPersonRepository));
                    var person = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);

                    if (person != null)
                    {
                        return new WorksQueryResult(message.Id, new List<IWork>(), person.Id);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<EligibilitiesQueryResult> Handle(EligibilitiesQuery message)
        {
            try
            {
                if (message.Parameter != Guid.Empty)
                {
                    var repository = (IPersonRepository)provider.GetService(typeof(IPersonRepository));
                    var person = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);

                    if (person != null)
                    {
                        return new EligibilitiesQueryResult(message.Id, new List<IEligibility>(), person.Id);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<EducationsQueryResult> Handle(EducationsQuery message)
        {
            try
            {
                if (message.Parameter != Guid.Empty)
                {
                    var repository = (IPersonRepository)provider.GetService(typeof(IPersonRepository));
                    var person = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);

                    if (person != null)
                    {
                        return new EducationsQueryResult(message.Id, new List<IEducation>(), person.Id);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<PersonDetailsQueryResult> Handle(PersonDetailsQuery message)
        {
            try
            {
                if (message.Parameter != Guid.Empty)
                {
                    var repository = (IPersonRepository)provider.GetService(typeof(IPersonRepository));
                    var person = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);

                    if (person != null)
                    {
                        return new PersonDetailsQueryResult(message.Id,
                            new PersonDetailsQueryData(), person.Id);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public AttributesQueriesValidator(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}
