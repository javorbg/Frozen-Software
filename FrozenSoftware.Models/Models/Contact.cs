using PropertyChanged;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrozenSoftware.Models
{
    [ImplementPropertyChanged]
    public class Contact : EntityBase
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Family { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        [Required, ForeignKey("Country")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
