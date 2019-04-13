using Fluent;
using FrozenSoftware.Controls;

namespace FrozenSoftware.Settings
{
    /// <summary>
    /// Interaction logic for SettingsRibbonTabItem.xaml
    /// </summary>
    public partial class SettingsRibbonTabItem : RibbonTabItem, ISettingsRibbon
    {
        public SettingsRibbonTabItem()
        {
            InitializeComponent();
        }

        public int Position { get; } = 3;
    }
}
