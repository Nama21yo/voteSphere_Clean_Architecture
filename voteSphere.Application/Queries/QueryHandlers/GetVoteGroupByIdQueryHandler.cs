using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using voteSphere.Application.Queries.Query;
using voteSphere.Domain.Entities;
using voteSphere.Domain.UseCases;

namespace voteSphere.Application.Queries.QueryHandlers
{
    public class GetVoteGroupByIdQueryHandler : IRequestHandler<GetVoteGroupByIdQuery, IEnumerable<VoteGroup>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetVoteGroupByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VoteGroup>> Handle(GetVoteGroupByIdQuery request, CancellationToken cancellationToken)
        {
            // Define the expression explicitly
            Expression<Func<VoteGroup, bool>> filter = g => g.Id == request.GroupId;

            var voteGroup = await _unitOfWork.VoteGroups.GetByIdAsync(filter);

            // Ensure return type matches expected IEnumerable<VoteGroup>
            return voteGroup != null ? new List<VoteGroup> { voteGroup } : Enumerable.Empty<VoteGroup>();
        }
    }
}
