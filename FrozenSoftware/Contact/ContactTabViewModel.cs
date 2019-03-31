using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using PropertyChanged;
using System.Collections.ObjectModel;
using Unity;

namespace FrozenSoftware
{
    [ImplementPropertyChanged]
    public class ContactTabViewModel : BaseTabViewModel
    {
        public ContactTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer) 
            : base(regionManger, unityContainer)
        {
            Contacts = DummyDataContext.Context.Contacts;
            this.ParentViewName = nameof(HomeRibbonTabItem);
        }

        public ObservableCollection<Contact> Contacts { get; set; }
    }
}
