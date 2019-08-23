using LinkedInModule.Services;
using LinkedInModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInModule
{
    public class ModuleLinkedIn : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("toolsRegion", typeof(UserControlLinkedIn));
            regionManager.RegisterViewWithRegion("toolsRegion", typeof(UserControlLinkedIn2));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IPeopleService, PeopleService>();
        }
    }
}
