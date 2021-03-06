﻿using FrozenSoftware.Controls;
using Prism.Ioc;
using Prism.Modularity;

namespace FrozenSoftware.Sales
{
    public class FrozenSoftwareSalesModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ISalesRibbon, SalesRibbonTabItem>();
        }
    }
}
