using Prism.Regions;
using System.Windows.Controls;

namespace FrozenSoftware.Controls.Adapters
{
    public class RegionAdapterTabControl : RegionAdapterBase<TabControl>
    {
        public RegionAdapterTabControl(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }
        protected override void Adapt(IRegion region, TabControl regionTarget)
        {
        }

        protected override IRegion CreateRegion()
        {
            return null;
        }
    }
}
