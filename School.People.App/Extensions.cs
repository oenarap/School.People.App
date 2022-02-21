using System;
using School.People.Core;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Dtos;
using System.Collections.Generic;

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
            var title = person.Title == null ? null : $"{person.Title} ";
            var extension = person.NameExtension == null ? null : $", {person.NameExtension}";
            return $"{title}{person.FirstName} {person.MiddleName} {person.LastName}{extension}";
        }

        public static Person[] ToPersonArray(this IEnumerable<IPerson> people)
        {
            var output = new List<Person>();

            foreach (var person in people)
            {
                output.Add(new Person()
                {
                    Id = person.Id,
                    LastName = person.LastName,
                    FirstName = person.FirstName,   
                    MiddleName = person.MiddleName,
                    NameExtension = person.NameExtension,
                    Title = person.Title
                });
            }

            return output.ToArray();
        }

        public static Person Copy(this IPerson person)
        {
            return new Person()
            {
                Id = person.Id,
                LastName = person.LastName,
                FirstName = person.FirstName,
                MiddleName = person.MiddleName,
                NameExtension = person.NameExtension,
                Title = person.Title,
            };
        }

        public static PersonDetails Copy(this IPersonDetails details)
        {
            return new PersonDetails()
            {
                Id=details.Id,
                CivilStatus = details.CivilStatus,
                OtherCivilStatus = details.OtherCivilStatus,
                HeightInCentimeters = details.HeightInCentimeters,
                WeightInKilograms = details.WeightInKilograms,
                BloodType = details.BloodType,
                Sex = details.Sex
            };
        }
    }
}
