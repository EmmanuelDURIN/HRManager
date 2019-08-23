using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoModule
{
    public class ModuleGeo : IModule
    {
        public ModuleGeo()
        {

        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IGeoService, GeoService>();
        }
    }
}
