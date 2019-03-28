using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrozenSoftware.Models
{
    public class DummyDataContext
    {
        private static DummyDataContext context;

        public static DummyDataContext Context
        {
            get
            {
                if (context == null)
                    context = new DummyDataContext();

                return context;
            }
        }

        public ObservableCollection<DocuentStatus> DocuentStatuses { get; set; }

        public ObservableCollection<Country> Countries { get; set; }

        public ObservableCollection<PaymentType> PaymentTypes { get; set; }

        public ObservableCollection<Contact> Contacts { get; set; }

        public ObservableCollection<Company> Companies { get; set; }

        private DummyDataContext()
        {
            InitializeCountries();
            InitializeDocumentStatuses();
            InitializePaymentTypes();
            InitializeContacts();
            InitializeDatabaseOwnerCompany();
        }

        private void InitializeContacts()
        {
            Contacts = new ObservableCollection<Contact>();
            Country country = Countries.FirstOrDefault(x => x.Code == "BG");
            Contacts.Add(new Contact()
            {
                Id = 1,
                Name = "Rovaj",
                Surname = "Vorodot",
                Family = "Vehsarba",
                Address = "Sofia",
                ZipCode = "1000",
                CompanyId = 1,
                Email = "rovaj@gmail.com",
                Country = country,
                CountryId = country.Id,
                Phone = "+35988888888888888"
            });
        }

        private void InitializeDatabaseOwnerCompany()
        {
            Companies = new ObservableCollection<Company>();
            Country country = Countries.FirstOrDefault(x => x.Code == "BG");
            Companies.Add(new Company()
            {
                Id = 1,
                Code = "1",
                CompanyName = "Rovaj",
                Address = "Sofia",
                Country = country,
                CountryId = country.Id,
                IsDatabaseOwner = true,
                ZipCode = "1000"
            });
        }

        private void InitializePaymentTypes()
        {
            PaymentTypes = new ObservableCollection<PaymentType>();
            PaymentTypes.Add(new PaymentType() { Id = 1, Name = "Cash", ResourceName = "Cash" });
            PaymentTypes.Add(new PaymentType() { Id = 1, Name = "Bank", ResourceName = "Bank" });
            PaymentTypes.Add(new PaymentType() { Id = 1, Name = "Vaucher", ResourceName = "Vaucher" });
            PaymentTypes.Add(new PaymentType() { Id = 1, Name = "Cash and Vaucher", ResourceName = "CashAndVaucher" });
        }

        private void InitializeDocumentStatuses()
        {
            DocuentStatuses = new ObservableCollection<DocuentStatus>();
            DocuentStatuses.Add(new DocuentStatus() { Id = 1, Name = "Draft", ResourceName = "Draft" });
            DocuentStatuses.Add(new DocuentStatus() { Id = 1, Name = "Paid", ResourceName = "Paid" });
            DocuentStatuses.Add(new DocuentStatus() { Id = 1, Name = "Posted", ResourceName = "Posted" });
            DocuentStatuses.Add(new DocuentStatus() { Id = 1, Name = "Cancelled", ResourceName = "Cancelled" });
        }

        private void InitializeCountries()
        {
            Countries = new ObservableCollection<Country>();
            Countries.Add(new Country() { Id = 1, Code = "AF", Name = "Afghanistan" });
            Countries.Add(new Country() { Id = 2, Code = "AL", Name = "Albania" });
            Countries.Add(new Country() { Id = 3, Code = "DZ", Name = "Algeria" });
            Countries.Add(new Country() { Id = 4, Code = "AS", Name = "American Samoa" });
            Countries.Add(new Country() { Id = 5, Code = "AD", Name = "Andorra" });
            Countries.Add(new Country() { Id = 6, Code = "AO", Name = "Angola" });
            Countries.Add(new Country() { Id = 7, Code = "AI", Name = "Anguilla" });
            Countries.Add(new Country() { Id = 8, Code = "AQ", Name = "Antarctica" });
            Countries.Add(new Country() { Id = 9, Code = "AG", Name = "Antigua and Barbuda" });
            Countries.Add(new Country() { Id = 10, Code = "AR", Name = "Argentina" });
            Countries.Add(new Country() { Id = 11, Code = "AM", Name = "Armenia" });
            Countries.Add(new Country() { Id = 12, Code = "AW", Name = "Aruba" });
            Countries.Add(new Country() { Id = 13, Code = "AU", Name = "Australia" });
            Countries.Add(new Country() { Id = 14, Code = "AT", Name = "Austria" });
            Countries.Add(new Country() { Id = 15, Code = "AZ", Name = "Azerbaijan" });
            Countries.Add(new Country() { Id = 16, Code = "BS", Name = "Bahamas" });
            Countries.Add(new Country() { Id = 17, Code = "BH", Name = "Bahrain" });
            Countries.Add(new Country() { Id = 18, Code = "BD", Name = "Bangladesh" });
            Countries.Add(new Country() { Id = 19, Code = "BB", Name = "Barbados" });
            Countries.Add(new Country() { Id = 20, Code = "BY", Name = "Belarus" });
            Countries.Add(new Country() { Id = 21, Code = "BE", Name = "Belgium" });
            Countries.Add(new Country() { Id = 22, Code = "BZ", Name = "Belize" });
            Countries.Add(new Country() { Id = 23, Code = "BJ", Name = "Benin" });
            Countries.Add(new Country() { Id = 24, Code = "BM", Name = "Bermuda" });
            Countries.Add(new Country() { Id = 25, Code = "BT", Name = "Bhutan" });
            Countries.Add(new Country() { Id = 26, Code = "BO", Name = "Bolivia" });
            Countries.Add(new Country() { Id = 27, Code = "BA", Name = "Bosnia and Herzegovina" });
            Countries.Add(new Country() { Id = 28, Code = "BW", Name = "Botswana" });
            Countries.Add(new Country() { Id = 29, Code = "BV", Name = "Bouvet Island" });
            Countries.Add(new Country() { Id = 30, Code = "BR", Name = "Brazil" });
            Countries.Add(new Country() { Id = 31, Code = "IO", Name = "British Indian Ocean Territory" });
            Countries.Add(new Country() { Id = 32, Code = "BN", Name = "Brunei Darussalam" });
            Countries.Add(new Country() { Id = 33, Code = "BG", Name = "Bulgaria" });
            Countries.Add(new Country() { Id = 34, Code = "BF", Name = "Burkina Faso" });
            Countries.Add(new Country() { Id = 35, Code = "BI", Name = "Burundi" });
            Countries.Add(new Country() { Id = 36, Code = "KH", Name = "Cambodia" });
            Countries.Add(new Country() { Id = 37, Code = "CM", Name = "Cameroon" });
            Countries.Add(new Country() { Id = 38, Code = "CA", Name = "Canada" });
            Countries.Add(new Country() { Id = 39, Code = "CV", Name = "Cape Verde" });
            Countries.Add(new Country() { Id = 40, Code = "KY", Name = "Cayman Islands" });
            Countries.Add(new Country() { Id = 41, Code = "CF", Name = "Central African Republic" });
            Countries.Add(new Country() { Id = 42, Code = "TD", Name = "Chad" });
            Countries.Add(new Country() { Id = 43, Code = "CL", Name = "Chile" });
            Countries.Add(new Country() { Id = 44, Code = "CN", Name = "China" });
            Countries.Add(new Country() { Id = 45, Code = "CX", Name = "Christmas Island" });
            Countries.Add(new Country() { Id = 46, Code = "CC", Name = "Cocos (Keeling) Islands" });
            Countries.Add(new Country() { Id = 47, Code = "CO", Name = "Colombia" });
            Countries.Add(new Country() { Id = 48, Code = "KM", Name = "Comoros" });
            Countries.Add(new Country() { Id = 49, Code = "CG", Name = "Congo" });
            Countries.Add(new Country() { Id = 50, Code = "CD", Name = "Congo, the Democratic Republic of the" });
            Countries.Add(new Country() { Id = 51, Code = "CK", Name = "Cook Islands" });
            Countries.Add(new Country() { Id = 52, Code = "CR", Name = "Costa Rica" });
            Countries.Add(new Country() { Id = 53, Code = "CI", Name = "Cote D'Ivoire" });
            Countries.Add(new Country() { Id = 54, Code = "HR", Name = "Croatia" });
            Countries.Add(new Country() { Id = 55, Code = "CU", Name = "Cuba" });
            Countries.Add(new Country() { Id = 56, Code = "CY", Name = "Cyprus" });
            Countries.Add(new Country() { Id = 57, Code = "CZ", Name = "Czech Republic" });
            Countries.Add(new Country() { Id = 58, Code = "DK", Name = "Denmark" });
            Countries.Add(new Country() { Id = 59, Code = "DJ", Name = "Djibouti" });
            Countries.Add(new Country() { Id = 60, Code = "DM", Name = "Dominica" });
            Countries.Add(new Country() { Id = 61, Code = "DO", Name = "Dominican Republic" });
            Countries.Add(new Country() { Id = 62, Code = "EC", Name = "Ecuador" });
            Countries.Add(new Country() { Id = 63, Code = "EG", Name = "Egypt" });
            Countries.Add(new Country() { Id = 64, Code = "SV", Name = "El Salvador" });
            Countries.Add(new Country() { Id = 65, Code = "GQ", Name = "Equatorial Guinea" });
            Countries.Add(new Country() { Id = 66, Code = "ER", Name = "Eritrea" });
            Countries.Add(new Country() { Id = 67, Code = "EE", Name = "Estonia" });
            Countries.Add(new Country() { Id = 68, Code = "ET", Name = "Ethiopia" });
            Countries.Add(new Country() { Id = 69, Code = "FK", Name = "Falkland Islands (Malvinas)" });
            Countries.Add(new Country() { Id = 70, Code = "FO", Name = "Faroe Islands" });
            Countries.Add(new Country() { Id = 71, Code = "FJ", Name = "Fiji" });
            Countries.Add(new Country() { Id = 72, Code = "FI", Name = "Finland" });
            Countries.Add(new Country() { Id = 73, Code = "FR", Name = "France" });
            Countries.Add(new Country() { Id = 74, Code = "GF", Name = "French Guiana" });
            Countries.Add(new Country() { Id = 75, Code = "PF", Name = "French Polynesia" });
            Countries.Add(new Country() { Id = 76, Code = "TF", Name = "French Southern Territories" });
            Countries.Add(new Country() { Id = 77, Code = "GA", Name = "Gabon" });
            Countries.Add(new Country() { Id = 78, Code = "GM", Name = "Gambia" });
            Countries.Add(new Country() { Id = 79, Code = "GE", Name = "Georgia" });
            Countries.Add(new Country() { Id = 80, Code = "DE", Name = "Germany" });
            Countries.Add(new Country() { Id = 81, Code = "GH", Name = "Ghana" });
            Countries.Add(new Country() { Id = 82, Code = "GI", Name = "Gibraltar" });
            Countries.Add(new Country() { Id = 83, Code = "GR", Name = "Greece" });
            Countries.Add(new Country() { Id = 84, Code = "GL", Name = "Greenland" });
            Countries.Add(new Country() { Id = 85, Code = "GD", Name = "Grenada" });
            Countries.Add(new Country() { Id = 86, Code = "GP", Name = "Guadeloupe" });
            Countries.Add(new Country() { Id = 87, Code = "GU", Name = "Guam" });
            Countries.Add(new Country() { Id = 88, Code = "GT", Name = "Guatemala" });
            Countries.Add(new Country() { Id = 89, Code = "GN", Name = "Guinea" });
            Countries.Add(new Country() { Id = 90, Code = "GW", Name = "Guinea-Bissau" });
            Countries.Add(new Country() { Id = 91, Code = "GY", Name = "Guyana" });
            Countries.Add(new Country() { Id = 92, Code = "HT", Name = "Haiti" });
            Countries.Add(new Country() { Id = 93, Code = "HM", Name = "Heard Island and Mcdonald Islands" });
            Countries.Add(new Country() { Id = 94, Code = "VA", Name = "Holy See (Vatican City State)" });
            Countries.Add(new Country() { Id = 95, Code = "HN", Name = "Honduras" });
            Countries.Add(new Country() { Id = 96, Code = "HK", Name = "Hong Kong" });
            Countries.Add(new Country() { Id = 97, Code = "HU", Name = "Hungary" });
            Countries.Add(new Country() { Id = 98, Code = "IS", Name = "Iceland" });
            Countries.Add(new Country() { Id = 99, Code = "IN", Name = "India" });
            Countries.Add(new Country() { Id = 100, Code = "ID", Name = "Indonesia" });
            Countries.Add(new Country() { Id = 101, Code = "IR", Name = "Iran, Islamic Republic of" });
            Countries.Add(new Country() { Id = 102, Code = "IQ", Name = "Iraq" });
            Countries.Add(new Country() { Id = 103, Code = "IE", Name = "Ireland" });
            Countries.Add(new Country() { Id = 104, Code = "IL", Name = "Israel" });
            Countries.Add(new Country() { Id = 105, Code = "IT", Name = "Italy" });
            Countries.Add(new Country() { Id = 106, Code = "JM", Name = "Jamaica" });
            Countries.Add(new Country() { Id = 107, Code = "JP", Name = "Japan" });
            Countries.Add(new Country() { Id = 108, Code = "JO", Name = "Jordan" });
            Countries.Add(new Country() { Id = 109, Code = "KZ", Name = "Kazakhstan" });
            Countries.Add(new Country() { Id = 110, Code = "KE", Name = "Kenya" });
            Countries.Add(new Country() { Id = 111, Code = "KI", Name = "Kiribati" });
            Countries.Add(new Country() { Id = 112, Code = "KP", Name = "Korea, Democratic People's Republic of" });
            Countries.Add(new Country() { Id = 113, Code = "KR", Name = "Korea, Republic of" });
            Countries.Add(new Country() { Id = 114, Code = "KW", Name = "Kuwait" });
            Countries.Add(new Country() { Id = 115, Code = "KG", Name = "Kyrgyzstan" });
            Countries.Add(new Country() { Id = 116, Code = "LA", Name = "Lao People's Democratic Republic" });
            Countries.Add(new Country() { Id = 117, Code = "LV", Name = "Latvia" });
            Countries.Add(new Country() { Id = 118, Code = "LB", Name = "Lebanon" });
            Countries.Add(new Country() { Id = 119, Code = "LS", Name = "Lesotho" });
            Countries.Add(new Country() { Id = 120, Code = "LR", Name = "Liberia" });
            Countries.Add(new Country() { Id = 121, Code = "LY", Name = "Libyan Arab Jamahiriya" });
            Countries.Add(new Country() { Id = 122, Code = "LI", Name = "Liechtenstein" });
            Countries.Add(new Country() { Id = 123, Code = "LT", Name = "Lithuania" });
            Countries.Add(new Country() { Id = 124, Code = "LU", Name = "Luxembourg" });
            Countries.Add(new Country() { Id = 125, Code = "MO", Name = "Macao" });
            Countries.Add(new Country() { Id = 126, Code = "MK", Name = "Macedonia, the Former Yugoslav Republic of" });
            Countries.Add(new Country() { Id = 127, Code = "MG", Name = "Madagascar" });
            Countries.Add(new Country() { Id = 128, Code = "MW", Name = "Malawi" });
            Countries.Add(new Country() { Id = 129, Code = "MY", Name = "Malaysia" });
            Countries.Add(new Country() { Id = 130, Code = "MV", Name = "Maldives" });
            Countries.Add(new Country() { Id = 131, Code = "ML", Name = "Mali" });
            Countries.Add(new Country() { Id = 132, Code = "MT", Name = "Malta" });
            Countries.Add(new Country() { Id = 133, Code = "MH", Name = "Marshall Islands" });
            Countries.Add(new Country() { Id = 134, Code = "MQ", Name = "Martinique" });
            Countries.Add(new Country() { Id = 135, Code = "MR", Name = "Mauritania" });
            Countries.Add(new Country() { Id = 136, Code = "MU", Name = "Mauritius" });
            Countries.Add(new Country() { Id = 137, Code = "YT", Name = "Mayotte" });
            Countries.Add(new Country() { Id = 138, Code = "MX", Name = "Mexico" });
            Countries.Add(new Country() { Id = 139, Code = "FM", Name = "Micronesia, Federated States of" });
            Countries.Add(new Country() { Id = 140, Code = "MD", Name = "Moldova, Republic of" });
            Countries.Add(new Country() { Id = 141, Code = "MC", Name = "Monaco" });
            Countries.Add(new Country() { Id = 142, Code = "MN", Name = "Mongolia" });
            Countries.Add(new Country() { Id = 143, Code = "MS", Name = "Montserrat" });
            Countries.Add(new Country() { Id = 144, Code = "MA", Name = "Morocco" });
            Countries.Add(new Country() { Id = 145, Code = "MZ", Name = "Mozambique" });
            Countries.Add(new Country() { Id = 146, Code = "MM", Name = "Myanmar" });
            Countries.Add(new Country() { Id = 147, Code = "NA", Name = "Namibia" });
            Countries.Add(new Country() { Id = 148, Code = "NR", Name = "Nauru" });
            Countries.Add(new Country() { Id = 149, Code = "NP", Name = "Nepal" });
            Countries.Add(new Country() { Id = 150, Code = "NL", Name = "Netherlands" });
            Countries.Add(new Country() { Id = 151, Code = "AN", Name = "Netherlands Antilles" });
            Countries.Add(new Country() { Id = 152, Code = "NC", Name = "New Caledonia" });
            Countries.Add(new Country() { Id = 153, Code = "NZ", Name = "New Zealand" });
            Countries.Add(new Country() { Id = 154, Code = "NI", Name = "Nicaragua" });
            Countries.Add(new Country() { Id = 155, Code = "NE", Name = "Niger" });
            Countries.Add(new Country() { Id = 156, Code = "NG", Name = "Nigeria" });
            Countries.Add(new Country() { Id = 157, Code = "NU", Name = "Niue" });
            Countries.Add(new Country() { Id = 158, Code = "NF", Name = "Norfolk Island" });
            Countries.Add(new Country() { Id = 159, Code = "MP", Name = "Northern Mariana Islands" });
            Countries.Add(new Country() { Id = 160, Code = "NO", Name = "Norway" });
            Countries.Add(new Country() { Id = 161, Code = "OM", Name = "Oman" });
            Countries.Add(new Country() { Id = 162, Code = "PK", Name = "Pakistan" });
            Countries.Add(new Country() { Id = 163, Code = "PW", Name = "Palau" });
            Countries.Add(new Country() { Id = 164, Code = "PS", Name = "Palestinian Territory, Occupied" });
            Countries.Add(new Country() { Id = 165, Code = "PA", Name = "Panama" });
            Countries.Add(new Country() { Id = 166, Code = "PG", Name = "Papua New Guinea" });
            Countries.Add(new Country() { Id = 167, Code = "PY", Name = "Paraguay" });
            Countries.Add(new Country() { Id = 168, Code = "PE", Name = "Peru" });
            Countries.Add(new Country() { Id = 169, Code = "PH", Name = "Philippines" });
            Countries.Add(new Country() { Id = 170, Code = "PN", Name = "Pitcairn" });
            Countries.Add(new Country() { Id = 171, Code = "PL", Name = "Poland" });
            Countries.Add(new Country() { Id = 172, Code = "PT", Name = "Portugal" });
            Countries.Add(new Country() { Id = 173, Code = "PR", Name = "Puerto Rico" });
            Countries.Add(new Country() { Id = 174, Code = "QA", Name = "Qatar" });
            Countries.Add(new Country() { Id = 175, Code = "RE", Name = "Reunion" });
            Countries.Add(new Country() { Id = 176, Code = "RO", Name = "Romania" });
            Countries.Add(new Country() { Id = 177, Code = "RU", Name = "Russian Federation" });
            Countries.Add(new Country() { Id = 178, Code = "RW", Name = "Rwanda" });
            Countries.Add(new Country() { Id = 179, Code = "SH", Name = "Saint Helena" });
            Countries.Add(new Country() { Id = 180, Code = "KN", Name = "Saint Kitts and Nevis" });
            Countries.Add(new Country() { Id = 181, Code = "LC", Name = "Saint Lucia" });
            Countries.Add(new Country() { Id = 182, Code = "PM", Name = "Saint Pierre and Miquelon" });
            Countries.Add(new Country() { Id = 183, Code = "VC", Name = "Saint Vincent and the Grenadines" });
            Countries.Add(new Country() { Id = 184, Code = "WS", Name = "Samoa" });
            Countries.Add(new Country() { Id = 185, Code = "SM", Name = "San Marino" });
            Countries.Add(new Country() { Id = 186, Code = "ST", Name = "Sao Tome and Principe" });
            Countries.Add(new Country() { Id = 187, Code = "SA", Name = "Saudi Arabia" });
            Countries.Add(new Country() { Id = 188, Code = "SN", Name = "Senegal" });
            Countries.Add(new Country() { Id = 189, Code = "CS", Name = "Serbia and Montenegro" });
            Countries.Add(new Country() { Id = 190, Code = "SC", Name = "Seychelles" });
            Countries.Add(new Country() { Id = 191, Code = "SL", Name = "Sierra Leone" });
            Countries.Add(new Country() { Id = 192, Code = "SG", Name = "Singapore" });
            Countries.Add(new Country() { Id = 193, Code = "SK", Name = "Slovakia" });
            Countries.Add(new Country() { Id = 194, Code = "SI", Name = "Slovenia" });
            Countries.Add(new Country() { Id = 195, Code = "SB", Name = "Solomon Islands" });
            Countries.Add(new Country() { Id = 196, Code = "SO", Name = "Somalia" });
            Countries.Add(new Country() { Id = 197, Code = "ZA", Name = "South Africa" });
            Countries.Add(new Country() { Id = 198, Code = "GS", Name = "South Georgia and the South Sandwich Islands" });
            Countries.Add(new Country() { Id = 199, Code = "ES", Name = "Spain" });
            Countries.Add(new Country() { Id = 200, Code = "LK", Name = "Sri Lanka" });
            Countries.Add(new Country() { Id = 201, Code = "SD", Name = "Sudan" });
            Countries.Add(new Country() { Id = 202, Code = "SR", Name = "Suriname" });
            Countries.Add(new Country() { Id = 203, Code = "SJ", Name = "Svalbard and Jan Mayen" });
            Countries.Add(new Country() { Id = 204, Code = "SZ", Name = "Swaziland" });
            Countries.Add(new Country() { Id = 205, Code = "SE", Name = "Sweden" });
            Countries.Add(new Country() { Id = 206, Code = "CH", Name = "Switzerland" });
            Countries.Add(new Country() { Id = 207, Code = "SY", Name = "Syrian Arab Republic" });
            Countries.Add(new Country() { Id = 208, Code = "TW", Name = "Taiwan, Province of China" });
            Countries.Add(new Country() { Id = 209, Code = "TJ", Name = "Tajikistan" });
            Countries.Add(new Country() { Id = 210, Code = "TZ", Name = "Tanzania, United Republic of" });
            Countries.Add(new Country() { Id = 211, Code = "TH", Name = "Thailand" });
            Countries.Add(new Country() { Id = 212, Code = "TL", Name = "Timor-Leste" });
            Countries.Add(new Country() { Id = 213, Code = "TG", Name = "Togo" });
            Countries.Add(new Country() { Id = 214, Code = "TK", Name = "Tokelau" });
            Countries.Add(new Country() { Id = 215, Code = "TO", Name = "Tonga" });
            Countries.Add(new Country() { Id = 216, Code = "TT", Name = "Trinidad and Tobago" });
            Countries.Add(new Country() { Id = 217, Code = "TN", Name = "Tunisia" });
            Countries.Add(new Country() { Id = 218, Code = "TR", Name = "Turkey" });
            Countries.Add(new Country() { Id = 219, Code = "TM", Name = "Turkmenistan" });
            Countries.Add(new Country() { Id = 220, Code = "TC", Name = "Turks and Caicos Islands" });
            Countries.Add(new Country() { Id = 221, Code = "TV", Name = "Tuvalu" });
            Countries.Add(new Country() { Id = 222, Code = "UG", Name = "Uganda" });
            Countries.Add(new Country() { Id = 223, Code = "UA", Name = "Ukraine" });
            Countries.Add(new Country() { Id = 224, Code = "AE", Name = "United Arab Emirates" });
            Countries.Add(new Country() { Id = 225, Code = "GB", Name = "United Kingdom" });
            Countries.Add(new Country() { Id = 226, Code = "US", Name = "United States" });
            Countries.Add(new Country() { Id = 227, Code = "UM", Name = "United States Minor Outlying Islands" });
            Countries.Add(new Country() { Id = 228, Code = "UY", Name = "Uruguay" });
            Countries.Add(new Country() { Id = 229, Code = "UZ", Name = "Uzbekistan" });
            Countries.Add(new Country() { Id = 230, Code = "VU", Name = "Vanuatu" });
            Countries.Add(new Country() { Id = 231, Code = "VE", Name = "Venezuela" });
            Countries.Add(new Country() { Id = 232, Code = "VN", Name = "Viet Nam" });
            Countries.Add(new Country() { Id = 233, Code = "VG", Name = "Virgin Islands, British" });
            Countries.Add(new Country() { Id = 234, Code = "VI", Name = "Virgin Islands, U.s." });
            Countries.Add(new Country() { Id = 235, Code = "WF", Name = "Wallis and Futuna" });
            Countries.Add(new Country() { Id = 236, Code = "EH", Name = "Western Sahara" });
            Countries.Add(new Country() { Id = 237, Code = "YE", Name = "Yemen" });
            Countries.Add(new Country() { Id = 238, Code = "ZM", Name = "Zambia" });
            Countries.Add(new Country() { Id = 239, Code = "ZW", Name = "Zimbabwe" });
        }
    }
}
