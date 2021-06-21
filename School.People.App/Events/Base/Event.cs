﻿using System;
using Apps.Communication.Core;

namespace School.People.App.Events
{
    public abstract class Event<T> : Event, IEvent<T>
    {
        public T Data { get; }

        protected Event(Guid id, T data)
            : base(id) { Data = data; }
    }

    public abstract class Event : IEvent
    {
        public Guid Id { get; }

        protected Event(Guid id)
        {
            Id = id;
        }
    }
}