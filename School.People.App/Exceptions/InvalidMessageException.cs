using System;
using Apps.Communication.Core;

namespace School.People.App.Exceptions
{
    public class InvalidMessageException : Exception
    {
        public InvalidMessageException()
            : this("A dispatch request's message is not valid for handling.") { }
        public InvalidMessageException(IMessage message)
            : this($"{message.GetType().Name} is not valid for handling.") { }
        public InvalidMessageException(string message)
            : base(message) { }
    }
}
