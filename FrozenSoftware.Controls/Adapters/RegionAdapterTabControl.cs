using Prism.Regions;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace FrozenSoftware.Controls
{
    public class RegionAdapterTabControl : RegionAdapterBase<TabControl>
    {
        public RegionAdapterTabControl(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, TabControl regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (TabItem element in e.NewItems)
                            regionTarget.Items.Add(element);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (TabItem element in e.OldItems)
                        {
                            MenuHandler.RemoveEditButtons(element, region.RegionManager, true);
                            element.Template = null;
                            regionTarget.Items.Remove(element);

                        }
                        break;
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}
