using System;
using School.People.Core;

namespace School.People.App.Commands
{
    public class InsertFatherChildCommand : Command<IPerson, Guid>
    {
        public InsertFatherChildCommand(Guid id, IPerson data, Guid param)
           : base(id, data, param) { }
    }

    public class InsertMotherChildCommand : Command<IPerson, Guid>
    {
        public InsertMotherChildCommand(Guid id, IPerson data, Guid param)
           : base(id, data, param) { }
    }

    public class UpdateSpouseCommand : Command<IPerson, Guid>
    {
        public UpdateSpouseCommand(Guid id, IPerson data, Guid param)
           : base(id, data, param) { }
    }

    public class UpdateFatherCommand : Command<IPerson, Guid>
    {
        public UpdateFatherCommand(Guid id, IPerson data, Guid param)
           : base(id, data, param) { }
    }

    public class UpdateMotherCommand : Command<IPerson, Guid>
    {
        public UpdateMotherCommand(Guid id, IPerson data, Guid param)
           : base(id, data, param) { }
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
