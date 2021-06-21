using System;
using Apps.Communication.Core;
using System.Collections.Generic;

namespace School.People.App.Hubs
{
    public class EventHub : Hub, IEventHub
    {
        /// <summary>
        /// A method that is invoked to throw an exception
        /// whilst handling an event in a fire-and-forget manner.
        /// </summary>
        /// <param name="ex">The exception to be (re-)thrown.</param>
        protected virtual void OnHandlingException(Exception ex)
        {
            throw new Exception($"An exception was encountered while handling the event. \n\n {ex.Message}", ex.InnerException);
        }

        /// <summary>
        /// Requests the hub to dispatch an event.
        /// </summary>
        /// <typeparam name="TEvent">Event's type.</typeparam>
        /// <param name="@event">An event instance to be dispatched.</param>
        public void Dispatch<TEvent>(TEvent @event) where TEvent : IEvent
        {
            Type key = typeof(TEvent);

            if (LiveHandlersReferences.ContainsKey(key))
            {
                foreach (var reference in LiveHandlersReferences[key])
                {
                    if (reference.IsAlive && reference.Target is IHandle<TEvent> handler)
                    {
                        handler.Handle(@event).FireAndForget(false, OnHandlingException);
                    }
                }
            }
            else
            {
                if (RegisteredHandlers.ContainsKey(key))
                {
                    List<WeakReference> handlerReferences = new List<WeakReference>();

                    foreach (var handlerType in RegisteredHandlers[key])
                    {
                        if (ServiceProvider.GetService(handlerType) is IHandle<TEvent> handler)
                        {
                            handler.Handle(@event).FireAndForget(false, OnHandlingException);
                            handlerReferences.Add(new WeakReference(handler));
                        }
                    }

                    if (handlerReferences.Count > 0)
                    {
                        LiveHandlersReferences.Add(key, handlerReferences);
                    }
                }
            }
        }

        /// <summary>
        /// Registers type of event and an instance of its handler type.
        /// </summary>
        /// <typeparam name="TEvent">Event's type.</typeparam>
        /// <typeparam name="THandler">Event's handler type.</typeparam>
        public void RegisterHandler<THandler, TEvent>(THandler handler) where TEvent : IEvent where THandler : IHandle<TEvent>
        {
            Type eventType = typeof(TEvent);
            WeakReference handlerReference = new WeakReference(handler);
            if (LiveHandlersReferences.ContainsKey(eventType))
            {
                if (!LiveHandlersReferences[eventType].Contains(handlerReference))
                { LiveHandlersReferences[eventType].Add(handlerReference); }
            }
            else
            {
                List<WeakReference> references = new List<WeakReference>() { handlerReference };
                LiveHandlersReferences.Add(eventType, references);
            }
        }

        /// <summary>
        /// Registers type of event and its corresponding handler type.
        /// </summary>
        /// <typeparam name="TEvent">Event's type.</typeparam>
        /// <typeparam name="THandler">Event's handler type.</typeparam>
        public void RegisterHandler<THandler, TEvent>() where TEvent : IEvent where THandler : IHandle<TEvent>
        {
            Type @event = typeof(TEvent);
            Type handler = typeof(THandler);

            if (RegisteredHandlers.ContainsKey(@event))
            {
                if (!RegisteredHandlers[@event].Contains(handler))
                {
                    RegisteredHandlers[@event].Add(handler);
                }
            }
            else
            {
                List<Type> handlersList = new List<Type>() { handler };
                RegisteredHandlers.Add(@event, handlersList);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    RegisteredHandlers.Clear();
                    LiveHandlersReferences.Clear();
                }
                disposed = true;
            }
        }

        public EventHub(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        private readonly Dictionary<Type, List<WeakReference>> LiveHandlersReferences = new Dictionary<Type, List<WeakReference>>();
        private readonly Dictionary<Type, List<Type>> RegisteredHandlers = new Dictionary<Type, List<Type>>();
    }
}
