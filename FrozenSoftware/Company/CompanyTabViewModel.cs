using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using System.Collections.ObjectModel;
using Unity;

namespace FrozenSoftware
{
    public class CompanyTabViewModel : BaseTabViewModel
    {
        public CompanyTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer) 
            : base(regionManger, unityContainer)
        {
            Companies = DummyDataContext.Context.Companies;
            this.ParentViewName = nameof(HomeRibbonTabItem);
        }

        public ObservableCollection<Company> Companies { get; set; }
    }
}
