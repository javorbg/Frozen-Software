namespace FrozenSoftware.Models
{
    public class Good : EntityBase
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string BarCode { get; set; }

        public int MeasureUnitId { get; set; }

        public virtual MeasureUnit MeasureUnit { get; set; }

        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Code):
                        if (string.IsNullOrEmpty(Code))
                            return "_Code is requird.";
                        break;
                    case nameof(Name):
                        if (string.IsNullOrEmpty(Name))
                            return "_Name is requird.";
                        break;
                    case nameof(MeasureUnitId):
                        if (MeasureUnitId < 1)
                            return "_Measure unit is requird.";
                        break;
                }

                return null;
            }
        }
    }
}
