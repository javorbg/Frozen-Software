using System.Windows;

namespace FrozenSoftware.Controls
{
    public class ConfirWindowViewModel : BaseDialogWindowViewModel
    {
        public ConfirWindowViewModel()
        {
            Icon = Application.Current.FindResource("Confirm");
        }
    }
}
