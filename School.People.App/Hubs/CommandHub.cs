using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Apps.Communication.Core;

namespace School.People.App.Hubs
{
    public class CommandHub : Hub, ICommandHub
    {
        /// <summary>
        /// Requests the hub to dispatch a command.
        /// </summary>
        /// <typeparam name="TCommand">Command's type.</typeparam>
        /// <param name="command">The command instance to be dispatched.</param>
        public async Task<TResult> Dispatch<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            Type key = typeof(TCommand);
            bool prehandled = await DispatchToPreHandlers(command, key).ConfigureAwait(false);
            if (prehandled == false) { return default; }
            TResult result = await DispatchToMainHandler<TCommand, TResult>(command, key).ConfigureAwait(false);
            return result;
        }

        // dispatching to pre-handling logics
        private Task<bool> DispatchToPreHandlers<TCommand>(TCommand command, Type key) where TCommand : ICommand
        {
            try
            {
                List<Task<bool>> taskList = new List<Task<bool>>();
                if (LivePreHandlersReferences.ContainsKey(key))
                {
                    foreach (var reference in LivePreHandlersReferences[key])
                    {
                        if (reference.IsAlive && reference.Target is IHandle<TCommand, bool> handler)
                        {
                            taskList.Add(handler.Handle(command));
                        }
                    }
                    Task.WaitAll(taskList.ToArray());
                }
                else
                {
                    if (RegisteredPreHandlers.ContainsKey(key))
                    {
                        List<WeakReference> handlerReferences = new List<WeakReference>();

                        foreach (var handlerType in RegisteredPreHandlers[key])
                        {
                            if (ServiceProvider.GetService(handlerType) is IHandle<TCommand, bool> handler)
                            {
                                taskList.Add(handler.Handle(command));
                                handlerReferences.Add(new WeakReference(handler));
                            }
                        }
                        Task.WaitAll(taskList.ToArray());
                        if (handlerReferences.Count > 0) { LivePreHandlersReferences.Add(key, handlerReferences); }
                    }
                }
                foreach (var task in taskList)
                {
                    if (task.Result == false) { return task; }
                }
                return Task.FromResult(true);
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex.InnerException); }
        }

        // dispatching to main handling logic
        private async Task<TResult> DispatchToMainHandler<TCommand, TResult>(TCommand command, Type key) where TCommand : ICommand
        {
            try
            {
                TResult result = default;
                if (LiveHandlersReferences.ContainsKey(key))
                {
                    WeakReference reference = LiveHandlersReferences[key];
                    if (reference.IsAlive && reference.Target is IHandle<TCommand, TResult> handler)
                    {
                        result = await handler.Handle(command);
                    }
                }
                else
                {
                    if (RegisteredHandlers.ContainsKey(key))
                    {
                        if (ServiceProvider.GetService(RegisteredHandlers[key]) is IHandle<TCommand, TResult> handler)
                        {
                            result = await handler.Handle(command);
                            LiveHandlersReferences.Add(key, new WeakReference(handler));
                        }
                    }
                }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex.InnerException); }
        }

        /// <summary>
        /// Registers a command's preparation handler.
        /// </summary>
        /// <typeparam name="THandler">Command handler's type.</typeparam>
        /// <typeparam name="TCommand">Command type to be handled.</typeparam>
        public void RegisterPreHandler<THandler, TCommand>() where THandler : IHandle<TCommand, bool> where TCommand : ICommand
        {
            Type command = typeof(TCommand);
            Type handler = typeof(THandler);

            if (RegisteredPreHandlers.ContainsKey(command))
            {
                if (!RegisteredPreHandlers[command].Contains(handler))
                {
                    RegisteredPreHandlers[command].Add(handler);
                }
            }
            else
            {
                List<Type> handlersList = new List<Type>() { handler };
                RegisteredPreHandlers.Add(command, handlersList);
            }
        }

        /// <summary>
        /// Registers a main command handler.
        /// </summary>
        /// <typeparam name="THandler">Command handler's type.</typeparam>
        /// <typeparam name="TCommand">Command type to be handled.</typeparam>
        public void RegisterHandler<THandler, TCommand, TResult>() where THandler : IHandle<TCommand, TResult> where TCommand : ICommand
        {
            Type commandType = typeof(TCommand);
            if (RegisteredHandlers.ContainsKey(commandType) == false) { RegisteredHandlers.Add(commandType, typeof(THandler)); }
        }

        protected override void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    RegisteredHandlers.Clear();
                    LiveHandlersReferences.Clear();
                    LivePreHandlersReferences.Clear();
                    RegisteredPreHandlers.Clear();
                }
                disposed = true;
            }
        }

        public CommandHub(IServiceProvider serviceProvider)
            : base(serviceProvider) { }

        private readonly Dictionary<Type, List<WeakReference>> LivePreHandlersReferences = new Dictionary<Type, List<WeakReference>>();
        private readonly Dictionary<Type, List<Type>> RegisteredPreHandlers = new Dictionary<Type, List<Type>>();
        private readonly Dictionary<Type, WeakReference> LiveHandlersReferences = new Dictionary<Type, WeakReference>();
        private readonly Dictionary<Type, Type> RegisteredHandlers = new Dictionary<Type, Type>();
    }
}