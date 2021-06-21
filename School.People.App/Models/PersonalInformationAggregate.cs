using System;
using School.People.Core.Attributes.Aggregates;

namespace School.People.App.Models
{
    public class PersonalInformationAggregate : IPersonalInformationAggregate
    {
        public Guid Id { get; set; }
        public object BirthAddress { get; set; }
        public object ResidentialAddress { get; set; }
        public object PermanentAddress { get; set; }
        public string EmailAddress { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string AgencyId { get; set; }
        public string GsisIdNumber { get; set; }
        public string PagIbigIdNumber { get; set; }
        public string PhilhealthNumber { get; set; }
        public string SssNumber { get; set; }
        public string Tin { get; set; }
        public string Sex { get; set; }
        public string CivilStatus { get; set; }
        public string OtherCivilStatus { get; set; }
        public double HeightInCentimeters { get; set; }
        public double WeightInKilograms { get; set; }
        public string BloodType { get; set; }
        public string DualCitizenshipMode { get; set; }
        public string DualCitizenship { get; set; }
        public string Country { get; set; }
        public DateTimeOffset? Birthdate { get; set; }

        public PersonalInformationAggregate()
            : this(Guid.Empty) { }

        public PersonalInformationAggregate(Guid id) 
            : this(id, null, null, null, null, null, 0d, 0d, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null) { }

        public PersonalInformationAggregate(Guid id, DateTimeOffset? birthDate, string dualCitizenship, string dualCitizenshipMode, string country,
            string bloodType, double weightInKilograms, double heightInCentimeters, string civilStatus, string otherCivilStatus, string sex, string tin,
            string sssNumber, string philhealthNumber, string pagIbigIdNumber, string gsisIdNumber, string agencyId, string mobileNumber,
            string telephoneNumber, string emailAddress, object birthAddress, object residentialAddress, object permanentAddress) {
            Id = id;
            Birthdate = birthDate;
            DualCitizenship = dualCitizenship;
            DualCitizenshipMode = dualCitizenshipMode;
            Country = country;
            BloodType = bloodType;
            WeightInKilograms = weightInKilograms;
            HeightInCentimeters = heightInCentimeters;
            CivilStatus = civilStatus;
            OtherCivilStatus = otherCivilStatus;
            Sex = sex;
            Tin = tin;
            SssNumber = sssNumber;
            PhilhealthNumber = philhealthNumber;
            PagIbigIdNumber = pagIbigIdNumber;
            GsisIdNumber = gsisIdNumber;
            AgencyId = agencyId;
            MobileNumber = mobileNumber;
            TelephoneNumber = telephoneNumber;
            EmailAddress = emailAddress;
            BirthAddress = birthAddress;
            ResidentialAddress = residentialAddress;
            PermanentAddress = permanentAddress;
        }
    }
}
