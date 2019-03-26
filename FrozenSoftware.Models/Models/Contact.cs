namespace FrozenSoftware.Models
{
    public class Contact : EntityBase
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Family { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public int CompanyId { get; set; }
    }
}
