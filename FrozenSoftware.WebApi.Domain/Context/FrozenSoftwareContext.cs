using FrozenSoftware.Models;
using System.Data.Entity;

namespace FrozenSoftware.WebApi.Context
{
    public class FrozenSoftwareContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<PaymentType> PaymentTypes { get; set; }

        public DbSet<DocumentStatus> DocumentStatuses { get; set; }
    }
}