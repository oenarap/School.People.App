using System;
using School.People.Core;

namespace School.People.App.Commands
{
    public class InsertFatherChildCommand : Command<IPerson>
    {
        public InsertFatherChildCommand(Guid id, IPerson data)
           : base(id, data) { }
    }

    public class InsertMotherChildCommand : Command<IPerson>
    {
        public InsertMotherChildCommand(Guid id, IPerson data)
           : base(id, data) { }
    }

    public class UpdateChildCommand : Command<IPerson>
    {
        public UpdateChildCommand(Guid id, IPerson data)
           : base(id, data) { }
    }

    public class UpdateSpouseCommand : Command<IPerson>
    {
        public UpdateSpouseCommand(Guid id, IPerson data)
           : base(id, data) { }
    }

    public class UpdateFatherCommand : Command<IPerson>
    {
        public UpdateFatherCommand(Guid id, IPerson data)
           : base(id, data) { }
    }

    public class UpdateMotherCommand : Command<IPerson>
    {
        public UpdateMotherCommand(Guid id, IPerson data)
           : base(id, data) { }
    }

    public class ArchiveStudentCommand : Command<IPerson>
    {
        public ArchiveStudentCommand(Guid id, IPerson data)
            : base(id, data) { }
    }

    public class ArchivePersonnelCommand : Command<IPerson>
    {
        public ArchivePersonnelCommand(Guid id, IPerson data)
            : base(id, data) { }
    }

    public class ArchiveOtherPersonCommand : Command<IPerson>
    {
        public ArchiveOtherPersonCommand(Guid id, IPerson data)
            : base(id, data) { }
    }

    public class InsertStudentCommand : Command<IPerson>
    {
        public InsertStudentCommand(Guid id, IPerson data)
            : base(id, data) { }
    }

    public class InsertPersonnelCommand : Command<IPerson>
    {
        public InsertPersonnelCommand(Guid id, IPerson data)
            : base(id, data) { }
    }

    public class InsertOtherPersonCommand : Command<IPerson>
    {
        public InsertOtherPersonCommand(Guid id, IPerson data)
            : base(id, data) { }
    }

    public class UpdatePersonCommand : Command<IPerson>
    {
        public UpdatePersonCommand(Guid id, IPerson data)
            : base(id, data) { }
    }
}
