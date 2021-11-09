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

        public void RegisterHandler<TCommand, THandler, TResult>(THandler handler) where THandler : IHandle<TCommand, TResult> where TCommand : ICommand
        {
            var key = typeof(TCommand);

            if (handlers.ContainsKey(key))
            {
                handlers[key] = handler;
            }
            else
            {
                handlers.Add(key, handler);
            }
        }

        public void RegisterValidator<TCommand, TValidator>(TValidator validator) where TValidator : IHandle<TCommand, bool> where TCommand : ICommand
        {
            var key = typeof(TCommand);

            if (validators.ContainsKey(key))
            {
                validators[key] = validator;
            }
            else
            {
                validators.Add(key, validator);
            }
        }

        private async Task<bool> Validate<TCommand>(TCommand command) where TCommand : ICommand
        {
            try
            {
                var key = typeof(TCommand);

                if (validators.ContainsKey(key))
                {
                    if (validators[key] is IHandle<TCommand, bool> handler)
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

        public CommandHub()
        {
            handlers = new Dictionary<Type, object>();
            validators = new Dictionary<Type, object>();
        }

        private readonly Dictionary<Type, object> handlers;
        private readonly Dictionary<Type, object> validators;
    }
}