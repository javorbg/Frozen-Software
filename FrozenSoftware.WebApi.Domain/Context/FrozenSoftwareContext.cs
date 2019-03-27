using FrozenSoftware.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FrozenSoftware.WebApi.Context
{
    public class FrozenSoftwareContext : DbContext
    {
        DbSet<Company> Companies { get; set; }

        DbSet<Contact> Contacts { get; set; }

        DbSet<Country> Countries { get; set; }

        DbSet<PaymentType> PaymentTypes { get; set; }

        DbSet<DocumentStatus> DocumentStatuses { get; set; }
    }
}