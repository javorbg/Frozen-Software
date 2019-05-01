using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FrozenSoftware.MainData
{
    [ImplementPropertyChanged]
    public class CompanyFormViewModel : BaseFormViewModel
    {
        public CompanyFormViewModel()
        {
        }

        public Company Entity { get; set; }

        public Contact ContactEntity { get; set; }

        public ObservableCollection<Country> Countries { get; set; }

        protected override void Initialize(int? entityId, ActionType actionType, List<object> additionalData = null)
        {
            base.Initialize(entityId, actionType, additionalData);

            Countries = new ObservableCollection<Country>(ApiClient.GetAllCountriesAsync().Result);

            switch (actionType)
            {
                case ActionType.Add:

                    Entity = new Company();
                    ContactEntity = new Contact() { CompanyId = Entity.Id };
                    break;
                case ActionType.Edit:
                    LockId = Guid.NewGuid();

                    Entity = ApiClient.GetCompanyAsync(entityId.Value).Result;
                    bool reslut = ApiClient.LockEntityAsync(Entity.Id, LockId, true, "Companies").Result;
                    ContactEntity = ApiClient.GetContactByCompanyIdAsync(entityId.Value).Result;

                    IsReadOnly = !reslut;
                    RaisePropertyChanged(nameof(IsReadOnly));

                    if (ContactEntity == null)
                        ContactEntity = new Contact() { CompanyId = Entity.Id };
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
                        Entity = await ApiClient.AddCompanyAsync(Entity);
                        ContactEntity.Company = null;
                        ContactEntity.CompanyId = Entity.Id;
                        await ApiClient.AddContactAsync(ContactEntity);
                        break;
                    case ActionType.Edit:
                        await ApiClient.UpdateComapnyAsync(Entity.Id, Entity);
                        await ApiClient.UpdateContactAsync(Entity.Id, ContactEntity);
                        await ApiClient.LockEntityAsync(Entity.Id, LockId, false, "Companies");
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
                await ApiClient.LockEntityAsync(Entity.Id, LockId, false, "Companies");
            }
            catch (Exception)
            {
            }

            base.OnCancelCommand();
        }
    }
}