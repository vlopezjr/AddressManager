using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressManager.Data
{
    [Table("tcpSO")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OPKey { get; set; }

        public int SOKey { get; set; }

        [Column("ShipAddrKey")]
        public int AddressKey { get; set; }
        public Address Address { get; set; }

        [Column("CustKey")]
        public int CustomerKey { get; set; }
        public Customer Customer { get; set; }
    }
}
