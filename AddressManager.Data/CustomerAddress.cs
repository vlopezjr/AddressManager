using System.ComponentModel.DataAnnotations.Schema;

namespace AddressManager.Data
{
    [Table("tarCustAddr")]
    public class CustomerAddress
    {
        [Column("AddrKey")]
        public int AddrKey { get; set; }
        public Address Address { get; set; }

        [Column("CustKey")]
        public int CustKey{ get; set; }
        public Customer Customer { get; set; }
    }
}
