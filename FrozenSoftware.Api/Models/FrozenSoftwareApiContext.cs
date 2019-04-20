using System.Data.Entity;

namespace FrozenSoftware.Api.Models
{
    public class FrozenSoftwareApiContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public FrozenSoftwareApiContext() : base("name=FrozenSoftwareApiContext")
        {
        }

        public System.Data.Entity.DbSet<FrozenSoftware.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<FrozenSoftware.Models.Country> Countries { get; set; }

        public System.Data.Entity.DbSet<FrozenSoftware.Models.Contact> Contacts { get; set; }

        public System.Data.Entity.DbSet<FrozenSoftware.Models.DateFormat> DateFormats { get; set; }

        public System.Data.Entity.DbSet<FrozenSoftware.Models.DocumentNumber> DocumentNumbers { get; set; }

        public System.Data.Entity.DbSet<FrozenSoftware.Models.DocumentNumberDefinition> DocumentNumberDefinitions { get; set; }

        public System.Data.Entity.DbSet<FrozenSoftware.Models.DocumentStatus> DocumentStatus { get; set; }

        public System.Data.Entity.DbSet<FrozenSoftware.Models.Good> Goods { get; set; }

        public System.Data.Entity.DbSet<FrozenSoftware.Models.MeasureUnit> MeasureUnits { get; set; }

        public System.Data.Entity.DbSet<FrozenSoftware.Models.PaymentType> PaymentTypes { get; set; }

        public System.Data.Entity.DbSet<FrozenSoftware.Models.PriceList> PriceLists { get; set; }

        public System.Data.Entity.DbSet<FrozenSoftware.Models.PriceListItem> PriceListItems { get; set; }
    }
}
