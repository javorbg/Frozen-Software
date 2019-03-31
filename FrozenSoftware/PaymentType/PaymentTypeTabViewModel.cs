using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using PropertyChanged;
using System.Collections.ObjectModel;
using Unity;

namespace FrozenSoftware
{
    [ImplementPropertyChanged]
    public class PaymentTypeTabViewModel : BaseTabViewModel
    {
        public PaymentTypeTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer) : 
            base(regionManger, unityContainer)
        {
            PaymentTypes = DummyDataContext.Context.PaymentTypes;
            this.ParentViewName = nameof(HomeRibbonTabItem);
            this.HasEditButtons = false;
        }

        public ObservableCollection<PaymentType> PaymentTypes { get; set; }
    }
}
