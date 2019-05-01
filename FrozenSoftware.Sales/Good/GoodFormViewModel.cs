using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FrozenSoftware.Sales
{
    public class GoodFormViewModel : BaseFormViewModel
    {
        public Good Entity { get; set; }

        public ObservableCollection<MeasureUnit> MeasureUnits { get; set; }

        protected override void Initialize(int? entityId, ActionType actionType, List<object> additionalData = null)
        {
            base.Initialize(entityId, actionType, additionalData);

            MeasureUnits = new ObservableCollection<MeasureUnit>(ApiClient.GetAllMeasureUnitsAsync().Result);

            switch (actionType)
            {
                case ActionType.Add:
                    Entity = new Good();
                    break;
                case ActionType.Edit:
                    Entity = ApiClient.GetGoodAsync(entityId.Value).Result;
                    bool reslut = ApiClient.LockEntityAsync(Entity.Id, LockId, true, "Goods").Result;
                    IsReadOnly = !reslut;
                    RaisePropertyChanged(nameof(IsReadOnly));

                    break;
            }
        }

        protected async override void OnConfirmCommand()
        {
            try
            {
                switch (ActionType)
                {
                    case ActionType.Add:
                        Entity = await ApiClient.AddGoodtAsync(Entity);
                        break;
                    case ActionType.Edit:
                        await ApiClient.UpdateGoodAsync(Entity.Id, Entity);
                        await ApiClient.LockEntityAsync(Entity.Id, LockId, false, "Goods");
                        break;
                }
               
                DialogResult = true;

                if (Close != null)
                    Close.Invoke();
            }
            catch (Exception)
            {
            }
        }

        protected async override void OnCancelCommand()
        {
            try
            {
                await ApiClient.LockEntityAsync(Entity.Id, LockId, false, "Goods");
            }
            catch (Exception)
            {
            }

            base.OnCancelCommand();
        }
    }
}
