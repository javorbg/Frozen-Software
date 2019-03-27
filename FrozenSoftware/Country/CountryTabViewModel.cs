using FrozenSoftware.Models;
using System.Collections.ObjectModel;

namespace FrozenSoftware
{
    public class CountryTabViewModel
    {
        public CountryTabViewModel()
        {
            this.Countries = DummyDataContext.Context.Countries;
        }

        public ObservableCollection<Country> Countries { get; set; }
    }
}
