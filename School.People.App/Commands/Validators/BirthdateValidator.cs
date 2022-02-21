using System;
using Apps.Communication.Core;
using School.People.Core.Repositories;
using System.Threading.Tasks;

namespace School.People.App.Commands.Validators
{
    public class BirthdateValidator : IHandle<UpdateDateOfBirthCommand, bool>
    {
        public async Task<bool> Handle(UpdateDateOfBirthCommand message)
        {
            if (message.Data.Birthdate is DateTimeOffset birthdate)
            {
                switch (DateTimeOffset.Now.Subtract(birthdate).Days)
                {
                    case var a when a < 5475 || a > 27375: //below 15 years old OR above 75 years old
                        var studentsRepo = (IStudentsRepository)provider.GetService(typeof(IStudentsRepository));
                        var student = await studentsRepo.ReadAsync(message.Data.Id).ConfigureAwait(false);
                        if (student != null) { return false; }
                        break;

                    default:
                        var birthdaysRepo = (IDateOfBirthsRepository)provider.GetService(typeof(IDateOfBirthsRepository));
                        var idsRepo = (IFamilyIdsRepository)provider.GetService(typeof(IFamilyIdsRepository));
                        var ids = await idsRepo.ReadAsync(message.Data.Id);

                        if (ids != null)
                        {
                            if (ids.MotherId is Guid motherId)
                            {
                                var mothersDob = await birthdaysRepo.ReadAsync(motherId);
                                if (mothersDob.Birthdate is DateTimeOffset momBirthdate)
                                {
                                    var ageGap = (birthdate.Subtract(momBirthdate)).Days;
                                    if (ageGap < VALID_AGE_GAP) { return false; }
                                }
                            }
                            if (ids.FatherId is Guid fatherId)
                            {
                                var fatherDob = await birthdaysRepo.ReadAsync(fatherId);
                                if (fatherDob.Birthdate is DateTimeOffset dadBirthdate)
                                {
                                    var ageGap = (birthdate.Subtract(dadBirthdate)).Days;
                                    if (ageGap < VALID_AGE_GAP) { return false; }
                                }
                            }
                        }

                        var childrenIdsRepo = (IChildrenIdsRepository)provider.GetService(typeof(IChildrenIdsRepository));
                        var childrenIds = await childrenIdsRepo.ReadAllAsync(message.Data.Id);

                        if (childrenIds != null)
                        {
                            foreach (var id in childrenIds)
                            {
                                var childDob = await birthdaysRepo.ReadAsync(id);

                                if (childDob.Birthdate is DateTimeOffset childBirthdate)
                                {
                                    var ageGap = (birthdate.Subtract(childBirthdate)).Days;
                                    if (ageGap < VALID_AGE_GAP) { return false; }
                                }
                            }
                        }
                        break;
                }
            }
            return true;
        }

        public BirthdateValidator(IServiceProvider provider)
        {
            this.provider = provider;
        }

        private const int VALID_AGE_GAP = 4015; // 11 years
        private readonly IServiceProvider provider;
    }
}
