using Prism.Commands;
using Prism.Mvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;

namespace FrozenSoftware.Controls
{
    [ImplementPropertyChanged]
    public class BaseFormViewModel : BindableBase
    {
        private ActionType actionType;
       

        public BaseFormViewModel()
        {
            ConfirmCommand = new DelegateCommand(OnConfirmCommand);
            CancelCommand = new DelegateCommand(OnCancelCommand);
        }

        public DelegateCommand ConfirmCommand { get; set; }

        public DelegateCommand CancelCommand { get; set; }

        public bool IsReadOnly { get; set; }

        public virtual ActionType ActionType
        {
            get
            {
                return actionType;
            }

            set
            {
                this.SetProperty(ref actionType, value);

                IsReadOnly = actionType == ActionType.ReadOnly;
            }
        }

        public virtual void Initialize(int? entityId, ActionType actionType, List<object> additionalData = null)
        {
            ActionType = ActionType;
            EntityId = entityId;
        }

        protected virtual void OnConfirmCommand()
        {
        }

        protected virtual void OnCancelCommand()
        {
            if (Close != null)
                Close.Invoke();

            this.Close = null;
            DialogResult = false;
        }

        public bool DialogResult { get; set; }

        public Action Close { get; set; }

        protected int? EntityId { get; set; }
    }
}
