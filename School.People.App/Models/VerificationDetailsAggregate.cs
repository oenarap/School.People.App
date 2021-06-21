using System;
using School.People.Core.Attributes;
using School.People.Core.Attributes.Aggregates;

namespace School.People.App.Models
{
    public class VerificationDetailsAggregate : IVerificationDetailsAggregate
    {
        public Guid Id { get; set; }
        public IVerificationDetails VerificationDetails { get; set; }
        public byte[] RecentPhoto { get; set; }
        public byte[] RightThumbmark { get; set; }
        public byte[] LeftThumbmark { get; set; }

        public VerificationDetailsAggregate()
            : this(Guid.Empty) { }

        public VerificationDetailsAggregate(Guid id)
            : this(id, null, null, null, null) { }

        public VerificationDetailsAggregate(Guid id, IVerificationDetails verificationDetails, byte[] recentPhoto, byte[] rightThumbmark, byte[] leftThumbmark)
        {
            Id = id;
            VerificationDetails = verificationDetails;
            RecentPhoto = recentPhoto;
            RightThumbmark = rightThumbmark;
            LeftThumbmark = leftThumbmark;
        }
    }
}
