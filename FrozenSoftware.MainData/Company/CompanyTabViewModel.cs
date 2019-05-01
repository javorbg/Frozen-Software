using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using PropertyChanged;
using System;
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
            try
            {
                var buffer = await this.ApiClient.GetAllCompaniesAsync();
                Companies = new ObservableCollection<Company>(buffer);
            }
            catch (Exception)
            {
            }
        }

        protected override void OnAddCommand()
        {
            WindowHandler.WindowHandlerInstance.ShowWindow(null, ActionType.Add, typeof(CompanyForm), UnityContainer, this.GetType().Name);
            InitializeData();
        }

        protected override void OnEditCommand()
        {
            WindowHandler.WindowHandlerInstance.ShowWindow(SelectedEntity.Id, ActionType.Edit, typeof(CompanyForm), UnityContainer, this.GetType().Name);
            InitializeData();
        }

        protected override void OnDeleteCommand()
        {
            bool? result = WindowHandler.WindowHandlerInstance.ShowConfirm($"Do you want to delete {(SelectedEntity as Company).CompanyName}?", this.GetType().Name, UnityContainer, "Company");

            if (result == true)
            {
                this.ApiClient.DeleteCompanyAsync(SelectedEntity.Id).Wait();
                InitializeData();
            }
        }
    }
}
