using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using System.Collections.ObjectModel;
using Unity;

namespace FrozenSoftware
{
    public class CountryTabViewModel : TabBaseViewModel
    {
        public CountryTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer) :
            base(regionManger, unityContainer)
        {
            this.Countries = DummyDataContext.Context.Countries;
        }

        public ObservableCollection<Country> Countries { get; set; }
    }
}
