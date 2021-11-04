using System;
using Apps.Communication.Core;

namespace School.People.App.Commands
{
    /// <summary>
    /// Base implementation of an <see cref="ICommand{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of data fed at execution time.</typeparam>
    public abstract class Command<T> : ICommand<T>
    {
        /// <summary>
        /// Gets the command's identifier.
        /// This property identifies the originator of this instance.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the <see cref="T"/> data used to execute this command.
        /// </summary>
        public T Data { get; }

        /// <summary>
        /// Gets the identifier of the data's origin/owner.
        /// </summary>
        public Guid? DataId { get; }

        protected Command(Guid id, T data)
            : this(id, data, null) { }

        protected Command(Guid id, T data, Guid? dataId)
        {
            Id = id;
            Data = data;
            DataId = dataId;
        }
    }
}
