using PropertyChanged;

namespace FrozenSoftware.Models
{
    [ImplementPropertyChanged]
    public abstract class ResourceBase : EntityBase
    {
        public string ResourceName { get; set; }
    }
}
