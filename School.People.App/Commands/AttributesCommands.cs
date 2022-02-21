using System;
using School.People.Core.Attributes;

namespace School.People.App.Commands
{
    public class UpdateImagesCommand : Command<IIdPicture>
    {
        public UpdateImagesCommand(Guid commandId, Guid userId, IIdPicture data)
            : base(commandId, userId, data) { }
    }

    public class UpdateAddressIdsCommand : Command<IAddressIds>
    {
        public UpdateAddressIdsCommand(Guid commandId, Guid userId, IAddressIds data)
            : base(commandId, userId, data) { }
    }

    public class UpdateCitizenshipCommand : Command<ICitizenship>
    {
        public UpdateCitizenshipCommand(Guid commandId, Guid userId, ICitizenship data)
            : base(commandId, userId, data) { }
    }

    public class UpdateContactDetailsCommand : Command<IContactDetails>
    {
        public UpdateContactDetailsCommand(Guid commandId, Guid userId, IContactDetails data)
            : base(commandId, userId, data) { }
    }

    public class UpdateAgencyMemberDetailsCommand : Command<IAgencyMemberDetails>
    {
        public UpdateAgencyMemberDetailsCommand(Guid commandId, Guid userId, IAgencyMemberDetails data)
            : base(commandId, userId, data) { }
    }
    
    public class UpdateDateOfBirthCommand : Command<IDateOfBirth>
    {
        public UpdateDateOfBirthCommand(Guid commandId, Guid userId, IDateOfBirth data)
            : base(commandId, userId, data) { }
    }

    public class UpdateVerificationDetailsCommand : Command<IVerificationDetails>
    {
        public UpdateVerificationDetailsCommand(Guid commandId, Guid userId, IVerificationDetails data)
            : base(commandId, userId, data) { }
    }

    public class UpdateFaqsCommand : Command<IFaqs>
    {
        public UpdateFaqsCommand(Guid commandId, Guid userId, IFaqs data)
            : base(commandId, userId, data) { }
    }

    public class UpdateCharacterReferencesIdsCommand : Command<ICharacterReferencesIds>
    {
        public UpdateCharacterReferencesIdsCommand(Guid commandId, Guid userId, ICharacterReferencesIds data)
            : base(commandId, userId, data) { }
    }

    public class DeleteOtherInformationCommand : Command<IOtherInformation>
    {
        public DeleteOtherInformationCommand(Guid commandId, Guid userId, IOtherInformation data)
            : base(commandId, userId, data) { }
    }

    public class UpdateOtherInformationCommand : Command<IOtherInformation>
    {
        public UpdateOtherInformationCommand(Guid commandId, Guid userId, IOtherInformation data)
            : base(commandId, userId, data) { }
    }

    public class InsertOtherInformationCommand : Command<IOtherInformation, Guid>
    {
        public InsertOtherInformationCommand(Guid commandId, Guid userId, IOtherInformation data, Guid parameter)
            : base(commandId, userId, data, parameter) { }
    }

    public class DeleteTrainingCommand : Command<ITraining>
    {
        public DeleteTrainingCommand(Guid commandId, Guid userId, ITraining data)
            : base(commandId, userId, data) { }
    }

    public class UpdateTrainingCommand : Command<ITraining>
    {
        public UpdateTrainingCommand(Guid commandId, Guid userId, ITraining data)
            : base(commandId, userId, data) { }
    }

    public class InsertTrainingCommand : Command<ITraining, Guid>
    {
        public InsertTrainingCommand(Guid commandId, Guid userId, ITraining data, Guid parameter)
            : base(commandId, userId, data, parameter) { }
    }

    public class DeleteCivicWorkCommand : Command<ICivicWork>
    {
        public DeleteCivicWorkCommand(Guid commandId, Guid userId, ICivicWork data)
            : base(commandId, userId, data) { }
    }

    public class UpdateCivicWorkCommand : Command<ICivicWork>
    {
        public UpdateCivicWorkCommand(Guid commandId, Guid userId, ICivicWork data)
            : base(commandId, userId, data) { }
    }

    public class InsertCivicWorkCommand : Command<ICivicWork, Guid>
    {
        public InsertCivicWorkCommand(Guid commandId, Guid userId, ICivicWork data, Guid parameter)
            : base(commandId, userId, data, parameter) { }
    }

    public class DeleteWorkCommand : Command<IWork>
    {
        public DeleteWorkCommand(Guid commandId, Guid userId, IWork data)
            : base(commandId, userId, data) { }
    }

    public class UpdateWorkCommand : Command<IWork>
    {
        public UpdateWorkCommand(Guid commandId, Guid userId, IWork data)
            : base(commandId, userId, data) { }
    }

    public class InsertWorkCommand : Command<IWork, Guid>
    {
        public InsertWorkCommand(Guid commandId, Guid userId, IWork data, Guid parameter)
            : base(commandId, userId, data, parameter) { }
    }

    public class DeleteEligibilityCommand : Command<IEligibility>
    {
        public DeleteEligibilityCommand(Guid commandId, Guid userId, IEligibility data)
            : base(commandId, userId, data) { }
    }

    public class UpdateEligibilityCommand : Command<IEligibility>
    {
        public UpdateEligibilityCommand(Guid commandId, Guid userId, IEligibility data)
            : base(commandId, userId, data) { }
    }

    public class InsertEligibilityCommand : Command<IEligibility>
    {
        public InsertEligibilityCommand(Guid commandId, Guid userId, IEligibility data)
            : base(commandId, userId, data) { }
    }

    public class DeleteEducationCommand : Command<IEducation>
    {
        public DeleteEducationCommand(Guid commandId, Guid userId, IEducation data)
            : base(commandId, userId, data) { }
    }

    public class UpdateEducationCommand : Command<IEducation>
    {
        public UpdateEducationCommand(Guid commandId, Guid userId, IEducation data)
            : base(commandId, userId, data) { }
    }

    public class InsertEducationCommand : Command<IEducation, Guid>
    {
        public InsertEducationCommand(Guid commandId, Guid userId, IEducation data, Guid parameter)
            : base(commandId, userId, data, parameter) { }
    }

    public class UpdateFamilyIdsCommand : Command<IFamilyIds>
    {
        public UpdateFamilyIdsCommand(Guid commandId, Guid userId, IFamilyIds data)
            : base(commandId, userId, data) { }
    }

    public class UpdatePersonDetailsCommand : Command<IPersonDetails>
    {
        public UpdatePersonDetailsCommand(Guid commandId, Guid userId, IPersonDetails data)
            : base(commandId, userId, data) { }
    }
}
