using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using PropertyChanged;
using System.Collections.ObjectModel;
using Unity;

namespace FrozenSoftware
{
    [ImplementPropertyChanged]
    public class CompanyTabViewModel : BaseTabViewModel
    {

        public CompanyTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer)
            : base(regionManger, unityContainer)
        {
            Companies = DummyDataContext.Context.Companies;
            this.ParentViewName = nameof(HomeRibbonTabItem);
        }

        public ObservableCollection<Company> Companies { get; set; }

        protected override void OnAddCommand()
        {
            WindowHandler.WindowHandlerInstance.ShowWindow(null, ActionType.Add, typeof(CompanyForm), UnityContainer);
        }

        protected override void OnEditCommand()
        {

            Company company = Companies[SelectedIndex.Value];

            WindowHandler.WindowHandlerInstance.ShowWindow(company.Id, ActionType.Edit, typeof(CompanyForm), UnityContainer);
        }

        protected override void OnDeleteCommand()
        {

        }
    }
}
