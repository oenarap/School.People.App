using System;
using School.People.Core;
using System.Threading.Tasks;
using School.People.Core.DTOs;
using School.People.Core.Attributes;

namespace School.People.App
{
    public static class Extensions
    {
        public static async void FireAndForget(this Task task, bool continueOnCapturedContext = true, Action<Exception> onException = null)
        {
            try
            {
                await task.ConfigureAwait(continueOnCapturedContext);
            }
            catch (Exception ex) when (onException != null)
            {
                onException(ex);
            }
        }

        public static string FullName(this IPerson person)
        {
            string nameExtension = person.NameExtension == null ? null : $", {person.NameExtension}";
            return $"{person.Title} {person.FirstName} {person.MiddleName} {person.LastName}{nameExtension}";
        }

        /// <summary>
        /// Copies the person's details except the Id.
        /// </summary>
        public static void CopyTo(this IPerson person, Person other)
        {
            if (other != null)
            {
                other.FirstName = person.FirstName;
                other.MiddleName = person.MiddleName;
                other.LastName = person.LastName;
                other.NameExtension = person.NameExtension;
                other.Title = person.Title;
            }
        }

        public static void CopyTo(this IPersonDetails details, PersonDetails other)
        {
            if (other != null)
            {
                other.Sex = details.Sex;
                other.CivilStatus = details.CivilStatus;
                other.OtherCivilStatus = details.OtherCivilStatus;
                other.HeightInCentimeters = details.HeightInCentimeters;
                other.WeightInKilograms = details.WeightInKilograms;
                other.BloodType = details.BloodType;
            }
        }
    }
}
