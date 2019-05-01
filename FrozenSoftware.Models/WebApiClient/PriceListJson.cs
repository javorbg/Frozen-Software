using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FrozenSoftware.Models
{
    public class PriceListJson
    {
        public PriceList PriceList { get; set; }

        public ObservableCollection<PriceListItem> PriceListItems { get; set; }
    }
}
