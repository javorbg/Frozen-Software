using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using PropertyChanged;
using System.Collections.ObjectModel;
using Unity;

namespace FrozenSoftware.MainData
{
    [ImplementPropertyChanged]
    public class DocumentStatusTabViewModel : BaseTabViewModel
    {
        public DocumentStatusTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer) 
            : base(regionManger, unityContainer)
        {
            DocumentStatuses = DummyDataContext.Context.DocuentStatuses;
            this.ParentViewName = nameof(MainDataRibbonTabItem);
            this.HasEditButtons = false;
        }

        public ObservableCollection<DocumentStatus> DocumentStatuses { get; set; }
    }
}
