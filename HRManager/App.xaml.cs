using GeoModule;
using HRManager.Views;
using LinkedInModule;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HRManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            MainWindow window = Container.Resolve<MainWindow>();
            return window;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //moduleCatalog.AddModule<GeoModule.ModuleGeo>();
            //moduleCatalog.AddModule<LinkedInModule.ModuleLinkedIn>();

            var moduleGeo = CreateModuleInfo(typeof(ModuleGeo));
            moduleCatalog.AddModule(moduleGeo);

            var moduleLinkedIn = CreateModuleInfo(typeof(ModuleLinkedIn));
            moduleLinkedIn.DependsOn = new System.Collections.ObjectModel.Collection<String> { moduleGeo.ModuleName };
            moduleCatalog.AddModule(moduleLinkedIn);
        }

        private ModuleInfo CreateModuleInfo(Type moduleType)
        {
            ModuleInfo module = new ModuleInfo()
            {
                ModuleName = moduleType.Name,
                ModuleType = moduleType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            };
            return module;
        }
    }
}