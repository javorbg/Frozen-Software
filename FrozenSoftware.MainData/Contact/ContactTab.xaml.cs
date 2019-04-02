using System.Windows.Controls;

namespace FrozenSoftware.MainData
{
    /// <summary>
    /// Interaction logic for ContactTab.xaml
    /// </summary>
    public partial class ContactTab : TabItem
    {
        public ContactTab()
        {
            InitializeComponent();
        }

        public string ParetViewName { get; set; } = nameof(HomeRibbonTabItem);
    }
}
