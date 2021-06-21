﻿using System;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.App.Events;
using School.People.Core.Repositories;
using Apps.Communication.Core;

namespace School.People.App.Commands.Handlers
{
    public class AttributesCommandsHandler : IHandle<InsertWorkCommand, Guid?>, IHandle<UpdateWorkCommand, bool>, IHandle<DeleteWorkCommand, bool>,
        IHandle<InsertEligibilityCommand, Guid?>, IHandle<UpdateEligibilityCommand, bool>, IHandle<DeleteEligibilityCommand, bool>,
        IHandle<InsertEducationCommand, Guid?>, IHandle<UpdateEducationCommand, bool>, IHandle<DeleteEducationCommand, bool>,
        IHandle<InsertCivicWorkCommand, Guid?>, IHandle<UpdateCivicWorkCommand, bool>, IHandle<DeleteCivicWorkCommand, bool>,
        IHandle<InsertTrainingCommand, Guid?>, IHandle<UpdateTrainingCommand, bool>, IHandle<DeleteTrainingCommand, bool>,
        IHandle<InsertOtherInformationCommand, Guid?>, IHandle<UpdateOtherInformationCommand, bool>, IHandle<DeleteOtherInformationCommand, bool>
    {
        public async Task<Guid?> Handle(InsertOtherInformationCommand command)
        {
            try
            {
                Guid? result = await OtherInformationsRepository.InsertAsync(command.Data, command.Key).ConfigureAwait(false);
                if (result is Guid id) { EventHub.Dispatch(new OtherInformationInsertedEvent(id, command.Data)); }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(UpdateOtherInformationCommand command)
        {
            try
            {
                if (command.Data is IOtherInformation data)
                {
                    bool result = await OtherInformationsRepository.UpdateAsync(data).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new OtherInformationUpdatedEvent(command.Id, data)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(DeleteOtherInformationCommand command)
        {
            try
            {
                if (command.Data is IOtherInformation data)
                {
                    bool result = await OtherInformationsRepository.DeleteAsync(data).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new OtherInformationDeletedEvent(command.Id, data)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<Guid?> Handle(InsertTrainingCommand command)
        {
            try
            {
                Guid? result = await TrainingsRepository.InsertAsync(command.Data, command.Key).ConfigureAwait(false);
                if (result is Guid id) { EventHub.Dispatch(new TrainingInsertedEvent(id, command.Data)); }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(UpdateTrainingCommand command)
        {
            try
            {
                if (command.Data is ITraining data)
                {
                    bool result = await TrainingsRepository.UpdateAsync(data).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new TrainingUpdatedEvent(command.Id, data)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(DeleteTrainingCommand command)
        {
            try
            {
                if (command.Data is ITraining data)
                {
                    bool result = await TrainingsRepository.DeleteAsync(data).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new TrainingDeletedEvent(command.Id, data)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<Guid?> Handle(InsertCivicWorkCommand command)
        {
            try
            {
                Guid? result = await CivicWorksRepository.InsertAsync(command.Data, command.Key).ConfigureAwait(false);
                if (result is Guid id) { EventHub.Dispatch(new CivicWorkInsertedEvent(id, command.Data)); }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(UpdateCivicWorkCommand command)
        {
            try
            {
                if (command.Data is ICivicWork data)
                {
                    bool result = await CivicWorksRepository.UpdateAsync(data).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new CivicWorkUpdatedEvent(command.Id, data)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(DeleteCivicWorkCommand command)
        {
            try
            {
                if (command.Data is ICivicWork data)
                {
                    bool result = await CivicWorksRepository.DeleteAsync(data).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new CivicWorkDeletedEvent(command.Id, data)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<Guid?> Handle(InsertWorkCommand command)
        {
            try
            {
                Guid? result = await WorksRepository.InsertAsync(command.Data, command.Key).ConfigureAwait(false);
                if (result is Guid id) { EventHub.Dispatch(new WorkInsertedEvent(id, command.Data)); }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(UpdateWorkCommand command)
        {
            try
            {
                if (command.Data is IWork data)
                {
                    bool result = await WorksRepository.UpdateAsync(data).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new WorkUpdatedEvent(command.Id, data)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(DeleteWorkCommand command)
        {
            try
            {
                if (command.Data is IWork data)
                {
                    bool result = await WorksRepository.DeleteAsync(data).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new WorkDeletedEvent(command.Id, data)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(DeleteEducationCommand command)
        {
            try
            {
                if (command.Data is IEducation data)
                {
                    bool result = await EducationsRepository.DeleteAsync(data).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new EducationDeletedEvent(command.Id, data)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(UpdateEducationCommand command)
        {
            if (command.Data is IEducation data)
            {
                bool result = await EducationsRepository.UpdateAsync(data).ConfigureAwait(false);
                if (result == true) { EventHub.Dispatch(new EducationUpdatedEvent(command.Id, data)); }
                return result;
            }
            return false;
        }

        public async Task<Guid?> Handle(InsertEducationCommand command)
        {
            try
            {
                Guid? result = await EducationsRepository.InsertAsync(command.Data, command.Key).ConfigureAwait(false);
                if (result is Guid id) { EventHub.Dispatch(new EducationInsertedEvent(id, command.Data)); }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<Guid?> Handle(InsertEligibilityCommand command)
        {
            try
            {
                Guid? result = await EligibilitiesRepository.InsertAsync(command.Data, command.Key).ConfigureAwait(false);
                if (result is Guid id) { EventHub.Dispatch(new EligibilityInsertedEvent(id, command.Data)); }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(UpdateEligibilityCommand command)
        {
            try
            {
                if (command.Data is IEligibility data)
                {
                    bool result = await EligibilitiesRepository.UpdateAsync(data).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new EligibilityUpdatedEvent(command.Id, data)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(DeleteEligibilityCommand command)
        {
            try
            {
                if (command.Data is IEligibility data)
                {
                    bool result = await EligibilitiesRepository.DeleteAsync(data).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new EligibilityDeletedEvent(command.Id, data)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public AttributesCommandsHandler(IEventHub eventHub, IEligibilitiesRepository eligibilitiesRepository, IEducationsRepository educationsRepository, 
            IWorksRepository worksRepository, ICivicWorksRepository civicWorksRepository, ITrainingsRepository trainingsRepository,
            IOtherInformationsRepository otherInformationsRepository)
        {
            OtherInformationsRepository = otherInformationsRepository ?? throw new ArgumentNullException(nameof(otherInformationsRepository));
            EligibilitiesRepository = eligibilitiesRepository ?? throw new ArgumentNullException(nameof(eligibilitiesRepository));
            EducationsRepository = educationsRepository ?? throw new ArgumentNullException(nameof(educationsRepository));
            CivicWorksRepository = civicWorksRepository ?? throw new ArgumentNullException(nameof(civicWorksRepository));
            TrainingsRepository = trainingsRepository ?? throw new ArgumentNullException(nameof(trainingsRepository));
            WorksRepository = worksRepository ?? throw new ArgumentNullException(nameof(worksRepository));
            EventHub = eventHub ?? throw new ArgumentNullException(nameof(eventHub));
        }

        private readonly IOtherInformationsRepository OtherInformationsRepository;
        private readonly IEligibilitiesRepository EligibilitiesRepository;
        private readonly IEducationsRepository EducationsRepository;
        private readonly ICivicWorksRepository CivicWorksRepository;
        private readonly ITrainingsRepository TrainingsRepository;
        private readonly IWorksRepository WorksRepository;
        private readonly IEventHub EventHub;
    }
}