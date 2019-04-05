using FrozenSoftware.Controls;
using FrozenSoftware.Models;
using Prism.Regions;
using System.Collections.ObjectModel;
using Unity;

namespace FrozenSoftware.Sales
{
    public class MeasureUnitTabViewModel : BaseTabViewModel
    {
        public MeasureUnitTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer)
            : base(regionManger, unityContainer)
        {
            MeasureUnits = DummyDataContext.Context.MeasureUnits;
            ParentViewName = nameof(SalesRibbonTabItem);
            HasEditButtons = false;
        }

        public ObservableCollection<MeasureUnit> MeasureUnits { get; set; }
    }
}
