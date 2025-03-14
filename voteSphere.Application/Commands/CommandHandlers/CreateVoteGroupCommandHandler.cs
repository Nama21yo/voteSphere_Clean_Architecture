using Microsoft.AspNetCore.Identity;
using voteSphere.Application.Commands.Command;
using voteSphere.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using voteSphere.Domain.UseCases;

namespace voteSphere.Application.Commands.CommandHandlers
{
    public class CreateVoteGroupHandler : IRequestHandler<CreateVoteGroupCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateVoteGroupHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateVoteGroupCommand request, CancellationToken cancellationToken)
        {
            // Create new VoteGroup entity
            var voteGroup = new VoteGroup
            {
                GroupName = request.GroupName,
                GroupDescription = request.GroupDescription,
                Symbol = request.GroupImageUrl,
                VotesCount = 0 // Assuming 'Symbol' is the correct field
            };

            try
            {
                // Add vote group to repository
                _unitOfWork.VoteGroups.Add(voteGroup);

                // Save changes to the database
                var result = await _unitOfWork.CompleteAsync();

                return result > 0; // Indicate success
            }
            catch
            {
                return false; // Handle failure scenario
            }
        }
    }
}
