using System;
using School.People.Core.Attributes;
using School.People.Core.DTOs.Aggregates;

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

    public class UpdateImagesCommand : Command<IIdPicture>
    {
        public UpdateImagesCommand(Guid id, IIdPicture data)
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

    public class InsertOtherInformationCommand : Command<IOtherInformation>
    {
        public InsertOtherInformationCommand(Guid id, IOtherInformation data, Guid key)
            : base(id, data, key) { }
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

    public class InsertTrainingCommand : Command<ITraining>
    {
        public InsertTrainingCommand(Guid id, ITraining data, Guid key)
            : base(id, data, key) { }
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

    public class InsertCivicWorkCommand : Command<ICivicWork>
    {
        public InsertCivicWorkCommand(Guid id, ICivicWork data, Guid key)
            : base(id, data, key) { }
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

    public class InsertWorkCommand : Command<IWork>
    {
        public InsertWorkCommand(Guid id, IWork data, Guid key)
            : base(id, data, key) { }
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

    public class InsertEligibilityCommand : Command<IEligibility>
    {
        public InsertEligibilityCommand(Guid id, IEligibility data, Guid key)
            : base(id, data, key) { }
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

    public class InsertEducationCommand : Command<IEducation>
    {
        public InsertEducationCommand(Guid id, IEducation data, Guid key)
            : base(id, data, key) { }
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
