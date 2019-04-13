using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using System.Collections.ObjectModel;
using Unity;

namespace FrozenSoftware.Settings
{
    public class DocumentNumberDefinitionTabViewModel : BaseTabViewModel
    {
        public DocumentNumberDefinitionTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer) : base(regionManger, unityContainer)
        {
        }

        public ObservableCollection<DocumentNumberDefinition> DocumentNumberDefinitions { get; set; }
    }
}
