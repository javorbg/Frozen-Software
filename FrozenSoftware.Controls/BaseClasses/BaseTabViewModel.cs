using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PropertyChanged;
using Unity;

namespace FrozenSoftware.Controls
{
    [ImplementPropertyChanged]
    public abstract class BaseTabViewModel : BindableBase, IParentViewName
    {
        private int? selectedIndex;

        public BaseTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer)
        {
            RegionManger = regionManger;
            UnityContainer = unityContainer;
            CloseTabCommand = new DelegateCommand(OnCloseTabCommand);
            AddCommand = new DelegateCommand(OnAddCommand);
            EditCommand = new DelegateCommand(OnEditCommand, CanExecuteEditCommand);
            DeleteCommand = new DelegateCommand(OnDeleteCommand, CanExecuteDeleteCommand);
            HasEditButtons = true;
        }

        public DelegateCommand CloseTabCommand { get; set; }

        public DelegateCommand AddCommand { get; set; }

        public DelegateCommand EditCommand { get; set; }

        public DelegateCommand DeleteCommand { get; set; }

        public virtual int? SelectedIndex
        {
            get
            {
                return selectedIndex;
            }

            set
            {
                SetProperty(ref selectedIndex, value);
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public string ParentViewName { get; set; }

        public bool HasEditButtons { get; set; }

        protected IRegionManager RegionManger { get; set; }

        protected IUnityContainer UnityContainer { get; set; }

        protected virtual void OnCloseTabCommand()
        {
            string viewName = this.GetType().Name.Replace("ViewModel", string.Empty);

            IRegion region = RegionManger.Regions[RegionNames.TabItemRegion];

            if (region == null)
                return;

            object view = region.GetView(viewName);

            if (view != null)
                region.Remove(view);
        }

        protected virtual void OnDeleteCommand()
        {
        }

        protected virtual bool CanExecuteDeleteCommand()
        {
            if (!this.SelectedIndex.HasValue || this.SelectedIndex.Value < 0)
                return false;

            return true;
        }

        protected virtual bool CanExecuteEditCommand()
        {
            if (!this.SelectedIndex.HasValue || this.SelectedIndex.Value < 0)
                return false;

            return true;
        }

        protected virtual void OnEditCommand()
        {
        }

        protected virtual void OnAddCommand()
        {
        }
    }
}
