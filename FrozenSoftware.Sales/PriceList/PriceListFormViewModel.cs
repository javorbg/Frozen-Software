using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Commands;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FrozenSoftware.Sales
{
    [ImplementPropertyChanged]
    public class PriceListFormViewModel : BaseFormViewModel
    {
        private bool isActive;

        private PriceListItem selectedPriceListItem;

        public PriceListFormViewModel()
        {
        }

        public PriceListItem SelectedPriceListItem
        {
            get
            {
                return selectedPriceListItem;
            }

            set
            {
                SetProperty(ref selectedPriceListItem, value);
            }
        }

        public PriceList Entity { get; set; }

        public ObservableCollection<PriceListItem> PriceListItems { get; set; }

        public ObservableCollection<PriceListItem> NewPriceListItems { get; set; }

        public ObservableCollection<Good> Goods { get; set; }

        public DelegateCommand AddPriceListItemCommand { get; set; }

        public bool IsActive
        {
            get { return isActive; }
            set { SetProperty(ref isActive, value); }
        }

        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(PriceListItems):
                        if (PriceListItems == null || PriceListItems.Count == 0)
                            return "_The price list must contains goods.";
                        break;
                }

                return null;
            }
        }

        protected override void Initialize(int? entityId, ActionType actionType, List<object> additionalData = null)
        {
            try
            {

                base.Initialize(entityId, actionType, additionalData);
                Goods = new ObservableCollection<Good>(ApiClient.GetAllGoodsAsync().Result);

                switch (ActionType)
                {
                    case ActionType.Add:
                        PriceListItems = new ObservableCollection<PriceListItem>();
                        Entity = new PriceList() { StartDate = DateTime.Today, EndDate = DateTime.Today.AddMonths(12) };
                        UpdatePriceListItems(Goods);
                        break;
                    case ActionType.Edit:
                        Entity = ApiClient.GetPriceListAsync(entityId.Value).Result;

                        var priceListItems = ApiClient.GetAllPriceListItemsByAsync(entityId.Value).Result;

                        if (priceListItems != null)
                            PriceListItems = new ObservableCollection<PriceListItem>(priceListItems);

                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        protected async override void OnConfirmCommand()
        {
            if (PriceListItems == null || PriceListItems.Count == 0)
                return;

            if (string.IsNullOrEmpty(Entity.Name))
                return;
            switch (ActionType)
            {
                case ActionType.Add:
                    await ApiClient.AddPriceListAsync(Entity, PriceListItems);
                    break;
                case ActionType.Edit:
                    await ApiClient.UpdatePriceListAsync(Entity.Id, Entity, PriceListItems);
                    break;
            }

            DialogResult = true;

            if (Close != null)
                Close.Invoke();
        }

        private void UpdatePriceListItems(IEnumerable<Good> goods)
        {
            NewPriceListItems = new ObservableCollection<PriceListItem>();

            foreach (Good good in goods)
            {
                PriceListItem newPriceListItem = new PriceListItem()
                {
                    Good = good,
                    GoodId = good.Id,
                    PriceListId = Entity.Id,
                };

                PriceListItems.Add(newPriceListItem);

                if (ActionType == ActionType.Edit)
                    NewPriceListItems.Add(newPriceListItem);
            }
        }

        private void OnAddPriceListItemCommand()
        {
            var currentGoods = PriceListItems.Select(x => x.Good);

            var goods = Goods.Except(currentGoods);

            if (goods == null || goods.Count() == 0)
                return;

            UpdatePriceListItems(goods);
        }

        private bool CanExecuteDeletePriceListItemCommand()
        {
            return SelectedPriceListItem != null;
        }
    }
}
