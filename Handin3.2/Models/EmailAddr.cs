using System;
using System.Collections.Generic;

namespace Handin3_2.2.Models
{
    public partial class EmailAddr
    {
        public int EmailId { get; set; }
        public int PersonId { get; set; }
        public bool IsPrimary { get; set; }
        public string EmailAddr1 { get; set; }

        public Person Person { get; set; }
    }
}
