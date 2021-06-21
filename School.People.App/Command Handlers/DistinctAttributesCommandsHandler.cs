using System;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.App.Events;
using School.People.Core.Repositories;
using Apps.Communication.Core;

namespace School.People.App.Commands.Handlers
{
    public class DistinctAttributesCommandsHandler : IHandle<UpdateAgencyMemberDetailsCommand, bool>, 
        IHandle<UpdateDateOfBirthCommand, bool>, IHandle<UpdateCitizenshipCommand, bool>, IHandle<UpdateImagesCommand, bool>,
        IHandle<UpdateAddressIdsCommand, bool>, IHandle<UpdateContactDetailsCommand, bool>, IHandle<UpdatePersonDetailsCommand, bool>,
        IHandle<UpdateMotherIdCommand, bool>, IHandle<UpdateFatherIdCommand, bool>, IHandle<UpdateSpouseIdCommand, bool>
    {
        public async Task<bool> Handle(UpdateSpouseIdCommand command)
        {
            try
            {
                bool result = await SpouseIdsRepository.UpdateAsync(command.Id, command.Data).ConfigureAwait(false);
                if (result == true) { EventHub.Dispatch(new SpouseIdUpdatedEvent(command.Id, command.Data)); }
                return result;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(UpdateFatherIdCommand command)
        {
            try
            {
                if (command.Data is Guid id)
                {
                    bool result = await FatherIdsRepository.UpdateAsync(command.Id, id).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new FatherIdUpdatedEvent(command.Id, id)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(UpdateMotherIdCommand command)
        {
            try
            {
                if (command.Data is Guid id)
                {
                    bool result = await MotherIdsRepository.UpdateAsync(command.Id, id).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new MotherIdUpdatedEvent(command.Id, id)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(UpdateImagesCommand command)
        {
            try
            {
                if (command.Data is IImage data)
                {
                    bool result = await ImagesRepository.UpdateAsync(data).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new ImagesUpdatedEvent(command.Id, data)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(UpdateContactDetailsCommand command)
        {
            try
            {
                if (command.Data is IContactDetails data)
                {
                    bool result = await ContactDetailsRepository.UpdateAsync(data).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new ContactDetailsUpdatedEvent(command.Id, data)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(UpdateAddressIdsCommand command)
        {
            try
            {
                if (command.Data is IAddressIds data)
                {
                    bool result = await AddressIdsRepository.UpdateAsync(data).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new AddressIdsUpdatedEvent(command.Id, data)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(UpdateAgencyMemberDetailsCommand command)
        {
            try
            {
                if (command.Data is IAgencyMemberDetails data)
                {
                    bool result = await AgencyMemberDetailsRepository.UpdateAsync(data).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new AgencyMemberDetailsUpdatedEvent(command.Id, data)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(UpdateDateOfBirthCommand command)
        {
            if (command.Data is IDateOfBirth data)
            {
                bool result = await DateOfBirthsRepository.UpdateAsync(data).ConfigureAwait(false);
                if (result == true) { EventHub.Dispatch(new DateOfBirthUpdatedEvent(command.Id, data)); }
                return result;
            }
            return false;
        }

        public async Task<bool> Handle(UpdateCitizenshipCommand command)
        {
            try
            {
                if (command.Data is ICitizenship data)
                {
                    bool result = await CitizenshipsRepository.UpdateAsync(data).ConfigureAwait(false);
                    if (result == true) { EventHub.Dispatch(new CitizenshipUpdatedEvent(command.Id, data)); }
                    return result;
                }
                return false;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public async Task<bool> Handle(UpdatePersonDetailsCommand command)
        {
            try
            {
                bool result = await PersonDetailsRepository.UpdateAsync(command.Data).ConfigureAwait(false);
                if (result == true) { EventHub.Dispatch(new PersonDetailsUpdatedEvent(command.Id, command.Data)); }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DistinctAttributesCommandsHandler(IEventHub eventHub, IMotherIdsRepository motherIdsRepository, IFatherIdsRepository fatherIdsRepository,
            ISpouseIdsRepository spouseIdsRepository, IContactDetailsRepository contactDetailsRepository, IAddressIdsRepository addressIdsRepository, 
            IDateOfBirthsRepository dateOfBirthsRepository, ICitizenshipsRepository citizenshipsRepository, IAgencyMemberDetailsRepository agencyMemberDetailsRepository, 
            IImagesRepository imagesRepository, IPersonDetailsRepository personalInformationsRepository)
        {
            ImagesRepository = imagesRepository ?? throw new ArgumentNullException(nameof(imagesRepository));
            AgencyMemberDetailsRepository = agencyMemberDetailsRepository ?? throw new ArgumentNullException(nameof(agencyMemberDetailsRepository));
            CitizenshipsRepository = citizenshipsRepository ?? throw new ArgumentNullException(nameof(citizenshipsRepository));
            DateOfBirthsRepository = dateOfBirthsRepository ?? throw new ArgumentNullException(nameof(dateOfBirthsRepository));
            PersonDetailsRepository = personalInformationsRepository ?? throw new ArgumentNullException(nameof(personalInformationsRepository));
            ContactDetailsRepository = contactDetailsRepository ?? throw new ArgumentNullException(nameof(contactDetailsRepository));
            MotherIdsRepository = motherIdsRepository ?? throw new ArgumentNullException(nameof(motherIdsRepository));
            FatherIdsRepository = fatherIdsRepository ?? throw new ArgumentNullException(nameof(fatherIdsRepository));
            SpouseIdsRepository = spouseIdsRepository ?? throw new ArgumentNullException(nameof(spouseIdsRepository));
            AddressIdsRepository = addressIdsRepository ?? throw new ArgumentNullException(nameof(addressIdsRepository));
            EventHub = eventHub ?? throw new ArgumentNullException(nameof(eventHub));
        }

        private readonly IImagesRepository ImagesRepository;
        private readonly IAgencyMemberDetailsRepository AgencyMemberDetailsRepository;
        private readonly ICitizenshipsRepository CitizenshipsRepository;
        private readonly IDateOfBirthsRepository DateOfBirthsRepository;
        private readonly IPersonDetailsRepository PersonDetailsRepository;
        private readonly IContactDetailsRepository ContactDetailsRepository;
        private readonly ISpouseIdsRepository SpouseIdsRepository;
        private readonly IFatherIdsRepository FatherIdsRepository;
        private readonly IMotherIdsRepository MotherIdsRepository;
        private readonly IAddressIdsRepository AddressIdsRepository;
        private readonly IEventHub EventHub;
    }
}
