using System;
using System.Collections.Generic;

namespace Handin3_2.2.Models
{
    public partial class Note
    {
        public int NoteId { get; set; }
        public int PersonId { get; set; }
        public string Note1 { get; set; }

        public Person Person { get; set; }
    }
}
