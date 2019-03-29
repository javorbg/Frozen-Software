namespace FrozenSoftware.Controls
{
    using FrozenSoftware.Models;
    using Prism.Commands;
    using Prism.Regions;
    using Unity;

    public abstract class BaseTabViewModel
    {
        public BaseTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer)
        {
            RegionManger = regionManger;
            UnityContainer = unityContainer;
            CloseTabCommand = new DelegateCommand(OnCloseTabCommand);
        }

        public DelegateCommand CloseTabCommand { get; set; }

        protected IRegionManager RegionManger { get; set; }

        protected IUnityContainer UnityContainer { get; set; }

        protected virtual void OnCloseTabCommand()
        {
            string viewName = this.GetType().Name.Replace("ViewModel", string.Empty);

            IRegion region = RegionManger.Regions[RegionNames.WorkSpaceRegion];

            if (region == null)
                return;

            object view = region.GetView(viewName);

            if (view != null)
                region.Remove(view);
        }
    }
}
