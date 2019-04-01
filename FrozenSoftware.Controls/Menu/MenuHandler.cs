using Fluent;
using Prism.Regions;
using System.Windows.Controls;
using Unity;

namespace FrozenSoftware.Controls
{
    public class MenuHandler
    {
        public static void AddEditButtons(TabItem view, IRegionManager regionManger, IUnityContainer unityContainer)
        {
            if (view == null)
                return;

            IParentViewName iNewSelection = view.DataContext as IParentViewName;

            if (iNewSelection == null || !iNewSelection.HasEditButtons)
                return;

            var editMenu = unityContainer.Resolve<EditMenuRibbonGroupBox>() ;
            editMenu.Header = $"Edit {view.Header}";
            IRegion ribbonRegion = regionManger.Regions[RegionNames.RibbonRegion];

            RibbonTabItem buttonsView = ribbonRegion.GetView(iNewSelection.ParentViewName) as RibbonTabItem;
            editMenu.DataContext = view.DataContext;
            view.Tag = editMenu;
            buttonsView.Groups.Add(editMenu);
        }

        public static void RemoveEditButtons(TabItem view, IRegionManager regionManger,bool isViewClosed)
        {
            if (view == null)
                return;

            IParentViewName iNewSelection = view.DataContext as IParentViewName;

            if (iNewSelection == null || !iNewSelection.HasEditButtons || view.Tag == null)
                return;

            IRegion ribbonRegion = regionManger.Regions[RegionNames.RibbonRegion];
            RibbonTabItem buttonsView = ribbonRegion.GetView(iNewSelection.ParentViewName) as RibbonTabItem;
            var editMenu = view.Tag as EditMenuRibbonGroupBox;
            if (isViewClosed)
            {
                view.Tag = null;
                editMenu.DataContext = null;
            }

            buttonsView.Groups.Remove(editMenu);
        }
    }
}
