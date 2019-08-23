using GeoModule;
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
        private IGeoService geoService;
        public UserControlLinkedIn2ViewModel(IPeopleService peopleService, IGeoService geoService)
        {
            this.peopleService = peopleService;
            this.geoService = geoService;
            Jobs = peopleService.GetJobs().ToList();
            ZipCodes = geoService.GetZipCodes().ToList();
        }

        private List<String> zipCodes;

        public List<String> ZipCodes
        {
            get { return zipCodes; }
            set
            {
                SetProperty(ref zipCodes, value);
            }
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
