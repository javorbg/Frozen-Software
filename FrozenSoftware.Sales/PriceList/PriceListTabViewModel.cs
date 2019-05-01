using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Unity;

namespace FrozenSoftware.Sales
{
    public class PriceListTabViewModel : BaseTabViewModel
    {
        public PriceListTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer)
            : base(regionManger, unityContainer)
        {
            ParentViewName = nameof(SalesRibbonTabItem);
            HasEditButtons = true;
        }

        public ObservableCollection<PriceList> PriceLists { get; set; }

        public async override void InitializeData()
        {
            try
            {
                var buffer = await ApiClient.GetAllPriceListsAsync();
                PriceLists = new ObservableCollection<PriceList>(buffer);
            }
            catch (Exception)
            {
            }
        }

        protected override void OnAddCommand()
        {
            WindowHandler.WindowHandlerInstance.ShowWindow(null, ActionType.Add, typeof(PriceListForm), UnityContainer, this.GetType().Name);
            InitializeData();
        }

        protected override void OnEditCommand()
        {
            WindowHandler.WindowHandlerInstance.ShowWindow(SelectedEntity.Id, ActionType.Edit, typeof(PriceListForm), UnityContainer, this.GetType().Name);
            InitializeData();
        }

        protected override void OnDeleteCommand()
        {
            bool? result = WindowHandler.WindowHandlerInstance.ShowConfirm($"Do you want to delete {(SelectedEntity as PriceList).Name}?", this.GetType().Name, UnityContainer, "Company");

            try
            {
                if (result == true)
                {
                    this.ApiClient.DeletePriceListAsync(SelectedEntity.Id).Wait();
                    InitializeData();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
