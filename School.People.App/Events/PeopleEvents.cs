using System;
using School.People.Core;


namespace School.People.App.Events
{
    public class OtherPersonArchivedEvent : Event<IPerson>
    {
        public OtherPersonArchivedEvent(Guid id, IPerson data)
            : base(id, data) { }
    }

    public class PersonnelArchivedEvent : Event<IPerson>
    {
        public PersonnelArchivedEvent(Guid id, IPerson data)
            : base(id, data) { }
    }

    public class StudentArchivedEvent : Event<IPerson>
    {
        public StudentArchivedEvent(Guid id, IPerson data)
            : base(id, data) { }
    }

    public class OtherPersonInsertedEvent : Event<IPerson>
    {
        public OtherPersonInsertedEvent(Guid id, IPerson data)
            : base(id, data) { }
    }

    public class PersonnelInsertedEvent : Event<IPerson>
    {
        public PersonnelInsertedEvent(Guid id, IPerson data)
            : base(id, data) { }
    }

    public class StudentInsertedEvent : Event<IPerson>
    {
        public StudentInsertedEvent(Guid id, IPerson data)
            : base(id, data) { }
    }

    public class PersonUpdatedEvent : Event<IPerson>
    {
        public PersonUpdatedEvent(Guid id, IPerson data)
            : base(id, data) { }
    }
}
