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

        public void RegisterContributor<TContributor, TQueryResult>(TContributor contributor) where TQueryResult : IQueryResult where TContributor : IHandle<TQueryResult>
        {
            var key = typeof(TQueryResult);

            if (contributors.ContainsKey(key))
            {
                contributors[key].Add(contributor);
            }
            else
            {
                contributors.Add(key, new HashSet<object>() { contributor });
            }
        }

        /// <summary>
        /// Registers a query validator.
        /// </summary>
        /// <remarks>
        /// There can be only one (1) validator for a certain query type. Hence,
        /// registering a new validator for such query, will overwrite the existing one.
        /// </remarks>
        public void RegisterValidator<TValidator, TQuery, TQueryResult>(TValidator validator) where TQuery : IQuery
            where TQueryResult : IQueryResult where TValidator : IHandle<TQuery, TQueryResult>
        {
            var key = typeof(TQuery);

            if (validators.ContainsKey(key))
            {
                validators[key] = validator;
            }
            else
            {
                validators.Add(key, validator);
            }
        }

        private async Task<TQueryResult> Validate<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery
        {
            try
            {
                var key = typeof(TQuery);

                if (validators.ContainsKey(key))
                {
                    if (validators[key] is IHandle<TQuery, TQueryResult> handler)
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

        private void Handle<TQueryResult>(ref TQueryResult result) where TQueryResult : IQueryResult
        {
            try
            {
                var key = typeof(TQueryResult);

                if (contributors.ContainsKey(key))
                {
                    var tasks = new List<Task>();

                    foreach (var contributor in contributors[key])
                    {
                        if (contributor is IHandle<TQueryResult> handler)
                        {
                            tasks.Add(handler.Handle(result));
                        }
                    }

                    Task.WaitAll(tasks.ToArray());
                }
                else
                {
                    // notify that the current query result is unhandled.
                    throw new UnhandledMessageException(result);
                }
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message, ex.InnerException); 
            }
        }

        public QueryHub()
        { 
            contributors = new Dictionary<Type, HashSet<object>>();
            validators = new Dictionary<Type, object>();
        }

        private readonly Dictionary<Type, HashSet<object>> contributors;
        private readonly Dictionary<Type, object> validators;
    }
}
