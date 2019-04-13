using FrozenSoftware.Controls;
using Prism.Ioc;
using Prism.Modularity;

namespace FrozenSoftware.Settings
{
    public class FrozenSoftwareSettingsModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ISettingsRibbon, SettingsRibbonTabItem>();
        }
    }
}
