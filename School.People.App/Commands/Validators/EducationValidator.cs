using System;
using System.Threading.Tasks;
using Apps.Communication.Core;

namespace School.People.App.Commands.Validators
{
    public class EducationValidator : IHandle<InsertEducationCommand, bool>, IHandle<UpdateEducationCommand, bool>
    {
        public Task<bool> Handle(InsertEducationCommand message)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(UpdateEducationCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
