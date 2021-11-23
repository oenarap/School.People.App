using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Apps.Communication.Core;
using School.People.App.Exceptions;

namespace School.People.App.Hubs
{
    public class CommandHub : ICommandHub
    {
        public async Task<TResult> Dispatch<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            try
            {
                var ok = await Validate(command).ConfigureAwait(false);
                
                if (ok) { return await Handle<TCommand, TResult>(command).ConfigureAwait(false); }

                // notify that the current command is invalid.
                throw new InvalidMessageException(command);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        /// <note>
        /// There can be only one command handler in this current implementation.
        /// Hence, registering a new handler type will overwrite the
        /// existing (previously registered) one.
        /// </note>
        public void RegisterHandler<TCommand, THandler, TResult>() where THandler : IHandle<TCommand, TResult> where TCommand : ICommand
        {
            var key = typeof(TCommand);

            if (handlers.ContainsKey(key))
            {
                handlers[key] = typeof(THandler);
            }
            else
            {
                handlers.Add(key, typeof(THandler));
            }
        }

        public void RegisterValidator<TCommand, TValidator>() where TValidator : IHandle<TCommand, bool> where TCommand : ICommand
        {
            var key = typeof(TCommand);

            if (validators.ContainsKey(key))
            {
                validators[key].Add(typeof(TValidator));
            }
            else
            {
                validators.Add(key, new HashSet<Type>() { typeof(TValidator) });
            }
        }

        private async Task<bool> Validate<TCommand>(TCommand command) where TCommand : ICommand
        {
            try
            {
                var key = typeof(TCommand);

                if (validators.ContainsKey(key))
                {
                    var counter = 0;

                    foreach (var type in validators[key])
                    {
                        if (provider.GetService(type) is IHandle<TCommand, bool> handler)
                        {
                            counter += await handler.Handle(command).ConfigureAwait(false) ? 1 : 0;
                        }
                    }

                    // a command is considered invalid if it
                    // failed in even just one of its validators
                    return counter == validators[key].Count;
                }

                // notify that the current command is unhandled.
                throw new UnhandledMessageException(command);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        private async Task<TResult> Handle<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            try
            {
                var key = typeof(TCommand);

                if (handlers.ContainsKey(key))
                {
                    if (handlers[key] is IHandle<TCommand, TResult> handler)
                    {
                        return await handler.Handle(command).ConfigureAwait(false);
                    }
                }

                // notify that the current command is unhandled.
                throw new UnhandledMessageException(command);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public CommandHub(IServiceProvider provider)
        {
            
            handlers = new Dictionary<Type, Type>();
            validators = new Dictionary<Type, HashSet<Type>>();
            this.provider = provider;
        }

        private readonly Dictionary<Type, Type> handlers;
        private readonly Dictionary<Type, HashSet<Type>> validators;
        private readonly IServiceProvider provider;
    }
}