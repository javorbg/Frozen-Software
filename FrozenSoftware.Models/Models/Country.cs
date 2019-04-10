using PropertyChanged;

namespace FrozenSoftware.Models
{
    [ImplementPropertyChanged]
    public class Country : ResourceBase
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
