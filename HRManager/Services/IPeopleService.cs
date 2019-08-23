using HRManager.BusinessObjects;
using System.Collections.Generic;

namespace HRManager.Services
{
    public interface IPeopleService
    {
        IEnumerable<string> GetJobs();
        IEnumerable<Person> GetPeopleByJob();
    }
}