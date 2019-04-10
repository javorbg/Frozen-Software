using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace FrozenSoftware.Models
{
    public class PriceList : EntityBase
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public override string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Name):
                        if (string.IsNullOrEmpty(Name))
                            return "_Price list name is Required";
                        break;
                }

                return null;
            }
        }
    }
}
