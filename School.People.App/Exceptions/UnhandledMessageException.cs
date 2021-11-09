using System;
using Apps.Communication.Core;

namespace School.People.App.Exceptions
{
    /// <summary>
    /// An exception thrown when a message cannot be mapped to a validator or handler.
    /// </summary>
    public class UnhandledMessageException : Exception
    {
        public UnhandledMessageException()
            : this("A message's validator or handler instance could not be found.") { }
        public UnhandledMessageException(IMessage message)
            : this($"A {message.GetType().Name} validator or handler instance could not be found.") { }
        public UnhandledMessageException(string message)
            : base(message) { }
    }
}
