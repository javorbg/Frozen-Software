using Fluent;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FrozenSoftware.Controls
{
    public class RegionAdapterFluentRibbon : RegionAdapterBase<Ribbon>
    {
        public RegionAdapterFluentRibbon(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, Ribbon regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        foreach (RibbonTabItem element in e.NewItems)
                            regionTarget.Tabs.Add(element);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        foreach (RibbonTabItem element in e.OldItems)
                            regionTarget.Tabs.Remove(element);
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
