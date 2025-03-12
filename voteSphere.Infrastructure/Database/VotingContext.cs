using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using voteSphere.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace voteSphere.Infrastructure.Database {
    public class VotingContext : IdentityDbContext<ApplicationUser>  {
            public VotingContext(DbContextOptions<VotingContext> options) : base(options) {

            }
            public DbSet<VoteGroup> VoteGroups {get; set;}

            public DbSet<Vote> Votes {get;set;}

    }
}
