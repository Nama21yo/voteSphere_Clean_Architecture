
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MediatR;
using voteSphere.Application.Queries.Query;
using voteSphere.Domain.Entities;
using voteSphere.Domain.UseCases;

namespace voteSphere.Application.Queries.QueryHandlers
{
    public class GetVoteGroupsQueryHandler : IRequestHandler<GetVoteGroupsQuery, IEnumerable<VoteGroup>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetVoteGroupsQueryHandler(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<VoteGroup>> Handle(GetVoteGroupsQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(()=> _unitOfWork.VoteGroups.GetAll());
        }
    }
}
