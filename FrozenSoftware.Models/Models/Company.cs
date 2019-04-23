using PropertyChanged;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrozenSoftware.Models
{
    [ImplementPropertyChanged]
    public class Company : EntityBase
    {
        public string Code { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public bool IsDatabaseOwner { get; set; }
    }
}
