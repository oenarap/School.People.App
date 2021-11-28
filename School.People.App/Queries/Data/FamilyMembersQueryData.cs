using System;
using School.People.Core;
using System.Collections.Generic;

namespace School.People.App.Queries.Data
{
    public class FamilyMembersQueryData
    {
        public Guid? MotherId { get; init; }
        public Guid? FatherId { get; init; }
        public Guid? SpouseId { get; init; }
        public List<IRelatedPerson> FamilyMembers { get; }

        public FamilyMembersQueryData()
        {
            FamilyMembers = new List<IRelatedPerson>();
        }
    }
}
