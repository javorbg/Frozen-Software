using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using PropertyChanged;
using System.Collections.ObjectModel;
using Unity;

namespace FrozenSoftware.MainData
{
    [ImplementPropertyChanged]
    public class PaymentTypeTabViewModel : BaseTabViewModel
    {
        public PaymentTypeTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer) : 
            base(regionManger, unityContainer)
        {
            this.ParentViewName = nameof(MainDataRibbonTabItem);
            this.HasEditButtons = false;
        }

        public ObservableCollection<PaymentType> PaymentTypes { get; set; }

        public async override void InitializeData()
        {
            var buffer = await this.ApiClient.GetAllPaymentTypesAsync();
            PaymentTypes = new ObservableCollection<PaymentType>(buffer);
        }
    }
}
