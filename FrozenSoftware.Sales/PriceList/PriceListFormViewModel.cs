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
            AddPriceListItemCommand = new DelegateCommand(OnAddPriceListItemCommand, () => this.ActionType == ActionType.Edit);
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

        public override void Initialize(int? entityId, ActionType actionType, List<object> additionalData = null)
        {
            base.Initialize(entityId, actionType, additionalData);

            PriceListItems = new ObservableCollection<PriceListItem>();
            Goods = DummyDataContext.Context.Goods;

            switch (actionType)
            {
                case ActionType.Add:
                    int lastId = 1;

                    if (DummyDataContext.Context.PriceLists.Count > 0)
                        lastId = DummyDataContext.Context.PriceLists.Select(x => x.Id).Max() + 1;

                    Entity = new PriceList() { Id = lastId, StartDate = DateTime.Today, EndDate = DateTime.Today.AddMonths(12) };
                    PriceListItems = new ObservableCollection<PriceListItem>();
                    UpdatePriceListItems(Goods);

                    break;
                case ActionType.ReadOnly:
                case ActionType.Edit:
                    Entity = DummyDataContext.Context.PriceLists.First(x => x.Id == entityId.Value);
                    var priceListItems = DummyDataContext.Context.PriceListItems.Where(x => x.PriceListId == entityId.Value);
                    PriceListItems = new ObservableCollection<PriceListItem>(priceListItems);
                    break;
            }

            AddPriceListItemCommand.RaiseCanExecuteChanged();
        }

        protected override void OnConfirmCommand()
        {
            if (PriceListItems == null || PriceListItems.Count == 0)
                return;

            if (string.IsNullOrEmpty(Entity.Name))
                return;

            if (ActionType == ActionType.Add)
            {
                DummyDataContext.Context.PriceLists.Add(Entity);
                DummyDataContext.Context.PriceListItems.AddRange(PriceListItems);
            }

            if (ActionType == ActionType.Edit && NewPriceListItems != null && NewPriceListItems.Count > 0)
                DummyDataContext.Context.PriceListItems.AddRange(NewPriceListItems);

            DialogResult = true;

            if (Close != null)
                Close.Invoke();
        }

        private void UpdatePriceListItems(IEnumerable<Good> goods)
        {
            int lastPriceListItemId = 1;
            int localLastId = 1;
            NewPriceListItems = new ObservableCollection<PriceListItem>();

            foreach (Good good in goods)
            {
                if (DummyDataContext.Context.PriceLists.Count > 0)
                    lastPriceListItemId = DummyDataContext.Context.PriceLists.Select(x => x.Id).Max() + 1;

                if (PriceListItems.Count > 0)
                    localLastId = PriceListItems.Select(x => x.Id).Max() + 1;

                lastPriceListItemId = Math.Max(lastPriceListItemId, localLastId);

                PriceListItem newPriceListItem = new PriceListItem()
                {
                    Id = lastPriceListItemId,
                    Good = good,
                    GoodId = good.Id,
                    PriceList = Entity,
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
