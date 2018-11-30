using System;
using System.Collections.Generic;

namespace Handin3_2.2.Models
{
    public partial class PhoneNumber
    {
        public int PhoneId { get; set; }
        public int PersonId { get; set; }
        public long? PhoneNumber1 { get; set; }
        public string Provider { get; set; }
        public string PhoneType { get; set; }

        public Person Person { get; set; }
    }
}
