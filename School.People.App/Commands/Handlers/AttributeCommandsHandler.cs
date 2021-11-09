using System;
using System.Threading.Tasks;
using Apps.Communication.Core;
using School.People.App.Events;
using School.People.Core.Repositories;

namespace School.People.App.Commands.Handlers
{
    public class AttributeCommandsHandler : IHandle<InsertWorkCommand, Guid?>, IHandle<UpdateWorkCommand, bool>, IHandle<DeleteWorkCommand, bool>,
        IHandle<InsertEligibilityCommand, Guid?>, IHandle<UpdateEligibilityCommand, bool>, IHandle<DeleteEligibilityCommand, bool>,
        IHandle<InsertEducationCommand, Guid?>, IHandle<UpdateEducationCommand, bool>, IHandle<DeleteEducationCommand, bool>,
        IHandle<InsertCivicWorkCommand, Guid?>, IHandle<UpdateCivicWorkCommand, bool>, IHandle<DeleteCivicWorkCommand, bool>,
        IHandle<InsertTrainingCommand, Guid?>, IHandle<UpdateTrainingCommand, bool>, IHandle<DeleteTrainingCommand, bool>,
        IHandle<InsertOtherInformationCommand, Guid?>, IHandle<UpdateOtherInformationCommand, bool>, IHandle<DeleteOtherInformationCommand, bool>
    {
        public async Task<Guid?> Handle(InsertOtherInformationCommand message)
        {
            try
            {
                var repository = (IOtherInformationsRepository)provider.GetService(typeof(IOtherInformationsRepository));
                var result = await repository.InsertAsync(message.Data).ConfigureAwait(false);

                if (result is Guid id) { eventHub.Dispatch(new OtherInformationInsertedEvent(id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(UpdateOtherInformationCommand message)
        {
            try
            {
                var repository = (IOtherInformationsRepository)provider.GetService(typeof(IOtherInformationsRepository));
                var result = await repository.UpdateAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new OtherInformationUpdatedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(DeleteOtherInformationCommand message)
        {
            try
            {
                var repository = (IOtherInformationsRepository)provider.GetService(typeof(IOtherInformationsRepository));
                var result = await repository.DeleteAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new OtherInformationDeletedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Guid?> Handle(InsertTrainingCommand message)
        {
            try
            {
                var repository = (ITrainingsRepository)provider.GetService(typeof(ITrainingsRepository));
                var result = await repository.InsertAsync(message.Data).ConfigureAwait(false);

                if (result is Guid id) { eventHub.Dispatch(new TrainingInsertedEvent(id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(UpdateTrainingCommand message)
        {
            try
            {
                var repository = (ITrainingsRepository)provider.GetService(typeof(ITrainingsRepository));
                var result = await repository.UpdateAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new TrainingUpdatedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(DeleteTrainingCommand message)
        {
            try
            {
                var repository = (ITrainingsRepository)provider.GetService(typeof(ITrainingsRepository));
                var result = await repository.DeleteAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new TrainingDeletedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Guid?> Handle(InsertCivicWorkCommand message)
        {
            try
            {
                var repository = (ICivicWorksRepository)provider.GetService(typeof(ICivicWorksRepository));
                var result = await repository.InsertAsync(message.Data).ConfigureAwait(false);

                if (result is Guid id) { eventHub.Dispatch(new CivicWorkInsertedEvent(id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(UpdateCivicWorkCommand message)
        {
            try
            {
                var repository = (ICivicWorksRepository)provider.GetService(typeof(ICivicWorksRepository));
                var result = await repository.UpdateAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new CivicWorkUpdatedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(DeleteCivicWorkCommand message)
        {
            try
            {
                var repository = (ICivicWorksRepository)provider.GetService(typeof(ICivicWorksRepository));
                var result = await repository.DeleteAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new CivicWorkDeletedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Guid?> Handle(InsertWorkCommand message)
        {
            try
            {
                var repository = (IWorksRepository)provider.GetService(typeof(IWorksRepository));
                var result = await repository.InsertAsync(message.Data).ConfigureAwait(false);

                if (result is Guid id) { eventHub.Dispatch(new WorkInsertedEvent(id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(UpdateWorkCommand message)
        {
            try
            {
                var repository = (IWorksRepository)provider.GetService(typeof(IWorksRepository));
                var result = await repository.UpdateAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new WorkUpdatedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(DeleteWorkCommand message)
        {
            try
            {
                var repository = (IWorksRepository)provider.GetService(typeof(IWorksRepository));
                var result = await repository.DeleteAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new WorkDeletedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(DeleteEducationCommand message)
        {
            try
            {
                var repository = (IEducationsRepository)provider.GetService(typeof(IEducationsRepository));
                var result = await repository.DeleteAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new EducationDeletedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(UpdateEducationCommand message)
        {
            try
            {
                var repository = (IEducationsRepository)provider.GetService(typeof(IEducationsRepository));
                var result = await repository.UpdateAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new EducationUpdatedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Guid?> Handle(InsertEducationCommand message)
        {
            try
            {
                var repository = (IEducationsRepository)provider.GetService(typeof(IEducationsRepository));
                var result = await repository.InsertAsync(message.Data).ConfigureAwait(false);

                if (result is Guid id) { eventHub.Dispatch(new EducationInsertedEvent(id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Guid?> Handle(InsertEligibilityCommand message)
        {
            try
            {
                var repository = (IEligibilitiesRepository)provider.GetService(typeof(IEligibilitiesRepository));
                var result = await repository.InsertAsync(message.Data).ConfigureAwait(false);

                if (result is Guid id) { eventHub.Dispatch(new EligibilityInsertedEvent(id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(UpdateEligibilityCommand message)
        {
            try
            {
                var repository = (IEligibilitiesRepository)provider.GetService(typeof(IEligibilitiesRepository));
                var result = await repository.UpdateAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new EligibilityUpdatedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(DeleteEligibilityCommand message)
        {
            try
            {
                var repository = (IEligibilitiesRepository)provider.GetService(typeof(IEligibilitiesRepository));
                var result = await repository.DeleteAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new EligibilityDeletedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex) 
            { 
                throw new Exception(ex.Message); 
            }
        }

        public AttributeCommandsHandler(ICommandHub commandHub, IServiceProvider provider, IEventHub eventHub)
        {
            commandHub.RegisterHandler<InsertOtherInformationCommand, AttributeCommandsHandler, Guid?>(this);
            commandHub.RegisterHandler<UpdateOtherInformationCommand, AttributeCommandsHandler, bool>(this);
            commandHub.RegisterHandler<DeleteOtherInformationCommand, AttributeCommandsHandler, bool>(this);
            commandHub.RegisterHandler<InsertTrainingCommand, AttributeCommandsHandler, Guid?>(this);
            commandHub.RegisterHandler<UpdateTrainingCommand, AttributeCommandsHandler, bool>(this);
            commandHub.RegisterHandler<DeleteTrainingCommand, AttributeCommandsHandler, bool>(this);
            commandHub.RegisterHandler<InsertCivicWorkCommand, AttributeCommandsHandler, Guid?>(this);
            commandHub.RegisterHandler<UpdateCivicWorkCommand, AttributeCommandsHandler, bool>(this);
            commandHub.RegisterHandler<DeleteCivicWorkCommand, AttributeCommandsHandler, bool>(this);
            commandHub.RegisterHandler<InsertWorkCommand, AttributeCommandsHandler, Guid?>(this);
            commandHub.RegisterHandler<UpdateWorkCommand, AttributeCommandsHandler, bool>(this);
            commandHub.RegisterHandler<DeleteWorkCommand, AttributeCommandsHandler, bool>(this);
            commandHub.RegisterHandler<DeleteEducationCommand, AttributeCommandsHandler, bool>(this);
            commandHub.RegisterHandler<UpdateEducationCommand, AttributeCommandsHandler, bool>(this);
            commandHub.RegisterHandler<InsertEducationCommand, AttributeCommandsHandler, Guid?>(this);
            commandHub.RegisterHandler<InsertEligibilityCommand, AttributeCommandsHandler, Guid?>(this);
            commandHub.RegisterHandler<UpdateEligibilityCommand, AttributeCommandsHandler, bool>(this);
            commandHub.RegisterHandler<DeleteEligibilityCommand, AttributeCommandsHandler, bool>(this);

            this.eventHub = eventHub;
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
        private readonly IEventHub eventHub;
    }
}