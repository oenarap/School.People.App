using School.People.Core.Dtos.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.People.App.Commands
{
    public class UpdatePersonVerificationDetailsCommand : Command<VerificationDetailsAggregate>
    {
        public UpdatePersonVerificationDetailsCommand(Guid id, VerificationDetailsAggregate data)
            : base(id, data) { }
    }
}
