using System;

namespace FrozenSoftware.Models
{
    public class PriceList : EntityBase
    {
        public int Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }
    }
}
