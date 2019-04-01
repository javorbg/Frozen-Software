using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows;

namespace FrozenSoftware.Controls
{
    public abstract class BaseDialogWindowViewModel : BindableBase
    {
        public BaseDialogWindowViewModel()
        {
            ConfirmCommand = new DelegateCommand<Window>(OnConfirmCommand);
        }

        public DelegateCommand<Window> ConfirmCommand { get; set; }

        /// <summary>
        /// the expeted type is StreamGeometry
        /// </summary>
        public object Icon { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        private void OnConfirmCommand(Window viewOwner)
        {
            viewOwner.DialogResult = true;
        }
    }
}