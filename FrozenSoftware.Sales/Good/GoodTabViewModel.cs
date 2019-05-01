using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using Unity;

namespace FrozenSoftware.Sales
{
    public class GoodTabViewModel : BaseTabViewModel
    {
        public GoodTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer)
            : base(regionManger, unityContainer)
        {


            ParentViewName = nameof(SalesRibbonTabItem);
            HasEditButtons = true;
        }

        public ObservableCollection<Good> Goods { get; set; }

        public async override void InitializeData()
        {
            try
            {
                var buffer = await this.ApiClient.GetAllGoodsAsync();
                Goods = new ObservableCollection<Good>(buffer);
            }
            catch (Exception)
            {
            }
        }

        protected override void OnAddCommand()
        {
            WindowHandler.WindowHandlerInstance.ShowWindow(null, ActionType.Add, typeof(GoodForm), UnityContainer, this.GetType().Name);
        }

        protected override void OnEditCommand()
        {
            WindowHandler.WindowHandlerInstance.ShowWindow(SelectedEntity.Id, ActionType.Edit, typeof(GoodForm), UnityContainer, this.GetType().Name);
            InitializeData();
        }

        protected override void OnDeleteCommand()
        {
            bool? result = WindowHandler.WindowHandlerInstance.ShowConfirm($"Do you want to delete {(SelectedEntity as Good).Name}?", this.GetType().Name, UnityContainer, "Company");

            if (result == true)
            {
                this.ApiClient.DeleteGoodAsync(SelectedEntity.Id).Wait();
                InitializeData();
            }
        }
    }
}
