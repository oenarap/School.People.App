using System;

namespace School.People.App.Queries.Data
{
    public class VerificationDetailsQueryData
    {
        public byte[] RightThumbmark { get; set; }
        public byte[] LeftThumbmark { get; set; }
        public string CommunityTaxCertificateNumber { get; set; }
        public DateTimeOffset? CommunityTaxCertificateIssuanceDate { get; set; }
        public byte[] RecentPhoto { get; set; }
    }
}
