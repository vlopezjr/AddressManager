using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressManager.Data
{
    [Table("tciAddress")]
    public class Address
    {
        [Key]
        [Column("AddrKey")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Key { get; set; }

        [Column("AddrName")]
        public string Name { get; set; }

        [Column("AddrLine1")]
        public string Line1 { get; set; }

        [Column("AddrLine2")]
        public string Line2 { get; set; }

        [Column("AddrLine3")]
        public string Line3 { get; set; }

        [Column("AddrLine4")]
        public string Line4 { get; set; }

        [Column("AddrLine5")]
        public string Line5 { get; set; }

        public string City { get; set; }

        [Column("StateID")]
        public string State { get; set; }

        [Column("PostalCode")]
        public string Zip { get; set; }

        [NotMapped]
        public string Zip5 { get; set; }

        [NotMapped]
        public string Zip4 { get; set; }

        [NotMapped]
        public string Type { get; set; }

        [NotMapped]
        public bool IsPrimary
        {
            get { return Type.Contains("P"); }
        }

        [NotMapped]
        public bool IsDefaultBilling
        {
            get { return Type.Contains("B"); }
        }

        [NotMapped]
        public bool IsDefaultShipping
        {
            get { return Type.Contains("S"); }
        }

        [Column("CountryID")]
        public string Country { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string MobilePhone { get; set; }
        public string Phone { get; set; }
        public string PhoneExt { get; set; }
        public short Residential { get; set; } = 0;
        public short TransactionOverride { get; set; } = 0;
        public int UpdateCounter { get; set; } = 0;

        public List<CustomerAddress> CustomerAddresses { get; set; }
        public List<Order> Orders { get; set; }
    }

}
