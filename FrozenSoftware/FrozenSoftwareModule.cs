using FrozenSoftware.Controls;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace FrozenSoftware
{
    class FrozenSoftwareModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(HomeRibbonTabItem));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
