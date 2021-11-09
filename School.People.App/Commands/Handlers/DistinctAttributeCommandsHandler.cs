using System;
using System.Threading.Tasks;
using School.People.App.Events;
using School.People.Core.Repositories;
using Apps.Communication.Core;

namespace School.People.App.Commands.Handlers
{
    public class DistinctAttributeCommandsHandler : IHandle<UpdateAgencyMemberDetailsCommand, bool>, 
        IHandle<UpdateDateOfBirthCommand, bool>, IHandle<UpdateCitizenshipCommand, bool>, IHandle<UpdateImagesCommand, bool>,
        IHandle<UpdateAddressIdsCommand, bool>, IHandle<UpdateContactDetailsCommand, bool>, IHandle<UpdatePersonDetailsCommand, bool>
    {
        public async Task<bool> Handle(UpdateImagesCommand message)
        {
            try
            {
                var repository = (IImagesRepository)provider.GetService(typeof(IImagesRepository));
                bool result = await repository.UpdateAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new ImagesUpdatedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(UpdateContactDetailsCommand message)
        {
            try
            {
                var repository = (IContactDetailsRepository)provider.GetService(typeof(IContactDetailsRepository));
                bool result = await repository.UpdateAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new ContactDetailsUpdatedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(UpdateAddressIdsCommand message)
        {
            try
            {
                var repository = (IAddressIdsRepository)provider.GetService(typeof(IAddressIdsRepository));
                bool result = await repository.UpdateAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new AddressIdsUpdatedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(UpdateAgencyMemberDetailsCommand message)
        {
            try
            {
                var repository = (IAgencyMemberDetailsRepository)provider.GetService(typeof(IAgencyMemberDetailsRepository));
                bool result = await repository.UpdateAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new AgencyMemberDetailsUpdatedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(UpdateDateOfBirthCommand message)
        {
            try
            {
                var repository = (IDateOfBirthsRepository)provider.GetService(typeof(IDateOfBirthsRepository));
                bool result = await repository.UpdateAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new DateOfBirthUpdatedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(UpdateCitizenshipCommand message)
        {
            try
            {
                var repository = (ICitizenshipsRepository)provider.GetService(typeof(ICitizenshipsRepository));
                bool result = await repository.UpdateAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new CitizenshipUpdatedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Handle(UpdatePersonDetailsCommand message)
        {
            try
            {
                var repository = (IPersonDetailsRepository)provider.GetService(typeof(IPersonDetailsRepository));
                bool result = await repository.UpdateAsync(message.Data).ConfigureAwait(false);

                if (result == true) { eventHub.Dispatch(new PersonDetailsUpdatedEvent(message.Id, message.Data)); }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DistinctAttributeCommandsHandler(ICommandHub commandHub, IServiceProvider provider, IEventHub eventHub)
        {
            commandHub.RegisterHandler<UpdateImagesCommand, DistinctAttributeCommandsHandler, bool>(this);
            commandHub.RegisterHandler<UpdateContactDetailsCommand, DistinctAttributeCommandsHandler, bool>(this);
            commandHub.RegisterHandler<UpdateAddressIdsCommand, DistinctAttributeCommandsHandler, bool>(this);
            commandHub.RegisterHandler<UpdateAgencyMemberDetailsCommand, DistinctAttributeCommandsHandler, bool>(this);
            commandHub.RegisterHandler<UpdateDateOfBirthCommand, DistinctAttributeCommandsHandler, bool>(this);
            commandHub.RegisterHandler<UpdateCitizenshipCommand, DistinctAttributeCommandsHandler, bool>(this);
            commandHub.RegisterHandler<UpdatePersonDetailsCommand, DistinctAttributeCommandsHandler, bool>(this);

            this.eventHub = eventHub;
            this.provider = provider;
        }

        private readonly IServiceProvider provider;
        private readonly IEventHub eventHub;
    }
}
