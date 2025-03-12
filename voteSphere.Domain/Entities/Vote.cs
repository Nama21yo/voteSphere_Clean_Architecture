using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace voteSphere.Domain.Entities {
    public class Vote   {
         public int VoteId { get; set; } // Primary Key

        public string? UserId { get; set; } // Foreign Key for ApplicationUser

        public int GroupId { get; set; } // Foreign Key for VoteGroup

        public DateTime VoteDate { get; set; }

        // Navigation properties (nullable to avoid potential issues)
        public ApplicationUser? User { get; set; } 
        public VoteGroup? VoteGroup { get; set; }

    }
}
