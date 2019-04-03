using Fluent;
using FrozenSoftware.Controls;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Windows;
using System.Windows.Controls;

namespace FrozenSoftware
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(TabControl), Container.Resolve<RegionAdapterTabControl>());
            regionAdapterMappings.RegisterMapping(typeof(Ribbon), Container.Resolve<RegionAdapterFluentRibbon>());
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);

            Type moduleCType = typeof(FrozenSoftwareModule);
            moduleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleCType.Name,
                ModuleType = moduleCType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.WhenAvailable
            });
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog() { ModulePath = "Modules" };
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            //On Startup change Color of Icons
            Application.Current.Resources["IconBrush"] = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);

        }
    }
}
