using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Unity;

namespace FrozenSoftware.Sales
{
    public class PriceListFormViewModel : BaseFormViewModel
    {
        private bool isActive;
        private int selectedPriceListItemIndex;

        public PriceListFormViewModel()
        {
            AddPriceListItemCommand = new DelegateCommand(OnAddPriceListItemCommand);
            DeletePriceListItemCommand = new DelegateCommand(OnDeletePriceListItemCommand, CanExecuteDeletePriceListItemCommand);
        }

        public int SelectedPriceListItemIndex
        {
            get
            {
                return selectedPriceListItemIndex;
            }

            set
            {
                SetProperty(ref selectedPriceListItemIndex, value);
                DeletePriceListItemCommand.RaiseCanExecuteChanged();
            }
        }

        public PriceList Entity { get; set; }

        public ObservableCollection<PriceListItem> PriceListItems { get; set; }

        public ObservableCollection<Good> Goods { get; set; }

        public DelegateCommand AddPriceListItemCommand { get; set; }

        public DelegateCommand DeletePriceListItemCommand { get; set; }

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
                            return "_The price list must contains goos.";
                        break;
                }

                return null;
            }
        }

        public override void Initialize(int? entityId, ActionType actionType, List<object> additionalData = null)
        {
            base.Initialize(entityId, actionType, additionalData);

            PriceListItems = new ObservableCollection<PriceListItem>();

            switch (actionType)
            {
                case ActionType.Add:
                    int lastId = 1;

                    if (DummyDataContext.Context.PriceLists.Count > 0)
                        lastId = DummyDataContext.Context.PriceLists.Select(x => x.Id).Max() + 1;

                    Entity = new PriceList() { Id = lastId, StartDate = DateTime.Today, EndDate = DateTime.Today.AddMonths(12) };
                    PriceListItems = new ObservableCollection<PriceListItem>();
                    break;
                case ActionType.ReadOnly:
                case ActionType.Edit:
                    Entity = DummyDataContext.Context.PriceLists.First(x => x.Id == entityId.Value);
                    var priceListItems = DummyDataContext.Context.PriceListItems.Where(x => x.PriceListId == entityId.Value);
                    PriceListItems = new ObservableCollection<PriceListItem>(priceListItems);
                    break;
            }

            Goods = DummyDataContext.Context.Goods;
        }

        protected override void OnConfirmCommand()
        {
            if (PriceListItems == null || PriceListItems.Count == 0)
                return;

            bool isValid = Validator.TryValidateObject(this, new ValidationContext(this, null), null);

            if (!isValid)
                return;

            foreach (PriceListItem priceListItem in PriceListItems)
            {
                isValid = Validator.TryValidateObject(priceListItem, new ValidationContext(priceListItem, null), null);
                if (!isValid)
                    return;
            }

            if (ActionType == ActionType.Add)
            {
                DummyDataContext.Context.PriceLists.Add(Entity);
                DummyDataContext.Context.PriceListItems.AddRange(PriceListItems);
            }

            DialogResult = true;

            if (Close != null)
                Close.Invoke();
        }

        private void OnDeletePriceListItemCommand()
        {
            if (PriceListItems == null || PriceListItems.Count == 0)
                return;
        }

        private void OnAddPriceListItemCommand()
        {
            if (PriceListItems == null)
                PriceListItems = new ObservableCollection<PriceListItem>();

            int lastId = 1;
            int localLastId = 1;

            if (DummyDataContext.Context.PriceLists.Count > 0)
                lastId = DummyDataContext.Context.PriceLists.Select(x => x.Id).Max() + 1;

            if (PriceListItems.Count > 0)
                localLastId = PriceListItems.Select(x => x.Id).Max() + 1;

            lastId = Math.Max(lastId, localLastId);

            PriceListItems.Add(new PriceListItem()
            {
                Id = lastId,
                PriceList = Entity,
                PriceListId = Entity.Id
            });
        }

        private bool CanExecuteDeletePriceListItemCommand()
        {
            return SelectedPriceListItemIndex >= 0;
        }
    }
}
