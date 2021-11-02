using System;
using School.People.Core.Attributes;

namespace School.People.App.Events
{
    public class SpouseIdUpdatedEvent : Event<Guid?>
    {
        public SpouseIdUpdatedEvent(Guid id, Guid? data)
            : base(id, data) { }
    }

    public class FatherIdUpdatedEvent : Event<Guid>
    {
        public FatherIdUpdatedEvent(Guid id, Guid data)
            : base(id, data) { }
    }

    public class MotherIdUpdatedEvent : Event<Guid>
    {
        public MotherIdUpdatedEvent(Guid id, Guid data)
            : base(id, data) { }
    }

    public class ImagesUpdatedEvent : Event<IIdPicture>
    {
        public ImagesUpdatedEvent(Guid id, IIdPicture data)
            : base(id, data) { }
    }

    public class ContactDetailsUpdatedEvent : Event<IContactDetails>
    {
        public ContactDetailsUpdatedEvent(Guid id, IContactDetails data)
            : base(id, data) { }
    }

    public class AddressIdsUpdatedEvent : Event<IAddressIds>
    {
        public AddressIdsUpdatedEvent(Guid id, IAddressIds data)
            : base(id, data) { }
    }

    public class AgencyMemberDetailsUpdatedEvent : Event<IAgencyMemberDetails>
    {
        public AgencyMemberDetailsUpdatedEvent(Guid id, IAgencyMemberDetails data)
            : base(id, data) { }
    }

    public class DateOfBirthUpdatedEvent : Event<IDateOfBirth>
    {
        public DateOfBirthUpdatedEvent(Guid id, IDateOfBirth data)
            : base(id, data) { }
    }

    public class CitizenshipUpdatedEvent : Event<ICitizenship>
    {
        public CitizenshipUpdatedEvent(Guid id, ICitizenship data)
            : base(id, data) { }
    }

    public class FamilyIdsUpdatedEvent : Event<IFamilyIds>
    {
        public FamilyIdsUpdatedEvent(Guid id, IFamilyIds data)
            : base(id, data) { }
    }

    public class PersonDetailsUpdatedEvent : Event<IPersonDetails>
    {
        public PersonDetailsUpdatedEvent(Guid id, IPersonDetails data)
            : base(id, data) { }
    }
}
