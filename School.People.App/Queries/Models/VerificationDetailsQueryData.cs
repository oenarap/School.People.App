using System;
using School.People.Core.DTOs.Aggregates;

namespace School.People.App.Queries.Models
{
    public class VerificationDetailsQueryData
    {
        public byte[] RightThumbmark { get => verification.RightThumbmark; set => verification.RightThumbmark = value; }
        public byte[] LeftThumbmark { get => verification.LeftThumbmark; set => verification.LeftThumbmark = value; }
        public string CommunityTaxCertificateNumber { get => verification.CommunityTaxCertificateNumber; set => verification.CommunityTaxCertificateNumber = value; }
        public DateTimeOffset? CommunityTaxCertificateIssuanceDate { get => verification.CommunityTaxCertificateIssuanceDate; set => verification.CommunityTaxCertificateIssuanceDate = value; }
        public byte[] RecentPhoto { get => verification.RecentPhoto; set => verification.RecentPhoto = value; }

        public VerificationDetailsQueryData(Guid id)
        {
            verification = new VerificationDetailsAggregate(id);
        }

        [ThreadStatic]
        private readonly VerificationDetailsAggregate verification;
    }
}
