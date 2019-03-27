using FrozenSoftware.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrozenSoftware
{
    public class CountryTabViewModel
    {
        public CountryTabViewModel()
        {
        }

        public ObservableCollection<Country> Countries { get; set; }
    }
}
