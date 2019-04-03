using System.Windows.Controls;

namespace FrozenSoftware.MainData
{
    /// <summary>
    /// Interaction logic for CompanyTab.xaml
    /// </summary>
    public partial class CompanyTab : TabItem
    {
        public CompanyTab()
        {
            InitializeComponent();
        }

        public string ParetViewName { get; set; } = nameof(MainDataRibbonTabItem);
    }
}
