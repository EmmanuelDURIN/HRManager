using HRManager;
using HRManager.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRManager.Services
{
    public class PeopleService : IPeopleService
    {
        public IEnumerable<string> GetJobs()
        {
            return new String[] { "Maçon", "Boulanger" };
        }
        public IEnumerable<Person> GetPeopleByJob()
        {
            return Enumerable.Range(1, 3).Select(i => new Person { Age = 20 + i, Firstname = "Firstname" + (i + 1), Lastname = "Lastname" + (i + 1) });
        }
    }
}
