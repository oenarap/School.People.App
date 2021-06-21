using System;
using Apps.Communication.Core;

namespace School.People.App.Exceptions
{
    /// <summary>
    /// An exception thrown when a command cannot be mapped to a handler.
    /// </summary>
    public class UnrecognizedCommandException : Exception
    {
        public UnrecognizedCommandException()
            : this("A command's handler instance or its registered type could not be found.") { }
        public UnrecognizedCommandException(ICommand command)
            : this($"A {command.GetType().Name} handler instance or its registered type could not be found.") { }
        public UnrecognizedCommandException(string message)
            : base(message) { }
    }
}
