using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using System.Collections.ObjectModel;
using Unity;


namespace FrozenSoftware.PaymentType
{
    public class PaymentTypeTabViewModel : TabBaseViewModel
    {
        public PaymentTypeTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer) : 
            base(regionManger, unityContainer)
        {
        }
    }
}
