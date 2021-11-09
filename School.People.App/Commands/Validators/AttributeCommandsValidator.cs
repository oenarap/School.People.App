using Apps.Communication.Core;
using System.Threading.Tasks;

namespace School.People.App.Commands.Validators
{
    public class AttributeCommandsValidator : IHandle<DeleteEligibilityCommand, bool>, IHandle<UpdateEligibilityCommand, bool>,
        IHandle<InsertEligibilityCommand, bool>, IHandle<InsertEducationCommand, bool>
    {
        public Task<bool> Handle(InsertEducationCommand message) => Task.FromResult(message.Data != null);

        public Task<bool> Handle(InsertEligibilityCommand message) => Task.FromResult(message.Data != null);

        public Task<bool> Handle(UpdateEligibilityCommand message) => Task.FromResult(message.Data != null);

        public Task<bool> Handle(DeleteEligibilityCommand message) => Task.FromResult(message.Data != null);

        public AttributeCommandsValidator(ICommandHub hub)
        {
            hub.RegisterValidator<DeleteEligibilityCommand, AttributeCommandsValidator>(this);
            hub.RegisterValidator<UpdateEligibilityCommand, AttributeCommandsValidator>(this);
            hub.RegisterValidator<InsertEligibilityCommand, AttributeCommandsValidator>(this);
            hub.RegisterValidator<InsertEducationCommand, AttributeCommandsValidator>(this);
        }
    }
}
