using FrozenSoftware.Controls.BaseClasses;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Unity;

namespace FrozenSoftware.Controls
{

    public abstract class BaseTabViewModel : BindableBase, IParentViewName
    {
        public BaseTabViewModel(IRegionManager regionManger, IUnityContainer unityContainer)
        {
            RegionManger = regionManger;
            UnityContainer = unityContainer;
            CloseTabCommand = new DelegateCommand(OnCloseTabCommand);
        }

        public DelegateCommand CloseTabCommand { get; set; }

        public int SelectedIndex { get; set; }

        public string ParentViewName { get; set; } = "HomeRibbonTabItem";

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
    }
}
