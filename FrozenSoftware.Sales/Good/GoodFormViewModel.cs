using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Unity;

namespace FrozenSoftware.Sales
{
    public class GoodFormViewModel : BaseFormViewModel
    {
        public Good Entity { get; set; }

        public ObservableCollection<MeasureUnit> MeasureUnits { get; set; }

        public override void Initialize(int? entityId, ActionType actionType, List<object> additionalData = null)
        {
            base.Initialize(entityId, actionType, additionalData);

            MeasureUnits = DummyDataContext.Context.MeasureUnits;

            switch (actionType)
            {
                case ActionType.Add:
                    int lastId = 1;

                    if (DummyDataContext.Context.Goods.Count > 0)
                        lastId = DummyDataContext.Context.Goods.Select(x => x.Id).Max() + 1;

                    Entity = new Good() { Id = lastId };
                    break;
                case ActionType.Edit:
                    Entity = DummyDataContext.Context.Goods.First(x => x.Id == entityId.Value);
                    break;
            }
        }

        protected override void OnConfirmCommand()
        {
            if (ActionType == ActionType.Add)
            {
                DummyDataContext.Context.Goods.Add(Entity);
            }

            DialogResult = true;

            if (Close != null)
                Close.Invoke();
        }
    }
}
