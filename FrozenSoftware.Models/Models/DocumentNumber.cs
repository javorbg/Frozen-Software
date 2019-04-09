using System;

namespace FrozenSoftware.Models
{
    public class DocumentNumber : EntityBase
    {
        public virtual int DocumentNumberDefinitionId { get; set; }

        public virtual DocumentNumberDefinition DocumentNumberDefinition { get; set; }

        public int Number { get; set; }

        public int? Day { get; set; }

        public int? Month { get; set; }

        public int?  Year { get; set; }

        public int? YearLenght { get; set; }

        public DateTime CreatedDate { get; set; }

        public string DocumentNumberText { get; set; }
    }
}
