using School.People.Core.Dtos.Aggregates;
using System;

namespace School.People.App.Queries.Data
{
    public class PersonalInformationQueryData
    {
        public object BirthAddress { get; set; }
        public object ResidentialAddress { get; set; }
        public object PermanentAddress { get; set; }
        public DateTimeOffset? Birthdate { get; set; }
        public string DualCitizenshipMode { get; set; }
        public string DualCitizenship { get; set; }
        public string Country { get; set; }
        public string Sex { get; set; }
        public string CivilStatus { get; set; }
        public string OtherCivilStatus { get; set; }
        public double HeightInCentimeters { get; set; }
        public double WeightInKilograms { get; set; }
        public string BloodType { get; set; }
        public string AgencyId { get; set; }
        public string GsisIdNumber { get; set; }
        public string PagIbigIdNumber { get; set; }
        public string PhilhealthNumber { get; set; }
        public string SssNumber { get; set; }
        public string Tin { get; set; }
        public string EmailAddress { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
    }
}
