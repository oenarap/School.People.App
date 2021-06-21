using System;
using System.Threading.Tasks;
using School.People.App.Queries;
using School.People.Core.Repositories;
using Apps.Communication.Core;
using School.People.App.QueryResults;

namespace School.People.App.QueryHandlers
{
    public class AttributesQueriesHandler : IHandle<PersonDetailsQuery, PersonDetailsQueryResult>, IHandle<EducationsQuery, EducationsQueryResult>,
        IHandle<EligibilitiesQuery, EligibilitiesQueryResult>, IHandle<WorksQuery, WorksQueryResult>, IHandle<CivicWorksQuery, CivicWorksQueryResult>
    {
        public async Task<CivicWorksQueryResult> Handle(CivicWorksQuery query)
        {
            var result = await CivicWorksRepository.ReadAsync(query.Parameter).ConfigureAwait(false);
            return new CivicWorksQueryResult(query.Id, result);
        }

        public async Task<WorksQueryResult> Handle(WorksQuery query)
        {
            var result = await WorksRepository.ReadAsync(query.Parameter).ConfigureAwait(false);
            return new WorksQueryResult(query.Id, result);
        }

        public async Task<EligibilitiesQueryResult> Handle(EligibilitiesQuery query)
        {
            var result = await EligibilitiesRepository.ReadAsync(query.Parameter).ConfigureAwait(false);
            return new EligibilitiesQueryResult(query.Id, result);
        }

        public async Task<EducationsQueryResult> Handle(EducationsQuery query)
        {
            var result = await EducationsRepository.ReadAsync(query.Parameter).ConfigureAwait(false);
            return new EducationsQueryResult(query.Id, result);
        }

        public async Task<PersonDetailsQueryResult> Handle(PersonDetailsQuery query)
        {
            var result = await PersonDetailsRepository.ReadAsync(query.Parameter).ConfigureAwait(false);
            return new PersonDetailsQueryResult(query.Id, result);
        }

        public AttributesQueriesHandler(IPersonDetailsRepository personalInformationsRepository, 
            IEducationsRepository educationsRepository, IEligibilitiesRepository eligibilitiesRepository, IWorksRepository worksRepository,
            ICivicWorksRepository civicWorksRepository)
        {
            PersonDetailsRepository = personalInformationsRepository ?? throw new ArgumentNullException(nameof(personalInformationsRepository));
            EligibilitiesRepository = eligibilitiesRepository ?? throw new ArgumentNullException(nameof(eligibilitiesRepository));
            CivicWorksRepository = civicWorksRepository ?? throw new ArgumentNullException(nameof(civicWorksRepository));
            EducationsRepository = educationsRepository ?? throw new ArgumentNullException(nameof(educationsRepository));
            WorksRepository = worksRepository ?? throw new ArgumentNullException(nameof(worksRepository));
        }

        private readonly IPersonDetailsRepository PersonDetailsRepository;
        private readonly IEligibilitiesRepository EligibilitiesRepository;
        private readonly ICivicWorksRepository CivicWorksRepository;
        private readonly IEducationsRepository EducationsRepository;
        private readonly IWorksRepository WorksRepository;
    }
}
