
using voteSphere.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using voteSphere.Domain.UseCases;
using voteSphere.Infrastructure.Database;

namespace voteSphere.Infrastructure.Implementation
{
    public class VoteGroupRepository : Repository<VoteGroup>, IVoteGroupRepository
    {
        public VoteGroupRepository(VotingContext context) : base(context)
        {
            
        }
    }
}
