using System.Linq;
using School.People.Core;
using System.Threading.Tasks;
using Apps.Communication.Core;

namespace School.People.App.Commands.Handlers
{
    public class PersonValidator : IHandle<InsertStudentCommand, bool>, IHandle<UpdatePersonCommand, bool>, 
        IHandle<InsertPersonnelCommand, bool>, IHandle<InsertOtherPersonCommand, bool>
    {
        public Task<bool> Handle(InsertOtherPersonCommand item) => IsValidPerson(item.Data);
        public Task<bool> Handle(InsertPersonnelCommand item) => IsValidPerson(item.Data);
        public Task<bool> Handle(UpdatePersonCommand item) => IsValidPerson(item.Data); 
        public Task<bool> Handle(InsertStudentCommand item) => IsValidPerson(item.Data);

        private Task<bool> IsValidPerson(IPerson person)
        {
            return Task.Run(() => {
                if (person != null)
                {
                    if (IsValidSurname(person.LastName) && IsValidFirstName(person.FirstName) &&
                    IsValidSurname(person.MiddleName) && IsValidExtensionName(person.NameExtension) &&
                    IsValidTitle(person.Title)) { return true; }
                }
                return false;
            });
        }

        // validation helper methods

        private bool IsValidFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrWhiteSpace(firstName) || !IsNonNumeric(firstName)) { return false; }
            return firstName.Length >= Constants.PersonNameFieldsMinLength && firstName.Length <= Constants.CommonNamesAndTitlesMaxLength;
        }

        private bool IsValidSurname(string surname)
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
    }
}
