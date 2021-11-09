using System;
using School.People.Core;
using System.Collections.Generic;
using School.People.Core.DTOs.Aggregates;

namespace School.People.App.Queries.Models
{
    public class FamilyMembersQueryData
    {
        public Guid Id { get => family.Id; }
        public IPerson Mother { get => family.Mother; set => family.Mother = value; }
        public IPerson Father { get => family.Father; set => family.Father = value; }
        public IPerson Spouse { get => family.Spouse; set => family.Spouse = value; }
        public IEnumerable<IPerson> Children { get => family.Children; set => family.Children = value; }

        public FamilyMembersQueryData(Guid id)
        {
            family = new FamilyMembersAggregate(id);
        }

        [ThreadStatic]
        private readonly FamilyMembersAggregate family;
    }
}
