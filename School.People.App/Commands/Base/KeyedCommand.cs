using System;

namespace School.People.App.Commands
{
    public abstract class KeyedCommand<T> : Command<T>
    {
        public Guid Key { get; }
        
        public KeyedCommand(Guid id, Guid key, T data)
            : base(id, data) { Key = key; }
    }
}
