using System;
using System.Collections.Generic;

namespace voteSphere.Domain.Entities
{
    public class VoteGroup
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }
        public string? GroupDescription { get; set; }
        public string? Symbol { get; set; } // `?` makes the property nullable, meaning it can hold `null` values.
        public int VotesCount { get; set; }

        // A VoteGroup can have many Votes (One-to-Many Relationship)
        public ICollection<Vote> Votes { get; set; } = new List<Vote>(); 
    }
}
