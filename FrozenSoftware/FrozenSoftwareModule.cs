using FrozenSoftware.Controls;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Unity;

namespace FrozenSoftware
{
    class FrozenSoftwareModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            var view = containerProvider.Resolve<HomeRibbonTabItem>();
            regionManager.Regions[RegionNames.RibbonRegion].Add(view, nameof(HomeRibbonTabItem));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
