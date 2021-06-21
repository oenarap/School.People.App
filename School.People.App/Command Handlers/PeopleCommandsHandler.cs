using System;
using System.Threading.Tasks;
using School.People.App.Events;
using School.People.Core.Repositories;
using Apps.Communication.Core;

namespace School.People.App.Commands.Handlers
{
    public class PeopleCommandsHandler : IHandle<InsertStudentCommand, Guid?>, IHandle<ArchiveStudentCommand, bool>,
        IHandle<InsertOtherPersonCommand, Guid?>, IHandle<ArchiveOtherPersonCommand, bool>, IHandle<UpdatePersonCommand, bool>,
        IHandle<InsertPersonnelCommand, Guid?>, IHandle<ArchivePersonnelCommand, bool>, IHandle<UpdateMotherCommand, bool>,
        IHandle<UpdateFatherCommand, bool>, IHandle<UpdateSpouseCommand, bool>, IHandle<UpdateChildCommand, bool>
    {
        public async Task<bool> Handle(UpdateChildCommand command)
        {
            try
            {
                var insertResult = await CommandHub.Dispatch<InsertOtherPersonCommand, Guid?>(new InsertOtherPersonCommand(command.Id, command.Data));
                if (insertResult is Guid id)
                {
                    string sex = null; // TODO: get person's sex from repository
                    switch (sex.ToLower())
                    {
                        case "male":
                            var updateFatherIdResult = await CommandHub.Dispatch<UpdateFatherIdCommand, bool>(new UpdateFatherIdCommand(id, command.Id)).ConfigureAwait(false);
                            return updateFatherIdResult;
                        case "female":
                            var updateMotherIdResult = await CommandHub.Dispatch<UpdateMotherIdCommand, bool>(new UpdateMotherIdCommand(id, command.Id)).ConfigureAwait(false);
                            return updateMotherIdResult;
                    }
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(UpdateSpouseCommand command)
        {
            try
            {
                var insertResult = await this.Handle(new InsertOtherPersonCommand(command.Id, command.Data));
                if (insertResult is Guid id)
                {
                    var cmd = new UpdateSpouseIdCommand(command.Id, id);
                    var updateResult = await CommandHub.Dispatch<UpdateSpouseIdCommand, bool>(cmd).ConfigureAwait(false);
                    return updateResult;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(UpdateFatherCommand command)
        {
            try
            {
                var insertResult = await this.Handle(new InsertOtherPersonCommand(command.Id, command.Data));
                if (insertResult is Guid id)
                {
                    var cmd = new UpdateFatherIdCommand(command.Id, id);
                    var updateResult = await CommandHub.Dispatch<UpdateFatherIdCommand, bool>(cmd).ConfigureAwait(false);
                    return updateResult;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(UpdateMotherCommand command)
        {
            try
            {
                var insertResult = await this.Handle(new InsertOtherPersonCommand(command.Id, command.Data));
                if (insertResult is Guid id)
                {
                    var cmd = new UpdateMotherIdCommand(command.Id, id);
                    var updateResult = await CommandHub.Dispatch<UpdateMotherIdCommand, bool>(cmd).ConfigureAwait(false);
                    return updateResult;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(ArchiveOtherPersonCommand command)
        {
            try
            {
                bool result = await OtherPeopleRepository.ArchiveAsync(command.Data).ConfigureAwait(false);
                if (result == true) { EventHub.Dispatch(new OtherPersonArchivedEvent(command.Id, command.Data)); }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<Guid?> Handle(InsertOtherPersonCommand command)
        {
            try
            {
                Guid? result = await OtherPeopleRepository.InsertAsync(command.Data).ConfigureAwait(false);
                if (result is Guid id) { EventHub.Dispatch(new OtherPersonInsertedEvent(id, command.Data)); }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(ArchivePersonnelCommand command)
        {
            try
            {
                bool result = await PersonnelRepository.ArchiveAsync(command.Data).ConfigureAwait(false);
                if (result == true) { EventHub.Dispatch(new PersonnelArchivedEvent(command.Id, command.Data)); }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<Guid?> Handle(InsertPersonnelCommand command)
        {
            try
            {
                Guid? result = await PersonnelRepository.InsertAsync(command.Data).ConfigureAwait(false);
                if (result is Guid id) { EventHub.Dispatch(new PersonnelInsertedEvent(command.Id, command.Data)); }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(ArchiveStudentCommand command)
        {
            try
            {
                bool result = await StudentsRepository.ArchiveAsync(command.Data).ConfigureAwait(false);
                if (result == true) { EventHub.Dispatch(new StudentArchivedEvent(command.Id, command.Data)); }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<Guid?> Handle(InsertStudentCommand command)
        {
            try
            {
                Guid? result = await StudentsRepository.InsertAsync(command.Data).ConfigureAwait(false);
                if (result is Guid id) { EventHub.Dispatch(new StudentInsertedEvent(id, command.Data)); }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(UpdatePersonCommand command)
        {
            try
            {
                bool result = await ActivePeopleRepository.UpdateAsync(command.Data).ConfigureAwait(false);
                if (result == true) { EventHub.Dispatch(new PersonUpdatedEvent(command.Id, command.Data)); }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public PeopleCommandsHandler(IEventHub eventHub, ICommandHub commandHub, IActivePeopleRepository activePeopleRepository, 
            IStudentsRepository studentsRepository, IPersonnelRepository personnelRepository, IOtherPeopleRepository otherPeopleRepository)
        {
            ActivePeopleRepository = activePeopleRepository ?? throw new ArgumentNullException(nameof(activePeopleRepository));
            OtherPeopleRepository = otherPeopleRepository ?? throw new ArgumentNullException(nameof(otherPeopleRepository));
            PersonnelRepository = personnelRepository ?? throw new ArgumentNullException(nameof(personnelRepository));
            StudentsRepository = studentsRepository ?? throw new ArgumentNullException(nameof(studentsRepository));
            CommandHub = commandHub ?? throw new ArgumentNullException(nameof(commandHub));
            EventHub = eventHub ?? throw new ArgumentNullException(nameof(eventHub));
        }

        private readonly IActivePeopleRepository ActivePeopleRepository;
        private readonly IOtherPeopleRepository OtherPeopleRepository;
        private readonly IPersonnelRepository PersonnelRepository;
        private readonly IStudentsRepository StudentsRepository;
        private readonly ICommandHub CommandHub;
        private readonly IEventHub EventHub;
    }
}
