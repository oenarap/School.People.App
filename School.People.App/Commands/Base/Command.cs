using System;
using Apps.Communication.Core;

namespace School.People.App.Commands
{
    /// <summary>
    /// Base implementation of an <see cref="ICommand{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The type of data fed at execution time.</typeparam>
    public abstract class Command<T> : ICommand<T>, IDisposable
    {
        /// <summary>
        /// Gets the command's identifier.
        /// This property identifies the originator of this instance.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the <see cref="T"/> data used to execute this command.
        /// </summary>
        public T Data { get; private set; }

        /// <summary>
        /// Gets the identifier of the data's origin.
        /// </summary>
        public Guid DataId { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // Dispose helper method
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing) { Data = default; }
                disposed = true;
            }
        }

        protected Command(Guid id, T data)
        {
            Id = id;
            Data = data;
        }

        // disposed flag
        private bool disposed = false;
    }
}
