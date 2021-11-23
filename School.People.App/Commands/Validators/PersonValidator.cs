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
                if (IsValidNameString(person.LastName, Constants.PersonSurnameMaxLength) && 
                    IsValidNameString(person.MiddleName, Constants.PersonSurnameMaxLength) &&
                    IsValidNameString(person.FirstName, Constants.CommonNamesAndTitlesMaxLength) &&
                    IsValidNameString(person.NameExtension, Constants.PersonNameExtensionMaxLength) &&
                    IsValidNameString(person.Title, Constants.PersonTitleMaxLength)) { return true; }
            }
            return false;
        }

        // O(n) name string validation method
        private bool IsValidNameString(string nameString, int maxLength)
        {
            if (nameString.Length == 0 || nameString.Length > maxLength) { return false; }

            var letters = 0;
            var spaces = 0;
            var others = 0;

            foreach (var c in nameString)
            {
                if (char.IsLetter(c))
                {
                    letters++;
                }
                else
                {
                    if (char.IsWhiteSpace(c))
                    {
                        spaces++;
                    }
                    else if (c == '-' || c == '.')
                    {
                        others++;
                    }
                }
            }

            return letters == 0 ? false : (letters + spaces + others) == nameString.Length;
        }
    }
}
