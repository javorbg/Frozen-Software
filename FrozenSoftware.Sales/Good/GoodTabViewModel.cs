using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Linq;
using Unity;

namespace FrozenSoftware.Sales
{
    public class GoodTabViewModel : BaseTabViewModel
    {
        public GoodTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer)
            : base(regionManger, unityContainer)
        {
            Goods = DummyDataContext.Context.Goods;
            ParentViewName = nameof(SalesRibbonTabItem);
            HasEditButtons = true;
        }

        public ObservableCollection<Good> Goods { get; set; }

        protected override void OnAddCommand()
        {
            WindowHandler.WindowHandlerInstance.ShowWindow(null, ActionType.Add, typeof(GoodForm), UnityContainer, this.GetType().Name);
        }

        protected override void OnEditCommand()
        {
            Good good = Goods[SelectedIndex];

            WindowHandler.WindowHandlerInstance.ShowWindow(good.Id, ActionType.Edit, typeof(GoodForm), UnityContainer, this.GetType().Name);
        }

        protected override void OnDeleteCommand()
        {
            Good good = Goods[SelectedIndex];
            bool? result = WindowHandler.WindowHandlerInstance.ShowConfirm($"Do you want to delete {good.Name}?", this.GetType().Name, UnityContainer, "Company");

            if (result == true)
            {
                DummyDataContext.Context.Goods.Remove(good);
            }
        }
    }
}
