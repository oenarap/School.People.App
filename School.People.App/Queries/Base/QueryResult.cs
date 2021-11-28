using System;
using Apps.Communication.Core;

namespace School.People.App.Queries
{
    public abstract class QueryResult<TData, TParam> : QueryResult<TData>, IQueryResult<TData, TParam>
    {
        public TParam Parameter { get; }

        protected QueryResult(Guid id, TData data, TParam parameter)
            : base(id, data) { Parameter = parameter; }
    }

    public abstract class QueryResult<T> : QueryResult, IQueryResult<T>
    {
        public T Data { get => data; }
        
        protected QueryResult(Guid id, T data) 
            : base(id) { this.data = data; }

        [ThreadStatic]
        private readonly T data;
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
