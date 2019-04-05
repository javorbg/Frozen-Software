namespace FrozenSoftware.Models
{
    public class Good : EntityBase
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string BarCode { get; set; }

        public int MeasureUnitId { get; set; }

        public virtual MeasureUnit MeasureUnit { get; set; }
    }
}
