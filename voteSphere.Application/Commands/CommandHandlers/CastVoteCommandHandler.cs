using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using voteSphere.Application.Commands.Command;
using voteSphere.Domain.Entities;
using voteSphere.Domain.UseCases;

namespace voteSphere.Application.Commands.CommandHandlers
{
    public class CastVoteCommandHandler : IRequestHandler<CastVoteCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CastVoteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CastVoteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve user and validate authorization
                var user = await _unitOfWork.Users.GetByIdAsync(request.UserId);
                if (user == null || !user.IsAuthorized)
                {
                    return false; // Unauthorized user
                }

                // Create a new vote
                var vote = new Vote
                {
                    UserId = request.UserId,
                    GroupId = request.GroupId,
                    VoteDate = DateTime.UtcNow
                };
                var existingVote = _unitOfWork.Votes.GetAll(v => v.UserId == request.UserId).FirstOrDefault();
                if (existingVote== null) {
                    return false;
                }
                // Add vote to repository
                await _unitOfWork.Votes.AddAsync(vote);

                // Retrieve vote group and update vote count
                var voteGroup = await _unitOfWork.VoteGroups.GetByIdAsync(request.GroupId);
                if (voteGroup != null)
                {
                    voteGroup.VotesCount++;
                    _unitOfWork.VoteGroups.Update(voteGroup);
                }
                else
                {
                    return false; // Vote group does not exist
                }

                // Commit changes to database
                var result = await _unitOfWork.CompleteAsync();
                return result > 0; // Returns true if at least one row was affected
            }
            catch (Exception)
            {
                return false; // Handle failure scenario
            }
        }
    }
}
