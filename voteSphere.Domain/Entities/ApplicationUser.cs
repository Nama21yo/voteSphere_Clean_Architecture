using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace voteSphere.Domain.Entities {
    public class ApplicationUser : IdentityUser  {
        public  string? FullName {get; set;}
        public  DateTime? DateOfBirth {get; set;}

        public string? State {get; set;}

        public string? City {get; set;} // basically ? >> to make it Nullable

        public string? Address {get; set;}

        public bool? HasVoted {get;  set;}

        public bool? IsAuthorized {get; set;}
    }
}
