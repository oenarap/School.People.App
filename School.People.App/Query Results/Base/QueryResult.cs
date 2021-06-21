using System;
using Apps.Communication.Core;

namespace School.People.App.QueryResults
{
    public abstract class QueryResult<T> : QueryResult, IQueryResult<T>
    {
        public T Data { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // dispose helper method
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Data = default;
                }
                disposed = true;
            }
        }

        protected QueryResult(Guid id, T data) 
            : base(id) { Data = data; }

        // disposed flag
        private bool disposed = false;
    }

    public abstract class QueryResult : IQueryResult
    {
        public Guid Id { get; }

        protected QueryResult(Guid id)
        {
            Id = id;
        }
    }
}
