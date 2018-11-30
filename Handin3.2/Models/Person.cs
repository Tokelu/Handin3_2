using System;
using System.Collections.Generic;

namespace Handin3_2.2.Models
{
    public partial class Person
    {
        public Person()
        {
            EmailAddr = new HashSet<EmailAddr>();
            LivesOn = new HashSet<LivesOn>();
            Note = new HashSet<Note>();
            PersonAddressRelations = new HashSet<PersonAddressRelations>();
            PhoneNumber = new HashSet<PhoneNumber>();
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactType { get; set; }

        public ICollection<EmailAddr> EmailAddr { get; set; }
        public ICollection<LivesOn> LivesOn { get; set; }
        public ICollection<Note> Note { get; set; }
        public ICollection<PersonAddressRelations> PersonAddressRelations { get; set; }
        public ICollection<PhoneNumber> PhoneNumber { get; set; }
    }
}
