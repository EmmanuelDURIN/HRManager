using LinkedInModule.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInModule.ViewModels
{
    public class UserControlLinkedIn2ViewModel : BindableBase
    {
        private IPeopleService peopleService;
        public UserControlLinkedIn2ViewModel(IPeopleService peopleService)
        {
            this.peopleService = peopleService;
            Jobs = peopleService.GetJobs().ToList();
        }

        private List<String> jobs;

        public List<String> Jobs
        {
            get { return jobs; }
            set
            {
                SetProperty(ref jobs, value);
            }
        }

    }
}
