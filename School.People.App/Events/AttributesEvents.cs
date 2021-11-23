using System;
using School.People.Core.Attributes;

namespace School.People.App.Events
{
    public class FaqsUpdatedEvent : Event<IFaqs>
    {
        public FaqsUpdatedEvent(Guid id, IFaqs data)
            : base(id, data) { }
    }

    public class OtherInformationInsertedEvent : Event<IOtherInformation>
    {
        public OtherInformationInsertedEvent(Guid id, IOtherInformation data)
            : base(id, data) { }
    }

    public class OtherInformationUpdatedEvent : Event<IOtherInformation>
    {
        public OtherInformationUpdatedEvent(Guid id, IOtherInformation data)
            : base(id, data) { }
    }

    public class OtherInformationDeletedEvent : Event<IOtherInformation>
    {
        public OtherInformationDeletedEvent(Guid id, IOtherInformation data)
            : base(id, data) { }
    }

    public class TrainingInsertedEvent : Event<ITraining>
    {
        public TrainingInsertedEvent(Guid id, ITraining data)
            : base(id, data) { }
    }

    public class TrainingUpdatedEvent : Event<ITraining>
    {
        public TrainingUpdatedEvent(Guid id, ITraining data)
            : base(id, data) { }
    }

    public class TrainingDeletedEvent : Event<ITraining>
    {
        public TrainingDeletedEvent(Guid id, ITraining data)
            : base(id, data) { }
    }

    public class CivicWorkInsertedEvent : Event<ICivicWork>
    {
        public CivicWorkInsertedEvent(Guid id, ICivicWork data)
            : base(id, data) { }
    }

    public class CivicWorkUpdatedEvent : Event<ICivicWork>
    {
        public CivicWorkUpdatedEvent(Guid id, ICivicWork data)
            : base(id, data) { }
    }

    public class CivicWorkDeletedEvent : Event<ICivicWork>
    {
        public CivicWorkDeletedEvent(Guid id, ICivicWork data)
            : base(id, data) { }
    }

    public class WorkInsertedEvent : Event<IWork>
    {
        public WorkInsertedEvent(Guid id, IWork data)
            : base(id, data) { }
    }

    public class WorkUpdatedEvent : Event<IWork>
    {
        public WorkUpdatedEvent(Guid id, IWork data)
            : base(id, data) { }
    }

    public class WorkDeletedEvent : Event<IWork>
    {
        public WorkDeletedEvent(Guid id, IWork data)
            : base(id, data) { }
    }

    public class EducationDeletedEvent : Event<IEducation>
    {
        public EducationDeletedEvent(Guid id, IEducation data)
            : base(id, data) { }
    }

    public class EducationUpdatedEvent : Event<IEducation>
    {
        public EducationUpdatedEvent(Guid id, IEducation data)
            : base(id, data) { }
    }

    public class EducationInsertedEvent : Event<IEducation>
    {
        public EducationInsertedEvent(Guid id, IEducation data)
            : base(id, data) { }
    }

    public class EligibilityInsertedEvent : Event<IEligibility>
    {
        public EligibilityInsertedEvent(Guid id, IEligibility data)
            : base(id, data) { }
    }

    public class EligibilityUpdatedEvent : Event<IEligibility>
    {
        public EligibilityUpdatedEvent(Guid id, IEligibility data)
            : base(id, data) { }
    }

    public class EligibilityDeletedEvent : Event<IEligibility>
    {
        public EligibilityDeletedEvent(Guid id, IEligibility data)
            : base(id, data) { }
    }
}
