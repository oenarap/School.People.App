using System;
using School.People.Core.Attributes;
using System.Collections.Generic;
using School.People.App.Queries.Data;

namespace School.People.App.Queries.Results
{
    public class FaqsQueryResult : QueryResult<IFaqs, Guid>
    {
        public FaqsQueryResult(Guid id, IFaqs data, Guid parameter)
            : base(id, data, parameter) { }
    }

    public class OtherInformationQueryResult : QueryResult<List<IOtherInformation>, Guid>
    {
        public OtherInformationQueryResult(Guid id, List<IOtherInformation> data, Guid parameter)
            : base(id, data, parameter) { }
    }

    public class TrainingsQueryResult : QueryResult<List<ITraining>, Guid>
    {
        public TrainingsQueryResult(Guid id, List<ITraining> data, Guid parameter)
            : base(id, data, parameter) { }
    }

    public class CivicWorksQueryResult : QueryResult<List<ICivicWork>, Guid>
    {
        public CivicWorksQueryResult(Guid id, List<ICivicWork> data, Guid parameter)
            : base(id, data, parameter) { }
    }

    public class WorksQueryResult : QueryResult<List<IWork>, Guid>
    {
        public WorksQueryResult(Guid id, List<IWork> data, Guid parameter)
            : base(id, data, parameter) { }
    }

    public class EligibilitiesQueryResult : QueryResult<List<IEligibility>, Guid>
    {
        public EligibilitiesQueryResult(Guid id, List<IEligibility> data, Guid parameter)
            : base(id, data, parameter) { }
    }

    public class EducationsQueryResult : QueryResult<List<IEducation>, Guid>
    {
        public EducationsQueryResult(Guid id, List<IEducation> data, Guid parameter)
            : base(id, data, parameter) { }
    }

    public class PersonDetailsQueryResult : QueryResult<PersonDetailsQueryData, Guid>
    {
        public PersonDetailsQueryResult(Guid id, PersonDetailsQueryData data, Guid parameter)
            : base(id, data, parameter) { }
    }
}
