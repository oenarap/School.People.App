using System;
using Apps.Communication.Core;

namespace School.People.App.Commands
{
    /// <summary>
    /// Parameterized implementation of <see cref="ICommand"/> interface.
    /// </summary>
    /// <typeparam name="TData">Data type.</typeparam>
    /// <typeparam name="TParam">Parameter type.</typeparam>
    public abstract class Command<TData, TParam> : Command<TData>
    {
        /// <summary>
        /// Gets the parameter used to execute this command.
        /// </summary>
        public TParam Parameter { get; }

        protected Command(Guid commandId, Guid userId, TData data, TParam parameter)
            : base(commandId, userId, data) { Parameter = parameter; }
    }

    /// <summary>
    /// Base implementation of an <see cref="ICommand{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of data fed at execution time.</typeparam>
    public abstract class Command<T> : ICommand<T>
    {
        /// <summary>
        /// Gets the command's identifier.
        /// This property identifies the originator of this command.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the identifier of the user
        /// who issued this command.
        /// </summary>
        public Guid UserId { get; }

        /// <summary>
        /// Gets the <see cref="T"/> data used to execute this command.
        /// </summary>
        public T Data { get; }

        protected Command(Guid commandId, Guid userId, T data)
        {
            Id = commandId;
            UserId = userId;
            Data = data;
        }
    }
}
