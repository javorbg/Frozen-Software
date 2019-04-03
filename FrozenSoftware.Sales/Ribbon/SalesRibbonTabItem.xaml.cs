using Fluent;
using FrozenSoftware.Controls;
using Prism.Regions;

namespace FrozenSoftware.Sales
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
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
