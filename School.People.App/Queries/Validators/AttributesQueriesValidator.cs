﻿using System;
using System.Threading.Tasks;
using School.People.Core.Repositories;
using Apps.Communication.Core;
using School.People.App.Queries.Results;
using School.People.Core.DTOs;
using System.Collections.Generic;
using School.People.Core.Attributes;

namespace School.People.App.Queries.Validators
{
    public class AttributesQueriesValidator : IHandle<PersonDetailsQuery, PersonDetailsQueryResult>, 
        IHandle<EducationsQuery, EducationsQueryResult>, IHandle<EligibilitiesQuery, EligibilitiesQueryResult>, 
        IHandle<WorksQuery, WorksQueryResult>, IHandle<CivicWorksQuery, CivicWorksQueryResult>
    {
        public async Task<CivicWorksQueryResult> Handle(CivicWorksQuery message)
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

        public async Task<WorksQueryResult> Handle(WorksQuery message)
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

        public async Task<EligibilitiesQueryResult> Handle(EligibilitiesQuery message)
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

        public async Task<EducationsQueryResult> Handle(EducationsQuery message)
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

        public async Task<PersonDetailsQueryResult> Handle(PersonDetailsQuery message)
        {
            if (message.Parameter != Guid.Empty)
            {
                var repository = (IPersonRepository)provider.GetService(typeof(IPersonRepository));
                var person = await repository.ReadAsync(message.Parameter).ConfigureAwait(false);

                if (person != null)
                {
                    var data = new PersonDetails(person.Id);
                    return new PersonDetailsQueryResult(message.Id, data);
                }
            }

            return null;
        }

        public AttributesQueriesValidator(IQueryHub hub, IServiceProvider provider)
        {
            hub.RegisterValidator<AttributesQueriesValidator,
                PersonDetailsQuery, PersonDetailsQueryResult>(this);
            hub.RegisterValidator<AttributesQueriesValidator,
                EducationsQuery, EducationsQueryResult>(this);
            hub.RegisterValidator<AttributesQueriesValidator,
                EligibilitiesQuery, EligibilitiesQueryResult>(this);
            hub.RegisterValidator<AttributesQueriesValidator,
                WorksQuery, WorksQueryResult>(this);
            hub.RegisterValidator<AttributesQueriesValidator,
                CivicWorksQuery, CivicWorksQueryResult>(this);

            this.provider = provider;
        }

        private readonly IServiceProvider provider;
    }
}