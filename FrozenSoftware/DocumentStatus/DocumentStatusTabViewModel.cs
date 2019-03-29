using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace FrozenSoftware
{
    public class DocumentStatusTabViewModel : BaseTabViewModel
    {
        public DocumentStatusTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer) 
            : base(regionManger, unityContainer)
        {
            DocumentStatuses = DummyDataContext.Context.DocuentStatuses;
        }

        public ObservableCollection<DocuentStatus> DocumentStatuses { get; set; }
    }
}
