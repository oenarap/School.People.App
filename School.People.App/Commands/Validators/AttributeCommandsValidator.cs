using Apps.Communication.Core;
using System.Threading.Tasks;

namespace School.People.App.Commands.Validators
{
    public class AttributeCommandsValidator : IHandle<DeleteEligibilityCommand, bool>, 
        IHandle<UpdateEligibilityCommand, bool>, IHandle<InsertEligibilityCommand, bool>, 
        IHandle<InsertEducationCommand, bool>, IHandle<UpdateEducationCommand, bool>,
        IHandle<DeleteEducationCommand, bool>, IHandle<InsertWorkCommand, bool>, IHandle<UpdateWorkCommand, bool>,
        IHandle<DeleteWorkCommand, bool>, IHandle<InsertCivicWorkCommand, bool>, IHandle<UpdateCivicWorkCommand, bool>,
        IHandle<DeleteCivicWorkCommand, bool>, IHandle<InsertTrainingCommand, bool>, IHandle<UpdateTrainingCommand, bool>,
        IHandle<DeleteTrainingCommand, bool>, IHandle<InsertOtherInformationCommand, bool>,
        IHandle<UpdateOtherInformationCommand, bool>, IHandle<DeleteOtherInformationCommand, bool>,
        IHandle<UpdateFaqsCommand, bool>
    {
        public Task<bool> Handle(UpdateFaqsCommand message) => Task.FromResult(message.Data != null);

        public Task<bool> Handle(InsertOtherInformationCommand message) => Task.FromResult(message.Data != null);
        public Task<bool> Handle(UpdateOtherInformationCommand message) => Task.FromResult(message.Data != null);
        public Task<bool> Handle(DeleteOtherInformationCommand message) => Task.FromResult(message.Data != null);

        public Task<bool> Handle(InsertTrainingCommand message) => Task.FromResult(message.Data != null);
        public Task<bool> Handle(UpdateTrainingCommand message) => Task.FromResult(message.Data != null);
        public Task<bool> Handle(DeleteTrainingCommand message) => Task.FromResult(message.Data != null);

        public Task<bool> Handle(InsertCivicWorkCommand message) => Task.FromResult(message.Data != null);
        public Task<bool> Handle(UpdateCivicWorkCommand message) => Task.FromResult(message.Data != null);
        public Task<bool> Handle(DeleteCivicWorkCommand message) => Task.FromResult(message.Data != null);

        public Task<bool> Handle(InsertWorkCommand message) => Task.FromResult(message.Data != null);
        public Task<bool> Handle(UpdateWorkCommand message) => Task.FromResult(message.Data != null);
        public Task<bool> Handle(DeleteWorkCommand message) => Task.FromResult(message.Data != null);

        public Task<bool> Handle(InsertEducationCommand message) => Task.FromResult(message.Data != null);
        public Task<bool> Handle(UpdateEducationCommand message) => Task.FromResult(message.Data != null);
        public Task<bool> Handle(DeleteEducationCommand message) => Task.FromResult(message.Data != null);

        public Task<bool> Handle(InsertEligibilityCommand message) => Task.FromResult(message.Data != null);
        public Task<bool> Handle(UpdateEligibilityCommand message) => Task.FromResult(message.Data != null);
        public Task<bool> Handle(DeleteEligibilityCommand message) => Task.FromResult(message.Data != null);
    }
}
