using HRManager.Views;
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
            MainWindow  window = Container.Resolve<MainWindow>();
            return window;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<LinkedInModule.ModuleLinkedIn>();
        }

        //protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        //{
        //    var moduleType = typeof(ModuleLinkedIn);
        //    moduleCatalog.AddModule(new ModuleInfo()
        //    {
        //        ModuleName = moduleType.Name,
        //        ModuleType = moduleType.AssemblyQualifiedName,
        //        InitializationMode = InitializationMode.OnDemand
        //    });
        //}
    }
}