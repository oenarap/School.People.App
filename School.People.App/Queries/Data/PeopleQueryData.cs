using School.People.Core;
using System.Collections.Generic;

namespace School.People.App.Queries.Data
{
    public class PeopleQueryData
    {
        public IEnumerable<IPerson> People { get; set; }
    }
}
