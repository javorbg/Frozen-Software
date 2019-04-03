using Fluent;
using FrozenSoftware.Controls;
using Prism.Regions;

namespace FrozenSoftware.MainData
{
    /// <summary>
    /// Interaction logic for HomeRibbonTabItem.xaml
    /// </summary>
    public partial class MainDataRibbonTabItem : RibbonTabItem, IMainDataRibbon
    {
        public MainDataRibbonTabItem()
        {
            InitializeComponent();
        }

        public int Position { get; } = 1;
    }
}
