using System;
using School.People.Core;
using System.Collections.Generic;

namespace School.People.App.Queries.Models
{
    public class PeopleQueryData
    {
        public void Add(IPerson person) => people.Add(person);
        public bool Remove(IPerson person) => people.Remove(person);

        public IPerson this[int index]
        {
            get { return people[index]; }
            set { people[index] = value; }
        }

        public IPerson[] ToPersonArray => people.ToArray();

        public PeopleQueryData()
        {
            people = new List<IPerson>();
        }

        [ThreadStatic]
        private readonly List<IPerson> people;
    }
}
