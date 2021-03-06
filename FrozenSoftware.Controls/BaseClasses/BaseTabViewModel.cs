﻿using FrozenSoftware.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PropertyChanged;
using System.ComponentModel;
using Unity;
using Unity.Resolution;

namespace FrozenSoftware.Controls
{
    [ImplementPropertyChanged]
    public abstract class BaseTabViewModel : BindableBase, IParentViewName, IDataErrorInfo
    {
        private EntityBase selectedEntity;

        public BaseTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer)
        {
            RegionManger = regionManger;
            UnityContainer = unityContainer;
            CloseTabCommand = new DelegateCommand(OnCloseTabCommand);
            AddCommand = new DelegateCommand(OnAddCommand);
            EditCommand = new DelegateCommand(OnEditCommand, CanExecuteEditCommand);
            DeleteCommand = new DelegateCommand(OnDeleteCommand, CanExecuteDeleteCommand);
            HasEditButtons = true;
            ParameterOverride contructorParameter = new ParameterOverride("baseUrl", FrozenSoftwareWebApiClient.BaseApiUrl);
            ApiClient = unityContainer.Resolve<FrozenSoftwareWebApiClient>(contructorParameter);
        }

        public DelegateCommand CloseTabCommand { get; set; }

        public DelegateCommand AddCommand { get; set; }

        public DelegateCommand EditCommand { get; set; }

        public DelegateCommand DeleteCommand { get; set; }

        public virtual int SelectedIndex { get; set; }

        public EntityBase SelectedEntity
        {
            get
            {
                return selectedEntity;
            }

            set
            {
                SetProperty(ref selectedEntity, value);
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public string ParentViewName { get; set; }

        public bool HasEditButtons { get; set; }

        public virtual string Error { get; }

        protected IRegionManager RegionManger { get; set; }

        protected IUnityContainer UnityContainer { get; set; }

        protected FrozenSoftwareWebApiClient ApiClient { get; set; }

        public virtual string this[string columnName]
        {
            get
            {
                return null;
            }
        }

        public virtual void InitializeData()
        {
        }

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
            if (SelectedEntity == null)
                return false;

            return true;
        }

        protected virtual bool CanExecuteEditCommand()
        {
            if (SelectedEntity == null)
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
