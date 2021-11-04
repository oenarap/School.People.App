using System;
using Apps.Communication.Core;

namespace School.People.App.QueryResults
{
    public abstract class QueryResult<T> : QueryResult, IQueryResult<T>
    {
        public T Data { get; private set; }
        
        protected QueryResult(Guid id, T data) 
            : base(id) { Data = data; }
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
