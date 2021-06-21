using System;
using School.People.Core.Attributes;
using School.People.App.Models;

namespace School.People.App.Commands
{
    public class UpdateSpouseIdCommand : Command<Guid?>
    {
        public UpdateSpouseIdCommand(Guid id, Guid? data)
           : base(id, data) { }
    }

    public class UpdateFatherIdCommand : Command<Guid>
    {
        public UpdateFatherIdCommand(Guid id, Guid data)
           : base(id, data) { }
    }

    public class UpdateMotherIdCommand : Command<Guid>
    {
        public UpdateMotherIdCommand(Guid id, Guid data)
           : base(id, data) { }
    }

    public class UpdateImagesCommand : Command<IImage>
    {
        public UpdateImagesCommand(Guid id, IImage data)
            : base(id, data) { }
    }

    public class UpdateAddressIdsCommand : Command<IAddressIds>
    {
        public UpdateAddressIdsCommand(Guid id, IAddressIds data)
            : base(id, data) { }
    }

    public class UpdateCitizenshipCommand : Command<ICitizenship>
    {
        public UpdateCitizenshipCommand(Guid id, ICitizenship data)
            : base(id, data) { }
    }

    public class UpdateContactDetailsCommand : Command<IContactDetails>
    {
        public UpdateContactDetailsCommand(Guid id, IContactDetails data)
            : base(id, data) { }
    }

    public class UpdateAgencyMemberDetailsCommand : Command<IAgencyMemberDetails>
    {
        public UpdateAgencyMemberDetailsCommand(Guid id, IAgencyMemberDetails data)
            : base(id, data) { }
    }
    
    public class UpdateDateOfBirthCommand : Command<IDateOfBirth>
    {
        public UpdateDateOfBirthCommand(Guid id, IDateOfBirth data)
            : base(id, data) { }
    }

    public class UpdateVerificationDetailsCommand : Command<VerificationDetailsAggregate>
    {
        public UpdateVerificationDetailsCommand(Guid id, VerificationDetailsAggregate data)
            : base(id, data) { }
    }

    public class UpdateFaqsCommand : Command<IFaqs>
    {
        public UpdateFaqsCommand(Guid id, IFaqs data)
            : base(id, data) { }
    }

    public class UpdateCharacterReferencesIdsCommand : Command<ICharacterReferencesIds>
    {
        public UpdateCharacterReferencesIdsCommand(Guid id, ICharacterReferencesIds data)
            : base(id, data) { }
    }

    public class DeleteOtherInformationCommand : Command<IOtherInformation>
    {
        public DeleteOtherInformationCommand(Guid id, IOtherInformation data)
            : base(id, data) { }
    }

    public class UpdateOtherInformationCommand : Command<IOtherInformation>
    {
        public UpdateOtherInformationCommand(Guid id, IOtherInformation data)
            : base(id, data) { }
    }

    public class InsertOtherInformationCommand : KeyedCommand<IOtherInformation>
    {
        public InsertOtherInformationCommand(Guid id, Guid key, IOtherInformation data)
            : base(id, key, data) { }
    }

    public class DeleteTrainingCommand : Command<ITraining>
    {
        public DeleteTrainingCommand(Guid id, ITraining data)
            : base(id, data) { }
    }

    public class UpdateTrainingCommand : Command<ITraining>
    {
        public UpdateTrainingCommand(Guid id, ITraining data)
            : base(id, data) { }
    }

    public class InsertTrainingCommand : KeyedCommand<ITraining>
    {
        public InsertTrainingCommand(Guid id, Guid key, ITraining data)
            : base(id, key, data) { }
    }

    public class DeleteCivicWorkCommand : Command<ICivicWork>
    {
        public DeleteCivicWorkCommand(Guid id, ICivicWork data)
            : base(id, data) { }
    }

    public class UpdateCivicWorkCommand : Command<ICivicWork>
    {
        public UpdateCivicWorkCommand(Guid id, ICivicWork data)
            : base(id, data) { }
    }

    public class InsertCivicWorkCommand : KeyedCommand<ICivicWork>
    {
        public InsertCivicWorkCommand(Guid id, Guid key, ICivicWork data)
            : base(id, key, data) { }
    }

    public class DeleteWorkCommand : Command<IWork>
    {
        public DeleteWorkCommand(Guid id, IWork data)
            : base(id, data) { }
    }

    public class UpdateWorkCommand : Command<IWork>
    {
        public UpdateWorkCommand(Guid id, IWork data)
            : base(id, data) { }
    }

    public class InsertWorkCommand : KeyedCommand<IWork>
    {
        public InsertWorkCommand(Guid id, Guid key, IWork data)
            : base(id, key, data) { }
    }

    public class DeleteEligibilityCommand : Command<IEligibility>
    {
        public DeleteEligibilityCommand(Guid id, IEligibility data)
            : base(id, data) { }
    }

    public class UpdateEligibilityCommand : Command<IEligibility>
    {
        public UpdateEligibilityCommand(Guid id, IEligibility data)
            : base(id, data) { }
    }

    public class InsertEligibilityCommand : KeyedCommand<IEligibility>
    {
        public InsertEligibilityCommand(Guid id, Guid key, IEligibility data)
            : base(id, key, data) { }
    }

    public class DeleteEducationCommand : Command<IEducation>
    {
        public DeleteEducationCommand(Guid id, IEducation data)
            : base(id, data) { }
    }

    public class UpdateEducationCommand : Command<IEducation>
    {
        public UpdateEducationCommand(Guid id, IEducation data)
            : base(id, data) { }
    }

    public class InsertEducationCommand : KeyedCommand<IEducation>
    {
        public InsertEducationCommand(Guid id, Guid key, IEducation data)
            : base(id, key, data) { }
    }

    public class UpdateFamilyIdsCommand : Command<IFamilyIds>
    {
        public UpdateFamilyIdsCommand(Guid id, IFamilyIds data)
            : base(id, data) { }
    }

    public class UpdatePersonDetailsCommand : Command<IPersonDetails>
    {
        public UpdatePersonDetailsCommand(Guid id, IPersonDetails data)
            : base(id, data) { }
    }
}
