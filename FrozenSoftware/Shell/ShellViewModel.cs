using System;
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
            ShowCountryCommand = new DelegateCommand(OnShowCountryCommand);
        }

        public DelegateCommand ShowCountryCommand { get; set; }

        private void OnShowCountryCommand()
        {
            IRegion region = regionManger.Regions[RegionNames.WorkSpaceRegion];
            string viewName = nameof(CountryTab);
            object tab = region.GetView(viewName);

            if (tab == null)
            {
                tab = unityContainer.Resolve(typeof(CountryTab));
                region.Add(tab, viewName);
            }

            region.Activate(tab);
        }
    }
}
