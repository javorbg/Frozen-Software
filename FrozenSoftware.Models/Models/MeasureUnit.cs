namespace FrozenSoftware.Models
{
    public class MeasureUnit : ResourceBase
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public MeasureUnitType MeasureUnitType { get; set; }
    }
}
