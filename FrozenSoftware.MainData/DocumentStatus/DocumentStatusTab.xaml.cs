using System.Windows.Controls;

namespace FrozenSoftware.MainData
{
    /// <summary>
    /// Interaction logic for DocumentStatusTab.xaml
    /// </summary>
    public partial class DocumentStatusTab : TabItem
    {
        public DocumentStatusTab()
        {
            InitializeComponent();
        }

        public string ParetViewName { get; set; } = nameof(MainDataRibbonTabItem);
    }
}
