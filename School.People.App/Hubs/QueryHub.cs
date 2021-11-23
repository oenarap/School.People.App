using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Apps.Communication.Core;
using School.People.App.Exceptions;

namespace School.People.App.Hubs
{
    public class QueryHub : IQueryHub
    {
        public async Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery where TQueryResult : IQueryResult
        {
            try
            {
                var result = await Validate<TQuery, TQueryResult>(query).ConfigureAwait(false);
                
                if (result != null) 
                { 
                    Handle(ref result);
                    return result;
                }

                // notify that the current query is invalid.
                throw new InvalidMessageException(query);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public void RegisterContributor<TContributor, TQueryResult>() where TQueryResult : IQueryResult where TContributor : IHandle<TQueryResult>
        {
            var key = typeof(TQueryResult);

            if (contributors.ContainsKey(key))
            {
                contributors[key].Add(typeof(TContributor));
            }
            else
            {
                contributors.Add(key, new HashSet<Type>() { typeof(TContributor) });
            }
        }

        /// <note>
        /// There can be only one validator for a certain query type in this current implementation.
        /// Hence, registering a new validator type for such query, will overwrite the
        /// existing (previously registered) one.
        /// </note>
        public void RegisterValidator<TValidator, TQuery, TQueryResult>() where TQuery : IQuery
            where TQueryResult : IQueryResult where TValidator : IHandle<TQuery, TQueryResult>
        {
            var key = typeof(TQuery);

            if (validators.ContainsKey(key))
            {
                validators[key] = typeof(TValidator);
            }
            else
            {
                validators.Add(key, typeof(TValidator));
            }
        }

        private async Task<TQueryResult> Validate<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery
        {
            try
            {
                var key = typeof(TQuery);

                if (validators.ContainsKey(key))
                {
                    if (provider.GetService(validators[key]) is IHandle<TQuery, TQueryResult> handler)
                    {
                        return await handler.Handle(query).ConfigureAwait(false);
                    }
                }

                // notify that the current query is unhandled.
                throw new UnhandledMessageException(query);
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex.InnerException); 
            }
        }

        private void Handle<TQueryResult>(ref TQueryResult message) where TQueryResult : IQueryResult
        {
            try
            {
                var key = typeof(TQueryResult);

                if (contributors.ContainsKey(key))
                {
                    var tasks = new List<Task>();

                    foreach (var type in contributors[key])
                    {
                        if (provider.GetService(type) is IHandle<TQueryResult> handler)
                        {
                            tasks.Add(handler.Handle(message));
                        }
                    }

                    Task.WaitAll(tasks.ToArray());
                }
                else
                {
                    // notify that the current query message is unhandled.
                    throw new UnhandledMessageException(message);
                }
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex.InnerException); 
            }
        }

        public QueryHub(IServiceProvider provider)
        { 
            contributors = new Dictionary<Type, HashSet<Type>>();
            validators = new Dictionary<Type, Type>();
            this.provider = provider;
        }

        private readonly Dictionary<Type, HashSet<Type>> contributors;
        private readonly Dictionary<Type, Type> validators;
        private readonly IServiceProvider provider;
    }
}
