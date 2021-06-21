using System;
using School.People.Core;

namespace School.People.App.Exceptions
{
    /// <summary>
    /// An exception thrown when an <see cref="IPerson"/> instance has invalid name detail(s).
    /// </summary>
    public class InvalidPersonException : Exception
    {
        public InvalidPersonException()
            : this("An IPerson instance has invalid name detail(s).") { }
        public InvalidPersonException(IPerson person)
            : this($"{person.FullName()} has invalid name detail(s).") { }
        public InvalidPersonException(string message)
            : base(message) { }
    }
}
