namespace FrozenSoftware.Models
{
    public class PriceListItem : EntityBase
    {
        public int GoodId { get; set; }

        public virtual Good Good { get; set; }

        public decimal BasePrice { get; set; }

        public decimal EndPrice { get; set; }

        public int PriceListId { get; set; }

        public virtual PriceList PriceList { get; set; }

        public string MeasureUnitName
        {
            get
            {
                return Good?.MeasureUnit?.Name;
            }
        }
    }
}