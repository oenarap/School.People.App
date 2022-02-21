using School.People.Core.Dtos.Aggregates;
using System;

namespace School.People.App.Commands
{
    public class UpdatePersonVerificationDetailsCommand : Command<VerificationDetailsAggregate>
    {
        public UpdatePersonVerificationDetailsCommand(Guid commandId, Guid userId, VerificationDetailsAggregate data)
            : base(commandId, userId, data) { }
    }
}
