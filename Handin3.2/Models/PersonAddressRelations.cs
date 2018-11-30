using System;
using System.Collections.Generic;

namespace Handin3_2.2.Models
{
    public partial class PersonAddressRelations
    {
        public int PersonId { get; set; }
        public int AddressId { get; set; }

        public Address Address { get; set; }
        public Person Person { get; set; }
    }
}
