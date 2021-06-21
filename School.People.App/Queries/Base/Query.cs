using System;
using Apps.Communication.Core;

namespace School.People.App.Queries
{
    public abstract class Query<TParam> : Query, IQuery<TParam>
    {
        public TParam Parameter { get; }

        protected Query(Guid id, TParam param)
            : base(id) { Parameter = param; }
    }

    public abstract class Query : IQuery
    {
        public Guid Id { get; }

        protected Query(Guid id)
        {
            Id = id;
        }
    }
}
