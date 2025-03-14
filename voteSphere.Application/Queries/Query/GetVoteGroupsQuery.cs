
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediatR;
using voteSphere.Domain.Entities;

namespace voteSphere.Application.Queries.Query
{
    public class GetVoteGroupsQuery : IRequest<IEnumerable<VoteGroup>>
    {
       
      
    }
}
