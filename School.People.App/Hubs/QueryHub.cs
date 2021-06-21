using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Apps.Communication.Core;

namespace School.People.App.Hubs
{
    public class QueryHub : Hub, IQueryHub
    {
        /// <summary>
        /// Requests the hub to dispatch a query.
        /// </summary>
        /// <typeparam name="TQuery">Query type constraint.</typeparam>
        /// <param name="query">The query instance to be dispatched.</param>
        public async Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery where TQueryResult : IQueryResult
        {
            Type key = typeof(TQuery);
            TQueryResult result = await DispatchToMainHandler<TQuery, TQueryResult>(query, key);
            if (result != null) 
            {
                key = typeof(TQueryResult);
                await DispatchToPostHandlers(key, result); 
            }
            return result;
        }

        // dispatching to main handling logic
        private async Task<TQueryResult> DispatchToMainHandler<TQuery, TQueryResult>(TQuery query, Type key) where TQuery : IQuery
        {
            try
            {
                TQueryResult result = default;
                if (LiveHandlersReferences.ContainsKey(key))
                {
                    WeakReference reference = LiveHandlersReferences[key];
                    if (reference.IsAlive && reference.Target is IHandle<TQuery, TQueryResult> handler)
                    {
                        result = await handler.Handle(query);
                    }
                }
                else
                {
                    if (RegisteredHandlers.ContainsKey(key))
                    {
                        if (ServiceProvider.GetService(RegisteredHandlers[key]) is IHandle<TQuery, TQueryResult> handler)
                        {
                            result = await handler.Handle(query);
                            LiveHandlersReferences.Add(key, new WeakReference(handler));
                        }
                    }
                }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex.InnerException); }
        }

        private async Task DispatchToPostHandlers<TQueryResult>(Type key, TQueryResult result) where TQueryResult : IQueryResult
        {
            try
            {
                //List<Task> taskList = new List<Task>();
                if (LivePostHandlersReferences.ContainsKey(key))
                {
                    foreach (var reference in LivePostHandlersReferences[key])
                    {
                        if (reference.IsAlive && reference.Target is IHandle<TQueryResult> handler)
                        {
                            await handler.Handle(result);
                            //taskList.Add(await handler.Handle(result));
                        }
                    }
                    //Task.WaitAll(taskList.ToArray());
                }
                else
                {
                    if (RegisteredPostHandlers.ContainsKey(key))
                    {
                        List<WeakReference> handlerReferences = new List<WeakReference>();
                        foreach (var handlerType in RegisteredPostHandlers[key])
                        {
                            if (ServiceProvider.GetService(handlerType) is IHandle<TQueryResult> handler)
                            {
                                //taskList.Add(handler.Handle(result));
                                await handler.Handle(result);
                                handlerReferences.Add(new WeakReference(handler));
                            }
                        }
                        //Task.WaitAll(taskList.ToArray());
                        if (handlerReferences.Count > 0) { LivePostHandlersReferences.Add(key, handlerReferences); }
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex.InnerException); }
        }

        /// <summary>
        /// Registers a handler that supports post-query processing.
        /// </summary>
        /// <typeparam name="TQueryResult">Query result's type.</typeparam>
        /// <typeparam name="THandler">Query handler's type.</typeparam>
        public void RegisterPostHandler<THandler, TQueryResult>() where TQueryResult : IQueryResult where THandler : IHandle<TQueryResult> 
        {
            Type resultType = typeof(TQueryResult);
            Type handlerType = typeof(THandler);

            if (RegisteredPostHandlers.ContainsKey(resultType))
            {
                if (RegisteredPostHandlers[resultType].Contains(handlerType) == false)
                {
                    RegisteredPostHandlers[resultType].Add(handlerType);
                }
            }
            else
            {
                List<Type> handlerTypesList = new List<Type>() { handlerType };
                RegisteredPostHandlers.Add(resultType, handlerTypesList);
            }
        }

        /// <summary>
        /// Registers a main query handler and its corresponding query type.
        /// </summary>
        /// <typeparam name="TQuery">Query's type.</typeparam>
        /// <typeparam name="THandler">Query handler's type.</typeparam>
        public void RegisterHandler<THandler, TQuery, TQueryResult>() where TQuery : IQuery 
            where TQueryResult : IQueryResult where THandler : IHandle<TQuery, TQueryResult>
        {
            Type queryType = typeof(TQuery);
            if (RegisteredHandlers.ContainsKey(queryType) == false) { RegisteredHandlers.Add(queryType, typeof(THandler)); }
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    RegisteredHandlers.Clear();
                    LiveHandlersReferences.Clear();
                    LivePostHandlersReferences.Clear();
                    RegisteredPostHandlers.Clear();
                }
                disposed = true;
            }
        }

        public QueryHub(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        private readonly Dictionary<Type, List<WeakReference>> LivePostHandlersReferences = new Dictionary<Type, List<WeakReference>>();
        private readonly Dictionary<Type, List<Type>> RegisteredPostHandlers = new Dictionary<Type, List<Type>>();
        private readonly Dictionary<Type, WeakReference> LiveHandlersReferences = new Dictionary<Type, WeakReference>();
        private readonly Dictionary<Type, Type> RegisteredHandlers = new Dictionary<Type, Type>();
    }
}
