﻿using FrozenSoftware.Controls;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace FrozenSoftware.MainData
{
    public class FrozenSoftwareMainDataModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IMainDataRibbon, MainDataRibbonTabItem>();
        }
    }
}
