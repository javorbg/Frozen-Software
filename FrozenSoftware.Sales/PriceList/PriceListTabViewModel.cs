using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
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
            PriceLists = DummyDataContext.Context.PriceLists;
            ParentViewName = nameof(SalesRibbonTabItem);
            HasEditButtons = true;
        }

        public ObservableCollection<PriceList> PriceLists { get; set; }

        protected override void OnAddCommand()
        {
            WindowHandler.WindowHandlerInstance.ShowWindow(null, ActionType.Add, typeof(PriceListForm), UnityContainer);
        }

        protected override void OnEditCommand()
        {
            PriceList priceList = PriceLists[SelectedIndex];

            WindowHandler.WindowHandlerInstance.ShowWindow(priceList.Id, ActionType.Edit, typeof(PriceListForm), UnityContainer);
        }

        protected override void OnDeleteCommand()
        {
            PriceList priceList = PriceLists[SelectedIndex];
            bool? result = WindowHandler.WindowHandlerInstance.ShowConfirm($"Do you want to delete {priceList.Name}?", UnityContainer, "Company");

            if (result == true)
            {
                IEnumerable<PriceListItem> deleteItems = DummyDataContext.Context.PriceListItems.Where(x => x.PriceListId == priceList.Id).ToList();
                DummyDataContext.Context.PriceLists.Remove(priceList);
                foreach (var item in deleteItems)
                {
                    DummyDataContext.Context.PriceListItems.Remove(item);
                }
            }
        }
    }
}
