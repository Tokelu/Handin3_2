using System;
using System.Collections.Generic;

namespace Handin3_2.2.Models
{
    public partial class Address
    {
        public Address()
        {
            LivesOn = new HashSet<LivesOn>();
            PersonAddressRelations = new HashSet<PersonAddressRelations>();
        }

        public int AddressId { get; set; }
        public string RoadName { get; set; }
        public string HouseNumber { get; set; }
        public int? Story { get; set; }
        public string IsRegisteredAddress { get; set; }
        public string AddressType { get; set; }
        public int? CityId { get; set; }

        public City City { get; set; }
        public ICollection<LivesOn> LivesOn { get; set; }
        public ICollection<PersonAddressRelations> PersonAddressRelations { get; set; }
    }
}
