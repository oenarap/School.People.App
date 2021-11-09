using System.Linq;
using School.People.Core;
using System.Threading.Tasks;
using Apps.Communication.Core;

namespace School.People.App.Commands.Validators
{
    public class PersonValidator : IHandle<InsertStudentCommand, bool>, IHandle<UpdatePersonCommand, bool>, 
        IHandle<InsertPersonnelCommand, bool>, IHandle<InsertOtherPersonCommand, bool>
    {
        public Task<bool> Handle(InsertOtherPersonCommand item) => Task.Run(() => IsValidPerson(item.Data));

        public Task<bool> Handle(InsertPersonnelCommand item) => Task.Run(() => IsValidPerson(item.Data));

        public Task<bool> Handle(UpdatePersonCommand item) => Task.Run(() => IsValidPerson(item.Data));

        public Task<bool> Handle(InsertStudentCommand item) => Task.Run(() => IsValidPerson(item.Data));

        private bool IsValidPerson(IPerson person)
        {
            if (person != null)
            {
                if (IsValidLastName(person.LastName) && IsValidFirstName(person.FirstName) &&
                    IsValidLastName(person.MiddleName) && IsValidExtensionName(person.NameExtension) &&
                    IsValidTitle(person.Title)) { return true; }
            }
            return false;
        }

        private bool IsValidFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName) || !IsNonNumeric(firstName)) { return false; }
            return firstName.Length >= Constants.PersonNameFieldsMinLength && firstName.Length <= Constants.CommonNamesAndTitlesMaxLength;
        }

        private bool IsValidLastName(string surname)
        {
            if (string.IsNullOrEmpty(surname) || string.IsNullOrWhiteSpace(surname) || !IsNonNumeric(surname)) { return false; }
            return surname.Length >= Constants.PersonNameFieldsMinLength && surname.Length <= Constants.PersonSurnameMaxLength;
        }

        private bool IsValidExtensionName(string extensionName)
        {
            if (extensionName != null && IsNonNumeric(extensionName)) 
            {
                return extensionName.Length <= Constants.PersonNameExtensionMaxLength;
            }
            return true;
        }

        private bool IsValidTitle(string title)
        {
            if (string.IsNullOrEmpty(title)) { return true; }
            return title.Length <= Constants.PersonTitleMaxLength;
        }

        private bool IsNonNumeric(string str)
        {
            string normalizedString = str.Replace(" ","").Replace("-", "").Replace(".", "");
            return normalizedString.All(char.IsLetter);
        }

        public PersonValidator(ICommandHub hub)
        {
            hub.RegisterValidator<InsertStudentCommand, PersonValidator>(this);
            hub.RegisterValidator<UpdatePersonCommand, PersonValidator>(this);
            hub.RegisterValidator<InsertPersonnelCommand, PersonValidator>(this);
            hub.RegisterValidator<InsertOtherPersonCommand, PersonValidator>(this);
        }
    }
}
