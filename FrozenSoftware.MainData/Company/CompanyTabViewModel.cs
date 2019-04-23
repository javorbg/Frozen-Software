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
            this.ParentViewName = nameof(MainDataRibbonTabItem);
        }

        public ObservableCollection<Company> Companies { get; set; }

        public async override void InitializeData()
        {
            var buffer = await this.ApiClient.GetAllCompaniesAsync();
            Companies = new ObservableCollection<Company>(buffer);
        }

        protected override void OnAddCommand()
        {
            WindowHandler.WindowHandlerInstance.ShowWindow(null, ActionType.Add, typeof(CompanyForm), UnityContainer, this.GetType().Name);
            InitializeData();
        }

        protected override void OnEditCommand()
        {
            Company company = Companies[SelectedIndex];

            WindowHandler.WindowHandlerInstance.ShowWindow(company.Id, ActionType.Edit, typeof(CompanyForm), UnityContainer, this.GetType().Name);
            InitializeData();
        }

        protected async override void OnDeleteCommand()
        {
            Company company = Companies[SelectedIndex];
            bool? result = WindowHandler.WindowHandlerInstance.ShowConfirm($"Do you want to delete {company.CompanyName}?", this.GetType().Name, UnityContainer, "Company");

            if (result == true)
            {
                await this.ApiClient.DeleteCompanyAsync(company.Id);
                InitializeData();
            }
        }
    }
}
