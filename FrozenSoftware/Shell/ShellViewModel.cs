using System;
using System.Windows.Controls;
using FrozenSoftware.Models;
using Prism.Commands;
using Prism.Regions;
using Unity;

namespace FrozenSoftware
{
    public class ShellViewModel
    {
        private IRegionManager regionManger;
        private IUnityContainer unityContainer;

        public ShellViewModel(IRegionManager regionManger, IUnityContainer unityContainer)
        {
            this.regionManger = regionManger;
            this.unityContainer = unityContainer;
            ShowTabCommand = new DelegateCommand<Type>(OnShowTabCommand);
        }

        public DelegateCommand<Type> ShowTabCommand { get; set; }

        private void OnShowTabCommand(Type viewType)
        {
            InjectViewToRegionBy(viewType);
        }

        public object SelectedTab { get; set; }

        private void InjectViewToRegionBy(Type viewType)
        {
            IRegion region = regionManger.Regions[RegionNames.TabItemRegion];
            string viewName = viewType.Name;
            TabItem tab = region.GetView(viewName) as TabItem;

            if (tab == null)
            {
                tab = unityContainer.Resolve(viewType) as TabItem;
                tab.IsSelected = true;
                region.Add(tab, viewName);
            }
            else
                tab.IsSelected = true;

            region.Activate(tab);
        }
    }
}