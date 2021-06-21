using System;

namespace School.People.App.Hubs
{
    public abstract class Hub
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract void Dispose(bool disposing);

        protected Hub(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        // inversion of control container
        protected readonly IServiceProvider ServiceProvider;

        // disposed flag
        protected bool disposed = false;
    }
}
