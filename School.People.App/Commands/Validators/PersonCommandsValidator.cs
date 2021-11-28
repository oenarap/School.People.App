using Apps.Communication.Core;
using System;
using System.Threading.Tasks;

namespace School.People.App.Commands.Validators
{
    public class PersonCommandsValidator : IHandle<UpdateMotherCommand, bool>, IHandle<UpdateFatherCommand, bool>,
        IHandle<UpdateSpouseCommand, bool>, IHandle<InsertFatherChildCommand, bool>
    {
        public Task<bool> Handle(InsertFatherChildCommand message) => Task.FromResult(message.Parameter != Guid.Empty);

        public Task<bool> Handle(UpdateSpouseCommand message) => Task.FromResult(message.Parameter != Guid.Empty);

        public Task<bool> Handle(UpdateMotherCommand message) => Task.FromResult(message.Parameter != Guid.Empty);

        public Task<bool> Handle(UpdateFatherCommand message) => Task.FromResult(message.Parameter != Guid.Empty);
    }
}
