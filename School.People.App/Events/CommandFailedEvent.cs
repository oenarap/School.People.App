using System;

namespace School.People.App.Events
{
    public class CommandFailedEvent : Event
    {
        public CommandFailedEvent(Guid id)
            : base(id) { }
    }
}
