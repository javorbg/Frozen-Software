using PropertyChanged;
using System;
using System.ComponentModel.DataAnnotations;

namespace FrozenSoftware.Models
{
    [ImplementPropertyChanged]
    public class DocumentNumberDefinition : EntityBase
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool HasDate { get; set; }

        public string DateFormat { get; set; }

        public int NumbersCount { get; set; }

        public string TextConstant { get; set; }

        public int? DatePosition { get; set; }

        public int? TextConstantPosition { get; set; }

        public int NumberPosition { get; set; }
    }
}
