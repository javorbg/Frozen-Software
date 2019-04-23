using FrozenSoftware.Controls;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PropertyChanged;
using System;
using System.Windows.Controls;
using Unity;

namespace FrozenSoftware
{
    [ImplementPropertyChanged]
    public class ShellViewModel : BindableBase
    {
        private IRegionManager regionManger;
        private IUnityContainer unityContainer;
        private TabItem selectedTab;

        public ShellViewModel(IRegionManager regionManger, IUnityContainer unityContainer)
        {
            this.regionManger = regionManger;
            this.unityContainer = unityContainer;
            ShowTabCommand = new DelegateCommand<Type>(OnShowTabCommand);
        }

        public DelegateCommand<Type> ShowTabCommand { get; set; }

        public TabItem SelectedTab
        {
            get
            {
                return selectedTab;
            }

            set
            {
                MenuHandler.RemoveEditButtons(selectedTab, regionManger, false);
                this.SetProperty(ref selectedTab, value);
                MenuHandler.AddEditButtons(selectedTab, regionManger, unityContainer);
            }
        }

        private void OnShowTabCommand(Type viewType)
        {
            InjectViewToRegionBy(viewType);
        }

        private void InjectViewToRegionBy(Type viewType)
        {
            if (viewType == null)
                return;

            IRegion region = regionManger.Regions[RegionNames.TabItemRegion];
            string viewName = viewType.Name;
            TabItem tab = region.GetView(viewName) as TabItem;

            if (tab == null)
            {
                tab = unityContainer.Resolve(viewType) as TabItem;
                tab.IsSelected = true;
                (tab.DataContext as BaseTabViewModel).InitializeData();
                region.Add(tab, viewName);
            }
            else
                tab.IsSelected = true;

            region.Activate(tab);
        }
    }
}