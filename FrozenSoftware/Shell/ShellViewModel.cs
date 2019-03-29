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
            ShowCountryCommand = new DelegateCommand(OnShowCountryCommand);
            ShowPaymentTypeCommand = new DelegateCommand(OnShowPaymentTypeCommand);
            ShowDocumentStatusCommand = new DelegateCommand(OnShowDocumentStatusCommand);
        }

        public DelegateCommand ShowCountryCommand { get; set; }

        public DelegateCommand ShowPaymentTypeCommand { get; set; }

        public DelegateCommand ShowDocumentStatusCommand { get; set; }

        private void OnShowCountryCommand()
        {
            InjectViewToRegionBy(typeof(CountryTab));
        }

        private void OnShowPaymentTypeCommand()
        {
            InjectViewToRegionBy(typeof(PaymentTypeTab));
        }

        private void OnShowDocumentStatusCommand()
        {
            InjectViewToRegionBy(typeof(DocumentStatusTab));
        }

        private void InjectViewToRegionBy(Type viewType)
        {
            IRegion region = regionManger.Regions[RegionNames.WorkSpaceRegion];
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