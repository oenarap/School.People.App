using System;
using Apps.Communication.Core;

namespace School.People.App.Exceptions
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException()
            : this("A dispatch request's command is not qualified for execution.") { }
        public InvalidCommandException(ICommand command)
            : this($"{command.GetType().Name} is not qualified for execution.") { }
        public InvalidCommandException(string message)
            : base(message) { }
    }
}
