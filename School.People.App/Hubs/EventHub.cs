using System;
using Apps.Communication.Core;
using System.Collections.Generic;

namespace School.People.App.Hubs
{
    public class EventHub : IEventHub 
    {
        public void Dispatch<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var key = typeof(TEvent);

            if (handlers.ContainsKey(key))
            {
                foreach (var reference in handlers[key])
                {
                    if (reference.IsAlive && reference.Target is IHandle<TEvent> handler)
                    {
                        handler.Handle(@event).FireAndForget(false, OnEventHandlingExceptionCallback);
                    }
                }
            }
        }

        public void RegisterHandler<TEvent, THandler>(THandler handler) where TEvent : IEvent where THandler : IHandle<TEvent>
        {
            var key = typeof(TEvent);
            var reference = new WeakReference(handler);

            if (handlers.ContainsKey(key))
            {
                handlers[key].Add(reference);
            }
            else
            {
                var references = new HashSet<WeakReference>() { reference };
                handlers.Add(key, references);
            }
        }

        protected virtual void OnEventHandlingExceptionCallback(Exception ex)
        {
            var message = $"{ex.Source} has encountered an exception. \n\n {ex.Message}";
            throw new Exception(message, ex.InnerException);
        }

        public EventHub()
        {
            handlers = new Dictionary<Type, HashSet<WeakReference>>();
        }

        private readonly Dictionary<Type, HashSet<WeakReference>> handlers;
    }
}
