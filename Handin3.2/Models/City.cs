using System;
using System.Collections.Generic;

namespace Handin3_2.2.Models
{
    public partial class City
    {
        public City()
        {
            Address = new HashSet<Address>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public string PostalCode { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
