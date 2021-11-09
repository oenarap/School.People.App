using School.People.App.Queries.Models;
using System;
using System.Threading;
using Xunit;

namespace School.People.App.Tests
{
    public class ModelsUnitTests
    {
        [Theory]
        [InlineData("By Birth", "Pakistan", "0912 345 6789")]
        public void ShouldAllowMultipleThrededUpdate_PersonalInformationAggregate(string dualCitizenshipMode, 
            string country, string mobileNumber) {

            var id = Guid.NewGuid();
            var model = new PersonalInformationQueryData(id);
            var birthdate = DateTimeOffset.UtcNow;

            var BirthdateThread = new Thread(() =>
            {
                Thread.Sleep(200);
                model.Birthdate = birthdate;
            });
            var DualCitizenshipModeThread = new Thread(() =>
            {
                Thread.Sleep(199);
                model.DualCitizenshipMode = dualCitizenshipMode;
            });
            var CountryThread = new Thread(() =>
            {
                Thread.Sleep(198);
                model.Country = country;
            });
            var MobileNumberThread = new Thread(() =>
            {
                Thread.Sleep(197);
                model.MobileNumber = mobileNumber;
            });

            BirthdateThread.Start();
            DualCitizenshipModeThread.Start();
            CountryThread.Start();
            MobileNumberThread.Start();

            Thread.Sleep(1000);

            Assert.Equal(id, model.Id);
            Assert.Equal(birthdate, model.Birthdate);
            Assert.Same(dualCitizenshipMode, model.DualCitizenshipMode);
            Assert.Same(country, model.Country);
            Assert.Same(mobileNumber, model.MobileNumber);
        }
    }
}
