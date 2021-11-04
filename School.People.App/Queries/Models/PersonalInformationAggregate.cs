using School.People.Core.DTOs.Aggregates;
using System;

namespace School.People.App.Queries.Models
{
    /// <summary>
    /// A personal information aggregate implementation that 
    /// allows multi-thread processing of its properties
    /// </summary>
    public class PersonalInformationAggregate
    {
        [ThreadStatic]
        private readonly Core.DTOs.Aggregates.PersonalInformationAggregate personalInfo;

        public PersonalInformationAggregate(Guid id)
        {
            personalInfo = new Core.DTOs.Aggregates.PersonalInformationAggregate(id);
        }

        public Guid Id { get => personalInfo.Id; set => personalInfo.Id = value; }

        public object BirthAddress { get => personalInfo.BirthAddress; set => personalInfo.BirthAddress = value; }
        public object ResidentialAddress { get => personalInfo.ResidentialAddress; set => personalInfo.ResidentialAddress = value; }
        public object PermanentAddress { get => personalInfo.PermanentAddress; set => personalInfo.PermanentAddress = value; }
        public DateTimeOffset? Birthdate { get => personalInfo.Birthdate; set => personalInfo.Birthdate = value; }
        public string DualCitizenshipMode { get => personalInfo.DualCitizenshipMode; set => personalInfo.DualCitizenshipMode = value; }
        public string DualCitizenship { get => personalInfo.DualCitizenship; set => personalInfo.DualCitizenship = value; }
        public string Country { get => personalInfo.Country; set => personalInfo.Country = value; }
        public string Sex { get => personalInfo.Sex; set => personalInfo.Sex = value; }
        public string CivilStatus { get => personalInfo.CivilStatus; set => personalInfo.CivilStatus = value; }
        public string OtherCivilStatus { get => personalInfo.OtherCivilStatus; set => personalInfo.OtherCivilStatus = value; }
        public double HeightInCentimeters { get => personalInfo.HeightInCentimeters; set => personalInfo.HeightInCentimeters = value; }
        public double WeightInKilograms { get => personalInfo.WeightInKilograms; set => personalInfo.WeightInKilograms = value; }
        public string BloodType { get => personalInfo.BloodType; set => personalInfo.BloodType = value; }
        public string AgencyId { get => personalInfo.AgencyId; set => personalInfo.AgencyId = value; }
        public string GsisIdNumber { get => personalInfo.GsisIdNumber; set => personalInfo.GsisIdNumber = value; }
        public string PagIbigIdNumber { get => personalInfo.PagIbigIdNumber; set => personalInfo.PagIbigIdNumber = value; }
        public string PhilhealthNumber { get => personalInfo.PhilhealthNumber; set => personalInfo.PhilhealthNumber = value; }
        public string SssNumber { get => personalInfo.SssNumber; set => personalInfo.SssNumber = value; }
        public string Tin { get => personalInfo.Tin; set => personalInfo.Tin = value; }
        public string EmailAddress { get => personalInfo.EmailAddress; set => personalInfo.EmailAddress = value; }
        public string TelephoneNumber { get => personalInfo.TelephoneNumber; set => personalInfo.TelephoneNumber = value; }
        public string MobileNumber { get => personalInfo.MobileNumber; set => personalInfo.MobileNumber = value; }
    }
}
