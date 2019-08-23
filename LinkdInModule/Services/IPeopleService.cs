using HRManager.BusinessObjects;
using System.Collections.Generic;

namespace LinkedInModule.Services
{
    public interface IPeopleService
    {
        IEnumerable<string> GetJobs();
        IEnumerable<Person> GetPeopleByJob();
    }
}