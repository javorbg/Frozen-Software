using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using PropertyChanged;
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

        public override void Initialize(int? entityId, ActionType actionType, List<object> additionalData = null)
        {
            base.Initialize(entityId, actionType, additionalData);

            Countries = DummyDataContext.Context.Countries;

            switch (actionType)
            {
                case ActionType.Add:
                    int lastId = 1;
                    if (DummyDataContext.Context.Companies.Count > 0)
                        lastId = DummyDataContext.Context.Companies.Select(x => x.Id).Max() + 1;

                    Entity = new Company() { Id = lastId };
                    ContactEntity = new Contact() { Company = Entity, CompanyId = Entity.Id };
                    break;
                case ActionType.Edit:
                    Entity = DummyDataContext.Context.Companies.First(x => x.Id == entityId.Value);
                    ContactEntity = DummyDataContext.Context.Contacts.First(x => x.CompanyId == entityId.Value);

                    if (ContactEntity == null)
                        ContactEntity = new Contact() { Company = Entity, CompanyId = Entity.Id };
                    break;
            }
        }

        protected override void OnConfirmCommand()
        {
            if (ActionType == ActionType.Add)
            {
                DummyDataContext.Context.Companies.Add(Entity);
                DummyDataContext.Context.Contacts.Add(ContactEntity);
            }

            DialogResult = true;
           
            if (Close != null)
                Close.Invoke();
        }
    }
}

