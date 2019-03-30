using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using System.Collections.ObjectModel;
using Unity;

namespace FrozenSoftware
{
    public class DocumentStatusTabViewModel : BaseTabViewModel
    {
        public DocumentStatusTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer) 
            : base(regionManger, unityContainer)
        {
            DocumentStatuses = DummyDataContext.Context.DocuentStatuses;
            this.ParentViewName = nameof(HomeRibbonTabItem);
        }

        public ObservableCollection<DocuentStatus> DocumentStatuses { get; set; }
    }
}
