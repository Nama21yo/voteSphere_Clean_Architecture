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


            protected override void OnModelCreating(ModelBuilder builder) {
                base.OnModelCreating(builder);
                builder.Entity<Vote>()
                .HasOne(v => v.VoteGroup)
                .WithMany(vg => vg.Votes)
                .HasForeignKey(v => v.UserId); 

                builder.Entity<Vote>()
                .HasOne(v => v.VoteGroup)
                .WithMany(vg => vg.Votes)
                .HasForeignKey(v => v.GroupId); 
            }

    }
}
