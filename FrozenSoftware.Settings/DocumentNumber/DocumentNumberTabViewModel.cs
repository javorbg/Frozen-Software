using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using System.Collections.ObjectModel;
using Unity;

namespace FrozenSoftware.Settings
{
    public class DocumentNumberTabViewModel : BaseTabViewModel
    {
        public DocumentNumberTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer) : base(regionManger, unityContainer)
        {
        }

        public ObservableCollection<object> Objects { get; set; }
    }
}
