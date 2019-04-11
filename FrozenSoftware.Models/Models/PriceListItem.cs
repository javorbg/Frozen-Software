using System.ComponentModel.DataAnnotations.Schema;

namespace FrozenSoftware.Models
{
    public class PriceListItem : EntityBase
    {
        [ForeignKey("Good")]
        public int GoodId { get; set; }

        public virtual Good Good { get; set; }

        public decimal BasePrice { get; set; }

        public decimal EndPrice { get; set; }

        public int Discount { get; set; }

        public int Vat { get; set; }

        [ForeignKey("PriceList")]
        public int PriceListId { get; set; }

        public virtual PriceList PriceList { get; set; }

        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Good):
                    case nameof(GoodId):
                        if (GoodId < 1 || Good == null)
                            return "_Good is requried.";
                        break;
                }

                return null;
            }
        }
    }
}