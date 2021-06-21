using System;
using School.People.Core.Attributes;
using School.People.App.Models;
using System.Collections.Generic;

namespace School.People.App.QueryResults
{
    public class VerificationDetailsQueryResult : QueryResult<VerificationDetailsAggregate>
    {
        public VerificationDetailsQueryResult(Guid id, VerificationDetailsAggregate data)
            : base(id, data) { }
    }

    public class FaqsQueryResult : QueryResult<IFaqs>
    {
        public FaqsQueryResult(Guid id, IFaqs data)
            : base(id, data) { }
    }

    public class OtherInformationQueryResult : QueryResult<IEnumerable<IOtherInformation>>
    {
        public OtherInformationQueryResult(Guid id, IEnumerable<IOtherInformation> data)
            : base(id, data) { }
    }

    public class TrainingsQueryResult : QueryResult<IEnumerable<ITraining>>
    {
        public TrainingsQueryResult(Guid id, IEnumerable<ITraining> data)
            : base(id, data) { }
    }

    public class CivicWorksQueryResult : QueryResult<IEnumerable<ICivicWork>>
    {
        public CivicWorksQueryResult(Guid id, IEnumerable<ICivicWork> data)
            : base(id, data) { }
    }

    public class WorksQueryResult : QueryResult<IEnumerable<IWork>>
    {
        public WorksQueryResult(Guid id, IEnumerable<IWork> data)
            : base(id, data) { }
    }

    public class EligibilitiesQueryResult : QueryResult<IEnumerable<IEligibility>>
    {
        public EligibilitiesQueryResult(Guid id, IEnumerable<IEligibility> data)
            : base(id, data) { }
    }

    public class EducationsQueryResult : QueryResult<IEnumerable<IEducation>>
    {
        public EducationsQueryResult(Guid id, IEnumerable<IEducation> data)
            : base(id, data) { }
    }

    public class PersonDetailsQueryResult : QueryResult<IPersonDetails>
    {
        public PersonDetailsQueryResult(Guid id, IPersonDetails data)
            : base(id, data) { }
    }
}
