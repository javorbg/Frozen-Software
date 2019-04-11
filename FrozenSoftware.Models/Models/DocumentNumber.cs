using PropertyChanged;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FrozenSoftware.Models
{
    [ImplementPropertyChanged]
    public class DocumentNumber : EntityBase, IComparable<DocumentNumber>
    {
        [ForeignKey("DocumentNumberDefinition")]
        public virtual int DocumentNumberDefinitionId { get; set; }

        public virtual DocumentNumberDefinition DocumentNumberDefinition { get; set; }

        public int Number { get; set; }

        public int? Day { get; set; }

        public int? Month { get; set; }

        public int? Year { get; set; }

        public int? YearLenght { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime DocumentDate { get; set; }

        public string DocumentNumberText { get; set; }

        public int CompareTo(DocumentNumber other)
        {
            if (other == null)
                return 1;

            int result = 0;

            if (Year.HasValue || Month.HasValue || Day.HasValue)
            {
                DateTime date = new DateTime(Year ?? 1, Month ?? 1, Day ?? 1);
                DateTime dateOther = new DateTime(other.Year ?? 1, other.Month ?? 1, other.Day ?? 1);
                result = date.CompareTo(dateOther);
            }

            if (result == 0)
                result = Number.CompareTo(other.Number);

            return result;
        }

        public string FormatNumber(DocumentNumberDefinition documentNumbDef, string date)
        {
            string[] numberOrder = new string[3];

            numberOrder[documentNumbDef.NumberPosition] = Number.ToString($"D{documentNumbDef.NumbersCount}");

            if (documentNumbDef.DatePosition.HasValue && date != null)
                numberOrder[documentNumbDef.DatePosition.Value] = date;

            if (documentNumbDef.TextConstantPosition.HasValue)
                numberOrder[documentNumbDef.TextConstantPosition.Value] = documentNumbDef.TextConstant;

            StringBuilder number = new StringBuilder();
            for (int i = 0; i < numberOrder.Length; i++)
            {
                if (!string.IsNullOrEmpty(numberOrder[i]))
                    number.Append(numberOrder[i]);
            }

            return number.ToString();
        }
    }
}
