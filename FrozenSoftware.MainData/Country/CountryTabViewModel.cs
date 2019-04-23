using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using PropertyChanged;
using System.Collections.ObjectModel;
using Unity;

namespace FrozenSoftware.MainData
{
    [ImplementPropertyChanged]
    public class CountryTabViewModel : BaseTabViewModel
    {
        public CountryTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer) :
            base(regionManger, unityContainer)
        {

            ParentViewName = nameof(MainDataRibbonTabItem);
            HasEditButtons = false;
        }

        public ObservableCollection<Country> Countries { get; set; }

        public async override void InitializeData()
        {
            var buffer = await this.ApiClient.GetAllCountriesAsync();
            Countries = new ObservableCollection<Country>(buffer);
        }
    }
}
