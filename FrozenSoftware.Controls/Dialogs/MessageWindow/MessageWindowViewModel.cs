using PropertyChanged;
using System.Windows;

namespace FrozenSoftware.Controls
{
    [ImplementPropertyChanged]
    public class MessageWindowViewModel : BaseDialogWindowViewModel
    {
        public MessageWindowViewModel()
        {
            Icon = Application.Current.FindResource("Warning");
        }
    }
}
