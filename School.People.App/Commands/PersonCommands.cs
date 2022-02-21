using System;
using School.People.Core;

namespace School.People.App.Commands
{
    public class InsertFatherChildCommand : Command<IPerson, Guid>
    {
        public InsertFatherChildCommand(Guid commandId, Guid userId, IPerson data, Guid parameter)
           : base(commandId, userId, data, parameter) { }
    }

    public class InsertMotherChildCommand : Command<IPerson, Guid>
    {
        public InsertMotherChildCommand(Guid commandId, Guid userId, IPerson data, Guid parameter)
           : base(commandId, userId, data, parameter) { }
    }

    public class UpdateSpouseCommand : Command<IPerson, Guid>
    {
        public UpdateSpouseCommand(Guid commandId, Guid userId, IPerson data, Guid parameter)
           : base(commandId, userId, data, parameter) { }
    }

    public class UpdateFatherCommand : Command<IPerson, Guid>
    {
        public UpdateFatherCommand(Guid commandId, Guid userId, IPerson data, Guid parameter)
           : base(commandId, userId, data, parameter) { }
    }

    public class UpdateMotherCommand : Command<IPerson, Guid>
    {
        public UpdateMotherCommand(Guid commandId, Guid userId, IPerson data, Guid parameter)
           : base(commandId, userId, data, parameter) { }
    }

    public class ArchiveStudentCommand : Command<IPerson>
    {
        public ArchiveStudentCommand(Guid commandId, Guid userId, IPerson data)
            : base(commandId, userId, data) { }
    }

    public class ArchivePersonnelCommand : Command<IPerson>
    {
        public ArchivePersonnelCommand(Guid commandId, Guid userId, IPerson data)
            : base(commandId, userId, data) { }
    }

    public class ArchiveOtherPersonCommand : Command<IPerson>
    {
        public ArchiveOtherPersonCommand(Guid commandId, Guid userId, IPerson data)
            : base(commandId, userId, data) { }
    }

    public class InsertStudentCommand : Command<IPerson>
    {
        public InsertStudentCommand(Guid commandId, Guid userId, IPerson data)
            : base(commandId, userId, data) { }
    }

    public class InsertPersonnelCommand : Command<IPerson>
    {
        public InsertPersonnelCommand(Guid commandId, Guid userId, IPerson data)
            : base(commandId, userId, data) { }
    }

    public class InsertOtherPersonCommand : Command<IPerson>
    {
        public InsertOtherPersonCommand(Guid commandId, Guid userId, IPerson data)
            : base(commandId, userId, data) { }
    }

    public class UpdatePersonCommand : Command<IPerson>
    {
        public UpdatePersonCommand(Guid commandId, Guid userId, IPerson data)
            : base(commandId, userId, data) { }
    }
}
