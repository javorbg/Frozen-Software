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
            ParentViewName = nameof(MainDataRibbonTabItem);
            HasEditButtons = false;
        }

        public ObservableCollection<DocumentStatus> DocumentStatuses { get; set; }

        public async override void InitializeData()
        {
            var buffer = await this.ApiClient.GetAllDocumentStatusesAsync();
            DocumentStatuses = new ObservableCollection<DocumentStatus>(buffer);
        }
    }
}
