using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using System.Collections.ObjectModel;
using Unity;

namespace FrozenSoftware
{
    public class PaymentTypeTabViewModel : BaseTabViewModel
    {
        public PaymentTypeTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer) : 
            base(regionManger, unityContainer)
        {
            PaymentTypes = DummyDataContext.Context.PaymentTypes;
            this.ParentViewName = nameof(HomeRibbonTabItem);
        }

        public ObservableCollection<PaymentType> PaymentTypes { get; set; }
    }
}
