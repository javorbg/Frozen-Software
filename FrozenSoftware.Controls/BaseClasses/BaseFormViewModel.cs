using FrozenSoftware.Models;
using Prism.Commands;
using Prism.Mvvm;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Unity;

namespace FrozenSoftware.Controls
{
    [ImplementPropertyChanged]
    public class BaseFormViewModel : BindableBase, IDataErrorInfo
    {
        private ActionType actionType;

        public BaseFormViewModel()
        {
            ConfirmCommand = new DelegateCommand(OnConfirmCommand);
            CancelCommand = new DelegateCommand(OnCancelCommand);
        }

        public string Error { get; }

        public DelegateCommand ConfirmCommand { get; set; }

        public DelegateCommand CancelCommand { get; set; }

        public IUnityContainer UnityContainer { get; set; }

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

        public bool DialogResult { get; set; }

        public Action Close { get; set; }

        public FrozenSoftwareWebApiClient ApiClient { get; set; }

        protected int? EntityId { get; set; }

        public virtual string this[string columnName]
        {
            get
            {
                return null;
            }
        }

        public virtual void Initialize(int? entityId, ActionType actionType, List<object> additionalData = null)
        {
            ActionType = actionType;
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
    }
}
