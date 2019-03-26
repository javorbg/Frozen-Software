using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrozenSoftware.Models
{
    public class Company : EntityBase
    {
        public string Code { get; set; }

        public string CompanyName { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
             
    }
}
