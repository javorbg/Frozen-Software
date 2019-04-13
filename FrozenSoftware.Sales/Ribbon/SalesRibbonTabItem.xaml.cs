using Fluent;
using FrozenSoftware.Controls;

namespace FrozenSoftware.Sales
{
    /// <summary>
    /// Interaction logic for SalesRibbonTabItem.xaml
    /// </summary>
    public partial class SalesRibbonTabItem : RibbonTabItem, ISalesRibbon
    {
        public SalesRibbonTabItem()
        {
            InitializeComponent();
        }

        public int Position { get; } = 2;
    }
}
