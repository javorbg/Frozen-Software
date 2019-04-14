using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System.Collections.Generic;
using System.Linq;

namespace FrozenSoftware
{
    public class FrozenSoftwareModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            this.LoadRibbon(containerProvider as Prism.Unity.Ioc.UnityContainerExtension);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<EditMenuRibbonGroupBox>();
            containerRegistry.RegisterSingleton<FrozenSoftwareWebApiClient>();
        }

        private void LoadRibbon(Prism.Unity.Ioc.UnityContainerExtension containerProvider)
        {
            IRegionManager regionManager = containerProvider.Resolve<IRegionManager>();
            var ribbonTabs = containerProvider.Instance.Registrations.Where(x => x.RegisteredType.GetInterface(nameof(IBaseRibbon)) != null).ToList();
            List<IBaseRibbon> ribbonTabsList = new List<IBaseRibbon>();
            foreach (var item in ribbonTabs)
            {
                IBaseRibbon ribbon = containerProvider.Resolve(item.MappedToType) as IBaseRibbon;
                ribbonTabsList.Add(ribbon);
            }

            ribbonTabsList.OrderBy(x => x.Position).ToList().ForEach(x =>
            {
                string viewName = x.GetType().Name;
                regionManager.Regions[RegionNames.RibbonRegion].Add(x, viewName);
            });

            ribbonTabs.Clear();
            ribbonTabsList.Clear();
        }
    }
}
