using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Linq;
using Unity;

namespace FrozenSoftware.MainData
{
    [ImplementPropertyChanged]
    public class CompanyTabViewModel : BaseTabViewModel
    {
        public CompanyTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer)
            : base(regionManger, unityContainer)
        {
            Companies = DummyDataContext.Context.Companies;
            this.ParentViewName = nameof(MainDataRibbonTabItem);
        }

        public ObservableCollection<Company> Companies { get; set; }

        protected override void OnAddCommand()
        {
            WindowHandler.WindowHandlerInstance.ShowWindow(null, ActionType.Add, typeof(CompanyForm), UnityContainer);
        }

        protected override void OnEditCommand()
        {
            Company company = Companies[SelectedIndex];

            WindowHandler.WindowHandlerInstance.ShowWindow(company.Id, ActionType.Edit, typeof(CompanyForm), UnityContainer);
        }

        protected override void OnDeleteCommand()
        {
            Company company = Companies[SelectedIndex];
            bool? result = WindowHandler.WindowHandlerInstance.ShowConfirm($"Do you want to delete {company.CompanyName}?", UnityContainer, "Company");

            if (result == true)
            {
                Contact contact = DummyDataContext.Context.Contacts.FirstOrDefault(x => x.CompanyId == company.Id);

                if (contact != null)
                    DummyDataContext.Context.Contacts.Remove(contact);

                DummyDataContext.Context.Companies.Remove(company);
            }
        }
    }
}
