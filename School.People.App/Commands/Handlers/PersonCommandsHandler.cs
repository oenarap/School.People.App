using System;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.App.Events;
using School.People.Core.Repositories;

namespace School.People.App.Commands.Handlers
{
    public class PersonCommandsHandler : IHandle<UpdatePersonCommand, bool>, IHandle<InsertStudentCommand, Guid?>,
        IHandle<ArchiveStudentCommand, bool>, IHandle<InsertPersonnelCommand, Guid?>,
        IHandle<ArchivePersonnelCommand, bool>, IHandle<InsertOtherPersonCommand, Guid?>,
        IHandle<ArchiveOtherPersonCommand, bool>, IHandle<UpdateMotherCommand, bool>, 
        IHandle<UpdateFatherCommand, bool>, IHandle<UpdateSpouseCommand, bool>,
        IHandle<InsertFatherChildCommand, bool>, IHandle<InsertMotherChildCommand, bool>
    {
        public async Task<bool> Handle(InsertMotherChildCommand message)
        {
            try
            {
                var command = new InsertOtherPersonCommand(message.Id, message.Data);
                var result = await commandHub.Dispatch<InsertOtherPersonCommand, Guid?>(command).ConfigureAwait(false);

                if (result is Guid id)
                {
                    var repository = (IMotherIdsRepository)provider.GetService(typeof(IMotherIdsRepository));
                    return await repository.UpdateAsync(id, (Guid)message.DataId).ConfigureAwait(false);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(InsertFatherChildCommand message)
        {
            try
            {
                var command = new InsertOtherPersonCommand(message.Id, message.Data);
                var result = await commandHub.Dispatch<InsertOtherPersonCommand, Guid?>(command).ConfigureAwait(false);

                if (result is Guid id)
                {
                    var repository = (IFatherIdsRepository)provider.GetService(typeof(IFatherIdsRepository));
                    return await repository.UpdateAsync(id, (Guid)message.DataId).ConfigureAwait(false);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(UpdateSpouseCommand message)
        {
            try
            {
                var command = new InsertOtherPersonCommand(message.Id, message.Data);
                var result = await commandHub.Dispatch<InsertOtherPersonCommand, Guid?>(command).ConfigureAwait(false);

                if (result is Guid id)
                {
                    var repository = (ISpouseIdsRepository)provider.GetService(typeof(ISpouseIdsRepository));
                    return await repository.UpdateAsync((Guid)message.DataId, id).ConfigureAwait(false);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(UpdateFatherCommand message)
        {
            try
            {
                var command = new InsertOtherPersonCommand(message.Id, message.Data);
                var result = await commandHub.Dispatch<InsertOtherPersonCommand, Guid?>(command).ConfigureAwait(false);

                if (result is Guid id)
                {
                    var repository = (IFatherIdsRepository)provider.GetService(typeof(IFatherIdsRepository));
                    return await repository.UpdateAsync((Guid)message.DataId, id).ConfigureAwait(false);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(UpdateMotherCommand message)
        {
            try
            {
                var command = new InsertOtherPersonCommand(message.Id, message.Data);
                var result = await commandHub.Dispatch<InsertOtherPersonCommand, Guid?>(command).ConfigureAwait(false);
                
                if (result is Guid id)
                {
                    var repository = (IMotherIdsRepository)provider.GetService(typeof(IMotherIdsRepository));
                    return await repository.UpdateAsync((Guid)message.DataId, id).ConfigureAwait(false);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(ArchiveOtherPersonCommand message)
        {
            try
            {
                var repository = (IOtherPeopleRepository)provider.GetService(typeof(IOtherPeopleRepository));
                var result = await repository.ArchiveAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new OtherPersonArchivedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Guid?> Handle(InsertOtherPersonCommand message)
        {
            try
            {
                var repository = (IOtherPeopleRepository)provider.GetService(typeof(IOtherPeopleRepository));
                var result = await repository.InsertAsync(message.Data).ConfigureAwait(false);

                if (result is Guid id) { eventHub.Dispatch(new OtherPersonInsertedEvent(id, message.Data)); }

                return result;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(ArchivePersonnelCommand message)
        {
            try
            {
                var repository = (IPersonnelRepository)provider.GetService(typeof(IPersonnelRepository));
                bool result = await repository.ArchiveAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new PersonnelArchivedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message); 
            }
        }

        public async Task<Guid?> Handle(InsertPersonnelCommand message)
        {
            try
            {
                var repository = (IPersonnelRepository)provider.GetService(typeof(IPersonnelRepository));
                var result = await repository.InsertAsync(message.Data).ConfigureAwait(false);

                if (result is Guid id) { eventHub.Dispatch(new PersonnelInsertedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message); 
            }
        }

        public async Task<bool> Handle(ArchiveStudentCommand message)
        {
            try
            {
                var repository = (IStudentsRepository)provider.GetService(typeof(IStudentsRepository));
                var result = await repository.ArchiveAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new StudentArchivedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message); 
            }
        }

        public async Task<Guid?> Handle(InsertStudentCommand message)
        {
            try
            {
                var repository = (IStudentsRepository)provider.GetService(typeof(IStudentsRepository));
                var result = await repository.InsertAsync(message.Data).ConfigureAwait(false);

                if (result is Guid id) { eventHub.Dispatch(new StudentInsertedEvent(id, message.Data)); }

                return result;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message); 
            }
        }

        public async Task<bool> Handle(UpdatePersonCommand message)
        {
            try
            {
                var repository = (IActivePeopleRepository)provider.GetService(typeof(IActivePeopleRepository));
                var result = await repository.UpdateAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new PersonUpdatedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message); 
            }
        }

        public PersonCommandsHandler(ICommandHub commandHub, IServiceProvider provider, IEventHub eventHub)
        {
            commandHub.RegisterHandler<UpdatePersonCommand, PersonCommandsHandler, bool>(this);
            commandHub.RegisterHandler<InsertStudentCommand, PersonCommandsHandler, Guid?>(this);
            commandHub.RegisterHandler<ArchiveStudentCommand, PersonCommandsHandler, bool>(this);
            commandHub.RegisterHandler<InsertPersonnelCommand, PersonCommandsHandler, Guid?>(this);
            commandHub.RegisterHandler<ArchivePersonnelCommand, PersonCommandsHandler, bool>(this);
            commandHub.RegisterHandler<InsertOtherPersonCommand, PersonCommandsHandler, Guid?>(this);
            commandHub.RegisterHandler<ArchiveOtherPersonCommand, PersonCommandsHandler, bool>(this);
            commandHub.RegisterHandler<UpdateMotherCommand, PersonCommandsHandler, bool>(this);
            commandHub.RegisterHandler<UpdateFatherCommand, PersonCommandsHandler, bool>(this);
            commandHub.RegisterHandler<UpdateSpouseCommand, PersonCommandsHandler, bool>(this);
            commandHub.RegisterHandler<InsertFatherChildCommand, PersonCommandsHandler, bool>(this);
            commandHub.RegisterHandler<InsertMotherChildCommand, PersonCommandsHandler, bool>(this);

            this.commandHub = commandHub;
            this.eventHub = eventHub;
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
        private readonly ICommandHub commandHub;
        private readonly IEventHub eventHub;
    }
}
