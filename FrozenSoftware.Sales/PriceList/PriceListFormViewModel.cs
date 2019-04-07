using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Unity;

namespace FrozenSoftware.Sales
{
    public class PriceListFormViewModel : BaseFormViewModel
    {
        private bool isActive;

        public PriceList Entity { get; set; }

        public ObservableCollection<PriceListItem> PriceListItems { get; set; }
        
        public bool IsActive
        {
            get { return isActive; }
            set { SetProperty(ref isActive, value); }
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
        }

        protected override void OnConfirmCommand()
        {
            if (ActionType == ActionType.Add)
            {
                DummyDataContext.Context.PriceLists.Add(Entity);
                DummyDataContext.Context.PriceListItems.AddRange(PriceListItems);
            }

            DialogResult = true;

            if (Close != null)
                Close.Invoke();
        }
    }
}
